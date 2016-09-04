using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace LemonWay.Controllers
{
    [RoutePrefix("api/math")]
    public class MathController : BaseController
    {

        //
        // GET: /Math/
        /// <summary>
        /// Suite de Fibonacci
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet()]
        [Route("fibo/{n}")]
        public HttpResponseMessage Fibonacci(int n)
        {

            try
            {
                long res = (n < 1 || n > 100) ? -1 : fibo(n);

                //Log de fibo
                logRequest(DateTime.Now + " - Fibonacci : " + n + " - Resultat : " + res);

                return Request.CreateResponse<long>(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                logFormat(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while executing Fibonacci");
            }

        }

        /// <summary>
        /// Methode de fibonacci trouvé sur :
        /// http://www.dotnetperls.com/fibonacci
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private long fibo(int n)
        {
            long a = 0;
            long b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                long temp = a;
                a = b;
                b = temp + b;
            }
            return a;

        }

    }
}
