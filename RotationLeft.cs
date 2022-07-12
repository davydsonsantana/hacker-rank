using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Challenges;
internal static class RotationLeft {

    public static void Call() {
        int[] a = { 1, 2, 3, 4, 5 };
        var result = rotLeft(a.ToList(), 1);
        Console.WriteLine(String.Join(", ", result));
    }

    private static List<int> rotLeft(List<int> a, int d) {

        var inputArr = a.ToArray();
        var arrCount = inputArr.Count();
        var realShift = d < arrCount ? d : d % arrCount;
        int[] arrFirstShifted = new int[arrCount];
        Array.Copy(inputArr, realShift, arrFirstShifted, 0, arrCount - realShift);
        Array.Copy(inputArr, 0, arrFirstShifted, arrCount - d, realShift);

        return arrFirstShifted.ToList();
    }

}
