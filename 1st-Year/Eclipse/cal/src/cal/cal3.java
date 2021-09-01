package cal;
import java.util.Scanner; 

public class cal3 {
	public static void main(String[] args) { 

        Scanner in = new Scanner(System.in);
        int monthNumber; 
        int day;
        String month = "";

        System.out.print("Enter month's number: "); 
        monthNumber = in.nextInt(); 
        
        System.out.println("Enter day number: ");
        day = in.nextInt();

        switch (monthNumber) { 

        case 1: month = "January";
        if(day < 1 || day > 31) 
        {
        	  System.out.println(day + " not valid for January ");
        }
        else
        {
        	System.out.println(day +" "+ month);
        }
        
        break;
        
        case 2: month = "February";
        if (day < 1 || day > 29) 
        {
        	System.out.println(day + " not valid for February ");
        }
        else
        {
        	System.out.println(day +" "+ month);
        }
        
        break;
        

        case 3: month = "March";
        if(day < 1 || day > 31) 
        {
            	System.out.println(day + " not valid for March ");
         }
        else
        {
            	System.out.println(day +" "+ month);
        }
        
        break;
        
      
        case 4: month = "April";
        if(day < 1 || day > 30) 
        {
        	System.out.println(day + " not valid for April ");
        }
        else
    	{
        	System.out.println(day +" "+ month);
     	}
        
        break;
        
        case 5: month = "May";
        if(day < 1 || day > 31) 
        {
        	System.out.println(day + " not valid for May ");
        }
        else
    	{
        	System.out.println(day +" "+ month);
     	}
        
        break;
        
        case 6: month = "June";
        if(day < 1 || day > 30) 
        {
        	System.out.println(day + " not valid for June ");
        }
        else
        {
        	System.out.println(day +" "+ month);
     	}
        
        break;
        

        case 7: month = "July";
        if(day < 1 || day > 31) 
        {
        	System.out.println(day + " not valid for July ");
        }
        else
    	{
        	System.out.println(day +" "+ month);
    	}
        
        break;

        case 8: month = "August";
        if(day < 1 || day > 31) 
        {
        	System.out.println(day + " not valid for August ");
        }
        else
    	{
        	System.out.println(day +" "+ month);
    	}
        
        break;

        case 9: month = "September";
        if(day < 1 || day > 30)
        {
        	System.out.println(day + " not valid for September ");
        }
        else
        {
        	System.out.println(day +" "+ month);
        }
        
        break;

        case 10:month = "October";
        if(day < 1 || day > 31)
        {
        	System.out.println(day + " not valid for October ");
        }
        else
    	{
        	System.out.println(day +" "+ month);
    	}
        
        break;

        case 11: month = "November";
        if(day < 1 || day > 30) 
        {
        	System.out.println(day + " not valid for November ");
        }	
        else
        {
        	System.out.println(day +" "+ month);
        }
        
        break;

        case 12: month = "December";
        if(day < 1 || day > 31) 
        {
        	System.out.println(day + " not valid for December ");
        }
        else
        {
        	System.out.println(day +" "+ month);
        }
        
        break;

        default: 
              System.out.println("Invalid month."); 
        } 
        
  } 

}
