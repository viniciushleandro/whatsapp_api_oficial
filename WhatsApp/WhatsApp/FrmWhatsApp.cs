namespace WhatsApp
{
    public partial class FrmWhatsApp : Form
    {
        public FrmWhatsApp()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            WhatsApp.EnviarMensagem("", true, false, "", WhatsApp.eTipoCabecalho.Documento, "", "", "");
        }
    }
}