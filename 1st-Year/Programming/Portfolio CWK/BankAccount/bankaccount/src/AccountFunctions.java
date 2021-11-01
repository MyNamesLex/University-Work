
public class AccountFunctions {

	
		int Balance (int deposit,int term)
		{
			double newBalance;
			if(term>0 && term<=10 && deposit>0 && deposit<=50000)
			{
				if(deposit>0 && deposit<=1000)
				{
					newBalance= deposit* Math.pow(1.0+0.005,term);
					return (int)(newBalance+0.5);
				}
				else if(deposit>=1001 && deposit<=10000)
				{
					newBalance= deposit* Math.pow(1.0+0.015,term);
					return (int)(newBalance+0.5);
				}
				else
				{
					newBalance= deposit* Math.pow(1.0+0.025,term);
					return (int)(newBalance+0.5);
				}
			   }
			else
			{
				return -1;
			}
		


	}
	
	}

