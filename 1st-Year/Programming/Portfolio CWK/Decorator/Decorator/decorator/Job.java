 
public class Job {
	float hourlyRate;
	 Room theRoom;
	
	//constructor
	public  Job(float hR , Room eachRoom) //hourlyRate and each room are float values
	{
		this.hourlyRate = hR; 
		this.theRoom = eachRoom;
	}
	
	public float calculateCost() //total cost is a float variable
	{
		float totalCost = theRoom.calculateCost ( hourlyRate ); //showing totalcost as float value
		return totalCost; //code to show the total cost
	}
}
