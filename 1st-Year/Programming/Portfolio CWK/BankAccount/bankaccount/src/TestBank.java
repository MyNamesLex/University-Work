
public class TestBank {

	static AccountFunctions function;
	
	
	static void BankTest()
	{
		int [] deposit = {1, 1000, 1001,10000,10001,50000,0,50001,1000,1000};
		
		int [] term = {1,10,1,10,5,10,1,10,0,11};
		
		int [] output = {1,1051,1016,11605,11315,64004,-1,-1,-1,-1};

		int numTestCases = deposit.length;
		System.out.println("***********\nTesting CompoundInterest ");
		int passed = 0;
		for ( int i = 0; i < numTestCases; i++ )
		{
			int result = function.Balance(deposit[i], term[i]);
			if ( result != output[i] )
			{
				System.out.println("Test "+i+" failed. Expected "+output[i]+" got "+result);
			}
			else if(result ==-1)
			{
				System.out.println("Test "+i+" Passed. ERROR! WRONG INPUT!" );
			}
			else
			{
				passed++;
				System.out.println("Test "+i+" passed!");
			}
		}
		System.out.println("Finished testing CompoundInterest - passed "+passed+" out of "+numTestCases);
	}
	public static void main( String args[] )
	{
		function = new AccountFunctions();
		BankTest();
		
	
	

	}
	
}
