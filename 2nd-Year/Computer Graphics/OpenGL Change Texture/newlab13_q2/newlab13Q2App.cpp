#include "stdafx.h"
#include "newlab13Q2App.h"
#include <random>


void NewLab13Q2App::Init()
{

	cube = new CubeLab13();

	// some render states
	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LESS);
	glEnable(GL_BLEND);
	glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

}


// responses to the passing of time. Called with before each draw()
void NewLab13Q2App::Update(float deltaT) { 

	if (delay >= 0.2f)
	{
		delay = 0.0f;
	}
	else
		delay += deltaT;
}


void NewLab13Q2App::Draw()
{
	//// camera and projection

	glm::vec3 cameraPos = glm::vec3(0.0f, 0.0f, 2.0f);
	glm::vec3 cameraDir = glm::vec3(0.0f, 0.0f, 0.0f);
	glm::mat4 view = glm::lookAt(cameraPos, cameraDir, glm::vec3(0.0f, 1.0f, 0.0f));
	glm::mat4 proj = glm::perspective(glm::radians(70.0f), (float)SOF::Window::GetHeight() / SOF::Window::GetWidth(), 0.1f, 1000.0f);



	cube->Draw(view, proj);

}

void NewLab13Q2App::KeyCallback(GLFWwindow* window, int key, int scanCode, int action, int mods)
{
	switch (key) {
	case GLFW_KEY_A:
		cube->SetXRotation(1.0);
		break;
	case GLFW_KEY_S:
		cube->SetYRotation(1.0);
		break;
	case GLFW_KEY_D:
		cube->SetZRotation(1.0);
		break;
	case GLFW_KEY_Z:
		cube->SetXRotation(-1.0);
		break;
	case GLFW_KEY_X:
		cube->SetYRotation(-1.0);
		break;
	case GLFW_KEY_C:
		cube->SetZRotation(-1.0);
		break;

	case GLFW_KEY_H:
		cube->SetTranslate(glm::vec3(0.1, 0.0, 0.0));
		break;
	case GLFW_KEY_J:
		cube->SetTranslate(glm::vec3(0.0, 0.1, 0.0));
		break;
	case GLFW_KEY_K:
		cube->SetTranslate(glm::vec3(0.0, 0.0, 0.1));
		break;
	case GLFW_KEY_N:
		cube->SetTranslate(glm::vec3(-0.1, 0.0, 0.0));
		break;
	case GLFW_KEY_M:
		cube->SetTranslate(glm::vec3(0.0, -0.1, 0.0));
		break;
	case GLFW_KEY_COMMA:
		cube->SetTranslate(glm::vec3(0.0, 0.0 , -0.1));
		break;
	case GLFW_KEY_Q: 
		cube->ChangeTexture2();
		break;
	}

}



