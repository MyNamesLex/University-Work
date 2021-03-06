// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers

// TODO: reference additional headers your program requires here
#include <iostream>
#include <stdexcept>
#include <string>
#include <vector>
#include <fstream>
#include <sstream>
#include <map>
// OpenGL stuff
#define GLEW_STATIC // use the statically linked (i.e. non-dll) version of glew library
#include <gl/glew.h>
// glfw (OpenGL framework)
#include <GLFW/glfw3.h>
// glm (open gl maths - vectors and matrices)
#define GLM_FORCE_CTOR_INIT // force glm to initialize vectors and matrices to 0 and identity respectively (default behaviour until recently)
#include <glm/glm.hpp>
#include <glm/gtc/type_ptr.hpp>
