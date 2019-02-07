// Brett Barinaga
// CPSC 450
// 1/16/2019
// Assignment 1 (Problems 1-3)

import java.io.*;
import java.math.*;
import java.awt.*;

public class hw1 {
  public static void main(String[] args) {
      // Test of Problem 1 algorithm
      System.out.println(problem1(23));

      // Test of Problem 2 algorithm
      int[] a = new int[]{2,5,5,5};
      int[] b = new int[]{2,2,3,5,5,7};
      int[] result = problem2(a,b);
      for (int i = 0; i < result.length - 1; i++) {
        System.out.print(result[i] + ", ");
      }
      System.out.println();

      // Test of Problem 3 algorithm
      String big = "Get thee gone, and take thy due place! See half-brother! This is sharper than thy tongue. Try but once to usurp my place and the love of my father, and maybe it would rid the Noldor of one who seeks to be the master of thralls.";
      String small = "Noldor";
      System.out.println("The word: " + small + " found?: " + problem3(big,small));
      small = "Vanyar";
      System.out.println("The word: " + small + " found?: " + problem3(big,small));
  }

  // Problem 1
  // Finds the floor(sqrt(n)) where n is a pos integer
  public static int problem1(int n) {
    if (n == 0 || n == 1)
      return n;
    int counter = 1;
    int result = 1;
    while (result <= n) {
      counter++;
      result = counter * counter;
    }
    return counter - 1;
  }

  // Problem 2
  // The maximum of comparisons given lengths m, n:
  // would be m or n depending on which one was smaller.
  public static int[] problem2(int[] a, int[] b) {
    int minLength;
    if (a.length <= b.length)
      minLength = a.length;
    else
      minLength = b.length;
    int[] inCommon = new int[minLength];

    int k = 0; int j = 0; int i = 0;
    while (i < minLength) {
      if (a[i] == b[j]) {
        inCommon[k] = a[i];
        j++; i++; k++;
      } else if (a[i] > b[j]) {
        j++;
      } else {
        i++;
      }
    }
    return inCommon;
  }

  // Problem 3
  // Finds the substring within a larger string
  public static boolean problem3(String big, String sub) {
    int endIndex = sub.length();
    int beginIndex = 0;

    for (int i = 0; i < big.length(); i++) {
      if (big.substring(beginIndex, endIndex).equals(sub))
        return true;
      else if (endIndex == big.length() - 1)
        return false;
      else {
        beginIndex++;
        endIndex++;
      }
    }
    return false;
  }
}





//
