using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //defining a custom route
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}", //parametros em curly braces {}
            //    new { controller = "Movies", action = "ByReleaseDate" }, //para especificar a rota default usamos um abjeto anonimo
            //    new { year = @"\d{4}", month = @"\d{2}"}); // essas strings com @ se chamam verbatum strings 
            // \d representa um dígito e o numero entre { } representa um numero de repetições

            routes.MapRoute(
                name: "Default", //nome da rota
                url: "{controller}/{action}/{id}", //padrão da url
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }  //caso não sejam fornecidos todos trecho do url que estão no pattern, a página é encaminhada para estes valores padrão.
            );
        }
    }
}
