using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto.Repositorio
{
    public class RepositorioCidade
    {
        SqlConnection conexaoDB;

        public RepositorioCidade()
        {
            conexaoDB = new RepositorioConexaoDB().GetConnection();
        }
        public bool Insert(Cidade cidade)
        {
            string queryString =
            "INSERT INTO Cidade VALUES (@nome,@uf) ";

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@nome", cidade.Nome);
                command.Parameters.AddWithValue("@uf", cidade.Uf);
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

        public bool Update(int? idCidade, Cidade cidade)
        {
            string queryString = "UPDATE CIDADE SET NOME=(@nome),UF = (@uf) WHERE CODCIDADE = " + idCidade;
                 
            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@nome", cidade.Nome);
                command.Parameters.AddWithValue("@uf", cidade.Uf);

                try
                {
                    SqlDataReader resultado = command.ExecuteReader();                
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return true;
        }

        public List<Cidade> FindAll()
        {
            List<Cidade> lista = new List<Cidade>();
            string queryString = "SELECT * FROM CIDADE";

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        var cidade = new Cidade
                        {
                            CodCidade = resultado.GetInt32(0),
                            Nome = resultado.GetString(1),
                            Uf = resultado.GetString(2)
                        };
                        lista.Add(cidade);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return lista;
        }

        public Cidade FindById(int? idCidade)
        {
            string queryString = "SELECT * FROM CIDADE WHERE CODCIDADE = " + idCidade;
            Cidade cidade = new Cidade();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        cidade.CodCidade = resultado.GetInt32(0);
                        cidade.Nome = resultado.GetString(1);
                        cidade.Uf = resultado.GetString(2);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return cidade;
        }

        public List<Cidade> FindByNome(string nome)
        {
            string queryString = "SELECT * FROM Cidade WHERE NOME LIKE '%" + nome + "%'";
            List<Cidade> lista = new List<Cidade>();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();

                    while (resultado.Read())
                    {
                        var cidade = new Cidade
                        {
                            CodCidade = resultado.GetInt32(0),
                            Nome = resultado.GetString(1),
                            Uf = resultado.GetString(2)
                        };
                        lista.Add(cidade);
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
