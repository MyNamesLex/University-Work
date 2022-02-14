#pragma once
#include "stdafx.h"
#include "GeometryHelper.h"
#include "ShaderProgram.h"

class TriangleGeom : public GeometryHelper
{
	std::vector<glm::vec3> positions;
	std::vector<glm::vec3> tangents;
	std::vector<glm::vec2> uvs;
	SOF::Geometry* geom;

	void CreateGeometry()
	{
		glm::vec3** vertexPos = new glm::vec3 * [5];
		glm::vec2** vertexUV = new glm::vec2 * [5];
		glm::vec3** vertexTangent = new glm::vec3 * [5];

		for (int i = 0; i < 5; i++)
		{
			vertexPos[i] = new glm::vec3[5];
			vertexUV[i] = new glm::vec2[5];
			vertexTangent[i] = new glm::vec3[5];
		}

		for (int i = 0; i < 5; i++)
		{
			float latitude = glm::radians(-90.0f) + glm::radians(180.0f) * (float)i / (5 - 1);
			for (int j = 0; j < 5; j++)
			{
				float longitude = glm::radians(360.0f) * (float)j / (5 - 1);
				float x, y, z;
				x = cos(latitude) * cos(longitude);
				y = sin(latitude);
				z = cos(latitude) * sin(longitude);
				vertexPos[i][j] = glm::vec3(x, y, z);
				vertexUV[i][j] = glm::vec2(1.0f - (float)j / 5, (float)i / 5);
			}
		}

		positions.push_back(vertexPos[1][1]); positions.push_back(vertexPos[1][1 + 1]); positions.push_back(vertexPos[1 + 1][1 + 1]);
		uvs.push_back(vertexUV[1][1]); uvs.push_back(vertexUV[1][1 + 1]); uvs.push_back(vertexUV[1 + 1][1 + 1]);
		tangents.push_back(vertexTangent[1][1]); tangents.push_back(vertexTangent[1][1 + 1]); tangents.push_back(vertexTangent[1 + 1][1 + 1]);

		// clean up memory
		for (int i = 0; i < 5; i++)
		{
			delete vertexPos[i];
			delete vertexUV[i];
		}
		delete[] vertexPos;
		delete[] vertexUV;

	}
public:
	TriangleGeom() { CreateGeometry(); }
	const std::vector<glm::vec3>& GetPositionVector() const { return positions; }
	const std::vector<glm::vec3>& GetNormalVector() const { return positions; }
	const std::vector<glm::vec2>& GetUVVector() const { return uvs; }
	const std::vector<glm::vec3>& GetTangentVector() const { return tangents; }
	int GetNumVertices() const { return positions.size(); }
};