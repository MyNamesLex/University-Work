#pragma once
#include "SOF.h"
#include "CubeLab10.h"
#include "CubeLab10Triangles.h"

class NewLab10Q1App : public SOF::App
{

	std::vector<CubeLab10*> cubes;
	std::vector<CubeLab10Triangles*> triangles;

	GLfloat delay = 0;
	glm::vec3 cameraDir = glm::vec3(1.0f, 0.0f, 0.0f);
	GLfloat cameraXAngle = 0.0f;
	GLfloat cameraYAngle = 0.0f;
	GLfloat cameraZAngle = 0.0f;
	GLint axis = 1;
	glm::vec3  theta = glm::vec3(0.0, 0.0, 0.0);
	GLfloat legmove = -0.025f;
	int count = 0;

	int cubecount = 0;
	int trianglecount = 0;

public:
	virtual void Draw();
	virtual void Init();
	virtual void Update(float deltaT);
	virtual void KeyCallback(GLFWwindow*, int, int, int, int);
	virtual void MouseButtonCallback(GLFWwindow*, int, int, int) {};

	virtual void Spawn();
	virtual void RemoveSpawn();

	virtual void SpawnTriangle();
	virtual void RemoveTriangle ();
};