#pragma once
#include "stdafx.h"
#include "ShaderProgram.h"
#include "Geometry.h"
#include "SphereGeom.h"
#include "Transforms.h"
class AlternateEmissive
{
	SOF::ShaderProgram* shader;
	SOF::Geometry* geom;
	float AltEmissiveTime;

	void CreateGeometry(const GeometryHelper& geometry)
	{
		shader = new SOF::ShaderProgram("shaders/v_emissive.glsl", "shaders/f_emissive.glsl");
		geom = new SOF::Geometry(geometry.GetNumVertices());
		geom->AddAttribute(geometry.GetPositionVector(), "vertexPos");
		geom->Finalize(shader);
	}
public:
	AlternateEmissive(const GeometryHelper& geometry) { CreateGeometry(geometry); }
	void Draw(const Transforms& trans, const glm::vec4& color)
	{
		glm::mat4 mvp;
		mvp = trans.GetProj() * trans.GetView() * trans.GetModel();
		shader->Use();
		shader->SetUniformMat4("mvp", mvp);
		shader->SetUniformFloat("deltaT", AltEmissiveTime);
		shader->SetUniformVec4("color", color);
		geom->DrawPrimitives();
	}

	void GetDeltaT(float deltaT)
	{
		AltEmissiveTime += deltaT;
		if (AltEmissiveTime >= 50.0f) // stop the altemissivetime getting too big and impacting performance
			AltEmissiveTime = 0.0f;
		shader->SetUniformFloat("deltaT", AltEmissiveTime);
	}
};