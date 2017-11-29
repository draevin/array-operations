using System;
using System.Diagnostics;

namespace ArrayOperations
{
    public class ArrayOps
    {
        Random rand;
        Stopwatch sw;
        public ArrayOps()
        {
            rand = new Random();
            sw = new Stopwatch();
        }
        public int[] InitializeRandomArray(int len, int max)
        {
            int[] ar;
            int iter = 0;
            ar = new int[len];

            foreach (int i in ar)
            {
                ar[iter] = rand.Next(max) + 1;
                iter++;
            }

            return ar;
        }

        public int[] InitializeOrderedArray(int len)
        {
            int[] ar = new int[len];
            for (int i = 0; i < len; i++)
            {
                ar[i] = i;
            }

            return ar;
        }

        public int[] ParseArrayInput(string input)
        {
            string[] sa = input.Split(',');
            int[] ar = new int[sa.Length];

            for (int i = 0; i < sa.Length; i++)
            {
                ar[i] = Int32.Parse(sa[i]);
            }

            return ar;
        }

        public int GenerateRandomInt(int maxVal)
        {
            int r;

            r = rand.Next(maxVal + 1);

            return r;
        }

        public Tuple<int, int> SeqSearchB(int[] ar, int sVal)
        {
            int compCount = 0;
            for (int index = 0; index < ar.Length; index++)
            {
                compCount++;
                if (ar[index] == sVal)
                {
                    return new Tuple<int, int>(index, compCount);
                }
            }
            return new Tuple<int, int>(-1, compCount);
        }

        public Tuple<int, int> SeqSearchC(int[] ar, int sVal, int occTarget)
        {
            int occCount = 0;
            int lastIdx = -1;
            bool occExists = false;

            for (int index = 0; index < ar.Length; index++)
            {
                if (!occExists)
                {
                    if (ar[index] == sVal)
                    {
                        lastIdx = index;
                        occCount++;
                        occExists = (occCount == occTarget);
                    }
                }
                else
                {
                    break;
                }
            }

            return Tuple.Create(occCount, lastIdx);

        }

        public Tuple<int, int> BinarySearch(int[] ar, int sVal)
        {
            int min = 0;
            int max = ar.Length - 1;
            int compCount = 0;

            do
            {
                compCount++;
                int mid = (min + max) / 2;
                if (sVal > ar[mid])
                    min = mid + 1;
                else
                    max = mid - 1;
                if (ar[mid] == sVal)
                    return new Tuple<int, int>(mid, compCount);
            } while (min <= max);
            return new Tuple<int, int>(-1, compCount);
        }


        public int FindMinVal(int[] ar)
        {
            int retVal = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                if (i == 0)
                {
                    retVal = ar[i];
                }
                else if (ar[i] < retVal)
                {
                    retVal = ar[i];
                }
            }

            return retVal;
        }

        public int FindMaxVal(int[] ar)
        {
            int retVal = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                if (i == 0)
                {
                    retVal = ar[i];
                }
                else if (ar[i] > retVal)
                {
                    retVal = ar[i];
                }
            }

            return retVal;
        }

        public Tuple<int[], long> BubbleSort(int[] ar)
        {
            sw.Reset();

            int length = ar.Length;
            int temp = ar[0];

            sw.Start();
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (ar[i] > ar[j])
                    {
                        temp = ar[i];

                        ar[i] = ar[j];

                        ar[j] = temp;
                    }
                }
            }
            sw.Stop();

            return new Tuple<int[], long>(ar, sw.ElapsedTicks);
        }

        public Tuple<string[], long> BubbleSort(string[] ar)
        {
            sw.Reset();

            int length = ar.Length;
            string temp = ar[0];

            sw.Start();
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (ar[i].CompareTo(ar[j]) > 0)
                    {
                        temp = ar[i];

                        ar[i] = ar[j];

                        ar[j] = temp;
                    }
                }
            }
            sw.Stop();

            return new Tuple<string[], long>(ar, sw.ElapsedTicks);
        }

        public Tuple<int[], long> ShellSort(int[] ar)
        {
            sw.Reset();

            int i, j, inc, temp;
            inc = 3;

            sw.Start();
            while (inc > 0)
            {
                for (i = 0; i < ar.Length; i++)
                {
                    j = i;
                    temp = ar[i];
                    while ((j >= inc) && (ar[j - inc] > temp))
                    {
                        ar[j] = ar[j - inc];
                        j = j - inc;
                    }
                    ar[j] = temp;
                }
                if (inc / 2 != 0)
                    inc = inc / 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }
            sw.Stop();

            return new Tuple<int[], long>(ar, sw.ElapsedTicks);
        }

        public void MergeSort(int[] ar, int low, int high)
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSort(ar, low, middle);
                MergeSort(ar, middle + 1, high);
                Merge(ar, low, middle, high);
            }
        }

        public Tuple<int[], long> MergeSort(int[] ar)
        {
            sw.Reset();

            sw.Start();
            MergeSort(ar, 0, ar.Length - 1);
            sw.Stop();

            return new Tuple<int[], long>(ar, sw.ElapsedTicks);
        }

        private void Merge(int[] ar, int low, int middle, int high)
        {

            int left = low;
            int right = middle + 1;
            int[] tmp = new int[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (ar[left] < ar[right])
                {
                    tmp[tmpIndex] = ar[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = ar[right];
                    right = right + 1;
                }
                tmpIndex = tmpIndex + 1;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = ar[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = ar[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                ar[low + i] = tmp[i];
            }

        }

        public void OutputArrayValues(int[] ar)
        {
            int iter = 0;
            string output = String.Empty;
            foreach (int i in ar)
            {
                iter++;
                if (iter == ar.Length)
                {
                    output += $"{i}";
                }
                else
                {
                    output += $"{i}, ";
                }
            }
            Console.Write(output);
            Console.WriteLine();
        }
    }
}
