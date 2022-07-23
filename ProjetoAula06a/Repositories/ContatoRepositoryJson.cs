using Newtonsoft.Json;
using ProjetoAula06a.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula06a.Repositories
{
    /// <summary>
    /// Classe para exportação de dados de contato para o formato JSON
    /// </summary>
    public class ContatoRepositoryJson : BaseRepository<Contato>
    {
        public override void Exportar(Contato obj)
        {
            // Serializando os dados para o formato JSON
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);

            //Abrindo o arquivo e gravando os dados
            using (var streamWriter = new StreamWriter($"G:\\Meu Drive\\Estudos\\Curso - Webdeveloper C#.NET\\WebDeveloper C#.NET (2022)\\ProjetoAula06a\\ArquivosJson\\{obj.IdContato}.json"))
            {
                streamWriter.WriteLine(json);
            }
        }
    }
}