namespace WhatsApp
{
    partial class FrmChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlPrincipal = new Panel();
            pnlTop = new Panel();
            pnlContatos = new Panel();
            pnlMensagens = new Panel();
            button1 = new Button();
            pnlPrincipal.SuspendLayout();
            pnlTop.SuspendLayout();
            pnlContatos.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.BackColor = SystemColors.ButtonHighlight;
            pnlPrincipal.Controls.Add(pnlMensagens);
            pnlPrincipal.Controls.Add(pnlContatos);
            pnlPrincipal.Controls.Add(pnlTop);
            pnlPrincipal.Dock = DockStyle.Fill;
            pnlPrincipal.Location = new Point(0, 0);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Size = new Size(875, 590);
            pnlPrincipal.TabIndex = 0;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.LightGreen;
            pnlTop.Controls.Add(button1);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(875, 103);
            pnlTop.TabIndex = 0;
            // 
            // pnlContatos
            // 
            pnlContatos.AutoScroll = true;
            pnlContatos.BackColor = Color.LightGreen;
            pnlContatos.Dock = DockStyle.Left;
            pnlContatos.Location = new Point(0, 103);
            pnlContatos.Name = "pnlContatos";
            pnlContatos.Size = new Size(225, 487);
            pnlContatos.TabIndex = 1;
            // 
            // pnlMensagens
            // 
            pnlMensagens.BackColor = SystemColors.WindowFrame;
            pnlMensagens.Dock = DockStyle.Fill;
            pnlMensagens.Location = new Point(225, 103);
            pnlMensagens.Name = "pnlMensagens";
            pnlMensagens.Size = new Size(650, 487);
            pnlMensagens.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(628, 12);
            button1.Name = "button1";
            button1.Size = new Size(146, 70);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FrmChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 590);
            Controls.Add(pnlPrincipal);
            Name = "FrmChat";
            Text = "WhatsApp";
            pnlPrincipal.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlContatos.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPrincipal;
        private Panel pnlMensagens;
        private Panel pnlContatos;
        private Panel pnlTop;
        private Button button1;
    }
}