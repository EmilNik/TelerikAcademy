namespace CallsTest
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using DefineClass;
    public class CallHistoryTest
    {
        private static decimal callPricePerMinute = 0.37m;

        public static void CallHistoryTests()
        {
            GSM phones = new GSM("Samsung", "GalaxyS", 500.00m, "John", "Smith", "Li-Ion", 730, 16, BatteryType.LiIon, 6d, 2000000);
            phones.AddCall(DateTime.Now.AddDays(-120.258), "+359 (87) 820 7979", 145);
            phones.AddCall(DateTime.Now, "+359 (88) 853 5280", 60);
            phones.AddCall(DateTime.Now.AddDays(35.086), "+359 (86) 315 7000", 80);
            phones.AddCall(DateTime.Now.AddDays(35.128), "+359 (2) 891 4868", 28);
            PrintCallHistory(phones);
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            decimal callsPrice = phones.CallPriceCalculate(callPricePerMinute);
            Console.WriteLine();
            Console.WriteLine("Total calls price {0:C2}\n", callsPrice);
            RemoveLongestCall(phones);
            Console.WriteLine("Longest call removed");
            callsPrice = phones.CallPriceCalculate(callPricePerMinute);
            Console.WriteLine("Total calls price now is {0:C2}\n", callsPrice);
            phones.ClearCallsHistory();
            PrintCallHistory(phones);
        }
        private static void PrintCallHistory(GSM phones)
        {
            Console.WriteLine("Calls list for {0} {1}\n", phones.Owner.FirstName, phones.Owner.SecondName);
            Console.WriteLine("{0,-12}{1,-10}{2,-20}{3}", "Date:", "Time:", "Called number:", "Duration [s]:");
            foreach (var call in phones.CallHistory)
            {
                DateTime callDate = call.CallDate;
                string calledNumber = call.CalledNumber;
                int callDuration = call.CallDuration;
                Console.WriteLine("{0,-12:dd.MM.yyyy}{0,-10:HH:mm:ss}{1,-20}{2,13:D0}", callDate, calledNumber, callDuration);
            }
        }
        private static void RemoveLongestCall(GSM phones)
        {
            int longestDuration = int.MinValue;
            Call longestCall = null;
            foreach (Call call in phones.CallHistory)
            {
                if (call.CallDuration > longestDuration)
                {
                    longestDuration = call.CallDuration;
                    longestCall = call;
                }
            }
            phones.RemoveCall(longestCall);
        }
    }
}