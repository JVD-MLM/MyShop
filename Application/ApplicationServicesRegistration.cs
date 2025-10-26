using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyShop.Application.Validators.Authentication;

namespace MyShop.Application;

public static class ApplicationServicesRegistration
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });

        // automatic import all validators
        //services.AddValidatorsFromAssemblyContaining<SignUpRequestDtoValidator>();
    }
}