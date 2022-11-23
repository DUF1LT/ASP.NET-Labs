using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;
using Models.Repository;
using Models.Services;
using Newtonsoft.Json;
using WebGrease.Css.Extensions;

namespace Lab3.Repository
{
    public class RecordJsonRepository : IRepository<Record>
    {
        private const string JsonFile = "Data\\Data.json";

        private readonly FileService _fileService;

        public RecordJsonRepository()
        {
            _fileService = new FileService();
        }

        public async Task<IReadOnlyCollection<Record>> GetAllAsync()
        {
            var records = await GetStorageAsync();

            return records.ToSafeReadOnlyCollection();
        }

        public async Task<Record> GetAsync(string id)
        {
            var records = await GetStorageAsync();
            var result = records.FirstOrDefault(r => r.Id == id);

            return result;
        }

        public async Task AddAsync(Record entity)
        {
            var records = await GetStorageAsync();

            records.Add(entity);

            await WriteToStorageAsync(records.ToSafeReadOnlyCollection());
        }

        public async Task EditAsync(Record entity)
        {
            var records = await GetStorageAsync();

            var result = records.FirstOrDefault(r => r.Id == entity.Id);
            if (result is null)
            {
                return;
            }

            result.Phone = entity.Phone;
            result.Surname = entity.Surname;

            await WriteToStorageAsync(records.ToSafeReadOnlyCollection());
        }

        public async Task DeleteAsync(string id)
        {
            var records = await GetStorageAsync();

            var result = records.Where(r => r.Id != id).ToList();

            await WriteToStorageAsync(result.ToSafeReadOnlyCollection());
        }


        private async Task<ICollection<Record>> GetStorageAsync()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + JsonFile;

            var content = await _fileService.ReadFileAsync(filePath);

            var records = JsonConvert.DeserializeObject<ICollection<Record>>(content);

            return records ?? new List<Record>();
        }

        private async Task WriteToStorageAsync(IReadOnlyCollection<Record> records)
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + JsonFile;

            var json = JsonConvert.SerializeObject(records);

            await _fileService.WriteFileAsync(filePath, json);
        }

    }
}