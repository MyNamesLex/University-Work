class Defender {
  int x=0;
  int y;

  Defender(int y) {
    this.y=y;
  }

  void render() {
    fill(255, 0, 0);
    rect(x, y, 50, 20);
    triangle(x+50, y, x+50, y+20, x+60, y+10);
    fill(0, 0, 100);
    rect(x, y-10, 20, 10);
  }
  boolean crash() {
    color pixel;

    for (int i = y; i < y+20; i++) {
      pixel = get(x+65, i);
      if (pixel == ALIEN1)
              return true;
    }
    return false;
  }
}
