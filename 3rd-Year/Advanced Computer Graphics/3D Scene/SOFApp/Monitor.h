#pragma once
#include "PointLight.h"
#include "RenderLib.h"
#include <vector>
#include "CuboidGeom.h"
#include "TexturedLit.h"
#include "physics.h"

class Monitor
{
public:
	float angles[4];
	float h[6];
	float w[6];
	float l[6];
	TexturedLit* meshes[6];
	glm::mat4 transforms[6];
	Monitor()
	{

		h[0] = 4.0f; w[0] = 20.0f; l[0] = 10.0f;
		h[1] = 10.0f; w[1] = 1.5f; l[1] = 1.5f;
		h[2] = 2.0f; w[2] = 1.5f; l[2] = 1.5f;

		h[3] = 1.0f; w[3] = 20.0f; l[3] = 20.0f;
		h[4] = 5.0f; w[4] = 0.75f; l[4] = 0.75f;
		h[5] = 5.0f; w[5] = 0.75f; l[5] = 0.75f;

		angles[0] = 0.0f;
		angles[1] = 0.0f;
		angles[2] = 0.0f;
		angles[3] = 90.0f;


		for (int i = 0; i < 6; i++)
		{
			transforms[i] = glm::mat4();
		}

		for (int i = 0; i < 6; i++)
		{
			CuboidGeometry c(w[i], h[i], l[i]);
			meshes[i] = new TexturedLit(c, "textures/marble.png");
		}
	}

	void RotateElement(int i, float delta) { angles[i] += delta; }
	void UpdateTransforms(const glm::mat4& model);
	void Draw(const Transforms& t, const PointLight& light);
};