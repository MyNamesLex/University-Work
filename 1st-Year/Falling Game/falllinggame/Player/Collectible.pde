color Collectible = color(0, 255, 0);

class Collectible {
  int x;
  int y;
  int dy = 7;
  int dx = 7;
  PImage C1;
  PImage C2;

  int counter = 0;
  int countDir = 1;

  Collectible(int x, int y) {
    this.x=x;
    this.y=y;
    C1 = loadImage("collect1.png");
    C2 = loadImage("collect2.png");
  }

  void render()
  {
    if (x < width-10)
    {
      if (counter >= 0 && counter <= 5)
      {
        image(C1, x, y);
        C1.resize(50, 50);
      } else if (counter > 5 && counter <= 10)
      {
        image(C2, x, y);
        C2.resize(50, 50);
      } else
      {
        countDir = -countDir;

        if (counter < 0)
          image(C1, x, y);

        if (counter > 10)
          image(C2, x, y);
      }
      counter = counter + countDir;
    } else
    {
      x=0;
    }
    if (y < 0)
    {
      y = 1000;
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
