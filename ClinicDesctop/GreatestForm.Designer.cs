namespace ClinicDesctop
{
    partial class GreatestForm
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
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSomething = new System.Windows.Forms.Button();
            this.listView1Clients = new System.Windows.Forms.ListView();
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSurname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPatronymic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonLoad.Location = new System.Drawing.Point(386, 12);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(86, 36);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSomething
            // 
            this.buttonSomething.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonSomething.Location = new System.Drawing.Point(386, 54);
            this.buttonSomething.Name = "buttonSomething";
            this.buttonSomething.Size = new System.Drawing.Size(84, 36);
            this.buttonSomething.TabIndex = 0;
            this.buttonSomething.Text = "Something";
            this.buttonSomething.UseVisualStyleBackColor = false;
            // 
            // listView1Clients
            // 
            this.listView1Clients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listView1Clients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderSurname,
            this.columnHeaderName,
            this.columnHeaderPatronymic});
            this.listView1Clients.FullRowSelect = true;
            this.listView1Clients.GridLines = true;
            this.listView1Clients.HideSelection = false;
            this.listView1Clients.Location = new System.Drawing.Point(12, 12);
            this.listView1Clients.MultiSelect = false;
            this.listView1Clients.Name = "listView1Clients";
            this.listView1Clients.Size = new System.Drawing.Size(368, 154);
            this.listView1Clients.TabIndex = 1;
            this.listView1Clients.UseCompatibleStateImageBehavior = false;
            this.listView1Clients.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "#";
            this.columnHeaderID.Width = 30;
            // 
            // columnHeaderSurname
            // 
            this.columnHeaderSurname.Text = "Surname";
            this.columnHeaderSurname.Width = 80;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 80;
            // 
            // columnHeaderPatronymic
            // 
            this.columnHeaderPatronymic.Text = "Patronymic";
            this.columnHeaderPatronymic.Width = 80;
            // 
            // GreatestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(556, 351);
            this.Controls.Add(this.listView1Clients);
            this.Controls.Add(this.buttonSomething);
            this.Controls.Add(this.buttonLoad);
            this.Name = "GreatestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo clinic window ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSomething;
        private System.Windows.Forms.ListView listView1Clients;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderSurname;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderPatronymic;
    }
}

