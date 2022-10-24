using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EnviarTextoArquivoWhatsApp
{
    public class WhatsAppDataModel
    {
        [JsonPropertyName("messaging_product")]
        public string messaging_product{ get; set; }

        public string to { get; set; }

        public string recipient_type { get; set; }

        public string type { get; set; }

        public Template Template { get; set; }

        public  Text text { get; set; }

        public  Document document { get; set; }

        [JsonPropertyName("file")]
        public byte[] media { get; set; }
    }

    public class Media
    {
        public string file { get; set; }
        public string messaging_product { get; set; }
    }

    public class Document
    {        
        public string id { get; set; }
        public string caption { get; set; }
        public string filename { get; set; }
    }


    public class Text
    {
        public Boolean preview_url { get; set; }
        public string body { get; set; }
    }

    public class Language
    {
        public string code { get; set; }
    }

    public class Template
    {
        public string name { get; set; }

        public Language language { get; set; }

        public List<Component> components { get; set; }

    }

    public class Component
    {
        public string type { get; set; }

        public string text { get; set; }
    }

    public class Contact
    {
        public string input { get; set; }
        public string wa_id { get; set; }
    }

    public class Message
    {
        public string id { get; set; }
    }

    public class WhatsappResponse
    {
        public string messaging_product { get; set; }

        public List<Contact> contacts { get; set; }

        public List<Message> messages { get; set; }
    }

    public class Retorno
    {
        public string id { get; set; }
    }

}
