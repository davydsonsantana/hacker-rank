using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Challenges;
internal class RepeatedString {
    public static void Call() {
        string s = "ojowrdcpavatfacuunxycyrmpbkvaxyrsgquwehhurnicgicmrpmgegftjszgvsgqavcrvdtsxlkxjpqtlnkjuyraknwxmnthfpt";
        repeatedString(s, 685118368975);
    }

    private static long repeatedString(string s, long n) {

        char firstChar = 'a';
        int fullBlockFirstCharCount = s.Where(x => x == firstChar).Count();
        long fullBlockUsed = (long)decimal.Truncate(n / s.Length);
        int blockRest = Convert.ToInt32(n - fullBlockUsed * s.Length);

        long totalFullblockFirstCharCount = fullBlockFirstCharCount * fullBlockUsed;
        long totalFirstCharCountAtRest = s.Substring(0, blockRest).Where(x => x == firstChar).Count();
        var total = totalFullblockFirstCharCount + totalFirstCharCountAtRest;

        return total;
    }
}

