using Eindopdracht.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Eindopdracht
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly MyDbContext _context;


        public App()
        {
            // Create a new instance of the context
            _context = new MyDbContext();

            // Register the context with the DI container
            var services = new ServiceCollection();
            services.AddSingleton(_context);

            // Build the service provider
            ServiceProvider = services.BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider { get; }

        protected override void OnExit(ExitEventArgs e)
        {
            // Dispose the context when the application exits
            _context.Dispose();
        }
    }
}
