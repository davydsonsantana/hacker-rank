using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Challenges;
internal static class MinimumBribes {

    public static void Call() {
        //var a = new int[] { 3, 2, 1, 4, 5 };
        //var a = new int[] { 1, 2, 3, 5, 4 };
        var a = new int[] { 1, 2, 5, 3, 7, 8, 6, 4 };

        minimumBribes(a.ToList());
    }
    private static void minimumBribes(List<int> q) {
        var qArr = q.ToArray();
        int totalPosition = q.Count;
        var bribesCounter = new List<List<int>>();

        for (int pos = 1; pos <= totalPosition; pos++) {

            int[] finalResult = new int[qArr.Count()];
            var index = Array.IndexOf(qArr, pos);

            // person is on original position
            if (qArr[index] == index + 1) continue;

            int corrupted;

            // Swap at beginning   idx= 2  Seq= 21345
            if (index == 1) {
                corrupted = qArr[1];
                finalResult[0] = corrupted;
                finalResult[1] = qArr[0];
                Array.Copy(qArr, 2, finalResult, 2, qArr.Count() - 2);
            } else {
                // Swap out of beginning   idx=3    Seq= 32145
                Array.Copy(qArr, 0, finalResult, 0, index - 1);
                corrupted = qArr[index];
                finalResult[index - 1] = corrupted;
                finalResult[index] = qArr[index - 1];
                Array.Copy(qArr, index + 1, finalResult, index + 1, qArr.Count() - index - 1);
            }

            qArr = finalResult;
            countBribes(corrupted, ref bribesCounter);
        }

        if (bribesCounter.Where(b => b[1] > 2).Count() > 0) { Console.WriteLine("Too chaotic"); return; }

        Console.WriteLine(bribesCounter.Sum(x => x[1]));
    }

    private static void countBribes(int corrupt, ref List<List<int>> bribesCounter) {
        var finded = bribesCounter.FirstOrDefault(b => b[0] == corrupt);
        if (finded == null) {
            bribesCounter.Add((new int[] { corrupt, 1 }).ToList());
        } else {
            ++finded[1];
        }
    }

}



