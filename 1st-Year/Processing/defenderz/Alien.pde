color ALIEN1 = color(0, 255, 0);
color ALIEN2 = color(50, 100, 0);

class Alien {
  int x;
  int y;
  int dy = 1;
  int dx = -2;


  Alien(int x, int y) {
    this.x=x;
    this.y=y;
  }

  void render() {
    fill(ALIEN1);
    ellipse(x, y, 30, 30);
    fill(ALIEN2);
    ellipse(x, y, 50, 15);
  }

  void move() {
   y -= dy;
   x += dx;
  }
  
  void bounce()
  {
     if (x <= 0)
     {
         x = 750;
     }
     if (y >= height)
     {
       dy = -dy;
     }
     if (y <= 0)
     {
       dy = -dy;
     }
  }
  
  void update() {
    render();
    move();
    bounce();
  }
}
