#include "stdafx.h"
#include "CubeLab13.h"

// statics

SOF::ShaderProgram *CubeLab13::pShader = nullptr;
SOF::ShaderProgram *CubeLab13::pShader2 = nullptr;

SOF::Geometry *CubeLab13::pGeometry = nullptr;
SOF::Geometry *CubeLab13::pGeometry2 = nullptr;

SOF::Texture *CubeLab13::pDiffuse = nullptr;
SOF::Texture *CubeLab13::pDiffuse2 = nullptr;

bool flag;

CubeLab13::CubeLab13()
{
	// load the shared resources, if this has not already been done
	if (pGeometry == nullptr)
	{
		flag = false;
		pShader = new SOF::ShaderProgram("shaders/lab13_vertex-shader.glsl", "shaders/lab13_fragment-shader.glsl");
		int nVertex = 6 * 2 * 3; // 6 faces * 2 triangles * 3 vertices each	
		pGeometry = new SOF::Geometry(nVertex);
		// make a cube, centred on the origin

		glm::vec3 vertexPositions[] = {
			glm::vec3(-0.5f, -0.5f, -0.5f),
			glm::vec3(-0.5f,  0.5f, -0.5f),
			glm::vec3( 0.5f,  0.5f, -0.5f),
			glm::vec3( 0.5f, -0.5f, -0.5f),
			glm::vec3(-0.5f, -0.5f,  0.5f),
			glm::vec3(-0.5f,  0.5f,  0.5f),
			glm::vec3( 0.5f,  0.5f,  0.5f),
			glm::vec3( 0.5f, -0.5f,  0.5f)
		};
		glm::vec4 vertexColors[] = {
			glm::vec4(1.0f, 0.0f, 0.0f, 1.0f),
			glm::vec4(1.0f, 1.0f, 0.0f, 1.0f),
			glm::vec4(0.0f, 1.0f, 0.0f, 1.0f),
			glm::vec4(0.0f, 1.0f, 1.0f, 1.0f),
			glm::vec4(0.0f, 0.0f, 1.0f, 1.0f),
			glm::vec4(1.0f, 0.0f, 1.0f, 1.0f),
			glm::vec4(1.0f, 1.0f, 1.0f, 1.0f),
			glm::vec4(0.0f, 0.0f, 0.0f, 1.0f)
		};
		
		
		//Standard arrangement - right way up! 
		int numUV = 6;
		glm::vec2 faceUVs[] =
		{
			glm::vec2(0.0f, 0.0f),
			glm::vec2(0.0f, 1.0f),
			glm::vec2(1.0f, 1.0f),
			glm::vec2(0.0f, 0.0f),
			glm::vec2(1.0f, 1.0f),
			glm::vec2(1.0f, 0.0f)
		};
		
		
		/*
		//Special arrangement for the mosaic:
		int image_ncols[] = { 4928, 259, 256, 512, 256, 256 };
		int image_nrows[] = { 3264, 194, 256, 512, 256, 256 };
		int tot_ncols = 6467;
		int tot_nrows = 3264;

		
		int numUV = 36;
		glm::vec2 faceUVs[] =
		{
			
		};
		*/
		

		int triangles[] = 
		{ 
			0,4,5,0,5,1, 
			1,5,6,1,6,2, 
			2,6,7,2,7,3, 
			3,7,4,3,4,0, 
			4,7,6,4,6,5,
			3,0,1,3,1,2 
		};





		std::vector<glm::vec3> vertexPos;
		std::vector<glm::vec4> vertexColor;
		std::vector<glm::vec2> vertexUV;
		for (int i = 0; i < nVertex; i++)
		{
			vertexPos.push_back(vertexPositions[triangles[i]]);	
			vertexColor.push_back(vertexColors[triangles[i]]);
			vertexUV.push_back(faceUVs[i%numUV]);
 		}

		pDiffuse = new SOF::Texture(1);
		//pDiffuse->loadTexture(0, "textures/image-mosaic.jpg");
		pDiffuse->loadTexture(0, "textures/wooden-crate.jpg");

		pGeometry->AddAttribute(vertexPos, "vertexPos");
		pGeometry->AddAttribute(vertexColor, "vertexColor");
		pGeometry->AddAttribute(vertexUV, "vertexTexCoord");
		pGeometry->Finalize(pShader);
	}
}

void CubeLab13::ChangeTexture2()
{
	// load the shared resources, if this has not already been done
	if (pGeometry2 == nullptr)
	{
		if (flag == true)
		{
			flag = false;
			CubeLab13(cube);
		}
		flag = true;
		pShader2 = new SOF::ShaderProgram("shaders/lab13_vertex-shader.glsl", "shaders/lab13_fragment-shader.glsl");
		int nVertex2 = 6 * 2 * 3; // 6 faces * 2 triangles * 3 vertices each	
		pGeometry2 = new SOF::Geometry(nVertex2);
		// make a cube, centred on the origin

		glm::vec3 vertexPositions[] = {
			glm::vec3(-0.5f, -0.5f, -0.5f),
			glm::vec3(-0.5f,  0.5f, -0.5f),
			glm::vec3(0.5f,  0.5f, -0.5f),
			glm::vec3(0.5f, -0.5f, -0.5f),
			glm::vec3(-0.5f, -0.5f,  0.5f),
			glm::vec3(-0.5f,  0.5f,  0.5f),
			glm::vec3(0.5f,  0.5f,  0.5f),
			glm::vec3(0.5f, -0.5f,  0.5f)
		};
		glm::vec4 vertexColors[] = {
			glm::vec4(1.0f, 0.0f, 0.0f, 1.0f),
			glm::vec4(1.0f, 1.0f, 0.0f, 1.0f),
			glm::vec4(0.0f, 1.0f, 0.0f, 1.0f),
			glm::vec4(0.0f, 1.0f, 1.0f, 1.0f),
			glm::vec4(0.0f, 0.0f, 1.0f, 1.0f),
			glm::vec4(1.0f, 0.0f, 1.0f, 1.0f),
			glm::vec4(1.0f, 1.0f, 1.0f, 1.0f),
			glm::vec4(0.0f, 0.0f, 0.0f, 1.0f)
		};

		//Standard arrangement - right way up! 
		int numUV = 6;
		glm::vec2 faceUVs[] =
		{
			glm::vec2(0.0f, 0.0f),
			glm::vec2(0.0f, 1.0f),
			glm::vec2(1.0f, 1.0f),
			glm::vec2(0.0f, 0.0f),
			glm::vec2(1.0f, 1.0f),
			glm::vec2(1.0f, 0.0f)
		};

		int triangles[] =
		{-
			0,4,5,0,5,1,
			1,5,6,1,6,2,
			2,6,7,2,7,3,
			3,7,4,3,4,0,
			4,7,6,4,6,5,
			3,0,1,3,1,2
		};

		std::vector<glm::vec3> vertexPos;
		std::vector<glm::vec4> vertexColor;
		std::vector<glm::vec2> vertexUV;
		for (int i = 0; i < nVertex2; i++)
		{
			vertexPos.push_back(vertexPositions[triangles[i]]);
			vertexColor.push_back(vertexColors[triangles[i]]);
			vertexUV.push_back(faceUVs[i % numUV]);
		}

		pDiffuse2 = new SOF::Texture(1);
		//pDiffuse->loadTexture(0, "textures/image-mosaic.jpg");
		pDiffuse2->loadTexture(0, "textures/golddiag.jpg");

		pGeometry2->AddAttribute(vertexPos, "vertexPos");
		pGeometry2->AddAttribute(vertexColor, "vertexColor");
		pGeometry2->AddAttribute(vertexUV, "vertexTexCoord");
		pGeometry2->Finalize(pShader2);
	}
}

void CubeLab13::SetRender(const GLboolean r)
{
	render = r;
}
GLboolean CubeLab13::GetRender()
{
	return render;
}

void CubeLab13::preDraw(const glm::mat4 &view, const glm::mat4 &proj)
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
	{
		pShader->SetUniformVec4("fixedColor", cubeColor);
		pShader->SetUniformInt("useFixedColor", 0);
	}

	if (flag == true)
	{
		pShader->SetUniformVec4("fixedColor", cubeColor);
		pShader->SetUniformInt("useFixedColor", 1);
	}
	if (flag == false)
	{
		pShader->SetUniformVec4("fixedColor", cubeColor);
		pShader->SetUniformInt("useFixedColor", 0);
	}

	// camera
	glm::vec3 cameraPosition = (glm::vec3)(glm::inverse(view)[3]);
	pShader->SetUniformMat4("vpm", proj*view);

	//texture
	pShader->AssignTextureSampler("diffuse", pDiffuse, 0);
}

void CubeLab13::Draw(const glm::mat4 &view, const glm::mat4 &proj)
{
	glm::mat4 b = glm::mat4();
	Draw(view, proj, b);
}



void CubeLab13::Draw(const glm::mat4 &view, const glm::mat4 &proj, const glm::mat4 &base)
{

	preDraw(view, proj);

	// model
	glm::mat4 combTrans = base * modelTransform;
	pShader->SetUniformMat4("mdm", combTrans);

	// draw the geometry
	pGeometry->DrawPrimitives();
}


void CubeLab13::DrawLines(const glm::mat4 &view, const glm::mat4 &proj)
{
	glm::mat4 b = glm::mat4();
	DrawLines(view, proj, b);
}

void CubeLab13::DrawLines(const glm::mat4 &view, const glm::mat4 &proj, const glm::mat4 &base)
{
	preDraw(view, proj);

	// model
	glm::mat4 combTrans = base * modelTransform;
	pShader->SetUniformMat4("mdm", combTrans);

	// draw the geometry
	pShader->SetUniformInt("useFixedColor", 1);
	// set the colour of the lines drawn in wire-frame mode to black
	pShader->SetUniformVec4("fixedColor", glm::vec4(0.0, 0.0, 0.0, 1.0));
	pGeometry->DrawLines();
	pShader->SetUniformInt("useFixedColor", 0);
	// set the colour of the lines drawn in wire-frame mode to black
	pShader->SetUniformVec4("fixedColor", cubeColor);

}


void CubeLab13::SetColor(const glm::vec4 &color)
{
	cubeColor = color;
	useColor = true;
}

void CubeLab13::SetTransform(const glm::mat4 &transform)
{ 
	modelTransform = transform; 
}

glm::mat4 CubeLab13::GetTransform()
{
	return modelTransform;
}

void CubeLab13::NullTransform()
{
	modelTransform = glm::mat4();
}

void CubeLab13::SetScale(const glm::vec3 &scale)
{
	modelTransform = glm::scale(modelTransform, scale);
}


void CubeLab13::SetTranslate(const glm::vec3 &trans)
{
	modelTransform = glm::translate(modelTransform, trans);
}
void CubeLab13::SetXRotation(float rot)
{
	modelTransform = glm::rotate(modelTransform, (float) glm::radians(rot), glm::vec3(1.0f, 0.0f, 0.0f));
}
void CubeLab13::SetYRotation(float rot)
{
	modelTransform = glm::rotate(modelTransform, (float)glm::radians(rot), glm::vec3(0.0f, 1.0f, 0.0f));
}
void CubeLab13::SetZRotation(float rot)
{
	modelTransform = glm::rotate(modelTransform, (float)glm::radians(rot), glm::vec3(0.0f, 0.0f, -1.0f));
}