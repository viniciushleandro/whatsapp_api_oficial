using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsApp
{
    public partial class FrmChat : Form
    {

        public GroupBox grpContato;
        public Label lblMessage;
        public Label lblNumero;
        public Label lblNome;

        public FrmChat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdicionaGroupContato();

        }

        private void AdicionaGroupContato() 
        {
            grpContato = new GroupBox();
            lblMessage = new Label();
            lblNumero = new Label();
            lblNome = new Label();
            
            // 
            // grpContato
            // 
            grpContato.BackColor = SystemColors.ControlLightLight;
            grpContato.Controls.Add(lblMessage);
            grpContato.Controls.Add(lblNumero);
            grpContato.Controls.Add(lblNome);
            grpContato.Dock = DockStyle.Top;
            grpContato.Location = new Point(0, 0);
            grpContato.Margin = new Padding(0);
            grpContato.Name = "grpContato";
            grpContato.Size = new Size(225, 83);
            grpContato.TabIndex = 0;
            grpContato.TabStop = false;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(6, 19);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(40, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(12, 34);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(51, 15);
            lblNumero.TabIndex = 0;
            lblNumero.Text = "Número";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(12, 58);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(66, 15);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Mensagem";

            pnlContatos.Controls.Add(grpContato);
        }
    }
}
