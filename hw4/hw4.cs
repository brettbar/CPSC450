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

using System;
using System.Diagnostics;


public class hw4 {
  public static void Main() {
      // int [] val = new int[]{60, 100, 120};
      // int [] wt = new int[]{10, 20, 30};
      // int W = 50;
      // int n = val.Length;

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

      Console.WriteLine(d(capacity, weights, costs, numItems));
      Console.WriteLine(buildMatrix(capacity, weights, costs, numItems));
  }
  
  public static int max(int a, int b) {
    if (a >= b)
      return a;
    else return b;
  }

  public static int d(int capacity, int []weights, int []costs, int numItems) {
    // Initials condition (8.7)
    if (numItems == 0) return 0;
    if (capacity == 0) return 0;

    // We can't have a weight that is greater than the maximum capacity
    if (weights[numItems-1] > capacity) return d(capacity, weights, costs, numItems-1);

    // Return the maximum of two cases:
    // (1) nth item included
    // (2) not included
    else {
      return max(costs[numItems-1] + d(capacity-weights[numItems-1], weights, costs, numItems-1), d(capacity, weights, costs, numItems-1));
    }
  }

  public static int buildMatrix(int capacity, int []weights, int []costs, int numItems) {
        int [,]matrix = new int[numItems+1,capacity+1];

        // Build table K[][] in bottom
        // up manner
        for (int i = 0; i <= numItems; i++) {
            for (int w = 0; w <= capacity; w++) {
                if (i == 0 || w == 0)
                    matrix[i,w] = 0;
                else if (weights[i-1] <= w)
                    matrix[i,w] = Math.Max(costs[i-1] + matrix[i-1,w-weights[i-1]], matrix[i-1,w]);
                else
                    matrix[i,w] = matrix[i-1,w];
            }
        }
        return matrix[numItems,capacity];
  }


  public static int f(int capacity, int []weights, int []costs, int numItems) {
     return buildMatrix(capacity, weights, costs, numItems);

    // for (int i = 0; i < numItems; i++) {
    //   for (int j = 0; j < capacity; j++) {
    //     if (i == 0 || j == 0)
    //       matrix[i,j] = 0;
    //     else if (weights[i-1] <= j)
    //       matrix[i,j] = max(costs[i-1] + matrix[i-1, capacity - weights[i-1]], matrix[i-1, capacity]);
    //     else
    //       matrix[i,j] = matrix[i-1, capacity];
    //   }
    // }
    // return matrix[numItems, capacity];
    //return f_rec(capacity, weights, costs, numItems, matrix);
  }

  public static int f_rec(int capacity, int []weights, int []costs, int numItems, int[,] matrix) {

    if (matrix[numItems, capacity] < 0) {
      int value;
      if (capacity < weights[numItems])
        value = f_rec(capacity, weights, costs, numItems - 1, matrix);
      else
        value = max(f_rec(capacity, weights, costs, numItems - 1, matrix), costs[numItems] + f_rec(capacity - weights[numItems], weights, costs, numItems -1, matrix));
      Console.WriteLine(value);
      matrix[numItems, capacity] = value;
    }
    return matrix[numItems, capacity];
  }


}





















//
