﻿using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); // Este filter redireciona o usuário para uma página de erro quando uma Action retorna uma mensagem de erro.
            filters.Add(new AuthorizeAttribute()); // Com este filter o usuário tem que estar logado pra tudo a não ser em controllers com a Annotations [AllowAnonymous]
            //filters.Add(new RequireHttpsAttribute());
        }
    }
}
