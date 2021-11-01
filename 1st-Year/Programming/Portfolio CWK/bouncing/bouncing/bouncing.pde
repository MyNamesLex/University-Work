int x=50, y=50;
bouncesquare square1;
bouncesquare square2;
bouncesquare square3;

void setup()
{
  size(400, 400);
  square1 = new bouncesquare(x, y,1,5);
  square2 = new bouncesquare(x+10, y+10, 5, 2);
  square3 = new bouncesquare(x+20, y+60, 1, 2);
}
void draw()
{
  background(0);
  square1.update();
  square2.update();
  square3.update();

  if(square1.crash(square2))
  {
      //call method for changing directions and images for both objects
  }
}
