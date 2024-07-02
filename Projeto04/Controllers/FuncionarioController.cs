using Projeto04.Entities;
using Projeto04.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Controllers
{
    public class FuncionarioController
    {
        private readonly FuncionarioRepository _funcionarioRepository;

        public FuncionarioController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        public void CadastrarEmpresa()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE FUNCIONARIO:\n");

                var funcioario = new Funcionario();

                Console.Write("ENTRE COM O NOME................: ");
                funcioario.Nome = Console.ReadLine();

                Console.Write("ENTRE COM O CPF.................: ");
                funcioario.Cpf = Console.ReadLine();

                Console.Write("ENTRE COM A MATRICULA.........................: ");
                funcioario.Matricula = Console.ReadLine();

                Console.Write("ENTRE COM A DATA ADMISSAO.........................: ");
                funcioario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                _funcionarioRepository.Add(funcioario);

                Console.WriteLine("\nFUNCIONARIO GRAVADO COM SUCESSO!\n");


            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nFALHA AO CADASTRAR FUNCIONARIO: " + e.Message);
            }
        }


    }
}
