using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ar[iter] = rand.Next(max+1);
                iter++;
            }

            return ar;
        }

        public int GenerateRandomInt(int maxVal)
        {
            int r;

            r = rand.Next(maxVal+1);

            return r;
        }

        public int SeqSearchB(int[] ar, int sVal)
        {
            for (int index = 0; index < ar.Length; index++)
            {
                if(ar[index] == sVal)
                {
                    return index;
                }                
            }
            return -1;
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

        public int FindMinVal(int[] ar)
        {
            int retVal = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                if(i == 0)
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
