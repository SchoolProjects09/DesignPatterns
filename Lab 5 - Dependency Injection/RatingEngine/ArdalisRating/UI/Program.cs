using System;
using IoC;

namespace ArdalisRating
{
    class Program
    {
        private static Container RegisterTypes()
        {
            Container container = new Container();

            //container.Register<ILogger, ConsoleLogger>();
            container.Register<IPolicySource, FilePolicySource>();
            container.Register<IPolicySerializer, JsonPolicySerializer>();

            ILogger logger = new ConsoleLogger();
            container.RegisterSingleton<ILogger>(logger);

            return container;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ardalis Insurance Rating System Starting...");
            //ILogger logger = new ConsoleLogger();

            //RatingEngine engine = new RatingEngine(logger,
            //    new FilePolicySource(),
            //    new JsonPolicySerializer(),
            //    new RaterFactory(logger));

            Container container = RegisterTypes();

            ILogger logger = container.GetInstance<ILogger>();
            RatingEngine engine = container.GetInstance<RatingEngine>();

            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }

            Console.ReadLine();
        }
    }
}
