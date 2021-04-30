using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto.Repositorio
{
    public class RepositorioEntrada
    {
        SqlConnection conexaoDB;

        public RepositorioEntrada()
        {
            conexaoDB = new RepositorioConexaoDB().GetConnection();
        }

        RepositorioTransportadora repositorioTransportadora = new RepositorioTransportadora();
        public bool Insert(Entrada entrada)
        {
            string queryString =
            "INSERT INTO ENTRADA VALUES " +
            "(@codtransportadora,@dataped,@dataentr,@total,@frete,@numnf,@imposto)";

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@codtransportadora", entrada.Transportadora_CodTransportadora);
                command.Parameters.AddWithValue("@dataped", entrada.DataPed);
                command.Parameters.AddWithValue("@dataentr", entrada.DataEntr);
                command.Parameters.AddWithValue("@total", entrada.Total);
                command.Parameters.AddWithValue("@frete", entrada.Frete);
                command.Parameters.AddWithValue("@numnf", entrada.NumNf);
                command.Parameters.AddWithValue("@imposto", entrada.Imposto);

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

        public bool Update(int? idEntrada,Entrada entrada)
        {
            string queryString = "UPDATE ENTRADA SET " +
                "DATAPED=(@dataped), DATAENTR=(@dataentr), TOTAL=(@total), FRETE =(@frete)," +
                "NUMNF=(@numnf), IMPOSTO=(@imposto), " +
                "TRANSPORTADORA_CODTRANSPORTADORA = (@codtransportadora)" +
                "WHERE CODENTRADA = " + idEntrada;
            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);           
                command.Parameters.AddWithValue("@codtransportadora",
                                                entrada.Transportadora_CodTransportadora);
                command.Parameters.AddWithValue("@dataped", entrada.DataPed);
                command.Parameters.AddWithValue("@dataentr", entrada.DataEntr);
                command.Parameters.AddWithValue("@total", entrada.Total);
                command.Parameters.AddWithValue("@frete", entrada.Frete);
                command.Parameters.AddWithValue("@numnf", entrada.NumNf);
                command.Parameters.AddWithValue("@imposto", entrada.Imposto);

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

        public List<Entrada> FindAll()
        {
            string queryString = "SELECT * FROM ENTRADA";
            List<Entrada> lista = new List<Entrada>();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {

                    SqlDataReader resultado = command.ExecuteReader();

                    while (resultado.Read())
                    {
                        var entrada = new Entrada
                        {
                            CodEntrada = resultado.GetInt32(0),
                            Transportadora_CodTransportadora = resultado.GetInt32(1),
                            DataPed = resultado.GetDateTime(2),
                            DataEntr = resultado.GetDateTime(3),
                            Total = resultado.GetDecimal(4),
                            Frete = resultado.GetDecimal(5),
                            NumNf = resultado.GetInt32(6),
                            Imposto = resultado.GetDecimal(7),
                            Transportadora = new RepositorioTransportadora().FindById(resultado.GetInt32(1))
                        };
                        lista.Add(entrada);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }

            return lista;
        }

        public Entrada FindById(int? idEntrada)
        {
            string queryString = "SELECT * FROM ENTRADA WHERE CODENTRADA = " + idEntrada;
            Entrada entrada = new Entrada();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        entrada.CodEntrada = resultado.GetInt32(0);
                        entrada.Transportadora_CodTransportadora = resultado.GetInt32(1);
                        entrada.DataPed = resultado.GetDateTime(2);
                        entrada.DataEntr = resultado.GetDateTime(3);
                        entrada.Total = resultado.GetDecimal(4);
                        entrada.Frete = resultado.GetDecimal(5);
                        entrada.NumNf = resultado.GetInt32(6);
                        entrada.Imposto = resultado.GetDecimal(7);
                        entrada.Transportadora = new RepositorioTransportadora().FindById(resultado.GetInt32(1));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return entrada;
        }
    }
}
