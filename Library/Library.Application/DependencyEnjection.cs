using Library.Application.Commands;
using Library.Application.Queries;

using Microsoft.Extensions.DependencyInjection;


namespace Library.Application
{
    public static class DependencyEnjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssemblies(
                    ApplicationCommandProvider.CommandsAssembly,
                    ApplicationQueryProvider.QueryAssembly);
            });
                
        }
    }
}
