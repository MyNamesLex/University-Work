#pragma once
#include "SOF.h"

class CubeLab10Triangles
{
	// a coloured cube

	// shared resources betweeen all instances
	static SOF::ShaderProgram* pShader;
	static SOF::Geometry* pGeometry;
	static glm::mat4* baseTransform;

	// per instance data
	glm::mat4 modelTransform;
	glm::vec4 cubeColor;
	GLboolean useColor = false;

public:
	CubeLab10Triangles();
	void SetBaseTransformTriangle(glm::mat4& transform);
	void SetTransformTriangle(const glm::mat4& transform);
	void DrawTriangle(const glm::mat4& view, const glm::mat4& proj);
	void setColorTriangle(const glm::vec4& color);

	void NullTransformTriangle();
	void SetScaleTriangle(const glm::vec3& scale);
	void SetTranslateTriangle(const glm::vec3& trans);
	void SetXRotationTriangle(float rot);
	void SetYRotationTriangle(float rot);
	void SetZRotationTriangle(float rot);
};
