using Lab8.Creator;
using Lab8.DataSource;
using Lab8.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers;

[ApiController]
[Route("api/dict")]
public class DictApiController : ControllerBase
{
    private readonly IRepository<Record> _repository;

    public DictApiController(IRepository<Record> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Record>>> Get()
    {
        var records = await _repository.GetAllAsync();
        var sortedRecords = records.OrderBy(r => r.Surname).ToList();

        return sortedRecords;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Record>> Get(string id)
    {
        var record = await _repository.GetAsync(id);

        return record;
    }

    [HttpPost]
    public async Task Post(RecordViewModel viewModel)
    {
        var record = RecordCreator.CreateFrom(viewModel);
        record.Id = Guid.NewGuid().ToString();

        await _repository.AddAsync(record);
    }

    [HttpPut("{id}")]
    public async Task Put(string id, RecordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return;
        }

        var record = RecordCreator.CreateFrom(id, model);
        await _repository.EditAsync(record);
    }

    [HttpDelete("{id}")]
    public async Task Delete(string id)
    {
        var record = await _repository.GetAsync(id);
        if (record is null)
        {
            return;
        }

        await _repository.DeleteAsync(id);
    }
}