using Microsoft.Extensions.DependencyInjection;
using ProjectPractika.Data;
using ProjectPractika.Services;
using ProjectPractika.ViewModels;

namespace ProjectPractika.Extensions;

public static class ServiceExtensionsCollection {
    public static void AddCommonServices(this IServiceCollection collection) {
        
        collection.AddDbContext<ApplicationDbContext>();

        collection.AddTransient<MainWindowViewModel>();

        collection.AddTransient<IEmployeeService, EmployeeService>();
    }
}