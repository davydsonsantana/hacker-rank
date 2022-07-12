using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Challenges;
internal class CountingValleys {
    public static void Call() {
        string path = "DDUDDUUDUU";
        countingValleys(path.Length, path);
    }
    private static int countingValleys(int steps, string path) {
        int valleyCount = 0;
        int seaLevel = 0;
        string previousMoviment = "";

        for (int i = 0; i < path.Length; i++) {
            var currentMovment = path.Substring(i, 1);

            if (currentMovment == "U") {
                ++seaLevel;
                if (seaLevel == 0) ++valleyCount;
            } else { // D
                --seaLevel;
            }

            previousMoviment = currentMovment;
        }

        return valleyCount;
    }
}

