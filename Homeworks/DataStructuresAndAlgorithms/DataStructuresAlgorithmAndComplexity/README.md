## Data Structures, Algorithms and Complexity Homework

1. What is the expected running time of the following C# code?
  - Explain why using Markdown.
  - Assume the array's size is `n`.

  ```cs
  long Compute(int[] arr)
  {
      long count = 0;
      for (int i=0; i<arr.Length; i++)
      {
          int start = 0, end = arr.Length-1;
          while (start < end)
              if (arr[start] < arr[end])
                  { start++; count++; }
              else 
                  end--;
      }
      return count;
  }
  ```
  
   - `long count = 0` is `1` operation. 
   
   ```cs
   1
   ```
   
   - `int i=0` is `1` operation. 
   - Let's assume that the operation `arr.Length` is cached after the first call and it s going to be executed only `1` time.
   - `i++` is also executed only one time for each cicle of the `for` loop
   - The `for` loop is going to execute the code in it `n` times. 
   
   ```cs
   1 + 1 + n(1 + 1) = 2 + n(2)
   ```
   
   - `int start = 0` and `end = arr.Length-1` are `1` operation each
   
   ```cs
   2 + n(2 + 2)
   ```
   
   -  The `while` loop is executed `n` times
   
   ```cs
   2 + n(4 + n)
   ```
   
   - `arr[start] < arr[end]` is `1` operation
   - Each of `start++`, `count++` and `end--` are `1` operation each. In the worst case scenario `arr[start] < arr[end]` is `true` each time and `start++; count++;` is executed which are `2` operaions
   
   ```cs
   2 +n(4 + n(2)) = 2 + 4n + 2n^2
   ```
   - We can assume that the complexity of this C# code is
   
   ```cs
   O(n^2)
   ```
   - Therefore the runnng time of the C# code should be less than one second when `n` is between 1 than 10000. If `n` is 10000 the runnng time should be around 2 sec and if `n` is 100000 the running time should be around 2-3min.

2. What is the expected running time of the following C# code?
  - Explain why using Markdown.
  - Assume the input matrix has size of `n * m`.

  ```cs
  long CalcCount(int[,] matrix)
  {
      long count = 0;
      for (int row=0; row<matrix.GetLength(0); row++)
          if (matrix[row, 0] % 2 == 0)
              for (int col=0; col<matrix.GetLength(1); col++)
                  if (matrix[row,col] > 0)
                      count++;
      return count;
  }
  ```
   
   - The `for` loop is going to be executed `n` times
   - In the worst case scenarion the secont `for` loop is going to be executed `m` times
   - Therefore the complexity of this C# code should be
   
   ```cs
   O(n*m)
   ```

3. (*) What is the expected running time of the following C# code?
  - Explain why using Markdown.
  - Assume the input matrix has size of `n * m`.

  ```cs
  long CalcSum(int[,] matrix, int row)
  {
      long sum = 0;
      for (int col = 0; col < matrix.GetLength(0); col++) 
          sum += matrix[row, col];
      if (row + 1 < matrix.GetLength(1)) 
          sum += CalcSum(matrix, row + 1);
      return sum;
  }
  
  Console.WriteLine(CalcSum(matrix, 0));
  ```
  
  - The first `for` loop is going to be executed `n` times
  - In the worrst case scenario the second `for` loop is going to be executed `m` times
  - Therefore the complexity of the given C# code is
  
  ```cs
  O(n*m)
  ```