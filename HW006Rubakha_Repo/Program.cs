using System;

namespace HW006Rubakha
{
    class Program
    {
        static void Main(string[] args)
        {
            string homeworkTitle = "Homework 6. Assigned 02.04.2021. Deadline 06.04.2021. Student Rubakha";
            Console.WriteLine(homeworkTitle);
           
            ArrTaskSwitcher();

            NumberTaskSwitcher();

            Console.WriteLine("Have a nice day :)");
        }

        private static void NumberTaskSwitcher()
        {
            Console.WriteLine("Task 6-7. Convert numbers from digital to text form and back");
            Console.WriteLine("Enter integer number BY DIGITS in range 0-999 to convert it to TEXT,");
            Console.WriteLine("Enter integer number BY TEXT in range 0-999 to convert it to DIGITS");
            Console.WriteLine("Enter 'help' to see examples and allowed words");
            Console.WriteLine("Enter 'exit' to cancel program");

            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input.ToLower()=="exit")
                { break; }
                int tempNumber;
                //string numberText;
                //string numberToTextError;
                if (Int32.TryParse(input, out tempNumber))
                {

                    string tmpStr;
                    string errStr;
                    if (NumberToText(tempNumber, out tmpStr, out errStr))
                    {
                        Console.WriteLine(tmpStr);
                    }
                    else
                    {
                        Console.WriteLine(errStr);
                    }
                    //continue;
                }
                else
                if (input.ToLower()=="help")
                {
                    NumberTaskHelp();
                }
                else
                {
                    Console.WriteLine("Trying to parse number from words...");
                    int parcedNumber;
                    string parseError;
                    if (TextToNumber(input, out parcedNumber, out parseError))
                    {
                        Console.WriteLine($"Number parced as: {parcedNumber}");
                    }
                    else
                    {
                        Console.WriteLine($"Parse error: {parseError}");
                    }
                }


            }

                

            

        }

        private static void NumberTaskHelp()
        {
            string[] words = new string[91];
            new string[20] {"zero","one", "two", "three", "four", "five", "six","seven","eight","nine","ten","eleven","twelve",
                "thirteen","fourteen", "fifteen", "sixteen","seventeen" , "eighteen","nineteen"}.CopyTo(words, 0);
            words[20] = "twenty";
            words[30] = "thirty";
            words[40] = "fourty";
            words[50] = "fifty";
            words[60] = "sixty";
            words[70] = "seventy";
            words[80] = "eighty";
            words[90] = "ninety";

            Console.WriteLine("You can use the next words in writing a number:");
            foreach (string wrd in words)
            {if (wrd!="" && wrd!=null)
                {
                    Console.Write($"{wrd}\t");
                }
            }
            Console.WriteLine("\nValid examples:");
            Console.WriteLine("One hundred four, three hundred, ninety seven, five hundred sixty three, etc");
        }
        
        private static void ArrTaskSwitcher()
        {
            Console.WriteLine("Tasks 1-5 merged. Set array to perform all tasks");
            do
            {
                int arrRows = GuaranteedNaturalRead("Enter number of rows. Natural number", "Only natural numbers allowed");
                int arrCols = GuaranteedNaturalRead("Enter number of columns.Natural number", "Only natural numbers allowed");
                int[,] arr = new int[arrRows, arrCols];
                Console.WriteLine("Array filled with random values in range -20..20");
                RandomArray2D(arr);
                PrintArray2D(arr);
                int minElementRow, minElementCol;
                int maxElementRow, maxElementCol;

                Console.WriteLine();
                Console.WriteLine($"Array's minimal element is: {MinElement2D(arr, out minElementRow, out minElementCol)}");
                Console.WriteLine($"Array's maximal element is: {MaxElement2D(arr, out maxElementRow, out maxElementCol)}");
                Console.WriteLine($"Array's minimal element index is: [{minElementRow},{minElementCol}]");
                Console.WriteLine($"Array's maximal element index is: [{maxElementRow},{maxElementCol}]");

                Console.WriteLine($"Searching for elements bigger than their nearest neighbors");

                Console.WriteLine($"Number of elements bigger than their nearest neighbors (left, right, above, behind) is: {BiggestNeighborCount(arr)}");
                Console.WriteLine("Do you want to repeat tasks 1-5 again? If so, type 'yes'. Other input proceed to tasks 6-7");
            } while (Console.ReadLine() == "yes");
            

        }

        
        private static int BiggestNeighborCount(int[,] arr)
        {
            int count = 0;
            int minRow = arr.GetLowerBound(0);
            int maxRow = arr.GetUpperBound(0);
            int minCol = arr.GetLowerBound(1);
            int maxCol = arr.GetUpperBound(1);
            for (int i=minRow; i<=maxRow; i++)
            {
                for (int j=minCol; j<=maxCol; j++)
                {
                    bool bigger = true;
                  
                    if (i != minRow && arr[i, j] <= arr[i - 1, j])
                    {
                            bigger = false;
                    }

                    if (i != maxRow && arr[i, j] <= arr[i + 1, j])
                    {
                            bigger = false;
                    }

                    if (j != minCol && arr[i, j] <= arr[i, j - 1])
                    {
                        bigger = false;
                    }
                    if (j != maxCol && arr[i, j] <= arr[i, j + 1])
                    {
                            bigger = false;
                    }

                    if (bigger==true)
                    {
                        count++;
                        Console.WriteLine($"Found biggest element {arr[i,j]}, index [{i},{j}]");
                    }
                }
            }

            return count;
        }
        private static int[,] RandomArray2D(int[,] arr)
        {
            var rnd = new Random();
            int maxRow = arr.GetUpperBound(0);
            int maxCol = arr.GetUpperBound(1);
            for (int i = 0; i <= maxRow; i++)
            {
                for (int j = 0; j <= maxCol; j++)
                {
                    arr[i, j] = rnd.Next(-20, 20);
                }
            }
            return arr;
        }

        private static void PrintArray2D(int[,] arr)
        {
            int maxRow = arr.GetUpperBound(0);
            int maxCol = arr.GetUpperBound(1);
            for (int i = 0; i <= maxRow; i++)
            {
                for (int j = 0; j <= maxCol; j++)
                {
                    Console.Write($"{arr[i, j]}\t");
                }
                Console.WriteLine();
            }
            
        }
        private static int MinElementValue2D(int[,] arr)
        {
            int maxRow = arr.GetUpperBound(0);
            int maxCol = arr.GetUpperBound(1);
            int minValue = arr[0, 0];

            for (int i=0; i<=maxRow; i++)
            {
                for (int j=0; j<=maxCol; j++)
                {
                    if (minValue>arr[i,j])
                        {
                        minValue = arr[i, j];

                        }
                }
            }
            return minValue;
        }

        

        private static int MinElement2D(int[,] arr, out int row, out int col)
        {
            int maxRow = arr.GetUpperBound(0);
            int maxCol = arr.GetUpperBound(1);
            row = 0;
            col = 0;
            int minValue = arr[0, 0];

            for (int i = 0; i <= maxRow; i++)
            {
                for (int j = 0; j <= maxCol; j++)
                {
                    if (minValue > arr[i, j])
                    {
                        minValue = arr[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return minValue;
            
        }

        private static int MaxElement2D(int[,] arr, out int row, out int col)
        {
            int maxRow = arr.GetUpperBound(0);
            int maxCol = arr.GetUpperBound(1);
            row = 0;
            col = 0;
            int maxValue = arr[0, 0];

            for (int i = 0; i <= maxRow; i++)
            {
                for (int j = 0; j <= maxCol; j++)
                {
                    if (maxValue < arr[i, j])
                    {
                        maxValue = arr[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return maxValue;

        }



 
        private static int GuaranteedIntRead(string normalMessage, string errorMessage)
        {
            int returnValue;
            Console.WriteLine(normalMessage);
            while (true)
            {
                string readValue = Console.ReadLine();
                if (int.TryParse(readValue, out returnValue))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
            return returnValue;
        }
        private static int GuaranteedNaturalRead(string normalMessage, string errorMessage)
        {
            int returnValue;
            Console.WriteLine(normalMessage);
            do
            {
                string readValue = Console.ReadLine();
                if (int.TryParse(readValue, out returnValue))
                {
                    if (returnValue > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(errorMessage);
                    }
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            } while (true);
            return returnValue;
        }

        private static bool NumberToText(int num, out string strNumber, out string errorMessage)
        {
            strNumber= "";
            errorMessage = "";
            
            if (num<0||num>999)
            {
                errorMessage = "Numbers less than 0 and above 999 are not allowed yet";
                return false;
            }
            else
            {
                if (num == 0)
                {
                    Console.WriteLine("Zero");
                }
                else
                {
                    string[] ones = new string[20] {"Zero", "One", "Two", "Three", "Four", "Five",
                                                    "Six", "Seven", "Eight", "Nine", "Ten",
                                                    "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
                                                    "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
                    string[] decades = new string[10] {"Zero", "Ten", "Twenty", "Thirty","Fourty","Fifty",
                                                        "Sixty", "Seventy", "Eighty", "Ninety"};
                    if (num > 99)
                    {
                        strNumber = ones[num / 100 ] + " hundred ";
                    }

                    int k = num % 100;

                    if (k > 0 && k <= 19)
                    {
                        string tmpStr = ones[num % 100];

                        if (num>99)
                        {
                             tmpStr=tmpStr.ToLower();
                        }
                        strNumber = strNumber + " " + tmpStr;
                    }
                    else
                    {//мы здесь, если младшие две цифры числа 20 и более (или 0!)
                         string tmpStr = decades[k / 10];
                        if (num>99)
                        { 
                            tmpStr = tmpStr.ToLower();
                        }
                        strNumber = strNumber + tmpStr;
                        if (k % 10 != 0)
                        {
                            tmpStr = ones[k % 10];
                            if (num>10)
                            {
                                tmpStr = tmpStr.ToLower();
                            }
                            strNumber = strNumber + " " + tmpStr;
                        }
                    }
                    strNumber = strNumber.Trim();
                    return true;
                }
            }
            return true;
        }
        private static bool TextToNumber(string strNumber, out int number, out string errorMessage)
        {
            number = 0;
            errorMessage = "";
            bool normal=true;

            string[] words = new string[91];
            new string[20] {"zero","one", "two", "three", "four", "five", "six","seven","eight","nine","ten","eleven","twelve",
                "thirteen","fourteen", "fifteen", "sixteen","seventeen" , "eighteen","nineteen"}.CopyTo(words, 0);
            words[20] = "twenty";
            words[30] = "thirty";
            words[40] = "fourty";
            words[50] = "fifty";
            words[60] = "sixty";
            words[70] = "seventy";
            words[80] = "eighty";
            words[90] = "ninety";
            strNumber = strNumber.Trim().ToLower();
            
            while (strNumber.Length != (strNumber=strNumber.Replace("  "," ")) .Length)
            {
            }
            
            string[] splitWords = strNumber.Split(" ");
            
            if (Array.IndexOf(splitWords,"hundred")>0)
            {
                // есть сотни. Должно быть не более 4 слов
                if (splitWords[1] != "hundred")
                {
                    normal = false;
                    errorMessage = "Word 'hundred' in unexpexted position!";

                }
                else
                {
                    int tmp = Array.IndexOf(words, splitWords[0]);
                    if (tmp >= 1 && tmp <= 9)
                    {
                        number += tmp * 100;
                        if (splitWords.Length > 4)
                        {
                            normal = false;
                            errorMessage = "Seems incorrect input";
                        }
                        else
                        {
                            //splitWords = Array.Reverse(splitWords);
                            if (splitWords.Length == 4)
                            {
                                tmp = Array.IndexOf(words, splitWords[2]);
                                if (tmp >= 0)
                                {
                                    if (tmp <= 19)
                                    {
                                        normal = false;
                                        errorMessage = "Word at position 2 in incorrect position";
                                    }
                                    else

                                    {
                                        number += tmp;
                                        tmp = Array.IndexOf(words, splitWords[3]);
                                        if (tmp >= 1 && tmp <= 9)
                                        {
                                            number += tmp;
                                        }
                                        else
                                        {
                                            normal = false;
                                            errorMessage = "Unknown last word";
                                        }
                                    }


                                }
                                else
                                {
                                    normal = false;
                                    errorMessage = "Unknown word at position 2";
                                }

                            }
                            else if (splitWords.Length == 3)
                            {
                                tmp = Array.IndexOf(words, splitWords[2]);
                                if (tmp >= 1)
                                {
                                    number += tmp;
                                }
                                else
                                {
                                    normal = false;
                                    errorMessage = "Unknown last word";
                                }
                            }
                            

                        }
                    }
                    else
                    {
                        normal = false;
                        errorMessage = "Unknown first word";

                    }

                }
            }
            else
            { //нет сотен. Должно быть не более двух слов
                if (splitWords.Length>2)
                {
                    normal = false;
                    errorMessage = "Seems incorrect input";
                }
                else
                {
                    //splitWords = Array.Reverse(splitWords);
                    if (splitWords.Length==2)
                    {
                        int tmp = Array.IndexOf(words, splitWords[0]);
                        if (tmp >= 0)
                        {
                            if (tmp<=19)
                            {
                                normal = false;
                                errorMessage = "Word at position 0 in incorrect position";
                            }
                            else

                            {
                                number += tmp;
                                tmp = Array.IndexOf(words, splitWords[1]);
                                if (tmp >= 1 && tmp <= 9)
                                {
                                    number += tmp;
                                }
                                else
                                {
                                    normal = false;
                                    errorMessage = "Unknown last word";
                                }
                            }
                        }
                            else
                            {
                            normal = false;
                            errorMessage = "Unknown word at position 0";
                            }

                    }
                    else  
                    {
                        int tmp = Array.IndexOf(words, splitWords[0]);
                        if (tmp >= 0 )
                        {
                            number += tmp;
                        }
                        else
                        {
                            normal = false;
                            errorMessage = "Unknown last word";
                        }
                    }
                }

            }


            
            return normal;
        }
        
    }
}
