using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Helpers
{
    public static class ConfigurationHelpers
    {
        public static string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            //retornando o valor da connectionstring contida no arquivo
            return configuration.GetConnectionString("Projeto04");
        }
    }
}
