using Business;
using System;
using System.Web.Mvc;

namespace ExemploMVC.Controllers
{
    public class PaginasController : Controller
    {   
        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Index()
        {
            try
            {
                ViewBag.Paginas = new BusinessPagina().ListaPaginas();
            }
            catch (ApplicationException ex)
            {
                TempData["Erro"] = ex.Message;
                //Response.Redirect("/alerta");
            }

            return View();
        }

        public ActionResult Editar(Guid id)
        {
            ViewBag.Pagina = new BusinessPagina().BuscarPorId(id);
            return View();
        }
        
        [HttpPost]
        public void Criar()
        {
            try            
            {
                BusinessPagina businessPagina = new BusinessPagina();
                businessPagina.Nome = Request["nome"];
                businessPagina.Conteudo = Request["conteudo"];
                businessPagina.Data = DateTime.Now;
                businessPagina.Status = "Start";
                businessPagina.Diretorio = Request["diretorio"];
                businessPagina.Criar();
            }
            catch
            {
                TempData["Erro"] = "Falha ao criar os dados.";
            }

            Response.Redirect("/paginas");

        }

        [HttpPost]
        public void Alterar()
        {
            try
            {
                BusinessPagina businessPagina = new BusinessPagina();
                businessPagina.Id = Guid.Parse(Request["id"].ToString());
                businessPagina.Nome = Request["nome"];
                businessPagina.Conteudo = Request["conteudo"];
                businessPagina.Data = DateTime.Now;
                businessPagina.Status = Request["Status"].ToString();
                businessPagina.Alterar();
                TempData["Sucesso"] = "Dados alterados com sucesso";
            }
            catch
            {
                TempData["Erro"] = "Falha ao alterar os dados.";
            }

            Response.Redirect("/paginas");
        }

        public void Excluir(Guid id)
        {
            try
            {
                new BusinessPagina().Excluir(id);
                TempData["Sucesso"] = "Dados excluídos com sucesso";
            }
            catch
            {
                TempData["Erro"] = "Falha ao excluir os dados.";
            }

            Response.Redirect("/paginas");
        }
    }
}