import java.awt.*;
import java.awt.image.*;
import javax.imageio.*;
import java.io.*;
public class Image2Ascii
{
	BufferedImage bImage = null;
	int imageWidth = 0;
	int imageHeight = 0;
	int[][] greyValues;
	String ramp = "@%#*+=-:.# ";
	
void LoadImage( String fileName )
{
	try
{
	bImage = ImageIO.read( new File(fileName) );
	imageWidth = bImage.getWidth();
	imageHeight = bImage.getHeight();
	greyValues = new int[imageHeight][imageWidth];
	
	for (int row = 0; row < imageHeight; row++) {
		for(int col = 0; col < imageWidth; col++) {
			Color pixel = new Color( bImage.getRGB( col, row ) );
			int red = pixel.getRed();
			int green = pixel.getGreen();
			int blue = pixel.getBlue();
			int grey = ( red + 2*green + blue ) / 4;
			greyValues[row][col] = grey;
		}
	}
}

catch (Exception e )
{
	System.out.println("could not open image file "+fileName);
	}
}
void print() 
{
	for (int row= 0; row < imageHeight; row+=2) {
		for (int col = 0; col < imageWidth; col++) {
			int grey = greyValues[row][col];
			int rampindex = 10*grey/256; // 0 - 9
			char charToPrint = ramp.charAt(rampindex);
			System.out.print(charToPrint);
		}
		System.out.println(); // move to next line
	}
}
}
