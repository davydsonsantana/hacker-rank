using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Challenges;
internal class JumpingOnClouds {
    public static void Call() {
        int[] c = { 0, 0, 0, 0, 1, 0 };
        jumpingOnClouds(c.ToList());
    }

    private static int jumpingOnClouds(List<int> c) {
        int jumps = 0;

        for (int i = 0; i < c.Count - 1; i++) {

            if (i + 2 < c.Count()) {// Check if two jumps overflow
                if (c[i + 2] == 0) {
                    ++jumps; i++;
                } else
                    ++jumps;
            } else {// 2 jumps will overflow
                //Check if last cloud is 0
                if (c[i + 1] == 0) ++jumps;
            }
        }

        return jumps;
    }

}

