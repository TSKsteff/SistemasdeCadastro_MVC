using Microsoft.AspNetCore.Mvc;
using Quallyteam.Models;
using Quallyteam.Database;
using System;
using System.Collections;
using System.Linq;
using System.Threading;
namespace Quallyteam.Controllers
{
    public class ArquivoController : Controller
    {
        public IActionResult Index()
        {
            var arquivolist = new CadastroM().lista();
            ViewBag.Arquivo = arquivolist.OrderBy(c => c.Titulo).ToList();
            return View();
        }
        public IActionResult Criar()
        {

            return View();
        }

        
        //public void Criar()
        //{


        //    var Arquivo = new CadastroM();
        //    Arquivo.Titulo = Request["Titulo"];
        //    Arquivo.Processo = Request["Processo"];
        //    Arquivo.Categoria = Request["Categoria"];


        //    var files = AddFiles(.Files,  "arquivo");

        //    foreach (var f in files)
        //    {
        //        if (f.Key == "arquivo")
        //            Arquivo.Arquivos = f.Value;
        //    }


        //    Arquivo.save();
        //    TempData.Add("sucesso", "Dados salvos com sucesso!");

        //    Response.Redirect("/arquivos");
        //}

        //private object AddFiles(object files, string v)
        //{
        //    throw new NotImplementedException();
        //}

        //public ActionResult Editar(int id)
        //{
        //    var arquivo = CadastroM.BuscaPorId(id);
        //    ViewBag.Arquivo = arquivo;
        //    return View();
        //}

        public IActionResult Editar(int id)
        {
            var arquivo = new CadastroM().Id;
            ViewBag.Arquivo = arquivo;
            return View();
        }
       

        public IActionResult ApagarC(int id)
        {
            CadastroM.Excluir(id);
            Response.Redirect("/Arquivos");
            return View();
        }


        // public IDictionary<string, string> AddFiles(HttpFileCollectionBase files, string name)
        //{
        //    try
        //    {

        //        IDictionary<string, string> savedFile = new Dictionary<string, string>();

        //        for (int i = 0; i < files.Count; i++)
        //        {
        //            string fname = "";

        //            string path = AppDomain.CurrentDomain.BaseDirectory + "Upload/";
        //            string filename = Path.GetFileName(Request.Files[i].FileName);
        //            string extension = Path.GetExtension(Request.Files[i].FileName);

        //            HttpPostedFileBase file = files[i];

        //            if (filename != "")
        //            {
        //                fname = name + "_" + DateTime.Now.Day.ToString() + "0" + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + "_" + i + DateTime.Now.Millisecond.ToString() + extension;

        //                filename = Path.Combine(Server.MapPath("~/Upload/"), fname);
        //                file.SaveAs(filename);
        //            }
        //            savedFile[files.AllKeys[i]] = fname;

        //        }

        //        return savedFile;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}




    }
}
