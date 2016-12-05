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

      if (prices != null && prices.Length > 1) {
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
    //           This has a special case though, the best buy and sell values could be in separate arrays.
    //           We have to determine that at each step by simply iterating over array and getting max profit

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
      double[] prices = new double[] { 4, 3, 6, 7 };
      double result = CalculateMaxProfit_DP(prices);
      Console.WriteLine("Answer: " + result);
    }



  }
}