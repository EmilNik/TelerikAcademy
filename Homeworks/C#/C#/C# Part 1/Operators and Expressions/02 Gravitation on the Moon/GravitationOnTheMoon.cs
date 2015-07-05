using System;

    class GravitationOnTheMoon
    {
        static void Main()
        {
            //The gravitational field of the Moon is approximately 17% of that on the Earth.
            //Write a program that calculates the weight of a man on the moon by a given weight on the Earth
            
            float moonGravity = 0.17F;

            Console.WriteLine("Write your mass and i will tell you how much you will weight on the Moon");
            Console.Write("Your mass is: ");
            int mass = int.Parse(Console.ReadLine());

            Console.WriteLine("You will weight around {0} on the Moon.", mass * moonGravity);
        }
    }
