using System;
using System.Collections.Generic;
using Aplicacao.Dominio.Entidades;
using Dapper;
using Infraestrutura.Interfaces.Pessoa;
using MySql.Data.MySqlClient;

namespace Infraestrutura.Pessoa
{
    //Responsavel por buscar, atualizar deletar e incluir dados. não deve haver regras de negócio.
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly string _conexaoBanco;
        public PessoaRepositorio(string conexaoBanco)
        {
            _conexaoBanco = conexaoBanco;
        }

        public int Cadastrar(PessoaEntidade objeto)
        {
            string sql = @"INSERT INTO Pessoa (Nome, Endereco, DataNascimento)
                        Values (@Nome, @Endereco, @DataNascimento);";
            using (MySqlConnection connection = new MySqlConnection(_conexaoBanco))
            {
                try
                {
                    return connection.Execute(sql, new { objeto.Nome, objeto.Endereco, objeto.DataNascimento });
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("tomar alguma ação com o exception" + ex.Message);
                    return 0;
                }
            }
        }

        public IEnumerable<PessoaEntidade> ConsultarPorNome(string nome)
        {
            string sql = @"SELECT Id, Nome, Endereco, DataNascimento FROM Pessoa
                        WHERE Nome like @Nome ORDER BY Nome ASC";
            using (MySqlConnection connection = new MySqlConnection(_conexaoBanco))
            {
                return connection.Query<PessoaEntidade>(sql, new { Nome = "%" + nome + "%" });
            }
        }

        public int Deletar(int id)
        {
            string sql = @"DELETE FROM Pessoa WHERE Id = @id";
            using (MySqlConnection connection = new MySqlConnection(_conexaoBanco))
            {
                try
                {
                    return connection.Execute(sql, new { id });
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("tomar alguma ação com o exception" + ex.Message);
                    return 0;
                }
            }
        }

        public PessoaEntidade ConsultarPorId(int id)
        {
            string sql = @"SELECT Id, Nome, Endereco, DataNascimento FROM Pessoa
                        WHERE Id = @id";
            using (MySqlConnection connection = new MySqlConnection(_conexaoBanco))
            {
                return connection.QueryFirst<PessoaEntidade>(sql, new { id });
            }
        }

        public IEnumerable<PessoaEntidade> ListarTodos()
        {
            string sql = @"SELECT Id, Nome, Endereco, DataNascimento FROM Pessoa ORDER BY Nome ASC";
            using (MySqlConnection connection = new MySqlConnection(_conexaoBanco))
            {
                return connection.Query<PessoaEntidade>(sql);
            }
        }

        public int Atualizar(PessoaEntidade objeto)
        {
            string sql = @"UPDATE Pessoa set Nome = @Nome, Endereco = @Endereco, DataNascimento = @DataNascimento
                        WHERE Id = @Id";
            using (MySqlConnection connection = new MySqlConnection(_conexaoBanco))
            {
                try
                {
                    return connection.Execute(sql, new { objeto.Nome, objeto.Endereco, objeto.DataNascimento, objeto.Id });
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("tomar alguma ação com o exception" + ex.Message);
                    return 0;
                }
            }
        }
    }
}
