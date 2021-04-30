using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto.Repositorio
{
    public class RepositorioItemSaida
    {
        SqlConnection conexaoDB;

       

        public RepositorioItemSaida()
        {
            conexaoDB = new RepositorioConexaoDB().GetConnection();
        }
        public bool Insert(ItemSaida itemSaida )
        {
            string queryString =
            "INSERT INTO ITEMSAIDA VALUES " +
            "(@codsaida, @codproduto, @lote,@qtde, @valor)";

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@codsaida", itemSaida.Saida_CodSaida);
                command.Parameters.AddWithValue("@codproduto", itemSaida.Produto_CodProduto);
                command.Parameters.AddWithValue("@lote", itemSaida.Lote);
                command.Parameters.AddWithValue("@qtde", itemSaida.Qtde);
                command.Parameters.AddWithValue("@valor", itemSaida.Valor);

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

        public bool Update(ItemSaida itemSaida)
        {
            string queryString = "UPDATE ITEMSAIDA SET " +
                "LOTE=(@lote)," +
                "QTDE=(@qtde), VALOR=(@valor) WHERE CODITEMSAIDA=(@coditemsaida)";
            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@coditemsaida", itemSaida.CodItemSaida);
                command.Parameters.AddWithValue("@codproduto", itemSaida.Produto.CodProduto);
                command.Parameters.AddWithValue("@codsaida", itemSaida.Saida.CodSaida);
                command.Parameters.AddWithValue("@lote", itemSaida.Lote);
                command.Parameters.AddWithValue("@qtde", itemSaida.Qtde);
                command.Parameters.AddWithValue("@valor", itemSaida.Valor);

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

        public List<ItemSaida> FindAll()
        {
            string queryString = "SELECT * FROM ITEMSAIDA";
            List<ItemSaida> listaSaida = new List<ItemSaida>();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        var itemSaida = new ItemSaida
                        {
                            CodItemSaida = resultado.GetInt32(0),
                            Saida_CodSaida = resultado.GetInt32(1),
                            Produto_CodProduto = resultado.GetInt32(2),                            
                            Lote = resultado.GetString(3),
                            Qtde = resultado.GetInt32(4),
                            Valor = resultado.GetDecimal(5),
                            Saida = new RepositorioSaida().FindById(resultado.GetInt32(1)),
                            Produto = new RepositorioProduto().FindById(resultado.GetInt32(2))
                          
                        };
                        listaSaida.Add(itemSaida);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return listaSaida;
        }
    }
}
