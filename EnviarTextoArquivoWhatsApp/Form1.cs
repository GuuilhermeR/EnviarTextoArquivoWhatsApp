using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnviarTextoArquivoWhatsApp.WhatsAppService;

namespace EnviarTextoArquivoWhatsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Enviar Mensagem
            WhatsAppDataModel wpModel = new WhatsAppDataModel();
            wpModel.messaging_product = "whatsapp";
            wpModel.to = "5547999145852";
            wpModel.type = "text";
            wpModel.text = new Text { preview_url = false, body = "Olá" };

            WhatsAppSender.SendMessage(wpModel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Enviar Documento           

            WhatsAppSender.SendDocument();
        }

    }
}
