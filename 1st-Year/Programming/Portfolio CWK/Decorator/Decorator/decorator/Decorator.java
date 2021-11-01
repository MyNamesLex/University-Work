import java.util.Scanner;
public class Decorator {

	public static void main(String[] args) {
		Scanner in = new Scanner ( System.in );
		
		System.out.print("Enter Hourly Rate: "); //prompt message the user to enter hourly rate 
		float hourlyRate = in.nextFloat (); //will only accept a float value as the answer
		
		System.out.print("Enter Rooms Area: ");//prompt message to tell the user to enter room area
		int space = in.nextInt ();//will only accept integer value as answer
				
		System.out.print("Enter Unit Cost Materials: ");//prompt message to tell the user to enter cost materials
		float unitCost =in.nextFloat ();//will only accept float values as answer
				
		System.out.print("Enter Decorating Time: ");//prompt message to tell the user to enter decorating time
		int requiredTime = in.nextInt ();//will only accept integer values as answer
		
		TiledRoom eachRoom = new TiledRoom (space,requiredTime, unitCost);//create a room
	
		Job eachJob = new Job (hourlyRate, eachRoom );	//create a Job
		
		float tC = eachJob.calculateCost();//calculate total cost;
		
		System.out.println("Total cost is £" + tC);//will show the total cost to the user
		in.close();	
	}
}