#include "stdafx.h"
#include "MainApp.h"
#include "physics.h"
#include "Monitor.h"
#include <random>

Node* Scene(Physics *phys);
extern std::vector<glm::vec3> splinePoints;
class CamColl : public CameraCollisionCallback
{
	Physics* phys;
public:
	CamColl(Physics* phys) : phys(phys) {}
	glm::vec3 operator()(const glm::vec3& pos, const glm::vec3& newPos, float rad) const override
	{
		std::vector<ContactInfo> contacts = phys->CollideWithWorld(newPos, rad);
		glm::vec3 finalPos = newPos;
		for (auto c : contacts)
		{
			finalPos += c.normal * c.depth;
		}
		return finalPos;
	}
	virtual ~CamColl() {}
};

void MainApp::SetupLights()
{
	glm::mat4 lightPos;

	lightPos[0] = glm::vec4(-50.0f, -50.0f, 50.0f, 1.0f);
	lightPos[1] = glm::vec4(-50.0f, 50.0f, 50.0f, 1.0f);
	lightPos[2] = glm::vec4(50.0f, 50.0f, 50.0f, 1.0f);
	lightPos[3] = glm::vec4(50.0f, -50.0f, 50.0f, 1.0f);

	glm::mat4 lightColor;

	lightColor[0] = glm::vec4(1.0f, 1.0f, 1.0f, 1.0f);
	lightColor[1] = glm::vec4(1.0f, 1.0f, 1.0f, 1.0f);
	lightColor[2] = glm::vec4(1.0f, 1.0f, 1.0f, 1.0f);
	lightColor[3] = glm::vec4(1.0f, 1.0f, 1.0f, 1.0f);

	pointLight = PointLight(lightPos, lightColor, 0.4, 0.85, 0.58, 10.9, glm::vec4(110.0f, 110.0f, 110.0f, 110.0f));
}

void MainApp::Init()
{
	//light
	SphereGeometry sphereGeom(20);
	lightSphere = new AlternateEmissive(sphereGeom);

	SetupLights();

	//monitor
	monitor = new Monitor();

	//keyboard
	keyboard = new Keyboard();

	//computer mouse
	computerMouse = new ComputerMouse();

	// setup the camera
	eye = glm::vec3(0.0f, 3.0f, -40.0f);
	lookAt = glm::vec3(0.0f, 3.0f, 0.0f);
	up = glm::vec3(0.0f, 1.0f, 0.0); // y is up!

	physics = new Physics(); //initialise physics

	camera = new FlyCam(eye, lookAt, true, new CamColl(physics));

	// scene graph for dynamic objects
	sceneGraphRoot = Scene(physics);
	dynamicObjectNode = new GroupNode();
	sceneGraphRoot->AddChild(dynamicObjectNode);

	//projectile
	projectileNode = new TransformNode(glm::scale(glm::mat4(), glm::vec3(0.2f, 0.2f, 0.2f)));
	SphereGeometry geom(20);
	TexturedLit* mesh = new TexturedLit(geom, "textures/grid.jpg");
	projectileNode->AddChild(new GeometryNode(mesh));


	//glowing spheres
	emissiveSphereNode = new TransformNode(glm::scale(glm::mat4(), glm::vec3(20.0f, 20.0f, 20.0f)));
	SphereGeometry geomEmissiveSphere(20);
	TexturedLit* meshSphereTexture = new TexturedLit(geomEmissiveSphere, "textures/grid.jpg");
	projectileNode->AddChild(new GeometryNode(meshSphereTexture));

	//dynamic node (miscellaneous)
	dynamicNode = new TransformNode(glm::scale(glm::mat4(), glm::vec3(20.0f, 20.0f, 20.0f)));
	SphereGeometry emptysphere(0);
	TexturedLit* emptytext = new TexturedLit(geomEmissiveSphere, "textures/grid.jpg");
	dynamicNode->AddChild(new GeometryNode(emptytext));

	//spline
	cameraSpline = new CRSpline(splinePoints, true);


	//visible lights vec4
	lightColors[0] = glm::vec4(0.5f, 0.6f, 1.0f, 1.0f);
	lightColors[1] = glm::vec4(0.8f, 0.6f, 1.0f, 1.0f);
	lightColors[2] = glm::vec4(0.8f, 0.3f, 1.0f, 1.0f);
	lightColors[3] = glm::vec4(0.5f, 0.8f, 1.0f, 1.0f);

	lightPos[0] = glm::vec3(-100.0f, 50.0f, 100.0f);
	lightPos[1] = glm::vec3(100.0f, 50.0f, 100.0f);
	lightPos[2] = glm::vec3(100.0f, 50.0f, -100.0f);
	lightPos[3] = glm::vec3(-100.0f, 50.0f, -100.0f);

	// render states
	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LESS);
	glEnable(GL_BLEND);
	glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
}

void MainApp::Draw()
{
	// camera
	glm::mat4 view;
	glm::mat4 proj;

	eye = camera->GetPos();
	lookAt = camera->GetLookAt();
	up = camera->GetUp();

	view = glm::lookAt(eye, lookAt, up);
	proj = glm::perspective(glm::radians(60.0f), (float)SOF::Window::GetWidth() / (float)SOF::Window::GetHeight(), 0.1f, 1000.0f);

	// glowing spheres
	glm::mat4 lightPositionMat;
	glm::mat4 lightColorMat;

	for (int i = 0; i < 4; i++)
	{
		lightPositionMat[i] = glm::vec4(lightPos[i], 0.0f);
		lightColorMat[i] = lightColors[i];
	}

	glm::mat4 model = glm::mat4();
	Transforms trans(model, view, proj);

	// draw the glowing sphere
	for (int i = 0; i < 4; i++)
	{
		model = glm::translate(glm::mat4(), lightPos[i]);
		trans.SetModel(model);
		lightSphere->Draw(trans, lightColors[i]);
	}

	//add to scene graph
	TransformNode* node = new TransformNode(model);
	dynamicObjectNode->AddChild(node);
	node->AddChild(emissiveSphereNode);

	//monitor
	glm::vec3 monitorXYZ= glm::vec3(200.0f, 0.0f, 200.0f);
	model = glm::translate(glm::mat4(), monitorXYZ);
	trans.SetModel(model);
	monitor->Draw(trans, pointLight);

	TransformNode* monitorTransNode = new TransformNode(model);
	dynamicObjectNode->AddChild(monitorTransNode);

	//keyboard
	glm::vec3 keyboardXYZ = glm::vec3(176.5f, 0.0f, 200.0f);
	model = glm::translate(glm::mat4(), keyboardXYZ);
	trans.SetModel(model);
	keyboard->Draw(trans, pointLight);

	TransformNode* keyboardTransNode = new TransformNode(model);
	dynamicObjectNode->AddChild(keyboardTransNode);

	//computer mouse
	glm::vec3 mouseXYZ = glm::vec3(180.5f, 0.0f, 210.5f);
	model = glm::translate(glm::mat4(), mouseXYZ);
	trans.SetModel(model);
	computerMouse->Draw(trans, pointLight);

	TransformNode* computerMouseTransNode = new TransformNode(model);
	dynamicObjectNode->AddChild(computerMouseTransNode);

	// Render the scene graph
	RenderVisitor rv(view, proj);
	rv.Traverse(sceneGraphRoot);
}

void MainApp::Shoot()
{
	// add to scene graph
	TransformNode* node = new TransformNode(glm::mat4());
	dynamicObjectNode->AddChild(node);
	node->AddChild(projectileNode);

	float speed = 20.0f;

	glm::vec3 vel = glm::normalize(camera -> GetLookAt() - camera->GetPos()) * speed;
	Projectile* proj = new Projectile(camera->GetPos(), vel, node);
	physics->AddProjectile(proj);
}

void MainApp::Update(float deltaT)
{
	physics->Update(deltaT);

	lightSphere->GetDeltaT(deltaT); //change glowing spheres over time

	// Update the scene graph
	UpdateVisitor uv(deltaT);
	uv.Traverse(sceneGraphRoot);

	//camera + player movement
	if (SOF::Window::IsKeyDown(GLFW_KEY_W))
		camera->Move(Speed *deltaT);
	if (SOF::Window::IsKeyDown(GLFW_KEY_S))
		camera->Move(-Speed * deltaT);
	if (SOF::Window::IsKeyDown(GLFW_KEY_A))
		camera->Strafe(-Speed * deltaT);
	if (SOF::Window::IsKeyDown(GLFW_KEY_D))
		camera->Strafe(Speed * deltaT);

	if (SOF::Window::IsKeyDown(GLFW_KEY_LEFT))
		camera->Pan(Sensitivity * deltaT);
	if (SOF::Window::IsKeyDown(GLFW_KEY_RIGHT))
		camera->Pan(-Sensitivity * deltaT);
	if (SOF::Window::IsKeyDown(GLFW_KEY_UP))
		camera->LookUpDown(Sensitivity * deltaT);
	if (SOF::Window::IsKeyDown(GLFW_KEY_DOWN))
		camera->LookUpDown(-Sensitivity * deltaT);

	//shoot projectiles

	if (SOF::Window::IsKeyPressed(GLFW_KEY_SPACE))
		Shoot();

	//sprint no toggle

	if (SOF::Window::IsKeyDown(GLFW_KEY_LEFT_SHIFT) && ToggleSprintEnabled == false)
		Speed = 20.0f;
	if (SOF::Window::IsKeyDown(GLFW_KEY_LEFT_SHIFT) == false && ToggleSprintEnabled == false)
		Speed = 10.0f;

	//enable/disable sprint toggle

	if (SOF::Window::IsKeyPressed(GLFW_KEY_Z) && ToggleSprintEnabled == false)
	{
		ToggleSprintEnabled = true;
		std::cout << "[INFO] Toggle Sprint Enabled" << std::endl;
	}
	else if (SOF::Window::IsKeyPressed(GLFW_KEY_Z) && ToggleSprintEnabled == true)
	{
		ToggleSprintEnabled = false;
		isSprintingToggled = false;
		std::cout << "[INFO] Toggle Sprint Disabled" << std::endl;
	}

	//sprint toggle

	if (SOF::Window::IsKeyPressed(GLFW_KEY_LEFT_SHIFT) && ToggleSprintEnabled == true && isSprintingToggled == false)
	{
		Speed = 20.0f;
		isSprintingToggled = true;
		std::cout << "[INFO] Toggle Sprinting" << std::endl;
	}
	else if (SOF::Window::IsKeyPressed(GLFW_KEY_LEFT_SHIFT) && ToggleSprintEnabled == true && isSprintingToggled == true)
	{
		Speed = 10.0f;
		isSprintingToggled = false;
		std::cout << "[INFO] Not Toggle Sprinting" << std::endl;
	}

	//Change Camera Sensitivity

	if (SOF::Window::IsKeyDown(GLFW_KEY_KP_ADD))
	{
		Sensitivity += 1;
		std::cout << "[INFO] Sensitivity:" << std::endl;
		std::cout << Sensitivity << std::endl;
	}
	if (SOF::Window::IsKeyDown(GLFW_KEY_KP_SUBTRACT))
	{
		Sensitivity -= 1;
		std::cout << "[INFO] Sensitivity:" << std::endl;
		std::cout << Sensitivity << std::endl;
	}

	//update the animated spheres spline
	splineParameter += cameraSpeed * deltaT;
	if (splineParameter > splinePoints.size())
	{
		splineParameter -= splinePoints.size();
	}

}


