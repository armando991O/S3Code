using System;

namespace TrafficFlowSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Monte Carlo Simulation for Traffic Flow");
                Console.WriteLine("1. Simulate Traffic Flow");
                Console.WriteLine("2. Optimize Traffic Flow");
                Console.WriteLine("3. Predict Traffic Congestion");
                Console.WriteLine("4. Optimize Signal Timing");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        var simulateTraffic = new SimulateTrafficFlow();
                        simulateTraffic.Execute();
                        break;
                    case 2:
                        var optimizeTraffic = new OptimizeTrafficFlow();
                        optimizeTraffic.Execute();
                        break;
                    case 3:
                        var predictCongestion = new PredictTrafficCongestion();
                        predictCongestion.Execute();
                        break;
                    case 4:
                        var signalTimingOptimization = new SignalTimingOptimization();
                        signalTimingOptimization.Execute();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                if (choice != 5)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

            } while (choice != 5);
        }
    }

    class SimulateTrafficFlow
    {
        public void Execute()
        {
            Random rand = new Random();
            int totalCars = rand.Next(50, 200);
            double averageSpeed = rand.Next(20, 60);
            Console.WriteLine("\nSimulating Traffic Flow...");
            Console.WriteLine($"Total Cars: {totalCars}");
            Console.WriteLine($"Average Speed: {averageSpeed} km/h");

            double travelTime = (totalCars / averageSpeed) * 60;
            Console.WriteLine($"Estimated Travel Time: {travelTime} minutes");
        }
    }

    class OptimizeTrafficFlow
    {
        public void Execute()
        {
            Random rand = new Random();
            int totalCars = rand.Next(50, 200);
            int greenLightDuration = rand.Next(30, 120);
            int redLightDuration = rand.Next(30, 120);

            Console.WriteLine("\nOptimizing Traffic Flow...");
            Console.WriteLine($"Number of Cars: {totalCars}");
            Console.WriteLine($"Initial Green Light Duration: {greenLightDuration} seconds");
            Console.WriteLine($"Initial Red Light Duration: {redLightDuration} seconds");

            double optimizedGreenLight = greenLightDuration * (1 + (totalCars / 200.0));
            double optimizedRedLight = redLightDuration * (1 - (totalCars / 200.0));

            Console.WriteLine($"Optimized Green Light Duration (based on {totalCars} cars): {optimizedGreenLight:F2} seconds");
            Console.WriteLine($"Optimized Red Light Duration (based on {totalCars} cars): {optimizedRedLight:F2} seconds");
        }
    }

    class PredictTrafficCongestion
    {
        public void Execute()
        {
            Random rand = new Random();
            int totalCars = rand.Next(50, 200);
            double congestionProbability = Math.Min(1.0, totalCars / 200.0);
            Console.WriteLine("\nPredicting Traffic Congestion...");
            Console.WriteLine($"Number of Cars: {totalCars}");
            Console.WriteLine($"Congestion Probability: {congestionProbability:P}");

            if (congestionProbability > 0.7)
            {
                Console.WriteLine("High chance of traffic congestion. Consider optimization strategies.");
            }
            else if (congestionProbability > 0.4)
            {
                Console.WriteLine("Moderate chance of congestion. Keep monitoring traffic flow.");
            }
            else
            {
                Console.WriteLine("Low chance of congestion. Traffic is flowing smoothly.");
            }
        }
    }

    class SignalTimingOptimization
    {
        public void Execute()
        {
            Random rand = new Random();
            double meanTrafficFlow = 100;
            double stdDevTrafficFlow = 20;

            double trafficFlow = GenerateNormalDistributedValue(meanTrafficFlow, stdDevTrafficFlow, rand);

            Console.WriteLine("\nOptimizing Signal Timing based on Historical Traffic Flow...");
            Console.WriteLine($"Generated Traffic Flow (cars per minute): {trafficFlow:F2}");

            double greenLightDuration = OptimizeGreenLight(trafficFlow);
            double redLightDuration = OptimizeRedLight(trafficFlow);

            Console.WriteLine($"Optimized Green Light Duration (for {trafficFlow:F2} cars/min): {greenLightDuration:F2} seconds");
            Console.WriteLine($"Optimized Red Light Duration (for {trafficFlow:F2} cars/min): {redLightDuration:F2} seconds");
        }

        private double GenerateNormalDistributedValue(double mean, double stdDev, Random rand)
        {
            double u1 = 1.0 - rand.NextDouble();
            double u2 = 1.0 - rand.NextDouble();
            double z0 = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
            return mean + z0 * stdDev;
        }

        private double OptimizeGreenLight(double trafficFlow)
        {
            return Math.Max(30, Math.Min(120, trafficFlow / 2));
        }

        private double OptimizeRedLight(double trafficFlow)
        {
            return Math.Max(30, Math.Min(120, 180 - (trafficFlow / 2)));
        }
    }
}
