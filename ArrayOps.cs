﻿using System;

namespace ArrayOperations
{
    public class ArrayOps
    {
        Random rand;
        public ArrayOps()
        {
            rand = new Random();
        }
        public int[] InitializeRandomArray(int len, int max)
        {
            int[] ar;
            int iter = 0;
            ar = new int[len];

            foreach (int i in ar)
            {
                ar[iter] = rand.Next(max + 1);
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

        public int[] BubbleSort(int[] ar)
        {
            int length = ar.Length;

            int temp = ar[0];

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

            return ar;
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
