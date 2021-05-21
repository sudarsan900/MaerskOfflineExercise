using System;
using Maersk.Sorting.Interface;
using Maersk.Sorting.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Maersk.Sorting.Api.App_Start
{
    public static class RegisterServiceConfig
    {
        internal static void RegisterDependency(this IServiceCollection services)
        {
            services.AddScoped<ISortService, SortService>();
            services.AddSingleton<ISortJobProcessorService, SortJobProcessorService>();
        }
    }
}
