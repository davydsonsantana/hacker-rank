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
    //TODO: Implement binary search to improve performance
    public static int minimumSwaps(int[] arr) {
        var swapCount = 0;
        for (int i = 0; i < arr.Length; i++) {
            bool performSwap = false;
            int minIndex = i;          

            for(int si = i; si < arr.Length; si++) {
                //Left to right
                if (arr[si] < arr[minIndex]) { minIndex = si; performSwap = true; }

                //Half achieved
                var rightIndex = arr.Length - 1 - si + i;
                if (rightIndex <= si) break;

                //Right to left
                if (arr[rightIndex] < arr[minIndex]) { minIndex = rightIndex; performSwap = true; }
            }

            if (performSwap) {
                Swap(ref arr, i, minIndex);                
                swapCount++;
            }
        }
        return swapCount;
    }

    private static void Swap(ref int[] arr, int idxFrom, int idxTo) {
        int bkp = arr[idxFrom];
        arr[idxFrom] = arr[idxTo];
        arr[idxTo] = bkp;
    }

}
