using System;
using System.Runtime.InteropServices;

namespace P11_SnowBall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte numOfSnowballs=byte.Parse(Console.ReadLine());
            short bestSnowBallSnow = 0;
            short bestSnowBallTime =0;
            short bestSnowBallQuality = 0;
            double bestSnowBallValue = 0;
            for (int i = 0; i < numOfSnowballs; i++)
            {
                short snowBallSnow=short.Parse(Console.ReadLine());
                short snowBallTime=short.Parse(Console.ReadLine());
                short snowBallQuality=short.Parse(Console.ReadLine());
                double currentSnowBallValue = Math.Pow((double)snowBallSnow / snowBallTime, snowBallQuality);
                if (currentSnowBallValue>bestSnowBallValue)
                {
                    bestSnowBallValue=currentSnowBallValue;
                    bestSnowBallSnow=snowBallSnow;
                    bestSnowBallTime=snowBallTime;
                    bestSnowBallQuality = snowBallQuality;
                }
            }
            Console.WriteLine($"{bestSnowBallSnow} : {bestSnowBallTime} = {bestSnowBallValue} ({bestSnowBallQuality})");
        }
    }
}