#pragma once
#include "SOF.h"
#include "CubeLab13.h"


class NewLab13Q2App : public SOF::App
{

	CubeLab13* cube;

	GLfloat delay = 0;
	int num = 0;

	float scale = 1.0;

public:
	virtual void Draw();
	virtual void Init();
	virtual void Update(float deltaT);
	virtual void KeyCallback(GLFWwindow*, int, int, int, int);
	virtual void MouseButtonCallback(GLFWwindow*, int, int, int) {};
};