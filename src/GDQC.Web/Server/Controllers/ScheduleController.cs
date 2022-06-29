using AutoMapper;
using GDQC.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GDQC.Web.Server.Controllers;
[ApiController]
[Route("[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleService _service;
    private readonly IMapper _mapper;

    public ScheduleController(IScheduleService parser, IMapper mapper)
    {
        _service = parser;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ScheduleView> Get()
    {
        try
        {

            return await _service.GetScheduleAsync();
        }
        catch (Exception e)
        {
            throw;
        }
    }
}
