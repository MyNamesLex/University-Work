PImage background;
int x=0; //global variable background location 
int y=0;

int deathcounter=0;
int points=0;
int healthcounter=3;
int Collectiblecounter=0;

ArrayList<Enemy> Enemyy = new ArrayList();

int i;
int splashTime;
PFont text;
Playe Player1;

GEnemy GEnemynew1;
GEnemy GEnemynew2;
GEnemy GEnemynew3;

BEnemy BEnemynew1;
BEnemy BEnemynew2;
BEnemy BEnemynew3;

Health healthnew1;
Health healthnew2;

Points Poi1;
Points Poi2;

Collectible Collectible1;

boolean presentGameOverScreen=false;

final int gamestart = 0;
final int gamefinish = 1;
int gameMode = gamestart;

public void settings()
{
  size(800, 1000);
}

void setup() 
{ 
  text = createFont("MS Sans Serif", 16, true);
  background = loadImage("background.png");
  background.resize(width, height);

  Player1 = new Playe(100);

  for (int i = 0; i < 5; i++)
  {
    Enemyy.add(new Enemy((int)random(700), 1000));
  }

  GEnemynew1 = new GEnemy (200, 1000);
  GEnemynew2 = new GEnemy (700, 1000);
  GEnemynew3 = new GEnemy (500, 1000);

  BEnemynew1 = new BEnemy (200, 1000);
  BEnemynew2 = new BEnemy (100, 1000);
  BEnemynew3 = new BEnemy (500, 1000);

  healthnew1 = new Health (150, 1000);
  healthnew2 = new Health (400, 1000);

  Poi1 = new Points (200, 200);
  Poi2 = new Points (400, 400);

  Collectible1 = new Collectible (500, 500);
} 

void draw () 
{
  if (millis() < 3000)
  {
    text("Welcome", 400, 500, 500);
  } 
  else
  {
    if (gameMode == gamestart)
    {

      drawBackground();
      Player1.update();

      for (int i=0; i <Enemyy.size(); i++)
      {
        Enemy e = Enemyy.get(i);
        e.update();
        if (Player1.crash(e))
        {
          healthcounter=healthcounter-1;
          Enemyy.remove(e);
          for (int j = 0; j < Enemyy.size(); j++)
          {
            Enemyy.remove(j);
          }
        }
      }

      GEnemynew1.update();
      GEnemynew2.update();
      GEnemynew3.update();

      BEnemynew1.update();
      BEnemynew2.update();
      BEnemynew3.update();

      healthnew1.update();
      healthnew2.update();

      Poi1.update();
      Poi2.update();

      if (Collectible1 != null)
        Collectible1.update();
    }
  }
}
void keyPressed() {
  if (key == CODED) {
    if (keyCode == LEFT && Player1.x > width-800) {
      Player1.x -= 6;
    }

    if (keyCode == RIGHT && Player1.x < width-40) {
      Player1.x += 6;
    }

    if (keyCode == DOWN && Player1.y < height-60) {
      Player1.y += 6;
    }

    if (keyCode == UP && Player1.y > height-990) {
      Player1.y -= 6;
    }



    if (keyCode == LEFT && keyCode == DOWN && Player1.x > width-800 && Player1.y < height-60) {
      Player1.x -= 6;
      Player1.y += 6;
    }

    if (keyCode == RIGHT && keyCode == UP && Player1.x < width-40 && Player1.y > height-990) {
      Player1.x += 6;
      Player1.y -= 6;
    }

    if (keyCode == LEFT && keyCode == UP && Player1.x > width-800 && Player1.y > height-990) {
      Player1.x -= 6;
      Player1.y -= 6;
    }

    if (keyCode == RIGHT && keyCode == DOWN && Player1.x < width-40 && Player1.y < height-60) {
      Player1.x += 6;
      Player1.y += 6;
    }
  }
  if (keyCode == 'R' && gameMode == gamefinish) {
    gameMode = gamestart;
    Player1.y = 100;
    Player1.x = 200;

    for (int i = 0; i < Enemyy.size(); i++)
    {
      Enemyy.remove(i);
    }
    for (int i = 0; i < 5; i++)
    {
      Enemyy.add(new Enemy((int)random(700), 1000));
    }

    GEnemynew1.x = 200;
    GEnemynew1.y = 1000;
    GEnemynew2.x = 700;
    GEnemynew2.y = 1000;
    GEnemynew3.x = 500;
    GEnemynew3.y = 1000;

    BEnemynew1.x = 400;
    BEnemynew1.y = 1000;
    BEnemynew2.x = 200;
    BEnemynew2.y = 1000;
    BEnemynew3.x = 500;
    BEnemynew3.y = 1000;

    healthnew1.x = 150;
    healthnew1.y = 1000;
    healthnew2.x = 400;
    healthnew2.y = 1000;

    Poi1.x = 200;
    Poi1.y = 200;
    Poi2.x = 400;
    Poi2.y = 400;

    if (Collectible1 == null)
    {
      Collectible1 = new Collectible (500, 500);
    }
    Collectible1.x = 500;
    Collectible1.y = 500;

    deathcounter=deathcounter+1;
    points=0;
    healthcounter=3;
    Collectiblecounter=0;
  }


  if (keyCode == 'A')
  {
    gameMode=gamestart;
  }

  if (keyCode == 'S')
  {

    GEnemynew1.dx = 2;
    GEnemynew1.dy = 2;
    GEnemynew2.dx = 2;
    GEnemynew2.dy = 2;
    GEnemynew3.dx = 2;
    GEnemynew3.dy = 2;

    BEnemynew1.dx = 2;
    BEnemynew1.dy = 2;
    BEnemynew2.dx = 2;
    BEnemynew2.dy = 2;
    BEnemynew3.dx = 2;
    BEnemynew3.dy = 2;

    healthnew1.dx = 1;
    healthnew1.dy = 1;
    healthnew2.dx = 1;
    healthnew2.dy = 1;

    Poi1.dx = 3;
    Poi1.dy = 3;
    Poi2.dx = 3;
    Poi2.dy = 3;

    if (Collectible1 != null)
    {
      Collectible1.dx = 3;
      Collectible1.dy = 3;
    }
  }
}

void keyReleased() 
{
  if (keyCode == 'S')
  {

    GEnemynew1.dx = -5;
    GEnemynew1.dy = 5;
    GEnemynew2.dx = -5;
    GEnemynew2.dy = 5;
    GEnemynew3.dx = -5;
    GEnemynew3.dy = 5;

    BEnemynew1.dx = -6;
    BEnemynew1.dy = 4;
    BEnemynew2.dx = -6;
    BEnemynew2.dy = 4;
    BEnemynew3.dx = -6;
    BEnemynew3.dy = 4;

    healthnew1.dx = 2;
    healthnew1.dy = 2;
    healthnew2.dx = 2;
    healthnew2.dy = 2;

    Poi1.dx = 7;
    Poi1.dy = 7;
    Poi2.dx = 7;
    Poi2.dy = 7;

    if (Collectible1 != null)
    {
      Collectible1.dx = 7;
      Collectible1.dy = 7;
    }
  }
}

void drawBackground() {
  image(background, 0, y); //draw background twice adjacent
  image(background, 0, y+background.height);
  y -=4;
  if (y == -background.height) {
    y=0; //wrap background
  }
  textFont(text, 32);  
  
  fill(10, 120, 120);  
  text ("Health - "+healthcounter, 10, 50, 200);
  
  fill(10, 120, 120);  
  text ("Deaths - "+deathcounter, 10, 100, 200);   

  fill(10, 120, 120);  
  text ("Points - "+points, 10, 150, 200);

  fill(10, 120, 120);  
  text ("Collectables - "+Collectiblecounter, 10, 200, 200);

  fill(10, 120, 120);  
  text ("'S' = Slow Mo", 10, 990, 200);
}
