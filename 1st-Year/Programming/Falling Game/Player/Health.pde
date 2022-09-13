color Health = color(0, 255, 0);

class Health {
  int x;
  int y;
  int dy = 2;
  int dx = +2;
  PImage health1;
  PImage health2;

  int counter = 0;
  int countDir = 1;

  boolean hitPlayer = true;

  Health(int x, int y) {
    this.x=x;
    this.y=y;
    health1 = loadImage("h1.png");
    health2 = loadImage("h2.png");
  }

  void render()
  {
    if (x < width-10)
    {
      if (counter >= 0 && counter <= 5)
      {
        image(health1, x, y);
        health1.resize(150, 100);
      } else if (counter > 5 && counter <= 10)
      {
        image(health2, x, y);
        health2.resize(150, 100);
      } else
      {
        countDir = -countDir;

        if (counter < 0)
          image(health1, x, y);

        if (counter > 10)
          image(health2, x, y);
      }
      counter = counter + countDir;
    } else
    {
      x=0;
    }
    if (y < 0)
    {
      y = 1000;
      healthnew1.hitPlayer = false;
      healthnew2.hitPlayer = false;
    }
  }

  void move() {
    x -= dx;
    y -= dy;
  }

  void bounce()
  {
    if (x <= 15)
    {
      dx =- dx;
    }
    if (x >= width-15) 
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
