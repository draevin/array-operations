﻿using System;
using System.Text.RegularExpressions;

namespace ArrayOperations
{
    class Program
    {
        private static ArrayOps AO;
        private static int[] stored = null;

        static void Main(string[] args)
        {
            Console.Clear();

            AO = new ArrayOps();

            Menu();

        }

        static void Menu()
        {
            bool exit = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Select an operation by the text between the (parens)");
                Console.Write("Available Array Operations: \n  -(Seq)uential Search \n  -(Bin)ary Search \n  -(Min)imum value \n  -(Max)imum value \n  -(Bub)ble sort \n  -(She)ll sort \n  -(Mer)ge sort \n  -Generate (ran)dom array \n  -Generate (ord)ered array \n  -Generate (spe)cified array \n  -(Exit) \n\n");
                switch (Console.ReadLine().ToUpper())
                {
                    case "SEQ":
                        if (CheckUseStored())
                        {
                            if (CheckFindFirst())
                            {
                                SeqSearch(stored);
                            }
                            else
                            {
                                SeqSearchOcc(stored);
                            }
                        }
                        else
                        {
                            if (CheckFindFirst())
                            {
                                SeqSearch();
                            }
                            else
                            {
                                SeqSearchOcc();
                            }
                        }
                        AnyKey();
                        break;
                    case "BIN":
                        Console.WriteLine("\nThe selected array will be sorted if it is not already.");
                        if (CheckUseStored())
                        {
                            BinSearch(stored);
                        }
                        else
                        {
                            BinSearch();
                        }
                        AnyKey();
                        break;
                    case "MIN":
                        if (CheckUseStored())
                        {
                            MinValue(stored);
                        }
                        else
                        {
                            MinValue();
                        }
                        AnyKey();
                        break;
                    case "MAX":
                        if (CheckUseStored())
                        {
                            MaxValue(stored);
                        }
                        else
                        {
                            MaxValue();
                        }
                        AnyKey();
                        break;
                    case "BUB":
                        if (CheckUseStored())
                        {
                            BubbleSort(stored);
                        }
                        else
                        {
                            BubbleSort();
                        }
                        AnyKey();
                        break;
                    case "SHE":
                        if (CheckUseStored())
                        {
                            ShellSort(stored);
                        }
                        else
                        {
                            ShellSort();
                        }
                        AnyKey();
                        break;
                    case "MER":
                        if (CheckUseStored())
                        {
                            MergeSort(stored);
                        }
                        else
                        {
                            MergeSort();
                        }
                        AnyKey();
                        break;
                    case "RAN":
                        GenRandArray();
                        AnyKey();
                        break;
                    case "ORD":
                        GenOrdArray();
                        AnyKey();
                        break;
                    case "SPE":
                        GenSpcArray();
                        AnyKey();
                        break;
                    case "EXIT":
                        exit = true;
                        break;
                    default:
                        break;
                }
            } while (!exit);


        }

        static bool CheckUseStored()
        {
            bool usingStored = false;
            bool dirty = true;

            if (stored != null)
            {
                do
                {
                    Console.WriteLine("\nWould you like to use the existing array? [Y/N] \n");
                    switch (Console.ReadLine().ToUpper())
                    {
                        case "Y":
                            usingStored = true;
                            dirty = false;
                            break;
                        case "N":
                            usingStored = false;
                            dirty = false;
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                } while (dirty);
            }

            return usingStored;
        }

        static bool CheckFindFirst()
        {
            bool findFirst = true;
            bool dirty = true;

            do
            {
                Console.WriteLine("\nWould you like to find the first occurence of your search value? [Y/N] \n");
                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        findFirst = true;
                        dirty = false;
                        break;
                    case "N":
                        findFirst = false;
                        dirty = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (dirty);

            return findFirst;
        }

        static int SetArrayLength()
        {
            bool cont = false;
            int arLen;
            do
            {
                Console.WriteLine("\nEnter a positive integer for array length:");
                if (int.TryParse(Console.ReadLine(), out arLen) && arLen > 0)
                {
                    cont = true;
                }
            } while (!cont);

            return arLen;
        }

        static int SetArrayMax()
        {
            bool cont = false;
            int arMax;
            do
            {
                Console.WriteLine("\nEnter a positive integer for the maximum value in the array:");
                if (int.TryParse(Console.ReadLine(), out arMax) && arMax >= 0)
                {
                    cont = true;
                }
            } while (!cont);

            return arMax;
        }

        static int SetSearchValue()
        {
            bool cont = false;
            int sVal;
            do
            {
                Console.WriteLine("\nEnter an integer to search for:");
                if (int.TryParse(Console.ReadLine(), out sVal))
                {
                    if (sVal >= 0)
                    {
                        cont = true;
                    }
                }
            } while (!cont);

            return sVal;
        }

        static int SetOccurenceValue()
        {
            bool cont = false;
            int occ;
            do
            {
                Console.WriteLine("\nEnter an occurence to search for:");
                if (int.TryParse(Console.ReadLine(), out occ))
                {
                    if (occ >= 0)
                    {
                        cont = true;
                    }
                }
            } while (!cont);

            return occ;
        }

        static void AnyKey()
        {
            Console.WriteLine("Press any key to clear and continue...");
            Console.ReadKey();
            Console.WriteLine();
        }

        static void SeqSearch()
        {
            int arLen = SetArrayLength();
            int arMax = SetArrayMax();
            int sVal = SetSearchValue();
            Tuple<int, int> searchReturn;
            string searchOutput;

            int[] ar = AO.InitializeRandomArray(arLen, arMax);
            stored = new int[arLen];
            ar.CopyTo(stored, 0);

            Console.WriteLine("\nRandom Array Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.SeqSearchB(ar, sVal);
            Console.WriteLine($"The search value was {sVal}.");
            if (searchReturn.Item1 == -1)
            {
                searchOutput = "The search value was not found in the array.";
            }
            else
            {
                searchOutput = $"The search value was first found at array index {searchReturn.Item1}. \nThis search took {searchReturn.Item2} computations.";
            }
            Console.WriteLine($"{searchOutput}\n");
        }

        static void SeqSearch(int[] ar)
        {
            int sVal = SetSearchValue();
            Tuple<int, int> searchReturn;
            string searchOutput;

            Console.WriteLine("\nArray Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.SeqSearchB(ar, sVal);
            Console.WriteLine($"The search value was {sVal}.");
            if (searchReturn.Item1 == -1)
            {
                searchOutput = "The search value was not found in the array.";
            }
            else
            {
                searchOutput = $"The search value was first found at array index {searchReturn.Item1}. \nThis search took {searchReturn.Item2} computations.";
            }
            Console.WriteLine($"{searchOutput}\n");
        }

        static void SeqSearchOcc()
        {
            int arLen = SetArrayLength();
            int arMax = SetArrayMax();
            int sVal = SetSearchValue();
            int occ = SetOccurenceValue();
            Tuple<int, int> searchReturn;
            string searchOutput;

            int[] ar = AO.InitializeRandomArray(arLen, arMax);
            stored = new int[arLen];
            ar.CopyTo(stored, 0);

            Console.WriteLine("\nRandom Array Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.SeqSearchC(ar, sVal, occ);
            Console.WriteLine($"The search value was {sVal}.");
            if (searchReturn.Item1 == occ)
            {
                searchOutput = $"Occurence {occ} of the search value was found at array index {searchReturn.Item2}.";
            }
            else if (searchReturn.Item2 >= 0)
            {
                searchOutput = $"The search value only appeared {searchReturn.Item1} times, last found at index {searchReturn.Item2}.";
            }
            else
            {
                searchOutput = "The search value was not found in the array.";
            }
            Console.WriteLine($"{searchOutput}\n");
        }

        static void SeqSearchOcc(int[] ar)
        {
            int sVal = SetSearchValue();
            int occ = SetOccurenceValue();
            Tuple<int, int> searchReturn;
            string searchOutput;

            Console.WriteLine("\nRandom Array Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.SeqSearchC(ar, sVal, occ);
            Console.WriteLine($"The search value was {sVal}.");
            if (searchReturn.Item1 == occ)
            {
                searchOutput = $"Occurence {occ} of the search value was found at array index {searchReturn.Item2}.";
            }
            else if (searchReturn.Item2 >= 0)
            {
                searchOutput = $"The search value only appeared {searchReturn.Item1} times, last found at index {searchReturn.Item2}.";
            }
            else
            {
                searchOutput = "The search value was not found in the array.";
            }
            Console.WriteLine($"{searchOutput}\n");
        }

        static void BinSearch()
        {
            int arLen = SetArrayLength();
            int arMax = SetArrayMax();
            int sVal = SetSearchValue();
            Tuple<int, int> searchReturn;
            string searchOutput;

            int[] ar = AO.InitializeRandomArray(arLen, arMax);
            ar = AO.BubbleSort(ar).Item1;
            stored = new int[arLen];
            ar.CopyTo(stored, 0);

            Console.WriteLine("\nSorted Random Array Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.BinarySearch(ar, sVal);
            Console.WriteLine($"The search value was {sVal}.");
            if (searchReturn.Item1 == -1)
            {
                searchOutput = $"The search value was not found in the array. \nThis search took {searchReturn.Item2} computations.";
            }
            else
            {
                searchOutput = $"The search value was first found at array index {searchReturn.Item1}. \nThis search took {searchReturn.Item2} computations.";
            }
            Console.WriteLine($"{searchOutput}\n");
        }

        static void BinSearch(int[] ar)
        {
            int sVal = SetSearchValue();
            Tuple<int, int> searchReturn;
            string searchOutput;

            ar = AO.BubbleSort(ar).Item1;

            Console.WriteLine("\nSorted Array Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.BinarySearch(ar, sVal);
            Console.WriteLine($"The search value was {sVal}.");
            if (searchReturn.Item1 == -1)
            {
                searchOutput = $"The search value was not found in the array. \nThis search took {searchReturn.Item2} computations.";
            }
            else
            {
                searchOutput = $"The search value was first found at array index {searchReturn.Item1}. \nThis search took {searchReturn.Item2} computations.";
            }
            Console.WriteLine($"{searchOutput}\n");
        }

        static void MinValue()
        {
            int arLen = SetArrayLength();
            int arMax = SetArrayMax();
            int searchReturn;
            int minIndex;

            int[] ar = AO.InitializeRandomArray(arLen, arMax);
            stored = new int[arLen];
            ar.CopyTo(stored, 0);

            Console.WriteLine("\nRandom Array Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.FindMinVal(ar);
            minIndex = AO.SeqSearchB(ar, searchReturn).Item1;
            Console.WriteLine($"The minimum value in the array was {searchReturn} and can be first found at index {minIndex}.\n");
        }

        static void MinValue(int[] ar)
        {
            int searchReturn;
            int minIndex;

            Console.WriteLine("\nArray Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.FindMinVal(ar);
            minIndex = AO.SeqSearchB(ar, searchReturn).Item1;
            Console.WriteLine($"The minimum value in the array was {searchReturn} and can be first found at index {minIndex}.\n");
        }

        static void MaxValue()
        {
            int arLen = SetArrayLength();
            int arMax = SetArrayMax();
            int searchReturn;
            int maxIndex;

            int[] ar = AO.InitializeRandomArray(arLen, arMax);
            stored = new int[arLen];
            ar.CopyTo(stored, 0);

            Console.WriteLine("\nRandom Array Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.FindMaxVal(ar);
            maxIndex = AO.SeqSearchB(ar, searchReturn).Item1;
            Console.WriteLine($"The maximum value in the array was {searchReturn} and can be first found at index {maxIndex}.\n");
        }

        static void MaxValue(int[] ar)
        {
            int searchReturn;
            int maxIndex;

            Console.WriteLine("\nArray Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.FindMaxVal(ar);
            maxIndex = AO.SeqSearchB(ar, searchReturn).Item1;
            Console.WriteLine($"The maximum value in the array was {searchReturn} and can be first found at index {maxIndex}.\n");
        }

        static void BubbleSort()
        {
            int arLen = SetArrayLength();
            int arMax = SetArrayMax();
            Tuple<int[], long> searchReturn;

            int[] ar = AO.InitializeRandomArray(arLen, arMax);
            Console.WriteLine("\nStarting Array Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.BubbleSort(ar);
            stored = searchReturn.Item1;

            Console.WriteLine("\nSorted Array Values:");
            AO.OutputArrayValues(stored);

            Console.WriteLine($"\nThis operation took {searchReturn.Item2} ticks. \n");
        }

        static void BubbleSort(int[] ar)
        {
            Tuple<int[], long> searchReturn;

            Console.WriteLine("\nStarting Array Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.BubbleSort(ar);
            stored = searchReturn.Item1;

            Console.WriteLine("\nSorted Array Values:");
            AO.OutputArrayValues(stored);

            Console.WriteLine($"\nThis operation took {searchReturn.Item2} ticks. \n");
        }

        static void ShellSort()
        {
            int arLen = SetArrayLength();
            int arMax = SetArrayMax();
            Tuple<int[], long> searchReturn;

            int[] ar = AO.InitializeRandomArray(arLen, arMax);
            Console.WriteLine("\nStarting Array Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.ShellSort(ar);
            stored = searchReturn.Item1;

            Console.WriteLine("\nSorted Array Values:");
            AO.OutputArrayValues(stored);

            Console.WriteLine($"\nThis operation took {searchReturn.Item2} ticks. \n");
        }

        static void ShellSort(int[] ar)
        {
            Tuple<int[], long> searchReturn;

            Console.WriteLine("\nStarting Array Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.ShellSort(ar);
            stored = searchReturn.Item1;

            Console.WriteLine("\nSorted Array Values:");
            AO.OutputArrayValues(stored);

            Console.WriteLine($"\nThis operation took {searchReturn.Item2} ticks. \n");
        }

        static void MergeSort()
        {
            int arLen = SetArrayLength();
            int arMax = SetArrayMax();
            Tuple<int[], long> searchReturn;

            int[] ar = AO.InitializeRandomArray(arLen, arMax);
            Console.WriteLine("\nStarting Array Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.MergeSort(ar);
            stored = searchReturn.Item1;

            Console.WriteLine("\nSorted Array Values:");
            AO.OutputArrayValues(stored);

            Console.WriteLine($"\nThis operation took {searchReturn.Item2} ticks. \n");
        }

        static void MergeSort(int[] ar)
        {
            Tuple<int[], long> searchReturn;

            Console.WriteLine("\nStarting Array Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.MergeSort(ar);
            stored = searchReturn.Item1;

            Console.WriteLine("\nSorted Array Values:");
            AO.OutputArrayValues(stored);

            Console.WriteLine($"\nThis operation took {searchReturn.Item2} ticks. \n");
        }

        static void GenRandArray()
        {
            int arLen = SetArrayLength();
            int arMax = SetArrayMax();
            stored = AO.InitializeRandomArray(arLen, arMax);

            Console.WriteLine("\nArray Values:");
            AO.OutputArrayValues(stored);
        }

        static void GenOrdArray()
        {
            int arLen = SetArrayLength();
            stored = AO.InitializeOrderedArray(arLen);

            Console.WriteLine("\nArray Values:");
            AO.OutputArrayValues(stored);
        }

        static void GenSpcArray()
        {
            bool cont = false;
            string input = string.Empty;
            do
            {
                Console.WriteLine("\nEnter your integer values as a comma-delimited list with no spaces or closing comma (i.e. 1,2,3)");
                input = Console.ReadLine();
                Regex r = new Regex(@"^(\d+(,\d+)*)?$");
                switch (r.IsMatch(input))
                {
                    case true:
                        stored = AO.ParseArrayInput(input);
                        cont = true;
                        break;
                    case false:
                        break;
                }
            }
            while (!cont);
        }
    }
}
