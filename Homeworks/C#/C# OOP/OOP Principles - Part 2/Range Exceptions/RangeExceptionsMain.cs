namespace Range_Exceptions
{
    using System;
    using System.Globalization;

    class RangeExceptionsMain
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            if (number < 1 || number > 100)
            {
                throw new InvalidRangeException<int>("Number must be between 1 and 100.", 1, 100);
            }

            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var startDate = new DateTime(1980, 1, 1);
            var endDate = new DateTime(2013, 12, 31);

            if (date < startDate || date > endDate)
            {
                throw new InvalidRangeException<DateTime>("Date must be between 1.1.1980 and 31.12.2013", startDate, endDate);
            }
        }
    }
}
