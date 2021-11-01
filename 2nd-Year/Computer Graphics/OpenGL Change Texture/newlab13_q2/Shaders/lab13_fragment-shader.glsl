#version 330
in vec4 fragColor;
in vec2 fragTexCoord;
out vec4 finalColor;
uniform sampler2D diffuse;
uniform int useTexture;

void main() 
{
	if (useTexture == 1)
		finalColor =  texture(diffuse, fragTexCoord);
	else if (useTexture == 0)
		finalColor = texture(diffuse, fragTexCoord);
	else
		finalColor = fragColor;
}
 