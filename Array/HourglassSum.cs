using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Challenges.Arrays;
internal static class HourglassSum {

    public static void Call() {
        /*
        int[] l1 = { 1, 1, 1, 0, 0, 0 };
        int[] l2 = { 0, 1, 0, 0, 0, 0 };
        int[] l3 = { 1, 1, 1, 0, 0, 0 };
        int[] l4 = { 0, 0, 2, 4, 4, 0 };
        int[] l5 = { 0, 0, 0, 2, 0, 0 };
        int[] l6 = { 0, 0, 1, 2, 4, 0 };
        */
        
        int[] l1 = { -1, -1, 0, -9, -2, -2 };
        int[] l2 = { -2, -1, -6, -8, -2, -5 };
        int[] l3 = { -1, -1, -1, -2, -3, -4 };
        int[] l4 = { -1, -9, -2, -4, -4, -5 };
        int[] l5 = { -7, -3, -3, -2, -9, -9 };
        int[] l6 = { -1, -3, -1, -2, -4, -5 };
        
        List<List<int>> arr = new List<List<int>>();
        arr.Add(l1.ToList());
        arr.Add(l2.ToList());
        arr.Add(l3.ToList());
        arr.Add(l4.ToList());
        arr.Add(l5.ToList());
        arr.Add(l6.ToList());
        var total = hourglassSum(arr);
        Console.WriteLine($"Maximum: {total}");

    }

    public static int hourglassSum(List<List<int>> arr) {
        int maxSum = int.MinValue;
        for (int row = 1; row < arr.Count - 1; row++) {
            for (int col = 1; col < arr[0].Count - 1; col++) {
                var sum = SumByCentralPosition(col, row, arr);
                if(sum > maxSum) maxSum = sum;
            }
        }        
        return maxSum;
    }

    public static int SumByCentralPosition(int posX, int posY, List<List<int>> arr) {
        if (posX <= 0 || posX >= arr[0].Count) throw new Exception("X position is out off the central box");
        if (posY <= 0 || posY >= arr[0].Count) throw new Exception("Y position is out off the central box");

        var headRowSum = arr[posY - 1].GetRange(posX - 1, 3).Sum();
        var bodyValue = arr[posY][posX];
        var feetRowSum = arr[posY + 1].GetRange(posX - 1, 3).Sum();

        return headRowSum + bodyValue + feetRowSum;
    }

}