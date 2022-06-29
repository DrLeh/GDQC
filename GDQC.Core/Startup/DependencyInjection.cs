using GDQC.Contracts;
using GDQC.Core.MappingProfiles;

namespace GDQC.Core;

public static class DependencyInjection
{
    public static void AddCore(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ScheduleProfile).Assembly);

        services.AddSingleton<IScheduleService, ScheduleService>();
    }
}
