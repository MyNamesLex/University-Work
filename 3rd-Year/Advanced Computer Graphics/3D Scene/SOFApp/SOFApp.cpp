#include "stdafx.h"
#include "MainApp.h"

int main()
{
	MainApp* app = new MainApp();
	SOF::Window::CreateWindow(1280, 1024, "3D Scene", app);
	SOF::Window::Run();

    return 0;
}

