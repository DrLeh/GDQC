global using GDQC.Contracts;
global using Refit;

namespace GDQC.Client;



public interface IGdqcApi
{
    [Get("/schedule")]
    Task<ScheduleView> GetScheduleAsync();
}


public class GdqcClient : IScheduleService
{
    private readonly IGdqcApi _api;

    public GdqcClient(IGdqcApi api)
    {
        _api = api;
    }

    public async Task<ScheduleView> GetScheduleAsync()
    {
        return await _api.GetScheduleAsync();
    }

}

