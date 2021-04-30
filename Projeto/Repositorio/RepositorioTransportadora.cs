using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto.Repositorio
{
    public class RepositorioTransportadora
    {
        SqlConnection conexaoDB;

        public RepositorioTransportadora()
        {
            conexaoDB = new RepositorioConexaoDB().GetConnection();
        }

        private RepositorioCidade repositorioCidade = new RepositorioCidade();
        public bool Insert(Transportadora transportadora)
        {
            string queryString =
            "INSERT INTO TRANSPORTADORA VALUES " +
            "(@codcidade,@nome,@endereco,@num,@bairro,@cep, @cnpj,@insc,@contato,@tel)";

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@codcidade", transportadora.Cidade_CodCidade);
                command.Parameters.AddWithValue("@nome", transportadora.Nome);
                command.Parameters.AddWithValue("@endereco", transportadora.Endereco);
                command.Parameters.AddWithValue("@num", transportadora.Num);
                command.Parameters.AddWithValue("@bairro", transportadora.Bairro);
                command.Parameters.AddWithValue("@cep", transportadora.Cep);
                command.Parameters.AddWithValue("@cnpj", transportadora.Cnpj);
                command.Parameters.AddWithValue("@insc", transportadora.Insc);
                command.Parameters.AddWithValue("@contato", transportadora.Contato);
                command.Parameters.AddWithValue("@tel", transportadora.Tel);

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

        public bool Update(int? idTransportadora,Transportadora transportadora)
        {
            string queryString = "UPDATE TRANSPORTADORA SET " +
                "NOME=(@nome), CIDADE_CODCIDADE = (@codcidade)," +
                "ENDERECO=(@endereco), NUM=(@num), " +
                "BAIRRO=(@bairro), CEP=(@cep) , CNPJ=(@cnpj), " +
                "INSC=(@insc), CONTATO=(@contato),TEL=(@tel)   " +
                "WHERE CODTRANSPORTADORA =" + idTransportadora;
            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                command.Parameters.AddWithValue("@codcidade", transportadora.Cidade_CodCidade);
                command.Parameters.AddWithValue("@nome", transportadora.Nome);
                command.Parameters.AddWithValue("@endereco", transportadora.Endereco);
                command.Parameters.AddWithValue("@num", transportadora.Num);
                command.Parameters.AddWithValue("@bairro", transportadora.Bairro);
                command.Parameters.AddWithValue("@cep", transportadora.Cep);
                command.Parameters.AddWithValue("@contato", transportadora.Contato);
                command.Parameters.AddWithValue("@tel", transportadora.Tel);
                command.Parameters.AddWithValue("@insc", transportadora.Insc);
                command.Parameters.AddWithValue("@cnpj", transportadora.Cnpj);

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


        public List<Transportadora> FindAll()
        {
            List<Transportadora> lista = new List<Transportadora>();
            string queryString = "SELECT * FROM TRANSPORTADORA";

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        var transportadora = new Transportadora
                        {
                            CodTransportadora = resultado.GetInt32(0),
                            Cidade_CodCidade = resultado.GetInt32(1),
                            Nome = resultado.GetString(2),
                            Endereco = resultado.GetString(3),
                            Num = resultado.GetInt32(4),
                            Bairro = resultado.GetString(5),
                            Cep = resultado.GetString(6),
                            Cnpj = resultado.GetString(7),
                            Insc = resultado.GetString(8),
                            Contato = resultado.GetString(9),
                            Tel = resultado.GetString(10),
                            Cidade = new RepositorioCidade().FindById(resultado.GetInt32(1))
                        };
                        lista.Add(transportadora);
                    }
                    
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return lista;
        }

        public Transportadora FindById(int? idTransportadora)
        {
            string queryString = "SELECT * FROM TRANSPORTADORA " +
                                 "WHERE CODTRANSPORTADORA = " + idTransportadora;

            Transportadora transportadora = new Transportadora();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();

                    while (resultado.Read())
                    {
                        transportadora.CodTransportadora = resultado.GetInt32(0);
                        transportadora.Cidade_CodCidade = resultado.GetInt32(1);
                        transportadora.Nome = resultado.GetString(2);
                        transportadora.Endereco = resultado.GetString(3);
                        transportadora.Num = resultado.GetInt32(4);
                        transportadora.Bairro = resultado.GetString(5);
                        transportadora.Cep = resultado.GetString(6);
                        transportadora.Cnpj = resultado.GetString(7);
                        transportadora.Insc = resultado.GetString(8);
                        transportadora.Contato = resultado.GetString(9);
                        transportadora.Tel = resultado.GetString(10);
                        transportadora.Cidade = new RepositorioCidade().FindById(resultado.GetInt32(1));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return transportadora;
        }

        public List<Transportadora> FindByNome(string nome)
        {
            string queryString = "SELECT * FROM Transportadora WHERE NOME LIKE '%" + nome + "%'";
            List<Transportadora> lista = new List<Transportadora>();

            using (conexaoDB)
            {
                SqlCommand command = new SqlCommand(queryString, conexaoDB);
                try
                {
                    SqlDataReader resultado = command.ExecuteReader();

                    while (resultado.Read())
                    {
                        var transportadora = new Transportadora
                        {
                            CodTransportadora = resultado.GetInt32(0),
                            Cidade_CodCidade = resultado.GetInt32(1),
                            Nome = resultado.GetString(2),
                            Endereco = resultado.GetString(3),
                            Num = resultado.GetInt32(4),
                            Bairro = resultado.GetString(5),
                            Cep = resultado.GetString(6),
                            Cnpj = resultado.GetString(7),
                            Insc = resultado.GetString(8),
                            Contato = resultado.GetString(9),
                            Tel = resultado.GetString(10),
                            Cidade = new RepositorioCidade().FindById(resultado.GetInt32(1))
                        };
                        lista.Add(transportadora);
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
