using Dapper;
using Projeto04.Entities;
using Projeto04.Helpers;
using Projeto04.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace Projeto04.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly string? _connectionStrig;

        public FuncionarioRepository()
        {
            _connectionStrig = ConfigurationHelpers.GetConnectionString();
        }
        public void Add(Funcionario funcionario)
        {
            var query = @"
                INSERT INTO FUNCIONARIO(IDFUNCIONARIO, NOME, CPF, MATRICULA, DATAADMISSAO, IDEMPRESA)
                VALUES(NEWID(), @Nome, @Cpf, @Matriucla, @DataAdmissao, @IdEmpresa)
            ";

            using (var connection = new SqlConnection(_connectionStrig))
            {
                connection.Execute(query, funcionario);
            }
        }

        public void Delete(Funcionario funcionario)
        {
            var query = @"
                DELETE FROM FUNCIONARIO
                WHERE IDFUNCIONARIO = @IdFuncionario
            ";

            using(var connection = new SqlConnection(_connectionStrig))
            {
                connection.Execute(query, funcionario);
            }
        }

        public List<Funcionario> GetAll()
        {
            var query = @"
                SELECT 
                    IDFUNCIONARIO AS IdFuncionario,
                    NOME AS Nome,
                    CPF AS Cpf,
                    MATRICULA AS Matricula,
                    DATAADMISSAO AS DataAdmissao,
                    IDEMPRESA AS IdEmpresa,
                FORM FUNCIONARIO
                ORDER BY NOME
                        
            ";

            using(var connection = new SqlConnection(_connectionStrig))
            {
                return connection.Query<Funcionario>(query).ToList();
            }
        }

        public Funcionario? GetById(Guid idFuncionario)
        {
            var query = @"
                SELECT 
                    IDFUNCIONARIO AS IdFuncionario,
                    NOME AS Nome,
                    CPF AS Cpf,
                    MATRICULA AS Matricula,
                    DATAADMISSAO AS DataAdmissao,
                    IDEMPRESA AS IdEmpresa
                FROM FUNCIONARIO
                WHERE IDFUNCIONARIO = @idFuncionario
            ";

            using (var connection = new SqlConnection(_connectionStrig))
            {
                return connection.Query<Funcionario>(query, new { idFuncionario }).FirstOrDefault();
            }
        }

        public void Update(Funcionario funcionario)
        {
            var query = @"
                UPDATE FUNCIONARIO
                SET
                    NOME = @Nome,
                    CPF = @Cpf,
                    MATRICULA = @Matricula
                    DATAADMISSAO = @DataAdmissao
                    IDEMPRESA = @IdEmpresa
                WHERE
                    IDFUNCIONARIO = @IdFuncionario
            ";

            using (var connection = new SqlConnection(_connectionStrig))
            {
                connection.Execute(query, funcionario);
            }
        }
    }
}
