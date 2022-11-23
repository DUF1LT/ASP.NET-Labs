using Lab8.Creator;
using Lab8.DataSource;
using Lab8.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers;

[Controller]
// [Route("Dict")]
public class DictionaryMvcController : Controller
{
    private readonly IRepository<Record> _repository;

    public DictionaryMvcController(IRepository<Record> repository)
    {
        _repository = repository;
    }

    // [HttpGet("records")]
    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var records = await _repository.GetAllAsync();
        var sortedRecords = records.OrderBy(r => r.Surname).ToList();

        return View(sortedRecords);
    }

    // [HttpGet("addPage")]
    [HttpGet]
    public ActionResult Add()
    {
        return View(new RecordViewModel());
    }

    // [HttpPost("record")]
    [HttpPost]
    public async Task<ActionResult> Add(RecordViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var record = RecordCreator.CreateFrom(viewModel);

        await _repository.AddAsync(record);

        return RedirectToAction("Index");
    }

    // [HttpGet("updatePage")]
    [HttpGet]
    public async Task<ActionResult> Update(string id)
    {
        var record = await _repository.GetAsync(id);
        if (record is null)
        {
            return View("EntityNotFound", (object)id);
        }

        var recordViewModel = RecordCreator.CreateFrom(record);

        return View((id, recordViewModel));
    }

    // [HttpPost("record/{id}")]
    [HttpPost]
    public async Task<ActionResult> Update(string id, RecordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View((id, model));
        }

        var record = RecordCreator.CreateFrom(id, model);

        await _repository.EditAsync(record);

        return RedirectToAction("Index");
    }

    // [HttpGet("deletePage")]
    [HttpGet]
    public async Task<ActionResult> DeleteConfirmation(string id)
    {
        var record = await _repository.GetAsync(id);
        if (record is null)
        {
            return View("EntityNotFound", (object)id);
        }

        return View(record);
    }

    // [HttpDelete("record/{id}")]
    [HttpDelete]
    public async Task<ActionResult> Delete(string id)
    {
        var record = await _repository.GetAsync(id);
        if (record is null)
        {
            return View("EntityNotFound", (object)id);
        }

        await _repository.DeleteAsync(id);

        return RedirectToAction("Index");
    }

    [NonAction]
    public IActionResult NotFound()
    {
        ViewData["Context"] = HttpContext;

        return Content("Not Found");
    }
}