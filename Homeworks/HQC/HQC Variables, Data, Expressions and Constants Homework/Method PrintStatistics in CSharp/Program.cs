//Refactor the following code to apply variable usage and naming best practices:

namespace Method_PrintStatistics_in_CSharp
{
    class MethodPrintStatistics
    {
        public void PrintStatistics(double[] collection, int numberOfElements)
        {
            double maxValue = double.MinValue;
            double minValue = double.MaxValue;
            double elementsSum = 0;

            for (int i = 0; i < numberOfElements; i++)
            {
                if (collection[i] > maxValue)
                {
                    maxValue = collection[i];
                }

                if (collection[i] < minValue)
                {
                    minValue = collection[i];
                }

                elementsSum += collection[i];
            }

            double averageSum = elementsSum / numberOfElements;

            PrintAvg(averageSum);
            PrintMax(maxValue);
            PrintMin(maxValue);
        }

        private void PrintAvg(double p)
        {
            throw new System.NotImplementedException();
        }

        private void PrintMin(double max)
        {
            throw new System.NotImplementedException();
        }

        private void PrintMax(double max)
        {
            throw new System.NotImplementedException();
        }
    }
}
