/*
Brett Barinaga
CPSC 450
HW4
3/28/2019
This program finds the optimal answer to the knapsack problem using Dynamic Programming
It takes in the following inputs from standard input
input values:
    1. Which algorithm to run
    2. Maximum amount of weight that can be held
    3. Number of items to consider
    4. item 0 weight
    5. item 0 cost
    6. item 1 weight
    7. item 1 cost
    8. etc...
    9. item n weight
    10. item n cost
knapsack problem: Given n items of known weights w1,w2...wn and
values v1,v2,...vn, and a knapsack of capactiy W. Find the most
valuable subset of items that fit into the knapsack.
*/

// Full disclosure I received help from these sources (C#)
// https://stackoverflow.com/questions/969290/exact-time-measurement-for-performance-testing - For time stuff
// https://www.tutorialspoint.com/Way-to-read-input-from-console-in-Chash - For input stuff

/*
  Analysis:
    When running my tests on the different algorithms, I found for small test instances
    the difference to be negligble.


*/


using System;
using System.Diagnostics;


public class hw4 {
  public static void Main() {
      char algChoice;
      algChoice = Convert.ToChar(Console.ReadLine());
      int capacity;
      capacity = Convert.ToInt32(Console.ReadLine());
      int numItems;
      numItems = Convert.ToInt32(Console.ReadLine());

      int[] weights = new int[numItems];
      int[] costs = new int [numItems];

      for (int i = 0; i < numItems; i++) {
        weights[i] = Convert.ToInt32(Console.ReadLine());
        costs[i] = Convert.ToInt32(Console.ReadLine());
      }

      if (algChoice == 'd') {
        Stopwatch sw1 = new Stopwatch();
        sw1.Start();
        Console.WriteLine(d(numItems, capacity, weights, costs));
        sw1.Stop();
        Console.WriteLine("algorithm d elapsed time={0}",sw1.Elapsed);
      } else if (algChoice == 'f') {
        // For algorithm f
        // This matrix is non-memoization approach to dynamic programming.
        int [,]memo_matrix = new int[numItems+1, capacity+1];
        for (int i = 0; i <= numItems; i++) {
            for (int j = 0; j <= capacity; j++) {
                if (i == 0 || j == 0)
                    memo_matrix[i,j] = 0;
                else
                  memo_matrix[i,j] = -1;
            }
        }
        Stopwatch sw2 = new Stopwatch();
        sw2.Start();
        Console.WriteLine(f(numItems, capacity, weights, costs, memo_matrix));
        sw2.Stop();
        Console.WriteLine("algorithm f elapsed time={0}",sw2.Elapsed);
      } else {
        System.Environment.Exit(1);
      }
  }

  public static int d(int numItems, int capacity, int[] weights, int[] costs) {
    // For algorithm d
    // This matrix is non-memoization approach to dynamic programming.
    int [,]matrix = new int[numItems+1,capacity+1];
    // Construct the 2d table with number of items as the left axis
    // and capacities as the top axis (as discussed on the quiz)

    for (int i = 0; i <= numItems; i++) {
        for (int j = 0; j <= capacity; j++) {
            if (i == 0 || j == 0)
                matrix[i,j] = 0;
            else if (weights[i-1] <= j)
                matrix[i,j] = max(costs[i-1] + matrix[i-1,j-weights[i-1]], matrix[i-1,j]);
            else
                matrix[i,j] = matrix[i-1,j];
        }
    }
    return matrix[numItems, capacity];
  }

  public static int f(int numItems, int capacity, int[] weights, int[] costs, int[,] memo_matrix) {
    return memory_func(capacity, weights, costs, numItems, memo_matrix);
  }

  // This is heavily influenced by the pseudocode on page 295 of the book
  public static int memory_func(int capacity, int[] weights, int[] costs, int numItems, int[,] matrix) {
    if (matrix[numItems, capacity] < 0) {
      int value;
      if (capacity < weights[numItems - 1])
        value = memory_func(capacity, weights, costs, numItems - 1, matrix);
      else
        value = max(memory_func(capacity, weights, costs, numItems - 1, matrix), costs[numItems - 1] + memory_func(capacity - weights[numItems -1 ], weights, costs, numItems -1, matrix));
      matrix[numItems, capacity] = value;
    }
    return matrix[numItems, capacity];
  }



  public static int max(int a, int b) {
    if (a >= b) return a;
    else return b;
  }

  public static int sanity_check(int capacity, int []weights, int []costs, int numItems) {
    // Initials condition (8.7) in the book
    if (numItems == 0) return 0;
    if (capacity == 0) return 0;

    // We can't have a weight that is greater than the maximum capacity
    if (weights[numItems-1] > capacity) return sanity_check(capacity, weights, costs, numItems-1);

    // We either include item n, or we don't, and we will find the larger of these two
    else {
      int max_val = max(sanity_check(capacity, weights, costs, numItems-1), costs[numItems-1] + sanity_check(capacity-weights[numItems-1], weights, costs, numItems-1));
      return max_val;
    }
  }
}



















//
