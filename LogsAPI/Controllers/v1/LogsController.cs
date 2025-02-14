using LogsDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using LogsDomain.Interfaces;
using LogsService.Validators;
using LogsDomain.Entities.LogTipos;

namespace LogsApplication.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class LogController(IBaseLogService<LogBase> service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] LogBase log)
    {
        if (log == null) return NotFound();

        var createdLog = await service.Add<LogBaseValidator, LogBase>(log); 
        return Ok(createdLog);
    }

    [HttpPost("PagamentoBoleto")]
    public async Task<IActionResult> CreateLogPagamentoboleto([FromBody] LogPagamentoBoleto log)
    {
        if (log == null) return NotFound();

        var createdLog = await service.Add<LogPagamentoBoletoValidator, LogPagamentoBoleto>(log);
        return Ok(createdLog);
    }

    [HttpPost("TransacaoInterna")]
    public async Task<IActionResult> CreateLogTransacaoInterna([FromBody] LogTransacaoInterna log)
    {
        if (log == null) return NotFound();

        var createdLog = await service.Add<LogTransacaoInternaValidator, LogTransacaoInterna>(log);
        return Ok(createdLog);
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
