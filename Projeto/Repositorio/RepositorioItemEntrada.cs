using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto.Repositorio
{
    public class RepositorioItemEntrada
    {
        SqlConnection conexaoDB;

        public RepositorioItemEntrada()
        {
            conexaoDB = new RepositorioConexaoDB().GetConnection();
        }
        public bool Insert(ItemEntrada itemEntrada )
        {
            string queryString =
            "INSERT INTO ITEMENTRADA VALUES " +
            "(@codproduto, @codentrada, @lote,@qtde, @valor)";

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@codproduto", itemEntrada.Produto_CodProduto);
                command.Parameters.AddWithValue("@codentrada", itemEntrada.Entrada_CodEntrada);
                command.Parameters.AddWithValue("@lote", itemEntrada.Lote);
                command.Parameters.AddWithValue("@qtde", itemEntrada.Qtde);
                command.Parameters.AddWithValue("@valor", itemEntrada.Valor);

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

        public bool Update(ItemEntrada itemEntrada)
        {
            string queryString = "UPDATE ITEMENTRADA SET " +
                "LOTE=(@lote)," +
                "QTDE=(@qtde), VALOR=(@valor) WHERE CODITEMENTRADA=(@coditementrada)";
            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@coditementrada", itemEntrada.CodItemEntrada);
                command.Parameters.AddWithValue("@codproduto", itemEntrada.Produto.CodProduto );
                command.Parameters.AddWithValue("@codentrada", itemEntrada.Entrada.CodEntrada);
                command.Parameters.AddWithValue("@lote", itemEntrada.Lote);
                command.Parameters.AddWithValue("@qtde", itemEntrada.Qtde);
                command.Parameters.AddWithValue("@valor", itemEntrada.Valor);

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

        public List<ItemEntrada> FindAll()
        {
            string queryString = "SELECT * FROM ITEMENTRADA";
            List<ItemEntrada> lista = new List<ItemEntrada>();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        var itemEntrada = new ItemEntrada
                        {
                            CodItemEntrada = resultado.GetInt32(0),
                            Produto_CodProduto = resultado.GetInt32(1),
                            Entrada_CodEntrada = resultado.GetInt32(2),                           
                            Lote = resultado.GetString(3),
                            Qtde = resultado.GetInt32(4),
                            Valor = resultado.GetDecimal(5),                    
                            Produto = new RepositorioProduto().FindById(resultado.GetInt32(1)),
                            Entrada = new RepositorioEntrada().FindById(resultado.GetInt32(2))
                        };
                        lista.Add(itemEntrada);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return lista;
        }
    }
}
