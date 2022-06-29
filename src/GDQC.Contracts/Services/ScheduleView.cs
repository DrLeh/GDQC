namespace GDQC.Contracts;

public interface IScheduleService
{
    Task<ScheduleView> GetScheduleAsync();
}