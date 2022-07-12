using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Challenges.Arrays;
internal static class MinimumSwaps {

    public static void Call() {
        //int[] a = { 4, 3, 1, 2 };
        //int[] a = { 1, 3, 5, 2, 4, 6, 7 };
        int[] a = { 7, 6, 1, 4, 3, 2, 5 };
        var result = minimumSwaps(a);

        Console.WriteLine(result);
    }
    
    public static int minimumSwaps(int[] arr) {
        int swapCount = 0, idx = 0, swapCache = 0;
        
        var visitControl = new bool[arr.Length];

        while (idx < arr.Length) {
            if (arr[idx] != idx+1) {
                swapCache = arr[idx];
                arr[idx] = arr[arr[idx] - 1];
                arr[swapCache - 1] = swapCache;
                swapCount++;
            } else {
                idx++;
            }
        }

        return swapCount;
    }
}
