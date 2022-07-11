using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            minimumBribesCall();
        }

        public static void minimumBribesCall() {
            //var a = new int[] { 3, 2, 1, 4, 5 };
            //var a = new int[] { 1, 2, 3, 5, 4 };
            var a = new int[] { 1, 2, 5, 3, 7, 8, 6, 4 };
            
            minimumBribes(a.ToList());
        }
        public static void minimumBribes(List<int> q) {
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
                countBribes(corrupted,ref bribesCounter);
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
     
        public static void rotLeftCall() {
            int[] a = { 1, 2, 3, 4, 5 };
            rotLeft(a.ToList(), 1);
        }

        public static List<int> rotLeft(List<int> a, int d) {

            var inputArr = a.ToArray();
            var arrCount = inputArr.Count();
            var realShift = d < arrCount ? d : d % arrCount;
            int[] arrFirstShifted = new int[arrCount];
            Array.Copy(inputArr, realShift, arrFirstShifted, 0, arrCount - realShift);
            Array.Copy(inputArr, 0, arrFirstShifted, arrCount - d, realShift);

            return arrFirstShifted.ToList();
        }

        public static void hourglassSumCall() {
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
            hourglassSum(arr);
        }

        public static int hourglassSum(List<List<int>> arr) {
            int cols = arr[0].Count - 2;
            int rows = arr.Count - 2;

            int maxSum = int.MinValue;

            // Each row
            for (int row = 1; row <= rows; row++) {

                // Each column
                for (int col = 1; col <= cols; col++) {

                    int currentSum = 0;

                    currentSum += arr[row - 1][col - 1] + arr[row - 1][col] + arr[row - 1][col + 1];
                    currentSum += arr[row][col];
                    currentSum += arr[row + 1][col - 1] + arr[row + 1][col] + arr[row + 1][col + 1];

                    if (currentSum > maxSum) maxSum = currentSum;
                }

            }

            return maxSum;
        }

        public static void repeatedStringCall() {
            string s = "ojowrdcpavatfacuunxycyrmpbkvaxyrsgquwehhurnicgicmrpmgegftjszgvsgqavcrvdtsxlkxjpqtlnkjuyraknwxmnthfpt";
            repeatedString(s, 685118368975);
        }

        public static long repeatedString(string s, long n) {

            char firstChar = 'a';
            int fullBlockFirstCharCount = s.Where(x => x == firstChar).Count();
            long fullBlockUsed = (long)decimal.Truncate(n / s.Length);
            int blockRest = Convert.ToInt32(n - fullBlockUsed * s.Length);

            long totalFullblockFirstCharCount = fullBlockFirstCharCount * fullBlockUsed;
            long totalFirstCharCountAtRest = s.Substring(0, blockRest).Where(x => x == firstChar).Count();
            var total = totalFullblockFirstCharCount + totalFirstCharCountAtRest;

            return total;
        }

        public static void jumpingOnCloudsCall() {
            int[] c = { 0, 0, 0, 0, 1, 0 };
            jumpingOnClouds(c.ToList());
        }

        public static int jumpingOnClouds(List<int> c) {
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

        public static void countingValleysCall() {
            string path = "DDUDDUUDUU";
            countingValleys(path.Length, path);
        }
        public static int countingValleys(int steps, string path) {
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

        public static void sockMerchantCall() {
            int[] ar = { 1, 2, 1, 2, 1, 3, 2 };
            sockMerchant(ar.Length, ar.ToList());
        }
        public static int sockMerchant(int n, List<int> ar) {
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
}
