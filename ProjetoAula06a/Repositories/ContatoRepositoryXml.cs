using ProjetoAula06a.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoAula06a.Repositories
{
    /// <summary>
    /// Classe para exportação de dados de contato para o formato XML
    /// </summary>
    public class ContatoRepositoryXml : BaseRepository<Contato>
    {
        public override void Exportar(Contato obj)
        {
            // Serializar os dados para arquivos XML
            var xml = new XmlSerializer(obj.GetType());

            // Abrindo um arquivo para gravar os dados
            using (var streamWriter = new StreamWriter($"G:\\Meu Drive\\Estudos\\Curso - Webdeveloper C#.NET\\WebDeveloper C#.NET (2022)\\ProjetoAula06a\\ArquivosXml\\{obj.IdContato}.xml"))
            {
                xml.Serialize(streamWriter, obj);
            }
        }
    }
}