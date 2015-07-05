using System;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        Console.Write("Enter number of elements in the array: ");
        int length = int.Parse(Console.ReadLine());

        int[] array = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        int count = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (CheckNeighbours(array, i, length))
            {
                Console.WriteLine("The index of the first element in array that is larger than its neighbours is: {0}", i);
                count++;
                return;
            }
        }

        if (count == 0) Console.WriteLine(-1);
    }

    static bool CheckNeighbours(int[] nums, int position, int N)
    {
        bool result;

        if (position == 0) result = nums[position] > nums[position + 1];
        else if (position == N - 1) result = nums[position] > nums[position - 1];
        else result = nums[position] > nums[position - 1] && nums[position] > nums[position + 1];
        return result;
    }
}
