// Example2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "SOF.h"
#include "newlab13Q2App.h"

int main()
{
	NewLab13Q2App *app = new NewLab13Q2App();
	SOF::Window::CreateWindow(768, 768, "Task 5", app);
	SOF::Window::SetBackground(glm::vec4(1.0f, 1.0f, 1.0f, 1.0f));
	SOF::Window::Run();

    return 0;
}

