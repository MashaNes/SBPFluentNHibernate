namespace SBPZelenePovrsine
{
    partial class frmZelenePovrsine
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
            this.btnJeSefCreate = new System.Windows.Forms.Button();
            this.btnJeSefGet = new System.Windows.Forms.Button();
            this.btnRadnikDelete = new System.Windows.Forms.Button();
            this.btnObjekatCreate = new System.Windows.Forms.Button();
            this.btnGetObjekat = new System.Windows.Forms.Button();
            this.btnZasticenObjekatCreate = new System.Windows.Forms.Button();
            this.btnGetZasticeniObjekti = new System.Windows.Forms.Button();
            this.btnGetZasticeniObjektiUParku = new System.Windows.Forms.Button();
            this.btnGetParkInfo = new System.Windows.Forms.Button();
            this.btnGetParkZasticeniInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnZelenePovrsineCreate
            // 
            this.btnZelenePovrsineCreate.Location = new System.Drawing.Point(25, 17);
            this.btnZelenePovrsineCreate.Name = "btnZelenePovrsineCreate";
            this.btnZelenePovrsineCreate.Size = new System.Drawing.Size(262, 33);
            this.btnZelenePovrsineCreate.TabIndex = 0;
            this.btnZelenePovrsineCreate.Text = "Kreiranje objekta u hijerarhiji Zelene Povrsine";
            this.btnZelenePovrsineCreate.UseVisualStyleBackColor = true;
            this.btnZelenePovrsineCreate.Click += new System.EventHandler(this.btnZelenePovrsineCreate_Click);
            // 
            // btnGetZelenePovrsine
            // 
            this.btnGetZelenePovrsine.Location = new System.Drawing.Point(25, 56);
            this.btnGetZelenePovrsine.Name = "btnGetZelenePovrsine";
            this.btnGetZelenePovrsine.Size = new System.Drawing.Size(262, 33);
            this.btnGetZelenePovrsine.TabIndex = 1;
            this.btnGetZelenePovrsine.Text = "Pribavljanje svih zelenih povrsina";
            this.btnGetZelenePovrsine.UseVisualStyleBackColor = true;
            this.btnGetZelenePovrsine.Click += new System.EventHandler(this.btnGetZelenePovrsine_Click);
            // 
            // btnGetRadnici
            // 
            this.btnGetRadnici.Location = new System.Drawing.Point(324, 55);
            this.btnGetRadnici.Name = "btnGetRadnici";
            this.btnGetRadnici.Size = new System.Drawing.Size(262, 33);
            this.btnGetRadnici.TabIndex = 2;
            this.btnGetRadnici.Text = "Pribavljanje svih radnika";
            this.btnGetRadnici.UseVisualStyleBackColor = true;
            this.btnGetRadnici.Click += new System.EventHandler(this.btnGetRadnici_Click);
            // 
            // btnRadniciCreate
            // 
            this.btnRadniciCreate.Location = new System.Drawing.Point(324, 17);
            this.btnRadniciCreate.Name = "btnRadniciCreate";
            this.btnRadniciCreate.Size = new System.Drawing.Size(262, 33);
            this.btnRadniciCreate.TabIndex = 3;
            this.btnRadniciCreate.Text = "Kreiranje radnika";
            this.btnRadniciCreate.UseVisualStyleBackColor = true;
            this.btnRadniciCreate.Click += new System.EventHandler(this.btnRadniciCreate_Click);
            // 
            // btnZelenePovrsineDelete
            // 
            this.btnZelenePovrsineDelete.Location = new System.Drawing.Point(25, 95);
            this.btnZelenePovrsineDelete.Name = "btnZelenePovrsineDelete";
            this.btnZelenePovrsineDelete.Size = new System.Drawing.Size(262, 33);
            this.btnZelenePovrsineDelete.TabIndex = 4;
            this.btnZelenePovrsineDelete.Text = "Brisanje Zelene povrsine";
            this.btnZelenePovrsineDelete.UseVisualStyleBackColor = true;
            this.btnZelenePovrsineDelete.Click += new System.EventHandler(this.btnZelenePovrsineDelete_Click);
            // 
            // btnRadiUCreate
            // 
            this.btnRadiUCreate.Location = new System.Drawing.Point(25, 157);
            this.btnRadiUCreate.Name = "btnRadiUCreate";
            this.btnRadiUCreate.Size = new System.Drawing.Size(262, 33);
            this.btnRadiUCreate.TabIndex = 5;
            this.btnRadiUCreate.Text = "Kreiranje stavke \'radi u\'";
            this.btnRadiUCreate.UseVisualStyleBackColor = true;
            this.btnRadiUCreate.Click += new System.EventHandler(this.btnRadiUCreate_Click);
            // 
            // btnRadiUGet
            // 
            this.btnRadiUGet.Location = new System.Drawing.Point(25, 194);
            this.btnRadiUGet.Name = "btnRadiUGet";
            this.btnRadiUGet.Size = new System.Drawing.Size(262, 33);
            this.btnRadiUGet.TabIndex = 6;
            this.btnRadiUGet.Text = "Pribavljanje istorije rada za određenog radnika";
            this.btnRadiUGet.UseVisualStyleBackColor = true;
            this.btnRadiUGet.Click += new System.EventHandler(this.btnRadiUGet_Click);
            // 
            // btnJeSefCreate
            // 
            this.btnJeSefCreate.Location = new System.Drawing.Point(324, 157);
            this.btnJeSefCreate.Name = "btnJeSefCreate";
            this.btnJeSefCreate.Size = new System.Drawing.Size(262, 33);
            this.btnJeSefCreate.TabIndex = 7;
            this.btnJeSefCreate.Text = "Kreiranje stavke \'je šef\'";
            this.btnJeSefCreate.UseVisualStyleBackColor = true;
            this.btnJeSefCreate.Click += new System.EventHandler(this.btnJeSefCreate_Click);
            // 
            // btnJeSefGet
            // 
            this.btnJeSefGet.Location = new System.Drawing.Point(324, 194);
            this.btnJeSefGet.Name = "btnJeSefGet";
            this.btnJeSefGet.Size = new System.Drawing.Size(262, 33);
            this.btnJeSefGet.TabIndex = 8;
            this.btnJeSefGet.Text = "Pribavljanje istorije šefovanja za određenog radnika";
            this.btnJeSefGet.UseVisualStyleBackColor = true;
            this.btnJeSefGet.Click += new System.EventHandler(this.btnJeSefGet_Click);
            // 
            // btnRadnikDelete
            // 
            this.btnRadnikDelete.Location = new System.Drawing.Point(324, 95);
            this.btnRadnikDelete.Name = "btnRadnikDelete";
            this.btnRadnikDelete.Size = new System.Drawing.Size(262, 33);
            this.btnRadnikDelete.TabIndex = 9;
            this.btnRadnikDelete.Text = "Brisanje radnika";
            this.btnRadnikDelete.UseVisualStyleBackColor = true;
            this.btnRadnikDelete.Click += new System.EventHandler(this.btnRadnikDelete_Click);
            // 
            // btnObjekatCreate
            // 
            this.btnObjekatCreate.Location = new System.Drawing.Point(619, 17);
            this.btnObjekatCreate.Name = "btnObjekatCreate";
            this.btnObjekatCreate.Size = new System.Drawing.Size(262, 33);
            this.btnObjekatCreate.TabIndex = 10;
            this.btnObjekatCreate.Text = "Kreiranje objekata u hijerarhiji Objekat";
            this.btnObjekatCreate.UseVisualStyleBackColor = true;
            this.btnObjekatCreate.Click += new System.EventHandler(this.btnObjekatCreate_Click);
            // 
            // btnGetObjekat
            // 
            this.btnGetObjekat.Location = new System.Drawing.Point(619, 93);
            this.btnGetObjekat.Name = "btnGetObjekat";
            this.btnGetObjekat.Size = new System.Drawing.Size(262, 33);
            this.btnGetObjekat.TabIndex = 11;
            this.btnGetObjekat.Text = "Pribavljanje svih objekata iz određenog parka";
            this.btnGetObjekat.UseVisualStyleBackColor = true;
            this.btnGetObjekat.Click += new System.EventHandler(this.btnGetObjekat_Click);
            // 
            // btnZasticenObjekatCreate
            // 
            this.btnZasticenObjekatCreate.Location = new System.Drawing.Point(619, 56);
            this.btnZasticenObjekatCreate.Name = "btnZasticenObjekatCreate";
            this.btnZasticenObjekatCreate.Size = new System.Drawing.Size(262, 31);
            this.btnZasticenObjekatCreate.TabIndex = 12;
            this.btnZasticenObjekatCreate.Text = "Kreiranje zaštićenih objekata u hijerarhiji Objekat";
            this.btnZasticenObjekatCreate.UseVisualStyleBackColor = true;
            this.btnZasticenObjekatCreate.Click += new System.EventHandler(this.btnZasticenObjekatCreate_Click);
            // 
            // btnGetZasticeniObjekti
            // 
            this.btnGetZasticeniObjekti.Location = new System.Drawing.Point(619, 157);
            this.btnGetZasticeniObjekti.Name = "btnGetZasticeniObjekti";
            this.btnGetZasticeniObjekti.Size = new System.Drawing.Size(262, 33);
            this.btnGetZasticeniObjekti.TabIndex = 13;
            this.btnGetZasticeniObjekti.Text = "Pribavljanje svih zaštićenih objekata";
            this.btnGetZasticeniObjekti.UseVisualStyleBackColor = true;
            this.btnGetZasticeniObjekti.Click += new System.EventHandler(this.btnGetZasticeniObjekti_Click);
            // 
            // btnGetZasticeniObjektiUParku
            // 
            this.btnGetZasticeniObjektiUParku.Location = new System.Drawing.Point(619, 194);
            this.btnGetZasticeniObjektiUParku.Name = "btnGetZasticeniObjektiUParku";
            this.btnGetZasticeniObjektiUParku.Size = new System.Drawing.Size(262, 33);
            this.btnGetZasticeniObjektiUParku.TabIndex = 14;
            this.btnGetZasticeniObjektiUParku.Text = "Pribavljanje svih zaštićenih objekata iz jednog parka";
            this.btnGetZasticeniObjektiUParku.UseVisualStyleBackColor = true;
            this.btnGetZasticeniObjektiUParku.Click += new System.EventHandler(this.btnGetZasticeniObjektiUParku_Click);
            // 
            // btnGetParkInfo
            // 
            this.btnGetParkInfo.Location = new System.Drawing.Point(62, 255);
            this.btnGetParkInfo.Name = "btnGetParkInfo";
            this.btnGetParkInfo.Size = new System.Drawing.Size(370, 33);
            this.btnGetParkInfo.TabIndex = 15;
            this.btnGetParkInfo.Text = "Pribavljanje svih podataka vezanih za jedan park";
            this.btnGetParkInfo.UseVisualStyleBackColor = true;
            this.btnGetParkInfo.Click += new System.EventHandler(this.btnGetParkInfo_Click);
            // 
            // btnGetParkZasticeniInfo
            // 
            this.btnGetParkZasticeniInfo.Location = new System.Drawing.Point(473, 255);
            this.btnGetParkZasticeniInfo.Name = "btnGetParkZasticeniInfo";
            this.btnGetParkZasticeniInfo.Size = new System.Drawing.Size(370, 33);
            this.btnGetParkZasticeniInfo.TabIndex = 16;
            this.btnGetParkZasticeniInfo.Text = "Pribavljanje podataka o svim parkovima sa zaštićenim objektima";
            this.btnGetParkZasticeniInfo.UseVisualStyleBackColor = true;
            this.btnGetParkZasticeniInfo.Click += new System.EventHandler(this.btnGetParkZasticeniInfo_Click);
            // 
            // frmZelenePovrsine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 305);
            this.Controls.Add(this.btnGetParkZasticeniInfo);
            this.Controls.Add(this.btnGetParkInfo);
            this.Controls.Add(this.btnGetZasticeniObjektiUParku);
            this.Controls.Add(this.btnGetZasticeniObjekti);
            this.Controls.Add(this.btnZasticenObjekatCreate);
            this.Controls.Add(this.btnGetObjekat);
            this.Controls.Add(this.btnObjekatCreate);
            this.Controls.Add(this.btnRadnikDelete);
            this.Controls.Add(this.btnJeSefGet);
            this.Controls.Add(this.btnJeSefCreate);
            this.Controls.Add(this.btnRadiUGet);
            this.Controls.Add(this.btnRadiUCreate);
            this.Controls.Add(this.btnZelenePovrsineDelete);
            this.Controls.Add(this.btnRadniciCreate);
            this.Controls.Add(this.btnGetRadnici);
            this.Controls.Add(this.btnGetZelenePovrsine);
            this.Controls.Add(this.btnZelenePovrsineCreate);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(918, 344);
            this.MinimumSize = new System.Drawing.Size(918, 344);
            this.Name = "frmZelenePovrsine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zelene površine";
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
        private System.Windows.Forms.Button btnJeSefCreate;
        private System.Windows.Forms.Button btnJeSefGet;
        private System.Windows.Forms.Button btnRadnikDelete;
        private System.Windows.Forms.Button btnObjekatCreate;
        private System.Windows.Forms.Button btnGetObjekat;
        private System.Windows.Forms.Button btnZasticenObjekatCreate;
        private System.Windows.Forms.Button btnGetZasticeniObjekti;
        private System.Windows.Forms.Button btnGetZasticeniObjektiUParku;
        private System.Windows.Forms.Button btnGetParkInfo;
        private System.Windows.Forms.Button btnGetParkZasticeniInfo;
    }
}

