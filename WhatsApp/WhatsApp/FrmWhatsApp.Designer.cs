namespace WhatsApp
{
    partial class FrmWhatsApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnEnviar = new Button();
            lblMensagem = new Label();
            SuspendLayout();
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(136, 61);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(94, 49);
            btnEnviar.TabIndex = 0;
            btnEnviar.Text = "Enviar Mensagem";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // lblMensagem
            // 
            lblMensagem.AutoSize = true;
            lblMensagem.ForeColor = Color.Red;
            lblMensagem.Location = new Point(40, 141);
            lblMensagem.Name = "lblMensagem";
            lblMensagem.Size = new Size(297, 15);
            lblMensagem.TabIndex = 1;
            lblMensagem.Text = "Para Enviar a mensagem, deve ser informado as chaves";
            // 
            // FrmWhatsApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 203);
            Controls.Add(lblMensagem);
            Controls.Add(btnEnviar);
            Name = "FrmWhatsApp";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEnviar;
        private Label lblMensagem;
    }
}