#version 330

// simple change over time shader

out vec4 finalColor;
uniform vec4 color;
uniform float deltaT;

void main()
{
	vec3 changecolour = cos(deltaT+vec3(40,0,0));
	finalColor = vec4(changecolour,1.0);
}