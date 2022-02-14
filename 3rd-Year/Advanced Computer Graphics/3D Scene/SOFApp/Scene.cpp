#include "stdafx.h"
#include "RenderLib.h"
#include "spline.h"
#include "physics.h"
#include "AlternateEmissive.h"
#include "AlternatePointLight.h"
#include "Monitor.h"
#include "Keyboard.h"
#include <random>

std::vector<glm::vec3> splinePoints;

// callback for animating on a spline
class SplineAnimationCallback : public UpdateCallback
{
	Spline* spline;
	TransformNode* trans;
	float rate;
	float t = 0;
public:
	SplineAnimationCallback(TransformNode* trans, Spline* spline, float rate) : trans(trans), spline(spline), rate(rate), t(0.0f) {}
	virtual void operator()(float dt)
	{
		t += dt;
		if (t > spline->GetNumPoints())
			t -= spline->GetNumPoints();
		// work out the new transform here
		glm::vec3 position = spline->GetPoint(t);
		glm::vec3 tangent = spline->GetTangent(t);
		glm::mat4 lookAt = glm::lookAt(position, position + tangent, glm::vec3(0, 1, 0));
		trans->SetTransform(glm::inverse(lookAt));
	}
};

Node* Scene(Physics* phys)
{
	//variables + light
	LightNode* light = new LightNode(glm::vec3(0, 100, 0), glm::vec4(1, 1, 1, 1), 0.1, 10.0f, 100.0f, 10.0f, 10.0f);

	QuadGeometry quad(10);
	TexturedLit* floor = new TexturedLit(quad, "textures/marble.png");
	GeometryNode* geomNodeWalls = new GeometryNode(floor);

	MeshObject* meshObject = new MeshObject("textures/wood_diffuse.jpg");

	//spline

	std::vector<glm::vec3> lineVerts;

	//spline pos

	splinePoints.push_back(glm::vec3(-6, 5, -6));
	splinePoints.push_back(glm::vec3(6, 5, 18));
	splinePoints.push_back(glm::vec3(24, 5, 6));
	splinePoints.push_back(glm::vec3(24, 5, -12));
	splinePoints.push_back(glm::vec3(24, 5, -21));
	splinePoints.push_back(glm::vec3(0, 5, -30));
	splinePoints.push_back(glm::vec3(-18, 5, -18));
	splinePoints.push_back(glm::vec3(-18, 5, 18));

	// spheres for spline

	SphereGeometry sphere(20);
	TexturedLit* sphereRender = new TexturedLit(sphere, "textures/grid.jpg");
	GeometryNode* sphereNode = new GeometryNode(sphereRender);

	//spline positions

	for (glm::vec3 pos : splinePoints)
	{
		TransformNode* sphereTrans = new TransformNode(glm::translate(glm::mat4(), pos));
		light->AddChild(sphereTrans);
		sphereTrans->AddChild(sphereNode);
	}

	//(points, tension, loop)
	CRSpline b(splinePoints, 0.9f, true);
	for (int i = 0; i < 500; i++)
	{
		float u = 8.0f * i / 499.0f;
		lineVerts.push_back(b.GetPoint(u));
	}


	//add to scene graph

	PolyLine* p = new PolyLine(lineVerts, glm::vec4(0, 20, 30, 1));
	light->AddChild(new GeometryNode(p));

	TransformNode* sphereTrans = new TransformNode(glm::mat4());
	light->AddChild(sphereTrans);
	sphereTrans->AddChild(sphereNode);
	sphereTrans->SetUpdateCallback(new SplineAnimationCallback(sphereTrans, new CRSpline(splinePoints, true, 0.5f), 1.0f));


	// complex geometry (has weird collision due to it being none convex)

	//bezier patch

	std::vector<glm::vec3> bezPoints{
	 glm::vec3(0,0,0), glm::vec3(1,1,0), glm::vec3(2,1,0), glm::vec3(3,0,0),
	 glm::vec3(0,0,1), glm::vec3(1,2,1), glm::vec3(2,2,1), glm::vec3(3,0,1),
	 glm::vec3(0,0,2), glm::vec3(1,2,2), glm::vec3(2,2,2), glm::vec3(3,0,2),
	 glm::vec3(0,0,3), glm::vec3(1,1,3), glm::vec3(2,1,3), glm::vec3(3,0,3),
	};

	glm::mat4 patchBezTrans = glm::mat4();
	patchBezTrans = glm::translate(patchBezTrans, glm::vec3(10.0f, -20.0, 0.0));
	patchBezTrans = glm::rotate(patchBezTrans, glm::radians(20.0f), glm::vec3(0.0f, 0.0f, 1.0));
	patchBezTrans = glm::scale(patchBezTrans, glm::vec3(20.0f, 20.0f, 20.0f));

	TexturedLit* patchBezTexture = new TexturedLit(BezierPatch(bezPoints, 32), "textures/grid.jpg");
	GeometryNode* patchBezGeomNode = new GeometryNode(patchBezTexture);
	TransformNode* patchBezTransNode = new TransformNode(patchBezTrans);
	light->AddChild(patchBezTransNode);
	patchBezTransNode->AddChild(patchBezGeomNode);
	phys->AddCollider(new QuadCollider(patchBezTrans));

	//the utah teapot

	glm::mat4 patchTeaTrans = glm::mat4();
	patchTeaTrans = glm::translate(patchTeaTrans, glm::vec3(-50.0f, 0.0, 0.0));
	patchTeaTrans = glm::rotate(patchTeaTrans, glm::radians(45.0f), glm::vec3(0.0f, 0.0f, 1.0));
	patchTeaTrans = glm::scale(patchTeaTrans, glm::vec3(10.0f, 10.0f, 10.0f));

	TexturedLit* patchTeaTexture = new TexturedLit(Teapot(32), "textures/grid.jpg");
	TransformNode* patchTeaTransNode = new TransformNode(patchTeaTrans);
	GeometryNode* patchTeaGeomNode = new GeometryNode(patchTeaTexture);
	light->AddChild(patchTeaTransNode);
	patchTeaTransNode->AddChild(patchTeaGeomNode);
	phys->AddCollider(new QuadCollider(patchTeaTrans));

	//triangles

	std::mt19937 rng = std::mt19937(std::random_device()());
	std::uniform_real_distribution<float> dist(0.0f, 1.0f);
	for (int i = 0; i < 90; i++)
	{
		//triangles trans
		float x = -100.0f + 200.0f * dist(rng);
		float z = -100.0f + 200.0f * dist(rng);
		float y = 50.0f * dist(rng);

		//model
		glm::mat4 TriangleTrans = glm::mat4();
		TriangleTrans = glm::translate(TriangleTrans, glm::vec3(x, y, z));
		TriangleTrans = glm::rotate(TriangleTrans, glm::radians(0.0f), glm::vec3(0.0f, 0.0f, 1.0));
		TriangleTrans = glm::scale(TriangleTrans, glm::vec3(5.0f, 5.0f, 5.0f));

		//draw + add to scene graph + collision
		TriangleGeom g = TriangleGeom();
		TexturedLit* triangleRender = new TexturedLit(g, "textures/grid.jpg");
		GeometryNode* triangleGeomNode = new GeometryNode(triangleRender);
		TransformNode* triangleTransNode = new TransformNode(TriangleTrans);
		light->AddChild(triangleTransNode);
		triangleTransNode->AddChild(triangleGeomNode);
		phys->AddCollider(new QuadCollider(TriangleTrans));
	}

	// scale the floor and add to scene graph + collision
	glm::mat4 floorMat = glm::scale(glm::mat4(), glm::vec3(500.0f, 500.0f, 500.0f));
	TransformNode* floorScale = new TransformNode(floorMat);
	light->AddChild(floorScale);
	floorScale->AddChild(geomNodeWalls);
	phys->AddCollider(new QuadCollider(floorMat));

	// walls and add to scene graph + collision
	glm::mat4 wtrans = glm::mat4();
	wtrans = glm::translate(wtrans, glm::vec3(250.0, 0.0, 0.0));
	wtrans = glm::rotate(wtrans, glm::radians(90.0f), glm::vec3(0.0f, 0.0f, 1.0));
	wtrans = glm::scale(wtrans, glm::vec3(250.0f, 250.0f, 250.0f));
	TransformNode *wall0 = new TransformNode(wtrans);
	light->AddChild(wall0);
	wall0->AddChild(geomNodeWalls);
	phys->AddCollider(new QuadCollider(wtrans));

	wtrans = glm::mat4();
	wtrans = glm::translate(wtrans, glm::vec3(-250.0, 0.0, 0.0));
	wtrans = glm::rotate(wtrans, glm::radians(-90.0f), glm::vec3(0.0f, 0.0f, 1.0));
	wtrans = glm::scale(wtrans, glm::vec3(250.0f, 250.0f, 250.0f));
	TransformNode* wall1 = new TransformNode(wtrans);
	light->AddChild(wall1);
	wall1->AddChild(geomNodeWalls);
	phys->AddCollider(new QuadCollider(wtrans));

	wtrans = glm::mat4();
	wtrans = glm::translate(wtrans, glm::vec3(0.0, 0.0, 250.0));
	wtrans = glm::rotate(wtrans, glm::radians(-90.0f), glm::vec3(1.0f, 0.0f, 0.0));
	wtrans = glm::scale(wtrans, glm::vec3(250.0f, 250.0f, 250.0f));
	TransformNode* wall2 = new TransformNode(wtrans);
	light->AddChild(wall2);
	wall2->AddChild(geomNodeWalls);
	phys->AddCollider(new QuadCollider(wtrans));

	wtrans = glm::mat4();
	wtrans = glm::translate(wtrans, glm::vec3(0.0, 0.0, -250.0));
	wtrans = glm::rotate(wtrans, glm::radians(90.0f), glm::vec3(1.0f, 0.0f, 0.0));
	wtrans = glm::scale(wtrans, glm::vec3(250.0f, 250.0f, 250.0f));
	TransformNode* wall3 = new TransformNode(wtrans);
	light->AddChild(wall3);
	wall3->AddChild(geomNodeWalls);
	phys->AddCollider(new QuadCollider(wtrans));

	//random squares

	for (int i = 0; i < meshObject->numObjects; i++)
	{
		//pos + trans values + collision
		float x = -100.0f + 200.0f * dist(rng);
		float z = -100.0f + 200.0f * dist(rng);
		float y = 50.0f * dist(rng);
		float radius = 1.0f + 5.0f * dist(rng);
		meshObject->objectPositions[i] = glm::vec4(x, y, z, radius);
		meshObject->Meshpositions.push_back(meshObject->objectPositions[i]);

		//model
		glm::mat4 rngsquare = glm::mat4();
		rngsquare = glm::mat4();
		rngsquare = glm::translate(rngsquare, glm::vec3(meshObject->objectPositions[i]));
		rngsquare = glm::rotate(rngsquare, glm::radians(-90.0f), glm::vec3(1.0f, 0.0f, 0.0));
		float scale = meshObject->objectPositions[i].w;
		rngsquare = glm::scale(rngsquare, glm::vec3(scale, scale, scale));

		//assign texture + render
		TexturedLit* boxrender = new TexturedLit(quad, "textures/wood_diffuse.jpg");
		GeometryNode* boxGeomNode = new GeometryNode(boxrender);
		TransformNode* randomboxes = new TransformNode(rngsquare);
		light->AddChild(randomboxes);
		randomboxes->AddChild(boxGeomNode);
		phys->AddCollider(new QuadCollider(rngsquare));
	}

	return light;
}
