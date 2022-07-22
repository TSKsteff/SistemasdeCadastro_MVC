using Quallyteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quallyteam.DataB;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace Quallyteam.Database

{
    public class CadastroData
    {
        //private void conectar()
        //{
        //    DataC.conn();
        //}

        ////função responsavel pelas instruições a serem cumpridas
        //public static MySqlConnector.MySqlCommand command;
        //// adapter responsavel por inserir dados em uma datatabela
        //public static MySqlConnector.MySqlDataAdapter adapter;
        //// responsavel por ligar o banco em controles com a  propriedades datasource
        //public static DataTable dattabela;


         public DataTable Lista()
        {
            using (MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection())
            {

                conn.ConnectionString =
                  "Server=127.0.0.1;" +
                  "database=documentos;" +
                  "uid=root;" +
                  "pwd=;";
                conn.Open();

                var queryString = " select * from arquivos ";
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(queryString, conn);
                command.ExecuteNonQuery();

                MySqlConnector.MySqlDataAdapter adapter = new MySqlConnector.MySqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }

         }
        public void Salvar(int id, string arquivos,  string processo, string titulo, string categoria)
        {
            using (MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection())
            {


                conn.ConnectionString =
                  "Server=127.0.0.1;" +
                  "database=documentos;" +
                  "uid=root;" +
                  "pwd=;";
                conn.Open();

                var queryString = " select * from arquivos ";
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(queryString, conn);
                command.ExecuteNonQuery();

                queryString = "INSERT INTO Arquivos (Arquivos,Processo,Titulo,Categoria) values ('" + arquivos + "','" + processo + "','" + titulo + "','" + categoria + "')";

                if (id != 0 && titulo != null && arquivos != null && processo != null && categoria != null)
                {
                    queryString = "update Arquivos  set titulo ='" + titulo + "',arquivos='" + arquivos + "',processo='" + processo + "', categoria ='" + categoria + "' where arquivoid=" + id;
                }
                MySqlConnector.MySqlCommand commandi = new MySqlConnector.MySqlCommand(queryString, conn);
                //commandi.ExecuteNonQuery();
                commandi.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
            using (MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection())
            {
                conn.ConnectionString =
                  "Server=127.0.0.1;" +
                  "database=documentos;" +
                  "uid=root;" +
                  "pwd=;";
                conn.Open();

                var queryString = " select * from arquivos ";
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(queryString, conn);
                command.ExecuteNonQuery();

                queryString = "DELETE FROM arquivos  where arquivoid=" + id;
                MySqlConnector.MySqlCommand commandi = new MySqlConnector.MySqlCommand(queryString, conn);
                
                commandi.ExecuteNonQuery();
            }
        }

        public DataTable BuscaPorId(int id)
        {
            using (MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection())
            {
                conn.ConnectionString =
                  "Server=127.0.0.1;" +
                  "database=documentos;" +
                  "uid=root;" +
                  "pwd=;";
                conn.Open();

                var queryString = " select * from arquivos ";
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(queryString, conn);
                command.ExecuteNonQuery();


                queryString = "select * from arquivos where ArquivoID= " + id;
                MySqlConnector.MySqlCommand commandi = new MySqlConnector.MySqlCommand(queryString, conn);
                commandi.ExecuteNonQuery();

                MySqlConnector.MySqlDataAdapter adapter = new MySqlConnector.MySqlDataAdapter();
                adapter.SelectCommand = commandi;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }


    }
}
