using Dapper;
using Microsoft.Extensions.Configuration;
using Projeto04.Entities;
using Projeto04.Helpers;
using Projeto04.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly string? _connectionString;

        public EmpresaRepository()
        {
            _connectionString = ConfigurationHelpers.GetConnectionString();
        }
        public void Add(Empresa empresa)
        {
            var query = @"
                INSERT INTO EMPRESA(IDEMPRESA, NOMEFANTASIA, RAZAOSOCIAL, CNPJ)
                VALUES(NEWID(), @NomeFantasia, @RazaoSocial, @Cnpj)
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, empresa);
            }
        }

        public void Delete(Empresa empresa)
        {
            var query = @"
                DELETE FROM EMPRESA
                WHERE IDEMPRESA = @IdEmpresa
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, empresa);
            }
        }

        public List<Empresa> GetAll()
        {
            var query = @"
                SELECT 
                    IDEMPRESA AS IdEmpresa,
                    NOMEFANTASIA AS NomeFantasia,
                    RAZAOSOCIAL AS RazaoSocial,
                    CNPJ AS Cnpj
                FROM EMPRESA
                ORDER BY NOMEFANTASIA
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Empresa>(query).ToList();
            }
        }

        public Empresa? GetById(Guid idEmpresa)
        {
            var query = @"
                SELECT 
                    IDEMPRESA AS IdEmpresa,
                    NOMEFANTASIA AS NomeFantasia,
                    RAZAOSOCIAL AS RazaoSocial,
                    CNPJ AS Cnpj
                FROM EMPRESA
                WHERE IDEMPRESA = @idEmpresa
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Empresa>(query, new { idEmpresa }).FirstOrDefault();
            }
        }

        public void Update(Empresa empresa)
        {
            var query = @"
                UPDATE EMPRESA
                SET
                    NOMEFANTASIA = @NomeFantasia,
                    RAZAOSOCIAL = @RazaoSocial,
                    Cnpj = @Cnpj
                WHERE
                    IDEMPRESA = @IdEmpresa
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, empresa);
            }
        }
    }
}
