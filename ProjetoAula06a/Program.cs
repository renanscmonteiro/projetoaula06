using ProjetoAula06a.Controllers;

namespace ProjetoAula06a
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var contatoController = new ContatoController();
            contatoController.CadastrarContato();

            Console.ReadKey();
        }
    }
}