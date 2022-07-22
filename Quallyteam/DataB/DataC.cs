using Microsoft.EntityFrameworkCore;
using Quallyteam.Models;
using MySql.Data.MySqlClient;
using System.Data;
using MySqlConnector;


namespace Quallyteam.DataB
{
    public class DataC
    {
        public static void conn()
        {
            MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection();


            conn.ConnectionString =
                "Data Source=localhost;" +
                "Initial Catalog=documentos;" +
                "uid=root;" +
                "pwd=;";
            conn.Open();


        }

        //função responsavel pelas instruições a serem cumpridas
        public static MySqlConnector.MySqlCommand command;
        // adapter responsavel por inserir dados em uma datatabela
        public static MySqlConnector.MySqlDataAdapter adapter;
        // responsavel por ligar o banco em controles com a  propriedades datasource
        public static DataTable dattabela;


        public DataTable Lista()
        {
            using (MySqlConnector.MySqlConnection conn= new MySqlConnector.MySqlConnection())
            {
                conn.ConnectionString =
                 "Data Source=localhost;" +
                 "Initial Catalog=documentos;" +
                 "uid=root;" +
                 "pwd=;";
                conn.Open();

                var queryString = "use bd_documentos select * from Arquivos ";
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(queryString, conn);
                command.Connection.Open();

                MySqlConnector.MySqlDataAdapter adapter = new MySqlConnector.MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }

        }

    }
} 
