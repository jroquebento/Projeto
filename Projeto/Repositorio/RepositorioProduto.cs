using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto.Repositorio
{
    public class RepositorioProduto
    {
        SqlConnection conexaoDB;

        public RepositorioProduto()
        {
            conexaoDB = new RepositorioConexaoDB().GetConnection();
        }

        public bool Insert(Produto produto)
        {
            string queryString =
            "INSERT INTO PRODUTO VALUES " +
            "(@codcategoria,@codfornecedor,@descricao,@peso,@controlado,@qtdemin)";

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@codcategoria", produto.Categoria_CodCategoria);
                command.Parameters.AddWithValue("@codfornecedor", produto.Fornecedor_CodFornecedor);
                command.Parameters.AddWithValue("@descricao", produto.Descricao);
                command.Parameters.AddWithValue("@peso", produto.Peso);
                command.Parameters.AddWithValue("@controlado", produto.Controlado);
                command.Parameters.AddWithValue("@qtdemin", produto.QtdeMin);

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
        public bool Update(int? idProduto,Produto produto)
        {
            string queryString = "UPDATE PRODUTO SET " +
                "Categoria_CodCategoria = (@codcategoria)," +
                "Fornecedor_CodFornecedor = (@codfornecedor), DESCRICAO=(@descricao)," +
                "PESO=(@peso), CONTROLADO=(@controlado), " +
                "QTDEMIN=(@qtdemin) WHERE CODPRODUTO = " + idProduto;
            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);           
                command.Parameters.AddWithValue("@codcategoria", produto.Categoria_CodCategoria);
                command.Parameters.AddWithValue("@codfornecedor", produto.Fornecedor_CodFornecedor);
                command.Parameters.AddWithValue("@descricao", produto.Descricao);
                command.Parameters.AddWithValue("@peso", produto.Peso);
                command.Parameters.AddWithValue("@controlado", produto.Controlado);
                command.Parameters.AddWithValue("@qtdemin", produto.QtdeMin);

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

        public List<Produto> FindAll()
        {
            string queryString = "SELECT * FROM PRODUTO";
            List<Produto> lista = new List<Produto>();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        var produto = new Produto
                        {
                            CodProduto = resultado.GetInt32(0),
                            Categoria_CodCategoria = resultado.GetInt32(1),
                            Fornecedor_CodFornecedor = resultado.GetInt32(2),
                            Descricao = resultado.GetString(3),
                            Peso = resultado.GetDecimal(4),
                            Controlado = resultado.GetBoolean(5),
                            QtdeMin = resultado.GetInt32(6),
                            Categoria = new RepositorioCategoria().FindById(resultado.GetInt32(1)),
                            Fornecedor = new RepositorioFornecedor().FindById(resultado.GetInt32(2))
                        };
                        lista.Add(produto);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return lista;
        }

        public Produto FindById(int? idProduto)
        {
            string queryString = "SELECT * FROM PRODUTO WHERE CODPRODUTO = " + idProduto;
            Produto produto = new Produto();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        produto.CodProduto = resultado.GetInt32(0);
                        produto.Categoria_CodCategoria = resultado.GetInt32(1);
                        produto.Fornecedor_CodFornecedor = resultado.GetInt32(2);
                        produto.Descricao = resultado.GetString(3);
                        produto.Peso = resultado.GetDecimal(4);
                        produto.Controlado = resultado.GetBoolean(5);
                        produto.QtdeMin = resultado.GetInt32(6);
                        produto.Categoria = new RepositorioCategoria().FindById(resultado.GetInt32(1));
                        produto.Fornecedor = new RepositorioFornecedor().FindById(resultado.GetInt32(2));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return produto;
        }

        public List<Produto> FindByDescricao(string descricao)
        {
            string queryString = "SELECT * FROM Produto WHERE DESCRICAO LIKE '%" + descricao + "%'";
            List<Produto> lista = new List<Produto>();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();

                    while (resultado.Read())
                    {
                        var produto = new Produto
                        {
                            CodProduto = resultado.GetInt32(0),
                            Categoria_CodCategoria = resultado.GetInt32(1),
                            Fornecedor_CodFornecedor = resultado.GetInt32(2),
                            Descricao = resultado.GetString(3),
                            Peso = resultado.GetDecimal(4),
                            Controlado = resultado.GetBoolean(5),
                            QtdeMin = resultado.GetInt32(6),
                            Categoria = new RepositorioCategoria().FindById(resultado.GetInt32(1)),
                            Fornecedor = new RepositorioFornecedor().FindById(resultado.GetInt32(2))
                        };
                        lista.Add(produto);
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
