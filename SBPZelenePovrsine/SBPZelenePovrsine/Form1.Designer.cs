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
            this.btnGetRadnici = new System.Windows.Forms.Button();
            this.btnRadniciCreate = new System.Windows.Forms.Button();
            this.btnZelenePovrsineDelete = new System.Windows.Forms.Button();
            this.btnRadiUCreate = new System.Windows.Forms.Button();
            this.btnRadiUGet = new System.Windows.Forms.Button();
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
            // btnGetRadnici
            // 
            this.btnGetRadnici.Location = new System.Drawing.Point(93, 198);
            this.btnGetRadnici.Name = "btnGetRadnici";
            this.btnGetRadnici.Size = new System.Drawing.Size(360, 33);
            this.btnGetRadnici.TabIndex = 2;
            this.btnGetRadnici.Text = "Pribavljanje svih radnika";
            this.btnGetRadnici.UseVisualStyleBackColor = true;
            this.btnGetRadnici.Click += new System.EventHandler(this.btnGetRadnici_Click);
            // 
            // btnRadniciCreate
            // 
            this.btnRadniciCreate.Location = new System.Drawing.Point(93, 159);
            this.btnRadniciCreate.Name = "btnRadniciCreate";
            this.btnRadniciCreate.Size = new System.Drawing.Size(360, 33);
            this.btnRadniciCreate.TabIndex = 3;
            this.btnRadniciCreate.Text = "Kreiranje radnika";
            this.btnRadniciCreate.UseVisualStyleBackColor = true;
            this.btnRadniciCreate.Click += new System.EventHandler(this.btnRadniciCreate_Click);
            // 
            // btnZelenePovrsineDelete
            // 
            this.btnZelenePovrsineDelete.Location = new System.Drawing.Point(93, 105);
            this.btnZelenePovrsineDelete.Name = "btnZelenePovrsineDelete";
            this.btnZelenePovrsineDelete.Size = new System.Drawing.Size(360, 33);
            this.btnZelenePovrsineDelete.TabIndex = 4;
            this.btnZelenePovrsineDelete.Text = "Brisanje Zelene povrsine";
            this.btnZelenePovrsineDelete.UseVisualStyleBackColor = true;
            this.btnZelenePovrsineDelete.Click += new System.EventHandler(this.btnZelenePovrsineDelete_Click);
            // 
            // btnRadiUCreate
            // 
            this.btnRadiUCreate.Location = new System.Drawing.Point(93, 253);
            this.btnRadiUCreate.Name = "btnRadiUCreate";
            this.btnRadiUCreate.Size = new System.Drawing.Size(360, 33);
            this.btnRadiUCreate.TabIndex = 5;
            this.btnRadiUCreate.Text = "Kreiranje stavke \'radi u\'";
            this.btnRadiUCreate.UseVisualStyleBackColor = true;
            this.btnRadiUCreate.Click += new System.EventHandler(this.btnRadiUCreate_Click);
            // 
            // btnRadiUGet
            // 
            this.btnRadiUGet.Location = new System.Drawing.Point(93, 292);
            this.btnRadiUGet.Name = "btnRadiUGet";
            this.btnRadiUGet.Size = new System.Drawing.Size(360, 33);
            this.btnRadiUGet.TabIndex = 6;
            this.btnRadiUGet.Text = "Pribavljanje istorije rada za oređenog radnika";
            this.btnRadiUGet.UseVisualStyleBackColor = true;
            this.btnRadiUGet.Click += new System.EventHandler(this.btnRadiUGet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 450);
            this.Controls.Add(this.btnRadiUGet);
            this.Controls.Add(this.btnRadiUCreate);
            this.Controls.Add(this.btnZelenePovrsineDelete);
            this.Controls.Add(this.btnRadniciCreate);
            this.Controls.Add(this.btnGetRadnici);
            this.Controls.Add(this.btnGetZelenePovrsine);
            this.Controls.Add(this.btnZelenePovrsineCreate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnZelenePovrsineCreate;
        private System.Windows.Forms.Button btnGetZelenePovrsine;
        private System.Windows.Forms.Button btnGetRadnici;
        private System.Windows.Forms.Button btnRadniciCreate;
        private System.Windows.Forms.Button btnZelenePovrsineDelete;
        private System.Windows.Forms.Button btnRadiUCreate;
        private System.Windows.Forms.Button btnRadiUGet;
    }
}

