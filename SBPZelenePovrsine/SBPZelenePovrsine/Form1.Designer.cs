namespace SBPZelenePovrsine
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
            this.btnZelenePovrsineCreate = new System.Windows.Forms.Button();
            this.btnGetZelenePovrsine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnZelenePovrsineCreate
            // 
            this.btnZelenePovrsineCreate.Location = new System.Drawing.Point(93, 27);
            this.btnZelenePovrsineCreate.Name = "btnZelenePovrsineCreate";
            this.btnZelenePovrsineCreate.Size = new System.Drawing.Size(360, 33);
            this.btnZelenePovrsineCreate.TabIndex = 0;
            this.btnZelenePovrsineCreate.Text = "Kreiranje objekta u hijerarhiji Zelene Povrsine";
            this.btnZelenePovrsineCreate.UseVisualStyleBackColor = true;
            this.btnZelenePovrsineCreate.Click += new System.EventHandler(this.btnZelenePovrsineCreate_Click);
            // 
            // btnGetZelenePovrsine
            // 
            this.btnGetZelenePovrsine.Location = new System.Drawing.Point(93, 66);
            this.btnGetZelenePovrsine.Name = "btnGetZelenePovrsine";
            this.btnGetZelenePovrsine.Size = new System.Drawing.Size(360, 33);
            this.btnGetZelenePovrsine.TabIndex = 1;
            this.btnGetZelenePovrsine.Text = "Pribavljanje svih zelenih povrsina";
            this.btnGetZelenePovrsine.UseVisualStyleBackColor = true;
            this.btnGetZelenePovrsine.Click += new System.EventHandler(this.btnGetZelenePovrsine_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 450);
            this.Controls.Add(this.btnGetZelenePovrsine);
            this.Controls.Add(this.btnZelenePovrsineCreate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnZelenePovrsineCreate;
        private System.Windows.Forms.Button btnGetZelenePovrsine;
    }
}

