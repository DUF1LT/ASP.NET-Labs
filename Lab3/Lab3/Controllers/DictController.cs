using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Lab3.Creators;
using Lab3.ViewModels;
using Models.Models;
using Models.Repository;

namespace Lab3.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DictController : ApiController
    {
        private readonly IRepository<Record> _repository;

        public DictController(IRepository<Record> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Record>> Get()
        {
            var records = await _repository.GetAllAsync();
            var sortedRecords = records.OrderBy(r => r.Surname).ToList();

            return sortedRecords;
        }

        public async Task Post(RecordViewModel viewModel)
        {
            var record = RecordCreator.CreateFrom(viewModel);
            record.Id = Guid.NewGuid().ToString();

            await _repository.AddAsync(record);
        }

        public async Task Put(RecordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            var record = RecordCreator.CreateFrom(model);
            await _repository.EditAsync(record);
        }

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
}