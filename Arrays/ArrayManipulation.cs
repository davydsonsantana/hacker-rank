using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Challenges.Arrays;
internal static class ArrayManipulation {

    public static void Call() {
        int[] l2 = { 1, 2, 100 };
        int[] l3 = { 2, 5, 100 };
        int[] l4 = { 3, 4, 100 };

        List<List<int>> arr = new List<List<int>>();
        //arr.Add(new int[] { 40, 30 }.ToList());
        arr.Add(new int[] { 29, 40, 787 }.ToList());
        arr.Add(new int[] { 9, 26, 219 }.ToList());
        arr.Add(new int[] { 21, 31, 214 }.ToList());
        arr.Add(new int[] { 8, 22, 719 }.ToList());
        arr.Add(new int[] { 15, 23, 102 }.ToList());
        arr.Add(new int[] { 11, 24, 83 }.ToList());
        arr.Add(new int[] { 14, 22, 321 }.ToList());
        arr.Add(new int[] { 5, 22, 300 }.ToList());
        arr.Add(new int[] { 11, 30, 832 }.ToList());
        arr.Add(new int[] { 5, 25, 29 }.ToList());
        arr.Add(new int[] { 16, 24, 577 }.ToList());
        arr.Add(new int[] { 3, 10, 905 }.ToList());
        arr.Add(new int[] { 15, 22, 335 }.ToList());
        arr.Add(new int[] { 29, 35, 254 }.ToList());
        arr.Add(new int[] { 9, 20, 20 }.ToList());
        arr.Add(new int[] { 33, 34, 351 }.ToList());
        arr.Add(new int[] { 30, 38, 564 }.ToList());
        arr.Add(new int[] { 11, 31, 969 }.ToList());
        arr.Add(new int[] { 3, 32, 11 }.ToList());
        arr.Add(new int[] { 29, 35, 267 }.ToList());
        arr.Add(new int[] { 4, 24, 531 }.ToList());
        arr.Add(new int[] { 1, 38, 892 }.ToList());
        arr.Add(new int[] { 12, 18, 825 }.ToList());
        arr.Add(new int[] { 25, 32, 99 }.ToList());
        arr.Add(new int[] { 3, 39, 107 }.ToList());
        arr.Add(new int[] { 12, 37, 131 }.ToList());
        arr.Add(new int[] { 3, 26, 640 }.ToList());
        arr.Add(new int[] { 8, 39, 483 }.ToList());
        arr.Add(new int[] { 8, 11, 194 }.ToList());
        arr.Add(new int[] { 12, 37, 502 }.ToList());
        var maximum = arrayManipulation(0, arr);
        Console.WriteLine($"Maximum: {maximum}");
    }
    //TODO: Performance must be improved
    public static long arrayManipulation(int n, List<List<int>> queries) {
        var maxColum = queries.Max(m => m[1]);
        var maxSum = int.MinValue;
        
        Parallel.For(0, maxColum, i => {
            var position = i + 1;
            var sumValue = queries.Where(w => position >= w[0] && position <= w[1]).Sum(s => s[2]);
            if (sumValue > maxSum) maxSum = sumValue;
        });

        return maxSum;
    }
}
