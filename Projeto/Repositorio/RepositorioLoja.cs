using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto.Repositorio
{
    public class RepositorioLoja
    {
        SqlConnection conexaoDB;

        public RepositorioLoja()
        {
            conexaoDB = new RepositorioConexaoDB().GetConnection();
        }

        RepositorioCidade repositorioCidade = new RepositorioCidade();
        public bool Insert(Loja loja)
        {
            string queryString =
            "INSERT INTO LOJA VALUES " +
            "(@codcidade,@nome,@endereco,@num, @bairro, @tel, @insc, @cnpj)";

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@codcidade", loja.Cidade_CodCidade);
                command.Parameters.AddWithValue("@nome", loja.Nome);
                command.Parameters.AddWithValue("@endereco", loja.Endereco);
                command.Parameters.AddWithValue("@num", loja.Num);
                command.Parameters.AddWithValue("@bairro", loja.Bairro);
                command.Parameters.AddWithValue("@tel", loja.Tel);
                command.Parameters.AddWithValue("@insc", loja.Insc);
                command.Parameters.AddWithValue("@cnpj", loja.Cnpj);

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

        public bool Update(int? idLoja, Loja loja)
        {
            string queryString = "UPDATE LOJA SET " +
                "NOME=(@nome), CIDADE_CODCIDADE = (@codcidade), " +
                "ENDERECO=(@endereco), NUM=(@num), " +
                "BAIRRO=(@bairro), TEL=(@tel), INSC=(@insc), CNPJ=(@cnpj) " +
                "WHERE CODLOJA = " + idLoja;
            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);             
                command.Parameters.AddWithValue("@codcidade", loja.Cidade_CodCidade);
                command.Parameters.AddWithValue("@nome", loja.Nome);
                command.Parameters.AddWithValue("@endereco", loja.Endereco);
                command.Parameters.AddWithValue("@num", loja.Num);
                command.Parameters.AddWithValue("@bairro", loja.Bairro);
                command.Parameters.AddWithValue("@tel", loja.Tel);
                command.Parameters.AddWithValue("@insc", loja.Insc);
                command.Parameters.AddWithValue("@cnpj", loja.Cnpj);

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

        public List<Loja> FindAll()
        {
            List<Loja> lista = new List<Loja>();
            string queryString = "SELECT * FROM LOJA";

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        var loja = new Loja
                        {
                            CodLoja = resultado.GetInt32(0),
                            Cidade_CodCidade = resultado.GetInt32(1) ,
                            Nome = resultado.GetString(2),
                            Endereco = resultado.GetString(3),
                            Num = resultado.GetInt32(4),
                            Bairro = resultado.GetString(5),
                            Tel = resultado.GetString(6),
                            Insc = resultado.GetString(7),
                            Cnpj = resultado.GetString(8),
                            Cidade = new RepositorioCidade().FindById(resultado.GetInt32(1))
                        };
                        lista.Add(loja);
                    }
                    
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return lista;
        }

        public Loja FindById(int? idLoja)
        {
            string queryString = "SELECT * FROM LOJA " +
                                 "WHERE CODLOJA = " + idLoja;

            Loja loja = new Loja();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();

                    while (resultado.Read())
                    {
                        loja.CodLoja = resultado.GetInt32(0);
                        loja.Cidade_CodCidade = resultado.GetInt32(1);
                        loja.Nome = resultado.GetString(2);
                        loja.Endereco = resultado.GetString(3);
                        loja.Num = resultado.GetInt32(4);
                        loja.Bairro = resultado.GetString(5);
                        loja.Tel = resultado.GetString(6);
                        loja.Insc = resultado.GetString(7);
                        loja.Cnpj = resultado.GetString(8);                                                            
                        loja.Cidade = new RepositorioCidade().FindById(resultado.GetInt32(1));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return loja;
        }

        public List<Loja> FindByNome(string nome)
        {
            string queryString = "SELECT * FROM Loja WHERE NOME LIKE '%" + nome + "%'";
            List<Loja> lista = new List<Loja>();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();

                    while (resultado.Read())
                    {
                        var loja = new Loja
                        {
                            CodLoja = resultado.GetInt32(0),
                            Cidade_CodCidade = resultado.GetInt32(1),
                            Nome = resultado.GetString(2),
                            Endereco = resultado.GetString(3),
                            Num = resultado.GetInt32(4),
                            Bairro = resultado.GetString(5),
                            Tel = resultado.GetString(6),
                            Insc = resultado.GetString(7),
                            Cnpj = resultado.GetString(8),
                            Cidade = new RepositorioCidade().FindById(resultado.GetInt32(1))
                        };
                        lista.Add(loja);
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
