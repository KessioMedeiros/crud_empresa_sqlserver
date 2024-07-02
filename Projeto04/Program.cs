
using Projeto04.Controllers;
using Projeto04.Repositories;



namespace Projeto04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nPROJETO PARA CONTROLE DE EMPRESAS E FUNCIONARIOS\n");

            Console.WriteLine("(1) CADASTRAR EMPRESAS");
            Console.WriteLine("(2) ATUALIZAR EMPRESAS");
            Console.WriteLine("(3) EXCLUIR EMPRESAS");
            Console.WriteLine("(4) CONSULTAR EMPRESAS");

            Console.WriteLine("\nINFORME A OPCAO DESEJADA: ");
            var opcao = int.Parse(Console.ReadLine());

            var empressaController = new EmpresaController();

            switch (opcao)
            {
                case 1:
                    empressaController.CadastrarEmpresa();
                    break;
                case 2:
                    empressaController.AtualizarEmpresa();
                    break;
                case 3:
                    empressaController.ExcluirEmpresa();
                    break;
                case 4:
                    empressaController.ConsultarEmpresa();
                    break;
            }

            Console.Write("\nDESEJA CONTINUAR? (S,N): ");
            var continuar = Console.ReadLine();
            if (continuar.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Main(args);
            }
            else
            {
                Console.WriteLine("\nFIM DO PROGRAMA!");
            }
        }
    }
}