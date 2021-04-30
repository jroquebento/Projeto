using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto.Repositorio
{
    public class RepositorioFornecedor
    {
        SqlConnection conexaoDB;

        public RepositorioFornecedor()
        {
            conexaoDB = new RepositorioConexaoDB().GetConnection();
        }

        RepositorioCidade repositorioCidade = new RepositorioCidade();

        public bool Insert(Fornecedor fornecedor)
        {
            string queryString =
            "INSERT INTO FORNECEDOR VALUES " +
            "(@codcidade,@nome,@endereco,@num,@bairro,@cep,@contato,@cnpj,@insc,@tel)";
            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@codcidade", fornecedor.Cidade_CodCidade);
                command.Parameters.AddWithValue("@nome", fornecedor.Nome);
                command.Parameters.AddWithValue("@endereco", fornecedor.Endereco);
                command.Parameters.AddWithValue("@num", fornecedor.Num);
                command.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                command.Parameters.AddWithValue("@cep", fornecedor.Cep);
                command.Parameters.AddWithValue("@contato", fornecedor.Contato);
                command.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                command.Parameters.AddWithValue("@insc", fornecedor.Insc);
                command.Parameters.AddWithValue("@tel", fornecedor.Tel);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return true;
        }

        public bool Update(int? idFornecedor,Fornecedor fornecedor)
        {
            string queryString = "UPDATE FORNECEDOR SET " +
                "NOME=(@nome), CIDADE_CODCIDADE = (@codcidade)," +
                "ENDERECO=(@endereco), NUM=(@num), " +
                "BAIRRO=(@bairro), CEP=(@cep), CONTATO=(@contato), CNPJ=(@cnpj), " +
                "INSC=(@insc),TEL=(@tel)" +
                "WHERE CODFORNECEDOR = " + idFornecedor;
            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);                
                command.Parameters.AddWithValue("@codcidade", fornecedor.Cidade_CodCidade);
                command.Parameters.AddWithValue("@nome", fornecedor.Nome);
                command.Parameters.AddWithValue("@endereco", fornecedor.Endereco);
                command.Parameters.AddWithValue("@num", fornecedor.Num);
                command.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                command.Parameters.AddWithValue("@cep", fornecedor.Cep);
                command.Parameters.AddWithValue("@contato", fornecedor.Contato);
                command.Parameters.AddWithValue("@tel", fornecedor.Tel);
                command.Parameters.AddWithValue("@insc", fornecedor.Insc);
                command.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return true;
        }


        public List<Fornecedor> FindAll()
        {
            List<Fornecedor> lista = new List<Fornecedor>();

            string queryString = "SELECT * FROM FORNECEDOR";

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        var fornecedor = new Fornecedor
                        {
                            CodFornecedor = resultado.GetInt32(0),
                            Cidade_CodCidade = resultado.GetInt32(1),
                            Nome = resultado.GetString(2),
                            Endereco = resultado.GetString(3),
                            Num = resultado.GetInt32(4),
                            Bairro = resultado.GetString(5),
                            Cep = resultado.GetString(6),
                            Contato = resultado.GetString(7),
                            Cnpj = resultado.GetString(8),
                            Insc = resultado.GetString(9),
                            Tel = resultado.GetString(10),
                            Cidade = new RepositorioCidade().FindById(resultado.GetInt32(1))
                        };
                        lista.Add(fornecedor);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return lista;
        }

        public Fornecedor FindById(int? idFornecedor)
        {
            string queryString = "SELECT * FROM FORNECEDOR WHERE CODFORNECEDOR = " + idFornecedor;
            Fornecedor fornecedor = new Fornecedor();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        fornecedor.CodFornecedor = resultado.GetInt32(0);
                        fornecedor.Cidade_CodCidade = resultado.GetInt32(1);
                        fornecedor.Nome = resultado.GetString(2);
                        fornecedor.Endereco = resultado.GetString(3);
                        fornecedor.Num = resultado.GetInt32(4);
                        fornecedor.Bairro = resultado.GetString(5);
                        fornecedor.Cep = resultado.GetString(6);
                        fornecedor.Contato = resultado.GetString(7);
                        fornecedor.Cnpj = resultado.GetString(8);
                        fornecedor.Insc = resultado.GetString(9);
                        fornecedor.Tel = resultado.GetString(10);
                        fornecedor.Cidade = new RepositorioCidade().FindById(resultado.GetInt32(1));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return fornecedor;
        }

        public List<Fornecedor> FindByNome(string nome)
        {
            string queryString = "SELECT * FROM Fornecedor WHERE NOME LIKE '%" + nome + "%'";
            List<Fornecedor> lista = new List<Fornecedor>();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();

                    while (resultado.Read())
                    {
                        var fornecedor = new Fornecedor
                        {
                            CodFornecedor = resultado.GetInt32(0),
                            Cidade_CodCidade = resultado.GetInt32(1),
                            Nome = resultado.GetString(2),
                            Endereco = resultado.GetString(3),
                            Num = resultado.GetInt32(4),
                            Bairro = resultado.GetString(5),
                            Cep = resultado.GetString(6),
                            Contato = resultado.GetString(7),
                            Cnpj = resultado.GetString(8),
                            Insc = resultado.GetString(9),
                            Tel = resultado.GetString(10),
                            Cidade = new RepositorioCidade().FindById(resultado.GetInt32(1))
                        };
                        lista.Add(fornecedor);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return lista;
        }
    }
}
