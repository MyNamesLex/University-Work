color Points = color(0, 255, 0);

class Points {
  int x;
  int y;
  int dy = 7;
  int dx = 7;
  PImage P1;
  PImage P2;

  int counter = 0;
  int countDir = 1;

  boolean hitPlayer = true;

  Points(int x, int y) {
    this.x=x;
    this.y=y;
    P1 = loadImage("Points1.png");
    P2 = loadImage("Points2.png");
  }

  void render()
  {
    if (x < width-10)
    {
      if (counter >= 0 && counter <= 5)
      {
        image(P1, x, y);
        P1.resize(100, 200);
      } else if (counter > 5 && counter <= 10)
      {
        image(P2, x, y);
        P2.resize(100, 200);
      } else
      {
        countDir = -countDir;

        if (counter < 0)
          image(P1, x, y);

        if (counter > 10)
          image(P2, x, y);
      }
      counter = counter + countDir;
    } else
    {
      x=0;
    }
    if (y < 0)
    {
      y = 1000;
      Poi1.hitPlayer = false;
      Poi2.hitPlayer = false;
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
