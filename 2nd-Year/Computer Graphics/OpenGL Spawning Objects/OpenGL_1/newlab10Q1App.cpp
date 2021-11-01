#include "stdafx.h"
#include "newlab10Q1App.h"
#include <random>


void NewLab10Q1App::Init()
{

	// build a set of 6 cubes
	
	for (int i = 0; i < 99; i++)
	{
		CubeLab10 *cube = new CubeLab10();
		cubes.push_back(cube);
	}

	for (int i = 0; i < 99; i++)
	{
		CubeLab10Triangles* triangle = new CubeLab10Triangles();
		triangles.push_back(triangle);
	}

	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LESS);
	glEnable(GL_BLEND);
	glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

}


// responses to the passing of time. Called with before each draw()
void NewLab10Q1App::Update(float deltaT)
{

}

void NewLab10Q1App::KeyCallback(GLFWwindow* window, int key, int scanCode, int action, int mods)
{
	//camera movement
	if (key == GLFW_KEY_D)
		cameraXAngle += 5;
	if (key == GLFW_KEY_W)
		cameraYAngle += 5;
	if (key == GLFW_KEY_A)
		cameraXAngle -= 5;
	if (key == GLFW_KEY_S)
		cameraYAngle -= 5;

	//Cube spawn
	if (key == GLFW_KEY_P)
		Spawn();
	if (key == GLFW_KEY_L)
		RemoveSpawn();

	//triangle spawn
	if (key == GLFW_KEY_O)
		SpawnTriangle();

	if (key == GLFW_KEY_K)
		RemoveTriangle();
}


void NewLab10Q1App::Spawn()
{
	for (int i = 0; i < 1; i++)
	{
		CubeLab10* cube = new CubeLab10();
		cubes.push_back(cube);
		cubecount++;
	}

	int xt = rand() % 10;
	int yt = rand() % 10;
	int zt = rand() % 10;

	int xs = rand() % 5;
	int ys = rand() % 5;
	int zs = rand() % 5;

	cubes[cubecount]->SetTranslate(glm::vec3(xt, yt, zt));
	cubes[cubecount]->SetScale(glm::vec3(xs, ys, zs));
	cubes[cubecount]->setColor(glm::vec4(1.0, 0.0, 0.0, 1.0));
}

void NewLab10Q1App::RemoveSpawn()
{
	for (int i = 0; i < 1; i++)
	{
		if (cubes.empty())
			break;

		CubeLab10* cube = new CubeLab10();
		cubecount--;
		cubes.pop_back();
		return;
	}
}

void NewLab10Q1App::SpawnTriangle()
{
	CubeLab10Triangles* triangle = new CubeLab10Triangles();
	triangles.push_back(triangle);
	trianglecount++;

	int xt = rand() % 10;
	int yt = rand() % 10;
	int zt = rand() % 10;

	int xs = rand() % 5;
	int ys = rand() % 5;
	int zs = rand() % 5;

	triangles[trianglecount]->SetTranslateTriangle(glm::vec3(xt, yt, zt));
	triangles[trianglecount]->SetScaleTriangle(glm::vec3(xs, ys, zs));
	triangles[trianglecount]->setColorTriangle(glm::vec4(0.0, 0.0, 0.0, 1.0));
}

void NewLab10Q1App::RemoveTriangle()
{
	for (int i = 0; i < 1; i++)
	{
		if (triangles.empty())
			break;

		CubeLab10Triangles* triangle = new CubeLab10Triangles();
		trianglecount--;
		triangles.pop_back();
		return;
	}
}

void NewLab10Q1App::Draw()
{
	//// camera and projection 
	glm::vec3 cameraPos = glm::vec3(0.0f, 0.0f, 10.0f);
	cameraDir[0] = glm::radians(cameraXAngle);
	cameraDir[1] = glm::radians(cameraYAngle);
	cameraDir[2] = glm::radians(cameraZAngle);
	glm::mat4 view = glm::lookAt(cameraPos, cameraDir, glm::vec3(0.0f, 1.0f, 0.0f));
	glm::mat4 proj = glm::perspective(glm::radians(70.0f), (float)SOF::Window::GetHeight() / SOF::Window::GetWidth(), 0.1f, 1000.0f);

	// draw the cubes
	for (auto cube : cubes)
		cube->Draw(view, proj);

	for (auto triangle : triangles)
		triangle->DrawTriangle(view, proj);
}
