using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto.Repositorio
{
    public class RepositorioSaida
    {
        SqlConnection conexaoDB;

        public RepositorioSaida()
        {
            conexaoDB = new RepositorioConexaoDB().GetConnection();
        }
        public bool Insert(Saida saida)
        {
            string queryString =
            "INSERT INTO SAIDA VALUES " +
            "(@codloja, @codtransportadora, @total,@frete, @imposto)";

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@codloja", saida.Loja_CodLoja);
                command.Parameters.AddWithValue("@codtransportadora", saida.Transportadora_CodTransportadora);
                command.Parameters.AddWithValue("@total", saida.Total);
                command.Parameters.AddWithValue("@frete", saida.Frete);
                command.Parameters.AddWithValue("@imposto", saida.Imposto);

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

        public bool Update(int? idSaida,Saida saida)
        {
            string queryString = "UPDATE SAIDA SET " +
                "Loja_CodLoja = (@codloja), " +
                "Transportadora_CodTransportadora = (@codtransportadora)," +
                "TOTAL=(@total)," +
                "FRETE=(@frete), IMPOSTO=(@imposto) WHERE CODSAIDA = " + idSaida;
            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);             
                command.Parameters.AddWithValue("@codloja", saida.Loja_CodLoja);
                command.Parameters.AddWithValue("@codtransportadora", 
                                                saida.Transportadora_CodTransportadora);
                command.Parameters.AddWithValue("@total", saida.Total);
                command.Parameters.AddWithValue("@frete", saida.Frete);
                command.Parameters.AddWithValue("@imposto", saida.Imposto);
              
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

        public List<Saida> FindAll()
        {
            List<Saida> lista = new List<Saida>();
            string queryString = "SELECT * FROM SAIDA";

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {

                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        var saida = new Saida
                        {
                            CodSaida = resultado.GetInt32(0),
                            Loja_CodLoja = resultado.GetInt32(1),
                            Transportadora_CodTransportadora = resultado.GetInt32(2),
                            Total = resultado.GetDecimal(3),
                            Frete = resultado.GetDecimal(4),
                            Imposto = resultado.GetDecimal(5),                          
                            Loja = new RepositorioLoja().FindById(resultado.GetInt32(1)),
                            Transportadora = new RepositorioTransportadora().FindById(resultado.GetInt32(2))
                        };
                        lista.Add(saida);
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return lista;
        }

        public Saida FindById(int? idSaida)
        {
            string queryString = "SELECT * FROM SAIDA WHERE CODSAIDA = " + idSaida;
            Saida saida = new Saida();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        saida.CodSaida = resultado.GetInt32(0);
                        saida.Loja_CodLoja = resultado.GetInt32(1);
                        saida.Transportadora_CodTransportadora = resultado.GetInt32(2);                       
                        saida.Total = resultado.GetDecimal(3);
                        saida.Frete = resultado.GetDecimal(4);                 
                        saida.Imposto = resultado.GetDecimal(5);
                        saida.Loja = new RepositorioLoja().FindById(resultado.GetInt32(1));
                        saida.Transportadora = new RepositorioTransportadora().FindById(resultado.GetInt32(2));
                     
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return saida;
        }
    }
}
