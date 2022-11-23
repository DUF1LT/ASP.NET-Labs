using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Lab3.DbContext;
using Models.Models;
using Models.Repository;

namespace DbDataProvider
{
    public class RecordDbRepository : IRepository<Record>
    {
        private readonly DictionaryDbContext _dbContext;
        private readonly DbSet<Record> _records;

        public RecordDbRepository()
        {
            _dbContext = new DictionaryDbContext();
            _records = _dbContext.Records;
        }

        public async Task<IReadOnlyCollection<Record>> GetAllAsync()
        {
            var records = _records.ToList();

            var result = await Task.FromResult(records);

            return result;
        }

        public async Task<Record> GetAsync(string id)
        {
            var record = _records.FirstOrDefault(r => r.Id == id);

            var result = await Task.FromResult(record);

            return result;
        }

        public async Task AddAsync(Record entity)
        {
            _records.Add(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Record entity)
        {
            var result = _records.FirstOrDefault(r => r.Id == entity.Id);
            if (result is null)
            {
                return;
            }

            result.Phone = entity.Phone;
            result.Surname = entity.Surname;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var result = _records.FirstOrDefault(r => r.Id == id);
            if (result is null)
            {
                return;
            }

            _records.Remove(result);

            await _dbContext.SaveChangesAsync();
        }
    }
}