#include "stdafx.h"
#include "CubeLab10Triangles.h"

// statics

SOF::ShaderProgram* CubeLab10Triangles::pShader = nullptr;
SOF::Geometry* CubeLab10Triangles::pGeometry = nullptr;
glm::mat4* CubeLab10Triangles::baseTransform = nullptr;

CubeLab10Triangles::CubeLab10Triangles()
{
	// load the shared resources, if this has not already been done
	if (pGeometry == nullptr)
	{
		pShader = new SOF::ShaderProgram("shaders/lab10_vertex-shader.glsl", "shaders/lab10_fragment-shader.glsl");
		int nVertex = 1 * 3; // 1 triangles * 3 vertices each	
		pGeometry = new SOF::Geometry(nVertex);
		// make a cube, centred on the origin
		glm::vec3 vertexPositions[] = {
			glm::vec3(-1.0f, -1.0f, -1.0f),
			glm::vec3(1.0f,  -1.0f, 1.0f),
		};

		glm::vec4 vertexColors[] = {
			glm::vec4(0.0, 0.0, 0.0, 1.0),  // black
			glm::vec4(1.0, 0.0, 0.0, 1.0),  // red
			glm::vec4(1.0, 1.0, 0.0, 1.0),  // yellow
			glm::vec4(0.0, 1.0, 0.0, 1.0),  // green
			glm::vec4(0.0, 0.0, 1.0, 1.0),  // blue
			glm::vec4(1.0, 0.0, 1.0, 1.0),  // magenta
			glm::vec4(1.0, 1.0, 1.0, 1.0),  // white
			glm::vec4(0.0, 1.0, 1.0, 1.0)   // cyan
		};

		int triangles[] = { 0,4,5,0,5,1, 1,5,6,1,6,2, 2,6,7,2,7,3, 3,7,4,3,4,0, 4,7,6,4,6,5, 3,0,1,3,1,2 };

		std::vector<glm::vec3> vertexPos;
		std::vector<glm::vec4> vertexColor;
		for (int i = 0; i < nVertex; i++)
		{
			vertexPos.push_back(vertexPositions[triangles[i]]);
			vertexColor.push_back(vertexColors[triangles[i]]);
		}

		pGeometry->AddAttribute(vertexPos, "vertexPos");
		pGeometry->AddAttribute(vertexColor, "vertexColor");
		pGeometry->Finalize(pShader);

	}

}

void CubeLab10Triangles::SetBaseTransformTriangle (glm::mat4& transform)
{
	if (baseTransform == nullptr)
		baseTransform = new glm::mat4();
	*baseTransform = transform;
}

void CubeLab10Triangles::DrawTriangle(const glm::mat4& view, const glm::mat4& proj)
{
	// set the shader uniforms
	// enable the shader
	pShader->Use();

	if (useColor)
	{
		pShader->SetUniformVec4("fixedColor", cubeColor);
		pShader->SetUniformInt("useFixedColor", 1);
	}
	else
		pShader->SetUniformInt("useFixedColor", 0);


	// camera
	glm::vec3 cameraPosition = (glm::vec3)(glm::inverse(view)[3]);
	pShader->SetUniformMat4("vpm", proj * view);
	if (baseTransform != nullptr) {
		glm::mat4 combTrans = *baseTransform * modelTransform;
		pShader->SetUniformMat4("mdm", combTrans);
	}
	else
		pShader->SetUniformMat4("mdm", modelTransform);

	// draw the geometry
	pGeometry->DrawPrimitives();


}

void CubeLab10Triangles::setColorTriangle(const glm::vec4& color)
{
	cubeColor = color;
	useColor = true;
}

void CubeLab10Triangles::SetTransformTriangle(const glm::mat4& transform)
{
	modelTransform = transform;
}


void CubeLab10Triangles::NullTransformTriangle()
{
	modelTransform = glm::mat4();
}

void CubeLab10Triangles::SetScaleTriangle(const glm::vec3& scale)
{
	modelTransform = glm::scale(modelTransform, scale);
}


void CubeLab10Triangles::SetTranslateTriangle(const glm::vec3& trans)
{
	modelTransform = glm::translate(modelTransform, trans);
}
void CubeLab10Triangles::SetXRotationTriangle(float rot)
{
	modelTransform = glm::rotate(modelTransform, (float)glm::radians(rot), glm::vec3(1.0f, 0.0f, 0.0f));
}
void CubeLab10Triangles::SetYRotationTriangle(float rot)
{
	modelTransform = glm::rotate(modelTransform, (float)glm::radians(rot), glm::vec3(0.0f, 1.0f, 0.0f));
}
void CubeLab10Triangles::SetZRotationTriangle(float rot)
{
	modelTransform = glm::rotate(modelTransform, (float)glm::radians(rot), glm::vec3(0.0f, 0.0f, -1.0f));
}