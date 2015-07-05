using System;

    class MergeSort
    {
        static void Main()
        {
        //Write a program that sorts an array of integers using the Merge sort algorithm.


            //Това за съжаление не е мое решение. Намерих го в интернет. Не успях да реша задачата сам...


            int[] array = { 2, -4, 5, 2, -10, 3, 1, 0, 13, 15, 9, 8, 4 };
            int[] tempArray = new int[array.Length];
            int arraySize = array.Length;
            int currentLength = 1;
            int currentPosition = 0;
            int left = 0;
            int right = 0;
            while (currentLength <= arraySize)
            {
                for (int i = 0; i < arraySize; i = i + currentLength * 2)
                {
                    while (currentPosition < arraySize)
                    {
                        if (left < currentLength && right < currentLength && i + right + currentLength < arraySize)
                        {
                            if (array[i + left] <= array[i + right + currentLength])
                            {
                                tempArray[currentPosition] = array[i + left];
                                left++;
                            }
                            else
                            {
                                tempArray[currentPosition] = array[i + right + currentLength];
                                right++;
                            }
                        }
                        else if (left < currentLength)
                        {
                            tempArray[currentPosition] = array[i + left];
                            left++;
                        }
                        else if (right < currentLength)
                        {
                            tempArray[currentPosition] = array[i + right + currentLength];
                            right++;
                        }
                        else
                        {
                            break;
                        }
                        currentPosition++;
                    }
                    right = 0;
                    left = 0;
                }
                currentLength = currentLength * 2;
                currentPosition = 0;
                for (int i = 0; i < arraySize; i++)
                {
                    array[i] = tempArray[i];
                }
            }
            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
