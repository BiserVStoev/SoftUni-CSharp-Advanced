namespace _02.ParkingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ParkingSystem
    {
        private static readonly HashSet<int> ParkingLot = new HashSet<int>();
        private static int parkingWidth;

        public static void Main()
        {
            var parkingDimensions = ParseNumbers(Console.ReadLine());
            parkingWidth = parkingDimensions[1];

            var command = Console.ReadLine();
            while (command != "stop")
            {
                var carDestination = ParseNumbers(command);
                var startRow = carDestination[0];
                var destinationRow = carDestination[1];
                var destinationCol = carDestination[2];

                var totalDistance = Math.Abs(destinationRow - startRow) + destinationCol + 1;

                var res = (destinationRow * 1000) + destinationCol;
                if (!ParkingLot.Contains(res))
                {
                    ParkingLot.Add(res);
                    Console.WriteLine(totalDistance);
                    command = Console.ReadLine();
                    continue;
                }
                
                var offset = 1;
                var @try = true;
                while (@try)
                {
                    @try = false;
                    if (ColIsInside(destinationCol - offset))
                    {
                        if (!ParkingLot.Contains(res - offset))
                        {
                            ParkingLot.Add(res - offset);
                            Console.WriteLine(totalDistance - offset);
                            @try = true;
                            break;
                        }

                        @try = true;
                    }

                    if (ColIsInside(destinationCol + offset))
                    {
                        if (!ParkingLot.Contains(res + offset))
                        {
                            ParkingLot.Add(res + offset);
                            Console.WriteLine(totalDistance + offset);
                            @try = true;
                            break;
                        }

                        @try = true;
                    }

                    offset++;
                }

                if (!@try)
                {
                    Console.WriteLine($"Row {destinationRow} full");
                }

                command = Console.ReadLine();
            }
        }

        private static int[] ParseNumbers(string input)
        {
            var resultArr = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            return resultArr;
        }

        private static bool ColIsInside(int col)
        {
            var result = col > 0 && col < parkingWidth;

            return result;
        }
    }
}