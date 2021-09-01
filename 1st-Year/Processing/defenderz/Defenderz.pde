PImage background;
int x=0; //global variable background location 
Defender player1;
Alien Alien1;
Alien Aliennew1;
Alien Aliennew2;
final int gamestart = 0;
final int gamefinish = 1;
int gameMode = gamestart;

void setup() 
{ 
  size(800, 400); 

  background = loadImage("spaceBackground.jpg");
  background.resize(width, height);

  player1 = new Defender(100);
  Alien1 = new Alien(width-30, height/2);
  Aliennew1 = new Alien(width-100, height/3);
  Aliennew2 = new Alien(width-170, height/2);
} 
void draw () 
{
  if (gameMode == gamestart)
  {
    drawBackground();
    player1.render();
    Alien1.update();
    Aliennew1.update();
    Aliennew2.update();

    if (player1.crash())
    {
      player1.render();
      gameMode = gamefinish;
      print("CRASHED");
    }
  }
}
void keyPressed() {
  if (key == CODED) {
    if (keyCode == UP && player1.y > 10) {
      player1.y -= 5;
    }
    if (keyCode == DOWN && player1.y < height-20) {
      player1.y += 5;
    }
  }
}
void drawBackground() {
  image(background, x, 0); //draw background twice adjacent
  image(background, x+background.width, 0);
  x -=4;
  if (x == -background.width)
    x=0; //wrap background
}
