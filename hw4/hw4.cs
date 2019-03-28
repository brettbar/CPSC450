/* A Naive recursive implementation of
0-1 Knapsack problem */
using System;


public class hw4 {

    // A utility function that returns
    // maximum of two integers
    public static int max(int a, int b) {
      if (a >= b)
        return a;
      else
        return b;
    }

    // Returns the maximum value that can
    // be put in a knapsack of capacity W
    public static int d(int W, int []wt, int []val, int n) {
      // Base Case
      if (n == 0 || W == 0)
          return 0;

      // If weight of the nth item is
      // more than Knapsack capacity W,
      // then this item cannot be
      // included in the optimal solution
      if (wt[n-1] > W)
          return d(W, wt, val, n-1);

      // Return the maximum of two cases:
      // (1) nth item included
      // (2) not included
      else return max(val[n-1] + d(W-wt[n-1], wt, val, n-1), d(W, wt, val, n-1));
    }

    public static int f(int W, int []wt, int []val, int n) {
      
    }

    // Driver function
    public static void Main() {
        int [] val = new int[]{60, 100, 120};
        int [] wt = new int[]{10, 20, 30};
        int W = 50;
        int n = val.Length;

        Console.WriteLine(d(W, wt, val, n));
    }
}
