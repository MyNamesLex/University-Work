color GEnemy = color(0, 255, 0);

class GEnemy {
  int x;
  int y;
  int dy = 5;
  int dx = -5;
  PImage g1;
  PImage g2;
  boolean hitPlayer = true;

  int counter = 0;
  int countDir = 1;

  GEnemy(int x, int y) {
    this.x=x;
    this.y=y;
    g1 = loadImage("g1.png");
    g2 = loadImage("g2.png");
  }

  void render()
  {
    if (x < width-10)
    {
      if (counter >= 0 && counter <= 10)
      {
        image(g1, x, y);
        g1.resize(50, 50);
      } else if (counter > 10 && counter <= 20)
      {
        image(g2, x, y);
        g2.resize(50, 50);
      } else
      {
        countDir = -countDir;

        if (counter < 0)
          image(g1, x, y);

        if (counter > 20)
          image(g2, x, y);
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
      GEnemynew1.hitPlayer = false;
      GEnemynew2.hitPlayer = false;
      GEnemynew3.hitPlayer = false;
    }
  }

  void move() {
    x += dx;
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
