using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using RestSharp.Serializers.Json;
using EnviarTextoArquivoWhatsApp.WhatsAppService;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.IO;
using static System.Net.WebRequestMethods;
using Org.BouncyCastle.Asn1.Ocsp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnviarTextoArquivoWhatsApp
{
    public static class WhatsAppSender
    {

        public static async void SendMessage(WhatsAppDataModel wpModel)
        {

            string url = $"https://graph.facebook.com/v15.0/{Key.phoneNumberID}";
            Uri baseUrl = new Uri(url);

            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest("messages", Method.Post);

            request.AddHeader("Authorization", "Bearer " + Key.Token);
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(wpModel);

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.BadRequest)
                return;
        }

        public static async void SendDocument()
        {
            string url = $"https://graph.facebook.com/v15.0/{Key.phoneNumberID}";
            Uri baseUrl = new Uri(url);

            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest("messages", Method.Post);

            var path = "C:\\Users\\GuilhermeRudiger\\teste.pdf";

            request.AddHeader("Authorization", "Bearer " + Key.Token);
            request.AddHeader("Content-Type", "application/json");

            if (System.IO.File.Exists(path))
            {             
                WhatsAppDataModel wpModel = new WhatsAppDataModel();
                wpModel.messaging_product = "whatsapp";
                wpModel.recipient_type = "individual";
                wpModel.to = "5547999145852";
                wpModel.type = "document";
                wpModel.document = new Document { id = SendDocumentToServer(path), caption = "", filename = "teste" };
                request.AddJsonBody(wpModel);

                var response = await client.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.BadRequest)
                    return;
            }            
        }

        public static string SendDocumentToServer(string path)
        {
            var client = new RestClient($"https://graph.facebook.com/v15.0/{Key.phoneNumberID}/");
            var request = new RestRequest("media",Method.Post);
            request.AddHeader("Authorization", "Bearer " + Key.Token);
            request.AddParameter("messaging_product", "whatsapp");
            request.AddFile("file", path, "application/pdf");

            RestResponse response = client.Execute(request);

            Retorno ret = JsonSerializer.Deserialize<Retorno>(response.Content);

            return ret.id;
        }

    }
}
