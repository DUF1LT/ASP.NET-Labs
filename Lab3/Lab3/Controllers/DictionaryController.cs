using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using Lab3.Creators;
using Lab3.Models;
using Lab3.Repository;
using Lab3.ViewModels;

namespace Lab3.Controllers
{
    public class DictionaryController : Controller
    {
        private readonly IRepository<Record> _repository;

        public DictionaryController()
        {
            var shouldUseDb = bool.Parse(WebConfigurationManager.AppSettings["UseDatabase"]);

            if (shouldUseDb)
            {
                _repository = new RecordDbRepository();
            }
            else
            {
                _repository = new RecordJsonRepository();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var records = await _repository.GetAllAsync();
            var sortedRecords = records.OrderBy(r => r.Surname).ToList();

            return View(sortedRecords);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new RecordViewModel());
        }

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

        [HttpPost]
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

        [HttpGet]
        public ActionResult NotFound()
        {
            ViewData["Context"] = HttpContext;

            return View("NotFound");
        }
    }
}