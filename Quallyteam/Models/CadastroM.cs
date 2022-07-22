using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Quallyteam.Database;

namespace Quallyteam.Models

{
    [Host]
    public class CadastroM
    {
        public int Id { get; set; }

        
        public string Titulo { get; set; }

        
        public string Arquivos { get; set; }

       
        public string Categoria { get; set; }

       
        public string Processo { get; set; }


        public List<CadastroM> lista()
        {
            var lista = new List<CadastroM>();

            var cadastroDb = new Database.CadastroData();
            foreach (DataRow row in cadastroDb.Lista().Rows)
            {
                var cadastroM = new CadastroM();
                cadastroM.Id = Convert.ToInt32(row["ArquivoID"]);
                cadastroM.Titulo = row["Titulo"].ToString();
                cadastroM.Arquivos = row["Arquivos"].ToString();
                cadastroM.Categoria = row["Categoria"].ToString();
                cadastroM.Processo = row["Processo"].ToString();
                lista.Add(cadastroM);

            }

            return lista;
                             
        }
        public void save()
        {
            new Database.CadastroData().Salvar(this.Id, this.Arquivos, this.Processo, this.Titulo, this.Categoria);
        }

        public static void Excluir(int id)
        {
            new Database.CadastroData().Excluir(id);
        }

        public  void BuscaPorId(int id)
        {
               new Database.CadastroData().BuscaPorId(id);
        }

        //internal class BuscaPorId
        //{
        //    private int id;

        //    public static BuscaPorId(int id)
        //    {
        //        this.id = id;
                
        //    }
        //}
    }
}
