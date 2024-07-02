using Projeto04.Entities;
using Projeto04.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Controllers
{
    public class EmpresaController
    {
        private readonly EmpresaRepository? _empresaRepository;

        public EmpresaController()
        {
            _empresaRepository = new EmpresaRepository();        
        }

        public void CadastrarEmpresa()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE EMPRESA:\n");

                var empresa = new Empresa();

                Console.Write("ENTRE COM O NOME FANTASIA................: ");
                empresa.NomeFantasia = Console.ReadLine();

                Console.Write("ENTRE COM A RAZAO SOCIAL.................: ");
                empresa.RazaoSocial = Console.ReadLine();

                Console.Write("ENTRE COM O CNPJ.........................: ");
                empresa.Cnpj = Console.ReadLine();

                _empresaRepository.Add(empresa);

                Console.WriteLine("\nEMPRESA GRAVADA COM SUCESSO!\n");


            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nFALHA AO CADASTRAR EMPRESA: " + e.Message);
            }
        }

        public void AtualizarEmpresa()
        {
            try
            {
                Console.WriteLine("\nEDICAO DE EMPRESA:\n");

                Console.Write("ENTRE COM O ID DA EMPRESA................: ");
                
                var idEmpresa = Guid.Parse(Console.ReadLine());
                
                var empresa = _empresaRepository.GetById(idEmpresa);

                if(empresa != null)
                {
                    Console.WriteLine("\nDADOS DA EMPRESA: ");
                    Console.WriteLine($"\tID DA EMPRESA.....: {empresa.IdEmpresa}");
                    Console.WriteLine($"\tNOME FANTASIA.....: {empresa.NomeFantasia}");
                    Console.WriteLine($"\tRAZAO SOCIAL......: {empresa.RazaoSocial}");
                    Console.WriteLine($"\tCNPJ..............: {empresa.Cnpj}");

                    Console.WriteLine("\nALTERE OS DADOS DA EMPRESA:\n");

                    Console.Write("ENTRE COM O NOME FANTASIA.........: ");
                    empresa.NomeFantasia = Console.ReadLine();

                    Console.Write("ENTRE COM A RAZAO SOCIAL..........: ");
                    empresa.RazaoSocial = Console.ReadLine();

                    Console.Write("ENTRE COM O CNPJ..................: ");
                    empresa.Cnpj = Console.ReadLine();

                    _empresaRepository.Update(empresa);
                    Console.WriteLine("\nEMPRESA ATUALIZADA COM SUCESSO!");
                }
                else
                {
                    Console.WriteLine("\nEMPRESA NÃO ENCONTRADA.");
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nFALHA AO ATUALIZAR EMPRESA: " + e.Message);
            }
        }


        public void ExcluirEmpresa()
        {
            try
            {
                Console.WriteLine("\nEXCLUSAO DE EMPRESA: \n");

                Console.Write("ENTRE COM O ID DA EMPRESA......: ");
                var idEmpresa = Guid.Parse(Console.ReadLine());
                var empresa = _empresaRepository.GetById(idEmpresa);

                if (empresa != null)
                {
                    Console.WriteLine("\nDADOS DA EMPRESA: ");
                    Console.WriteLine($"\tID DA EMPRESA..........: {empresa.IdEmpresa} ");
                    Console.WriteLine($"\tNOME FANTASIA..........: {empresa.NomeFantasia} ");
                    Console.WriteLine($"\tRAZAO SOCIAL...........: {empresa.RazaoSocial} ");
                    Console.WriteLine($"\tCNPJ...................: {empresa.Cnpj} ");

                    Console.WriteLine("\nDESEJA EXCLUIR ESSA EMPRESA? (S,N): ");
                    var opcao = Console.ReadLine();

                    if(opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                    {
                        _empresaRepository.Delete(empresa);
                        Console.WriteLine("EMPRESA EXCLUIDA COM SUCESSO!");
                    }
                    else
                    {
                        Console.WriteLine("\nOPERACAO CANCELADA!");
                    }
                }
                else
                {
                    Console.WriteLine("\nEMPRESA NÃO ENCONTRADA.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nFALHA AO EXCLUIR EMPRESA: " + e.Message);
            }
        }

        public void ConsultarEmpresa()
        {
            try
            {
                Console.WriteLine("\nCONSULTAR EMPRESAS: \n");

                var empresas = _empresaRepository.GetAll();

                foreach(var item in empresas)
                {
                    Console.WriteLine($"ID EMPRESA.........: {item.IdEmpresa}");
                    Console.WriteLine($"NOME FANTASIA......: {item.NomeFantasia}");
                    Console.WriteLine($"RAZAO SOCIAL.......: {item.RazaoSocial}");
                    Console.WriteLine($"CNPJ...............: {item.Cnpj}");
                    Console.WriteLine("...");
                }

                Console.WriteLine($"\nQUANTIDADE DE EMPRESAS: {empresas.Count}");

            }
            catch(ArgumentException e)
            {
                Console.WriteLine("\nFALHA AO CONSULTAR EMPRESA: " + e.Message);
            }
        }

    }
}
