using LogsDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using LogsDomain.Interfaces;
using LogsService.Validators;

namespace LogsApplication.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class LogController(IBaseLogService<LogBase> service) : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] LogBase log)
    {
        return log == null ? NotFound() : Execute(() => service.Add<LogBaseValidator>(log));
    }

    [HttpPut]
    public IActionResult Update([FromBody] LogBase log)
    {
        if (log == null) return NotFound();

        return Execute(() => service.Update<LogBaseValidator>(log));

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (id == 0) return NotFound();

        Execute(() =>
        {
            service.Delete(id);
            return true;
        });

        return NoContent();
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Execute(service.Get);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (id == 0) return NotFound();

        return Execute(() => service.GetById(id));
    }

    private IActionResult Execute(Func<object> func)
    {
        try
        {
            var result = func();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
