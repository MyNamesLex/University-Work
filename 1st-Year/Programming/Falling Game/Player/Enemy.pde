color Enemy = color(255, 0, 0);

class Enemy {
  int x;
  int y;
  int dy = 4;
  int dx = -5;
  PImage r1;
  PImage r2;
  boolean hitPlayer = true;

  int counter = 0;
  int countDir = 1;

  Enemy(int x, int y) {
    this.x=x;
    this.y=y;
    r1 = loadImage("r1.png");
    r2 = loadImage("r2.png");
  }

  void render()
  {
    if (x < width-10)
    {
      if (counter >= 0 && counter <= 10)
      {
        image(r1, x, y);
        r1.resize(50, 50);
      } else if (counter > 10 && counter <= 20)
      {
        image(r2, x, y);
        r2.resize(50, 50);
      } else
      {
        countDir = -countDir;

        if (counter < 0)
          image(r1, x, y);

        if (counter > 20)
          image(r2, x, y);
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
