using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Challenges;
internal class SockMerchant {
    public static void Call() {
        int[] ar = { 1, 2, 1, 2, 1, 3, 2 };
        sockMerchant(ar.Length, ar.ToList());
    }
    private static int sockMerchant(int n, List<int> ar) {
        var organizedSocksQueue = new List<int>();
        var totalPairs = 0;

        for (int idx = 0; idx < n; idx++) {
            // Seek at queue
            if (organizedSocksQueue.Count(x => x == ar[idx]) > 0) {
                // if find remove from queue
                organizedSocksQueue.Remove(ar[idx]);
                ++totalPairs;
            } else {
                // otherwise remove from queue
                organizedSocksQueue.Add(ar[idx]);
            }
        }
        return totalPairs;
    }
}

