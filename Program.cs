// ReSharper disable All

using System;

namespace ProjectEuler
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Numerics;

    public class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(problem52());
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.ReadKey();
        }
        
        public static long problem52()
        {
            for(long i = 40; i < 2000000; i++)
            {
                int[] arri = new int[10]; 

                for (int z = 0; z < i.ToString().Length; z++)
                {
                    arri[int.Parse(i.ToString()[z].ToString())]++;
                }

                bool point = true;
                for (long j = 2; j <= 6; j++)
                {
                    long num = i * j;
                    int[] arrj = new int[10];
                    
                    for (int c = 0; c < num.ToString().Length; c++) 
                    {
                        arrj[int.Parse(num.ToString()[c].ToString())]++;
                    }

                    for (int t = 0; t < 10; t++)
                    {
                        if (arri[t] != arrj[t])
                        {
                            point = false;
                            break;
                        }
                    }
                    if (point == false)
                        break;
                }

                if (point == true)
                    return i;
            }

            return 0;
        }


        public static long problem10()
        {
            long result = 0;
            for (int i = 0; i < 2000000; i++)
            {
                if (problem10A(i))
                {
                    result += i;
                }
            }
            return result;
        }

        public static long problem10b()
        {
            int num = 2000000;
            List<bool> a = new List<bool>();
            for (int i = 0; i < num; i++)
                a.Add(true);

            for (int i = 2; i < Math.Sqrt(num); i++)
            {
                if (a[i] == true)
                {
                    int square = i * i;
                    for (int j = square; j < num; j += i)
                    {
                        a[j] = false;
                    }
                }
            }
            long l = 0;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] == true)
                {
                    l += i;
                }
            }
            return l;
        }

        private static bool problem10A(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }   
            }

            return true;
        }

        public static string problem13()
        {
            BigInteger bigInt = new BigInteger();
            List<BigInteger> lines = new List<BigInteger>();
            using (StreamReader sr = new StreamReader("C:\\Users\\Vedran\\Desktop\\input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    bigInt += BigInteger.Parse(sr.ReadLine());
                }
            }

            var big = bigInt.ToString().Take(10).ToArray();
            var result = new string(big);

            return result;
        }

        public static int problem14()
        {
            Dictionary<int,int> dict = new Dictionary<int, int>();

            for (int i = 1; i <= 1000000; i++)
            {
                var touple = problem14A(i);
                if (!dict.ContainsKey(touple.Item1))
                {
                    dict.Add(touple.Item1, touple.Item2);
                }
            }

            var max = dict.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            return max;
        }
        
        public static BigInteger problem16()
        {
            BigInteger big = BigInteger.Pow(2,1000);

            string bitString = big.ToString();
            int size = 0;
            for (int i = 0; i < bitString.Length; i++)
            {
                size += int.Parse(bitString[i].ToString());
            }

            return size;
        }

        public static int problem20()
        {
            BigInteger a = 1;
            for (int i = 1; i < 100; i++)
            {
                a *= i;
            }

            var sm = a.ToString().ToCharArray();
            int sum = 0;
            foreach (var s in sm)
            {
                sum += int.Parse(s.ToString());
            }
            return sum;
        }

        public int problem18() 
        {
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\input.txt";
            int[,] inputTriangle = problem18A(filename);

            int posSolutions = (int)Math.Pow(2, inputTriangle.GetLength(0) - 1);
            int largestSum = 0;
            int tempSum, index;

            for (int i = 0; i <= posSolutions; i++)
            {
                tempSum = inputTriangle[0, 0];
                index = 0;
                for (int j = 0; j < inputTriangle.GetLength(0) - 1; j++)
                {
                    index = index + (i >> j & 1);
                    tempSum += inputTriangle[j + 1, index];
                }
                if (tempSum > largestSum)
                {
                    largestSum = tempSum;
                }
            }

            return 0;
        }
        
        public static int problem9()
        {
            int res = 0;
            for (int i = 1; i < 1000; i++)
            {
                for (int j = 1; j < 1000; j++)
                {
                    int c = 1000 - i - j;

                    if (i * i + j * j == c * c)
                    {
                        res = c * i * j;
                    }
                }
            }
            return res;
        }

        public static long problem8(string s)
        {
            List<long> li = new List<long>();
            for (int i = 0; i < s.Length - 13; i++)
            {
                long product = 1;
                for (int j = i; j < i + 13; j++)
                {
                    product *= int.Parse(s[j].ToString());
                }
                li.Add(product);
            }

            long max = long.MinValue;
            foreach (var l in li) max = Math.Max(max, l);
            return max;
        }

        #region Private

        

        private static int[,] problem18A(string filename)
        {
            string line;
            string[] linePieces;
            int lines = 0;

            StreamReader r = new StreamReader(filename);
            while ((line = r.ReadLine()) != null)
            {
                lines++;
            }

            int[,] inputTriangle = new int[lines, lines];
            r.BaseStream.Seek(0, SeekOrigin.Begin);

            int j = 0;
            while ((line = r.ReadLine()) != null)
            {
                linePieces = line.Split(' ');
                for (int i = 0; i < linePieces.Length; i++)
                {
                    inputTriangle[j, i] = int.Parse(linePieces[i]);
                }
                j++;
            }
            r.Close();
            return inputTriangle;
        }

        private static Tuple<int, int> problem14A(int n)
        {
            long c = n;
            int counter = 1;
            for (int i = n; c != 1 && c > 0; counter++)
            {
                if (c % 2 == 0)
                {
                    c /= 2;
                }
                else
                {
                    c = 3 * c + 1;
                }

            }

            return Tuple.Create(n, counter);
        }

        #endregion

    }
}
