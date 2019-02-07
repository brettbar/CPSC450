// Brett Barinaga 
// CPSC 450
// HW2
// Problems 9 and 10
// Partner: Andrew Flagstead

// This file includes the code used for problem 9 and 10
// printing the size, comparisons, and time in ms

public class HW2
{
    public static void main(String args[])
    {
        int count = 0;

        // Answers 2.a
        for (int i = 1000; i <= 20000; i+=1000) {
        	int[] arr = ranArray(i);
        	System.out.print("Array size " + i + ": ");
        	count = theFunction(arr);
        }
        int[] arr = ranArray(25000);
    	System.out.print("Array size " + 25000 + ": ");
    	count = theFunction(arr);
    }

    public static int theFunction(int[] num)
    {	long startTime = System.nanoTime();
        int counter = 0;
        for (int i = 0; i<num.length; i++)
        {
            int v = num[i];
            int j = i - 1;

            while (j>= 0 && num[j] > v)
            {
                counter++;
                num[j+1] = num[j];
                j = j -1;
            }
            num[j + 1] = v;
            
        }
        long stopTime = System.nanoTime();
        long timeDiff = stopTime - startTime;
        System.out.print(counter + " comparisons" + " in " + timeDiff/1000000.0 + " ms");
        System.out.println();
        return counter;
    }

    public static int[] ranArray(int arrSize)
    {
        
        int[] thing = new int[arrSize];
        for(int i = 0; i <  thing.length; i++) 
        {
            thing[i] = (int)(Math.random() * 100);
        }
        return thing;
    }

}