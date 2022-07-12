using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Challenges.Arrays;
internal static class RotationLeft {

    public static void Call() {
        int[] a = { 1, 2, 3, 4, 5 };
        var result = rotLeft(a.ToList(), 1);
        Console.WriteLine(string.Join(", ", result));
    }

    private static List<int> rotLeft(List<int> a, int d) {
        var trueShift = d < a.Count() ? d : d % a.Count();
        return a.Skip(trueShift).Concat(a.Take(trueShift)).ToList();
    }

}
