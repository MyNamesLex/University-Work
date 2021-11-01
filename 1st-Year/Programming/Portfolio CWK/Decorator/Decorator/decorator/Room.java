
public class Room {
	int space;//space is a integer value
	int completedTime;//completedtime is a integer value
	float unitMaterialCost;//material cost is a float value
	
	
	public Room(int S, int TC, float UMC)//constructor 
	{
		this.space = S;
		this.completedTime = TC;
		this. unitMaterialCost  = UMC ;
	}
	
	public float calculateCost(float hourlyRate)
	{
		float a = space * unitMaterialCost ;//multiplying the space and materialcost
		float b = completedTime * hourlyRate;//multiplying the completed and hourlyrate
		float totalCost = a + b;//calaculating total cost as float value
		return totalCost; //showing the answer
	}
}