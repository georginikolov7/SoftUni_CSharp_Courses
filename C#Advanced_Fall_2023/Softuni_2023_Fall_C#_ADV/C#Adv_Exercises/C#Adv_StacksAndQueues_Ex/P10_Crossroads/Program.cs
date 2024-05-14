

namespace P10_Crossroads
{
    internal class Program
    {
        static Queue<string> queue = new Queue<string>();
        static int passedCarsCount = 0;
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    passCars(greenLightDuration, freeWindowDuration);
                }
                else
                {
                    queue.Enqueue(command);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCarsCount} total cars passed the crossroads.");
        }

        static void passCars(int greenLightDuration, int freeWindowDuration)
        {
            while (queue.Count > 0)
            {
                string currentCar = queue.Dequeue();
                greenLightDuration -= currentCar.Length;
                if (greenLightDuration > 0) //light is still green after currentCar has passed
                {
                    passedCarsCount++;
                }
                else            //car is entering into freeWindow
                {
                    int extraTimeNeeded = Math.Abs(greenLightDuration); //greenLightDuration is negative
                    if (freeWindowDuration >= extraTimeNeeded)  //time is enough for car to pass:
                    {
                          passedCarsCount++;
                        return; //no more cars are to enter crossroad
                    }
                    else        //car will crash:
                    {
                        int indexToCrashAt = currentCar.Length - (extraTimeNeeded - freeWindowDuration);
                        CrashCar(indexToCrashAt, currentCar);
                        Environment.Exit(0);

                    }
                }
            }
        }

        static void CrashCar(int index, string car)
        {
            char crashedChar = car[index];
            Console.WriteLine("A crash happened!");
            Console.WriteLine($"{car} was hit at {crashedChar}.");
        }
    }
}