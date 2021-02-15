using System;
using DesignPatterns.IoC;
namespace TestingOfIoC
{
    class Program
    {
        private static IServiceCollection _services;
        static void Main(string[] args)
        {
            _services = new ServiceCollection();
            _services.AddSingleton<SomeSingleton>();
            _services.AddTransient(provider => new SomeSecondTransient(provider.GetService<SomeSingleton>()));

            DesignPatterns.IoC.IServiceProvider serviceProvider = _services.BuildServiceProvider();

            SomeSingleton sing = serviceProvider.GetService<SomeSingleton>();
            SomeSecondTransient first = serviceProvider.GetService<SomeSecondTransient>();
            SomeSecondTransient second = serviceProvider.GetService<SomeSecondTransient>();
        }
    }
}
