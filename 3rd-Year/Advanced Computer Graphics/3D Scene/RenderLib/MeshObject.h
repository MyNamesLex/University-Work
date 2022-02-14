#pragma once
#include "ShaderProgram.h"
#include "Geometry.h"
#include "Transforms.h"
#include "PointLight.h"
#include "Texture.h"
#include "GeometryHelper.h"
#include "TexturedLit.h"
#include "FlyCam.h"
// assimp includes
#include <assimp/Importer.hpp>
#include <assimp/scene.h>           // Output data structure
#include <assimp/postprocess.h>     // Post processing flags

class MeshObject : public Drawable
{
	std::vector<TexturedLit*> subObjects;
	void Load(const std::string& fileName);
public:
	std::vector<glm::vec4> Meshpositions;
	const static int numObjects = 100;
	glm::vec4 objectPositions[numObjects];

	FlyCam* cam;

	MeshObject(const std::string& meshFile);
	void Draw(const Transforms& trans, const PointLight& light);
};