using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extensions
{
    public static class FileExtensions
    {
        /// <summary>
        /// Lê o arquivo e retorna as linhas em uma lista
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static async Task<List<string>> ToListAsync(this IFormFile formFile)
        {
            var linhasParaLeitura = new List<string>();
            using (var reader = new StreamReader(formFile.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    linhasParaLeitura.Add(await reader.ReadLineAsync());
            }
            return linhasParaLeitura;
        }
    }
}
