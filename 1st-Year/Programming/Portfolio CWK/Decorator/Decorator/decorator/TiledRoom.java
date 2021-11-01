
public class TiledRoom extends Room {

	public TiledRoom(int S, int TC, float UMC) {
		super(S, TC, UMC);
	}
	
	public float calculateCost(float hourlyRate)
	{ 
		float a = space * unitMaterialCost; //amount of space multiplied by the hourly rate as a float value
				
		double b = completedTime * hourlyRate * 1.5 + space;//multiplying completed time, hourlyrate and 1.5 then adding the space as a double value
		
		double totalCost = a + b ;//calculating the total cost
		return  (float) totalCost;  
	}
}