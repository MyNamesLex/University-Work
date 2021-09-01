class Playe {
  int x = 200;
  int y = 100;
  int speed = 5;
  int i = 0;

  PImage pla1;
  PImage pla2;
  PImage deadpla;
  PImage pright;
  PImage pleft;
  PImage pup;
  PImage pdown;
  PImage phit;

  int counter = 0;
  int countDir = 1;

  Playe(int y) {
    this.y=y;
    pla1 = loadImage("p1.png");
    pla2 = loadImage("p2.png");
    deadpla = loadImage("dead.png");
    pleft = loadImage("pleft.png");
    pright = loadImage("pright.png");
    pup = loadImage("pup.png");
    pdown = loadImage("pdown.png");
    phit = loadImage("phit.png");
  }

  void render() 
  {
    if (x < width-10)
    {
      if (counter >= 0 && counter <= 10)
      {
        image(pla1, x, y);
        pla1.resize(40, 50);
      } else if (counter > 10 && counter <= 20)
      {
        image(pla2, x, y);
        pla2.resize(40, 50);
      } else
      {
        countDir = -countDir;

        if (counter < 0)
          image(pla1, x, y);

        if (counter > 20)
          image(pla2, x, y);
      }
      counter = counter + countDir;
    } else
    {
      x=0;
    }

    if (keyCode == LEFT)
    {
      image(pleft, x, y);
      pleft.resize(40, 50);
    }
    if (keyCode == RIGHT)
    {
      image(pright, x, y);
      pright.resize(40, 50);
    }
    if (keyCode == UP)
    {
      image(pup, x, y);
      pup.resize(40, 50);
    }
    if (keyCode == DOWN)
    {
      image(pdown, x, y);
      pdown.resize(40, 50);
    }
  }

  void draw()
  {
    if (Player1.crash(BEnemynew1) && BEnemynew1.hitPlayer == false)
    {
      healthcounter=healthcounter-1;
      BEnemynew1.hitPlayer = true;
    }

    if (Player1.crash(BEnemynew2)&& BEnemynew2.hitPlayer == false)
    {
      healthcounter=healthcounter-1;
      BEnemynew2.hitPlayer = true;
    }

    if (Player1.crash(BEnemynew3)&& BEnemynew3.hitPlayer == false)
    {
      healthcounter=healthcounter-1;
      BEnemynew3.hitPlayer = true;
    }



    if (Player1.crash(GEnemynew1)&& GEnemynew1.hitPlayer == false)
    {
      healthcounter=healthcounter-1;
      GEnemynew1.hitPlayer = true;
    }

    if (Player1.crash(GEnemynew2)&& GEnemynew2.hitPlayer == false)
    {
      healthcounter=healthcounter-1;
      GEnemynew2.hitPlayer = true;
    }

    if (Player1.crash(GEnemynew3)&& GEnemynew3.hitPlayer == false)
    {
      healthcounter=healthcounter-1;
      GEnemynew3.hitPlayer = true;
    }



    if (Player1.crash(healthnew1)&& healthnew1.hitPlayer == false)
    {
      healthcounter=healthcounter+1;
      healthnew1.hitPlayer = true;
    }

    if (Player1.crash(healthnew2)&& healthnew2.hitPlayer == false)
    {
      healthcounter=healthcounter+1;
      healthnew2.hitPlayer = true;
    }


    if (Player1.crash(Poi1)&& Poi1.hitPlayer == false)
    {
      points=points+50;
      Poi1.hitPlayer = true;
    }

    if (Player1.crash(Poi2)&& Poi2.hitPlayer == false)
    {
      points=points+50;
      Poi2.hitPlayer = true;
    }

    if (Collectible1!= null) {
      if (Player1.crash(Collectible1)) {

        Collectiblecounter += 1; // reduce lives by one

        Collectible1 = null; // set to null (removes from game)
      }
    }


    if (healthcounter <= 0)
    {
      Player1.render();
      textFont(text, 32);                  
      fill(255, 255, 30);                        
      text("Game Over", 0, 300);
      text("Press the 'R' key to Restart", 0, 400);
      gameMode = gamefinish;
    }
  }
  boolean crash(BEnemy other) 
  {
    if (abs(this.x-other.x) <= 40 && abs(this.y-other.y) <=40)
      return true;

    return false;
  }
  boolean crash(GEnemy other) 
  {
    if (abs(this.x-other.x) <= 40 && abs(this.y-other.y) <=40)
      return true;

    return false;
  }
  boolean crash(Enemy other) 
  {
    if (abs(this.x-other.x) <= 40 && abs(this.y-other.y) <=40)
      return true;

    return false;
  }

  boolean crash(Health other) 
  {
    if (abs(this.x-other.x) <= 140 && abs(this.y-other.y) <=90)
      return true;
    return false;
  }

  boolean crash(Points other) 
  {
    if (abs(this.x-other.x) <= 140 && abs(this.y-other.y) <=90)
      return true;
    return false;
  }

  boolean crash(Collectible other) 
  {
    if (abs(this.x-other.x) <= 25 && abs(this.y-other.y) <=25)
      return true;
    return false;
  }

  void update()
  {
    draw();
    render();
  }
}
