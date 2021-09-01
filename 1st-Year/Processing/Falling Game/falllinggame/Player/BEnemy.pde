color BEnemy = color(0, 0, 255);

class BEnemy {
  int x;
  int y;
  int dy = 3;
  int dx = -5;
  PImage b1;
  PImage b2;
  boolean hitPlayer = true;

  int counter = 0;
  int countDir = 1;

  BEnemy(int x, int y) {
    this.x=x;
    this.y=y;
    b1 = loadImage("b1.png");
    b2 = loadImage("b2.png");
  }
  void render()
  {
    if (x < width-10)
    {
      if (counter >= 0 && counter <= 10)
      {
        image(b1, x, y);
        b1.resize(50, 50);
      } else if (counter > 10 && counter <= 20)
      {
        image(b2, x, y);
        b2.resize(50, 50);
      } else
      {
        countDir = -countDir;

        if (counter < 0)
          image(b1, x, y);

        if (counter > 20)
          image(b2, x, y);
      }
      counter = counter + countDir;
    } else
    {
      x=0;
    }
    if (y < 0)
    {
      y = 1000;
      points=points+10;
      BEnemynew1.hitPlayer = false;
      BEnemynew2.hitPlayer = false;
      BEnemynew3.hitPlayer = false;
    }
  }

  void move() {
    x -= dx;
    y -= dy;
  }

  void bounce()
  {
    if (x <= 30)
    {
      dx =- dx;
    }
    if (x >= width-30) 
    {
      dx =- dx;
    }
  }

  void update() {
    render();
    move();
    bounce();
  }
}
