class bouncesquare
{
  int x;
  int y;
  int speed;
  int speedY;
  PImage img1, img2, img3, img4;
  int currentImage = 1;

  bouncesquare(int x, int y, int speedX, int speedY) 
  {
    this.x = x;
    this.y = y;
    speed = speedX;
    this.speedY = speedY;
    
    img1 = loadImage("square1img.png");
    img2 = loadImage("square2img.png");
    img3 = loadImage("square3img.png");
    img4 = loadImage("square4img.png");
  }

  void update() 
  {
    render();
    move();
    bounceOffWalls();
  }
  
  void render()
      {
          if(currentImage == 1) // if indicator says to use image 1, assign img1 so it can be used
          {
              image(img1,x,y);
          }
          else if (currentImage == 2)
          {
              image(img2,x,y);
          }
          else if (currentImage == 3)
          {
              image(img3,x,y);
          }
          else
          {
              image(img4,x,y);
          }        
      }    

  void bounceOffWalls()
      {
        //collision detection
        //collide right hand edge
         if(x >= width-50) 
         {
          speed =- speed; //reverse direcion
          currentImage = 4;   //assign indicator for which image is needed     
         }
         
         //collide left hand edge   
         if(x <= 0)
         {
           speed =- speed;
           currentImage = 2;         
         }
           
         //collide top edge
         if(y <= 0)
         {
           speedY =- speedY;
           currentImage = 3;         
         }
           
        //collide bottom edge
         if( y >= height-50)
         {
            speedY =- speedY;
            currentImage = 1;
         }
      } 
  
  boolean crash(bouncesquare other)
   {
     return (abs(this.x-other.x) < 10  &&  abs(this.y-other.y) < 10);
   }


  void move()
  {
         x = x + speed; 
         y = y + speedY;
  }
}
