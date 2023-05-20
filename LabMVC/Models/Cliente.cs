﻿using LabMVC.DbSqLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace LabWebForms.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Cidade Cidade { get; set; }

        public static void Salvar(Cliente cliente)
        {
            //using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            //{
            //    string query = "INSERT INTO Clientes (Nome, Telefone, id_cidade) VALUES (@Nome, @Telefone, @idCidade)";
            //    SQLiteCommand command = new SQLiteCommand(query, connection);
            //    command.Parameters.AddWithValue("@Nome", Nome);
            //    command.Parameters.AddWithValue("@Telefone", Telefone);
            //    command.Parameters.AddWithValue("@idCidade", Cidade.Id);

            //    connection.Open();
            //    command.ExecuteNonQuery();
            //}

            string query = @"INSERT INTO CLIENTES (Nome, Telefone)
                                           VALUES (@Nome, @Telefone)";

            SqliteDataAccess.SalvarValor(query, cliente);
        }

        public static void Deletar(int? id)
        {
            string query = @"DELETE FROM CLIENTES
                                   WHERE ID = @Id";

            SqliteDataAccess.DeletarValor(query, new { Id = id });
        }

        public static List<Cliente> Todos()
        {
            //List<Cliente> clientes = new List<Cliente>();
            //using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            //{
            //    string query = "SELECT Id, Nome, id_cidade, Telefone FROM Clientes";
            //    SQLiteCommand command = new SQLiteCommand(query, connection);

            //    connection.Open();
            //    SQLiteDataReader reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Cliente cliente = new Cliente
            //        {
            //            Id = (int)reader["Id"],
            //            Nome = reader["Nome"].ToString(),
            //            Telefone = reader["Telefone"].ToString()
            //        };

            //        if (reader["id_cidade"] != DBNull.Value)
            //            cliente.Cidade = new Cidade() { Id = Convert.ToInt32(reader["id_cidade"]) };

            //        clientes.Add(cliente);
            //    }
            //}
            //return clientes;

            string query = @"SELECT Id, 
                                    Nome, 
                                    id_cidade, 
                                    REPLACE(Telefone, ' ', '') AS Telefone 
                               FROM Clientes";

            return SqliteDataAccess.BuscarLista<Cliente>(query).Result;
        }
    }
}
