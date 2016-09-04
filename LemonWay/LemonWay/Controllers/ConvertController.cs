using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml;

namespace LemonWay.Controllers
{
    [RoutePrefix("api/convert")]
    public class ConvertController : BaseController
    {

        /// <summary>
        /// Transformation d'un xml en json
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost()]
        [Route("xmltojson")]
        public HttpResponseMessage XmlToJson(string xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);

                //Log de la transformation
                logRequest(DateTime.Now + " - Transformation du xml : " + xml);

                return Request.CreateResponse<string>(HttpStatusCode.OK, jsonText, Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                logFormat(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Bad Xml format");

            }

        }
    }
}
