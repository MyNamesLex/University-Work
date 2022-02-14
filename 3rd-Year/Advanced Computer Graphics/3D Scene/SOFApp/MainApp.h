#pragma once
#include "stdafx.h"
#include "app.h"
#include "RenderLib.h"
#include "physics.h"
#include "AlternateEmissive.h"
#include "AlternatePointLight.h"
#include "spline.h"
#include "ComputerMouse.h"
#include "Keyboard.h"
#include "Monitor.h"

class MainApp : public SOF::App
{
	// geometry
	TexturedLit* floorQuad;

	// camera
	glm::vec3 eye;
	glm::vec3 lookAt;
	glm::vec3 up;
	FlyCam* camera;
	float Sensitivity = 40.0f;

	// player
	float Speed = 10.0f;
	bool ToggleSprintEnabled = false;
	bool isSprintingToggled = false;

	// scene graph
	Node* sceneGraphRoot;
	GroupNode* dynamicObjectNode;
	TransformNode* projectileNode;
	TransformNode* emissiveSphereNode;
	TransformNode* dynamicNode;

	//physics
	Physics* physics;
	void Shoot();

	//glowing spheres
	AlternateEmissive* lightSphere;
	glm::vec3 lightPos[4];
	glm::vec4 lightColors[4];
	float lightRadius[4];

	//camera spline
	Spline* cameraSpline;
	float splineParameter = 0.0f;
	float cameraSpeed = 0.5f;

	//light
	PointLight pointLight;

	//monitor
	Monitor* monitor;

	//keyboard
	Keyboard* keyboard;

	//computer mouse
	ComputerMouse* computerMouse;
public:
	virtual void Init();
	virtual void Draw();
	virtual void Update(float deltaT);
	virtual void SetupLights();
};