#pragma once
#include "PointLight.h"
#include "RenderLib.h"
#include <vector>
#include "CuboidGeom.h"
#include "TexturedLit.h"
#include "physics.h"

class ComputerMouse
{
public:
	float angles[4];
	float h[6];
	float w[6];
	float l[6];
	TexturedLit* meshes[6];
	glm::mat4 transforms[6];
	ComputerMouse()
	{

		h[0] = 0.0f; w[0] = 0.0f; l[0] = 0.0f;
		h[1] = 0.0f; w[1] = 0.0f; l[1] = 0.0f;
		h[2] = 0.0f; w[2] = 0.0f; l[2] = 0.0f;

		h[3] = 1.0f; w[3] = 7.0f; l[3] = 2.0f;
		h[4] = 0.0f; w[4] = 0.0f; l[4] = 0.0f;
		h[5] = 0.0f; w[5] = 0.0f; l[5] = 0.0f;

		angles[0] = 0.0f;
		angles[1] = 0.0f;
		angles[2] = 0.0f;
		angles[3] = 0.0f;


		for (int i = 0; i < 6; i++)
		{
			transforms[i] = glm::mat4();
		}

		for (int i = 0; i < 6; i++)
		{
			CuboidGeometry c(w[i], h[i], l[i]);
			meshes[i] = new TexturedLit(c, "textures/stone.png");
		}
	}

	void RotateElement(int i, float delta) { angles[i] += delta; }
	void UpdateTransforms(const glm::mat4& model);
	void Draw(const Transforms& t, const PointLight& light);
};