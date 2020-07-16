using System.Web.Mvc;
using System.Web.Routing;

namespace ExemploMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "paginas",
                url: "paginas",
                new { controller = "Paginas", action = "Index" }
            );

            routes.MapRoute(
                name: "nova",
                url: "paginas/novo",
                new { controller = "Paginas", action = "Novo" }
            );

            routes.MapRoute(
                name: "criar",
                url: "paginas/criar",
                new { controller = "Paginas", action = "Criar" }
            );

            routes.MapRoute(
                name: "alterar",
                url: "paginas/{id}/alterar",
                new { controller = "Paginas", action = "Alterar", id = 0 }
            );

            routes.MapRoute(
                name: "editar",
                url: "paginas/{id}/editar",
                new { controller = "Paginas", action = "Editar", id = 0 }
            );

            routes.MapRoute(
                name: "excluir",
                url: "paginas/{id}/excluir",
                new { controller = "Paginas", action = "Excluir", id = 0 }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
