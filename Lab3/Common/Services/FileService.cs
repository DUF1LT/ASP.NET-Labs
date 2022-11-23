using System.IO;
using System.Threading.Tasks;

namespace Models.Services
{
    public class FileService
    {
        public async Task<string> ReadFileAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath))
                { }
            }

            using (var reader = new StreamReader(filePath))
            {
                var content = await reader.ReadToEndAsync();

                return content;
            }
        }

        public async Task WriteFileAsync(string filePath, string content)
        {
            using (File.Create(filePath))
            { }

            using (var writer = new StreamWriter(filePath))
            {
                await writer.WriteLineAsync(content);
            }
        }
    }
}