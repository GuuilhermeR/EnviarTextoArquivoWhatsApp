using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using EnviarTextoArquivoWhatsApp.WhatsAppService;

namespace EnviarTextoArquivoWhatsApp
{
    public static class WhatsAppSender
    {

        public static void SendMessage()
        {

            string url = "https://graph.facebook.com/v15.0/100837532833986/messages";
            Uri baseUrl = new Uri(url);

            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest("message", Method.Post);


            request.AddHeader("Authorization", "Bearer " + Key.Token);
            request.AddHeader("Content-Type", "application/json");
            Language lanObj = new Language();
            lanObj.code = "pt_BR";

            List<Models.Parameter> parameterlist = new List<Models.Parameter>();
            parameterlist.Add(new Models.Parameter
            {
                Type = "text",
                text = "Jaswinder"
            });

        }

    }
}
