package Image2Ascii2;


public class Main {

	public static void main(String[] args) {
		Image2Ascii img2ascii = new Image2Ascii();
		Image2Ascii2 img2ascii2 = new Image2Ascii2();
		img2ascii.LoadImage("mona.png");
		img2ascii.print();
		img2ascii2.LoadImage("mona.png");
		img2ascii2.print();
		img2ascii2.LoadImage("mona.png");
		img2ascii2.print();
		img2ascii.LoadImage("mona.png");
		img2ascii.print();
	}

}