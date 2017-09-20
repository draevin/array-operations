using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.Write("Available Array Operations: \n  -(Seq)uential Search \n  -(Min)imum value \n  -(Max)imum value \n  -(Bub)ble sort \n  -(Exit) \n\n");
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
                    Console.WriteLine("Would you like to use the existing array? [Y/N] \n");
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
                Console.WriteLine("Would you like to find the first occurence of your search value? [Y/N] \n");
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
            int searchReturn;
            string searchOutput;

            int[] ar = AO.InitializeRandomArray(arLen, arMax);
            stored = new int[arLen];
            ar.CopyTo(stored, 0);

            Console.WriteLine("\nRandom Array Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.SeqSearchB(ar, sVal);
            Console.WriteLine($"The search value was {sVal}.");
            if (searchReturn == -1)
            {
                searchOutput = "The search value was not found in the array.";
            }
            else
            {
                searchOutput = $"The search value was first found at array index {searchReturn}.";
            }
            Console.WriteLine($"{searchOutput}\n");
        }

        static void SeqSearch(int[] ar)
        {
            int sVal = SetSearchValue();
            int searchReturn;
            string searchOutput;

            Console.WriteLine("\nArray Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.SeqSearchB(ar, sVal);
            Console.WriteLine($"The search value was {sVal}.");
            if (searchReturn == -1)
            {
                searchOutput = "The search value was not found in the array.";
            }
            else
            {
                searchOutput = $"The search value was first found at array index {searchReturn}.";
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
                searchOutput = $"Occurence {occ} of the search value was found at array index {searchReturn.Item1}.";                
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
                searchOutput = $"Occurence {occ} of the search value was found at array index {searchReturn.Item1}.";
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
            minIndex = AO.SeqSearchB(ar, searchReturn);
            Console.WriteLine($"The minimum value in the array was {searchReturn} and can be first found at index {minIndex}.\n");
        }

        static void MinValue(int[] ar)
        {
            int searchReturn;
            int minIndex;

            Console.WriteLine("\nArray Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.FindMinVal(ar);
            minIndex = AO.SeqSearchB(ar, searchReturn);
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
            maxIndex = AO.SeqSearchB(ar, searchReturn);
            Console.WriteLine($"The maximum value in the array was {searchReturn} and can be first found at index {maxIndex}.\n");
        }

        static void MaxValue(int[] ar)
        {
            int searchReturn;
            int maxIndex;

            Console.WriteLine("\nArray Values:");
            AO.OutputArrayValues(ar);

            searchReturn = AO.FindMaxVal(ar);
            maxIndex = AO.SeqSearchB(ar, searchReturn);
            Console.WriteLine($"The maximum value in the array was {searchReturn} and can be first found at index {maxIndex}.\n");
        }

        static void BubbleSort()
        {
            int arLen = SetArrayLength();
            int arMax = SetArrayMax();

            int[] ar = AO.InitializeRandomArray(arLen, arMax);
            Console.WriteLine("\nStarting Array Values:");
            AO.OutputArrayValues(ar);

            stored = AO.BubbleSort(ar);
                        
            Console.WriteLine("\nSorted Array Values:");
            AO.OutputArrayValues(stored);


        }

        static void BubbleSort(int[] ar)
        {
            Console.WriteLine("\nStarting Array Values:");
            AO.OutputArrayValues(ar);

            stored = AO.BubbleSort(ar);

            Console.WriteLine("\nSorted Array Values:");
            AO.OutputArrayValues(stored);
        }
    }
}
