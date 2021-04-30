using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto.Repositorio
{
    public class RepositorioCategoria
    {
        SqlConnection conexaoDB;

        public RepositorioCategoria()
        {
            conexaoDB = new RepositorioConexaoDB().GetConnection();
        }
        
        public void Insert(Categoria categoria)
        {
            string queryString = "INSERT INTO CATEGORIA VALUES (@nome) ";
            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@nome", categoria.Nome);

                try
                {
                    
                    SqlDataReader reader = command.ExecuteReader();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //
        }
        public bool Update(int? idCategoria,Categoria categoria)
        {
            string queryString = "UPDATE CATEGORIA SET NOME=(@nome) WHERE CODCATEGORIA= " + idCategoria;
            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@codcategoria", categoria.CodCategoria);
                command.Parameters.AddWithValue("@nome", categoria.Nome);
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
        public void Delete()
        {
        }

        public List<Categoria> FindAll()
        {

            List<Categoria> lista = new List<Categoria>();

            string queryString = "SELECT * FROM CATEGORIA";
            using (conexaoDB)
            {
               
                SqlCommand command = new SqlCommand(queryString, conexaoDB);

                try
                {
                    
                    SqlDataReader resultado = command.ExecuteReader();

                    while (resultado.Read())
                    {
                        var categoria = new Categoria
                        {
                            CodCategoria = resultado.GetInt32(0),
                            Nome = resultado.GetString(1),
                        };
                        lista.Add(categoria);
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
            return lista;
        }

        public Categoria FindById(int? idCategoria)
        {
            string queryString = "SELECT * FROM CATEGORIA WHERE CODCATEGORIA = " + idCategoria;
            Categoria categoria = new Categoria();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        categoria.CodCategoria = resultado.GetInt32(0);
                        categoria.Nome = resultado.GetString(1);                    
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return categoria;
        }

        public List<Categoria> FindByNome(string nome) 
        {
            string queryString = "SELECT * FROM Categoria WHERE NOME LIKE '%" + nome + "%'";
            List<Categoria> lista = new List<Categoria>();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();

                    while (resultado.Read()) 
                    {
                        var categoria = new Categoria
                        {
                            CodCategoria = resultado.GetInt32(0),
                            Nome = resultado.GetString(1)
                        };
                        lista.Add(categoria);
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
