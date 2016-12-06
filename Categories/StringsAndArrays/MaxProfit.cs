// Interviewer check-list:
// 1. Cultural fit?
// 2. Ask 

using System;
namespace CodingInterviewPrep.SA {
  
  // Suppose we are given an array of positive numeric values representing stock prices over a period of time.
  // Determine the maximum single-sell profit.
  // Ex: [4, 5, 6, 3, 9, 12] => {9} - buy at 3 and sell at 12
  
  public class MaxProfit {
    // Method 1: brute force - for each element in array iterate over the entire array and calculate max profit and store it.
    //          At the end we will have the maximum profit.
    //          Space Complexity 0(1) - Time complexity 0(n2)
    public static double CalculateMaxProfit_BruteForce(double[] prices) {
      double maxProfit = 0;

      if (prices != null && prices.Length > 0) {
        for (int i = 0; i < prices.Length; i++) {
          for (int j = i + 1; j < prices.Length; j++) {
            double profit = prices[j] - prices[i];
            
            if (maxProfit < profit) {
              maxProfit = profit;
            }
          }
        }
      }

      return maxProfit;
    }

    // Method 2: Divide and conquer
    //           Keep splitting array into 2 subarrays, get max profit from each, compare and return maximum.
    //           Special case: the best buy and sell values could be in separate arrays.
    //           We have to determine that at each step by simply iterating over array and getting max profit
    public static double CalculateMaxProfit_DivideConquer(double[] prices) {
      if (prices == null || prices.Length < 2) {
        return 0;
      }
      return CalculateMaxProfit_DivideConquerHelper(prices, 0, prices.Length - 1);
    }

    private static double CalculateMaxProfit_DivideConquerHelper(double[] prices, int start, int end) {
      if (end - start == 1) {
        return prices[end] - prices[start];
      } else if (start >= end) {
        return 0;
      }

      double maxProfit = 0;
      int mid = (start + end) / 2;

      // get max profit from left sub array
      double leftProfit =  CalculateMaxProfit_DivideConquerHelper(prices, start, mid);
      
      // get max profit from right sub array
      double rightProfit = CalculateMaxProfit_DivideConquerHelper(prices, mid + 1, end);
   
      // calculate best possible from across 2 subarrays
      double minLeft = FindMinOrMax(prices, start, mid, false);
      double maxRight = FindMinOrMax(prices, mid + 1, end, true);
      double crossArrayProfit = maxRight - minLeft;

      // pick best profit from subarrays and across them
      maxProfit = (leftProfit > rightProfit) ? leftProfit : rightProfit;
      maxProfit = (maxProfit > crossArrayProfit) ? maxProfit : crossArrayProfit;
      return maxProfit;
    }

    private static double FindMinOrMax(double[] prices, int start, int end, bool findMax) {
      double result = prices[start];
      for (int i = start + 1; i <= end; i++) {
        if (findMax) {
          result = Math.Max(result, prices[i]);
        } else {
          result = Math.Min(result, prices[i]);
        }
      }
      return result;
    }

    // Method 3: Dynamic programming
    //           If we have just one element, we already know that it has to be the best buy/sell pair. 
    //           Now suppose we know the best answer for the first k elements and look at the (k+1)st element. 
    //           If we store max profit seen so far as well as lowest buy price, we know that the only way
    //           the k+1th element can create a better outcome if the difference between its value and lowest seen so far
    //           is greater than the max profit.
    //           The key is to keep updating the lowest prices at each step.
    public static double CalculateMaxProfit_DP(double[] prices) {
      double maxProfit = 0;
      double lowestPrice = 0;

      if (prices != null && prices.Length > 0) {
        lowestPrice = prices[0];
        for (int i = 1; i < prices.Length; i++) {
          double profit = prices[i] - lowestPrice;
          if (maxProfit < profit) {
            maxProfit = profit;
          }
          lowestPrice = Math.Min(lowestPrice, prices[i]);
        } 
      }

      return maxProfit;
    }

    public static void MaxProfit_Test() {
      double[] prices = new double[] { 10000, 20, 90, 2100, 9, 10, 100};
      Console.WriteLine("CalculateMaxProfit_BF: Answer: " + CalculateMaxProfit_BruteForce(prices));
      Console.WriteLine("CalculateMaxProfit_DC: Answer: " + CalculateMaxProfit_DivideConquer(prices));
      Console.WriteLine("CalculateMaxProfit_DP: Answer: " + CalculateMaxProfit_DP(prices));

    }
  }
}