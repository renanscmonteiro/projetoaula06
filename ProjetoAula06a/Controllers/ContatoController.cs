using ProjetoAula06a.Entities;
using ProjetoAula06a.Helpers;
using ProjetoAula06a.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula06a.Controllers
{
    public class ContatoController
    {
        public void CadastrarContato()
        {
            try
            {
                Console.WriteLine("\n*** CADASTRO DE CONTATOS ***\n");

                var contato = new Contato()
                {
                    IdContato = Guid.NewGuid(),
                    Nome = InputHelper.Get("Entre com o nome do contato.........: "),
                    Email = InputHelper.Get("Entre com o email do contato........: "),
                    Cpf = InputHelper.Get("Entre com o cpf do contato..........: "),
                    Telefone = InputHelper.Get("Entre com o telefone do contato.....: ")
                };
                // verificar se o objeto Contato está correto (validação)
                var validationResult = contato.validate;
                // verificar se o objeto não possui erros
                if (validationResult.IsValid)
                {
                    var opcao = InputHelper.Get("Deseja salvar em 1 (XML) ou 2 (JSON) ?");

                    BaseRepository<Contato> repository; // Objeto genérico

                    switch (int.Parse(opcao))
                    {
                        case 1: //XML
                            repository = new ContatoRepositoryXml(); // Poliformismo
                            break;

                        case 2: //JSON
                            repository = new ContatoRepositoryJson(); // Poliformismo
                            break;
                        default:
                            throw new ArgumentException("Opção inválida");
                    }
                    // Exportando os dados do contato
                    repository.Exportar(contato);

                    if (repository is ContatoRepositoryXml)
                        Console.WriteLine("\nDados exportados em XML com sucesso!");
                    else if (repository is ContatoRepositoryJson)
                        Console.WriteLine("\nDados exportados em JSON com sucesso!");
                }
                else
                {
                    // Imprimindo os erros de validação
                    Console.WriteLine("\nOcorreram erros de validação no preencimento dos dados:");
                    foreach (var item in validationResult.Errors)
                    {
                        Console.WriteLine($"\t * {item.ErrorMessage}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha: {e.Message}");
            }
            finally
            {
                var opcao = InputHelper.Get("\nDeseja repetir o processo? (S,N): ");

                if (opcao != null && opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                    CadastrarContato(); //Recursividade
            }
        }
    }
}