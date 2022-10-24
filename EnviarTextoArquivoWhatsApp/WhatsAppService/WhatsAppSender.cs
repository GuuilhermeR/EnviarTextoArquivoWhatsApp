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

namespace EnviarTextoArquivoWhatsApp
{
    public static class WhatsAppSender
    {

        public static async void SendMessage()
        {

            string url = $"https://graph.facebook.com/v15.0/{Key.phoneNumberID}";
            Uri baseUrl = new Uri(url);

            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest("messages", Method.Post);

            request.AddHeader("Authorization", "Bearer " + Key.Token);
            request.AddHeader("Content-Type", "application/json");

            WhatsAppDataModel wpModel = new WhatsAppDataModel();
            wpModel.messaging_product = "whatsapp";
            wpModel.to = "5547999145852";
            wpModel.type = "text";
            wpModel.text = new Text{ preview_url = false, body = "Olá" };

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

            request.AddHeader("Authorization", "Bearer " + Key.Token);
            request.AddHeader("Content-Type", "application/json");

            WhatsAppDataModel wpModel = new WhatsAppDataModel();
            wpModel.messaging_product = "whatsapp";
            wpModel.recipient_type = "individual";
            wpModel.to = "5547999145852";
            wpModel.type = "document";
            wpModel.document = new Document { id = "", caption="", filename="" };

            request.AddJsonBody(wpModel);

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.BadRequest)
                return;
        }
    }
}
