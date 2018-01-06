using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDiscoteca.Musicas.Web.Filtro
{
    public class LogResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string mensagem = string.Format("[{0}] Resultado: {1}/{2} | {3}",
                DateTime.Now.ToString(),
                filterContext.RouteData.Values["Controller"].ToString(),
                filterContext.RouteData.Values["Action"].ToString(),
                filterContext.Result.ToString());

            Debug.WriteLine(mensagem);
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string mensagem = string.Format("[{0}] Processando. . . {1}/{2}",
                DateTime.Now.ToString(),
                filterContext.RouteData.Values["Controller"].ToString(),
                filterContext.RouteData.Values["Action"].ToString());

            Debug.WriteLine(mensagem);
        }
    }
}