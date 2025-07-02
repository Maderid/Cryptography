namespace Cryptography
{
    partial class Form1
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
            this.inputTxt = new System.Windows.Forms.TextBox();
            this.methodCmb = new System.Windows.Forms.ComboBox();
            this.keyTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.EncryptFileBtn = new System.Windows.Forms.Button();
            this.DecryptFileByn = new System.Windows.Forms.Button();
            this.outputTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // inputTxt
            // 
            this.inputTxt.Location = new System.Drawing.Point(259, 37);
            this.inputTxt.Name = "inputTxt";
            this.inputTxt.Size = new System.Drawing.Size(130, 20);
            this.inputTxt.TabIndex = 4;
            // 
            // methodCmb
            // 
            this.methodCmb.FormattingEnabled = true;
            this.methodCmb.Items.AddRange(new object[] {
            "Caesar",
            "Vigenère",
            "Transposition",
            "Vernam",
            "Color Code",
            "Custom",
            "Product Cipher"});
            this.methodCmb.Location = new System.Drawing.Point(259, 115);
            this.methodCmb.Name = "methodCmb";
            this.methodCmb.Size = new System.Drawing.Size(130, 21);
            this.methodCmb.TabIndex = 5;
            this.methodCmb.SelectedIndexChanged += new System.EventHandler(this.methodCmb_SelectedIndexChanged);
            // 
            // keyTxt
            // 
            this.keyTxt.Location = new System.Drawing.Point(259, 78);
            this.keyTxt.Name = "keyTxt";
            this.keyTxt.Size = new System.Drawing.Size(130, 20);
            this.keyTxt.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 37);
            this.button1.TabIndex = 9;
            this.button1.Text = "Encrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(175, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 37);
            this.button2.TabIndex = 10;
            this.button2.Text = "Decrypt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EncryptFileBtn
            // 
            this.EncryptFileBtn.Location = new System.Drawing.Point(32, 289);
            this.EncryptFileBtn.Name = "EncryptFileBtn";
            this.EncryptFileBtn.Size = new System.Drawing.Size(93, 37);
            this.EncryptFileBtn.TabIndex = 11;
            this.EncryptFileBtn.Text = "Encrypt";
            this.EncryptFileBtn.UseVisualStyleBackColor = true;
            this.EncryptFileBtn.Click += new System.EventHandler(this.EncryptFileBtn_Click);
            // 
            // DecryptFileByn
            // 
            this.DecryptFileByn.Location = new System.Drawing.Point(175, 289);
            this.DecryptFileByn.Name = "DecryptFileByn";
            this.DecryptFileByn.Size = new System.Drawing.Size(95, 37);
            this.DecryptFileByn.TabIndex = 12;
            this.DecryptFileByn.Text = "Decrypt";
            this.DecryptFileByn.UseVisualStyleBackColor = true;
            this.DecryptFileByn.Click += new System.EventHandler(this.DecryptFileByn_Click);
            // 
            // outputTxt
            // 
            this.outputTxt.Location = new System.Drawing.Point(216, 234);
            this.outputTxt.Name = "outputTxt";
            this.outputTxt.Size = new System.Drawing.Size(100, 20);
            this.outputTxt.TabIndex = 13;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(548, 459);
            this.Controls.Add(this.outputTxt);
            this.Controls.Add(this.DecryptFileByn);
            this.Controls.Add(this.EncryptFileBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.keyTxt);
            this.Controls.Add(this.methodCmb);
            this.Controls.Add(this.inputTxt);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.Button btnEncryptFile;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.Button btnDecryptFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputTxt;
        private System.Windows.Forms.ComboBox methodCmb;
        private System.Windows.Forms.TextBox keyTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button EncryptFileBtn;
        private System.Windows.Forms.Button DecryptFileByn;
        private System.Windows.Forms.TextBox outputTxt;
    }
}

