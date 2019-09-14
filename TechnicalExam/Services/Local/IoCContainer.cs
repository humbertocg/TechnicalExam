using System;
using Algorithms;
using Microsoft.Extensions.DependencyInjection;

namespace TechnicalExam.Services.Local
{
    public static class IoCContainer
    {
        public static ServiceProvider Container;

        public static void Config()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IAlgorithms, Algorithms.Algorithms>();
            Container = serviceCollection.BuildServiceProvider();
        }
    }
}
