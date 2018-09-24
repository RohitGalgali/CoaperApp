namespace CoaperApp
{
    partial class CoaperFinder
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
            this.AddressBarTextBox = new System.Windows.Forms.TextBox();
            this.AddressBarLabel = new System.Windows.Forms.Label();
            this.PayloadDataTextBox = new System.Windows.Forms.RichTextBox();
            this.CoapTreeView = new System.Windows.Forms.TreeView();
            this.GetButton = new System.Windows.Forms.Button();
            this.PutButton = new System.Windows.Forms.Button();
            this.DiscoverButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddressBarTextBox
            // 
            this.AddressBarTextBox.Location = new System.Drawing.Point(101, 15);
            this.AddressBarTextBox.Name = "AddressBarTextBox";
            this.AddressBarTextBox.Size = new System.Drawing.Size(362, 20);
            this.AddressBarTextBox.TabIndex = 0;
            // 
            // AddressBarLabel
            // 
            this.AddressBarLabel.AutoSize = true;
            this.AddressBarLabel.Location = new System.Drawing.Point(22, 15);
            this.AddressBarLabel.Name = "AddressBarLabel";
            this.AddressBarLabel.Size = new System.Drawing.Size(61, 13);
            this.AddressBarLabel.TabIndex = 1;
            this.AddressBarLabel.Text = "AddressBar";
            // 
            // PayloadDataTextBox
            // 
            this.PayloadDataTextBox.Location = new System.Drawing.Point(248, 93);
            this.PayloadDataTextBox.Name = "PayloadDataTextBox";
            this.PayloadDataTextBox.Size = new System.Drawing.Size(656, 412);
            this.PayloadDataTextBox.TabIndex = 2;
            this.PayloadDataTextBox.Text = "";
            // 
            // CoapTreeView
            // 
            this.CoapTreeView.BackColor = System.Drawing.SystemColors.Info;
            this.CoapTreeView.Location = new System.Drawing.Point(7, 93);
            this.CoapTreeView.Name = "CoapTreeView";
            this.CoapTreeView.Size = new System.Drawing.Size(235, 412);
            this.CoapTreeView.TabIndex = 3;
            this.CoapTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CoapTreeView_AfterSelect);
            // 
            // GetButton
            // 
            this.GetButton.Location = new System.Drawing.Point(198, 51);
            this.GetButton.Name = "GetButton";
            this.GetButton.Size = new System.Drawing.Size(75, 23);
            this.GetButton.TabIndex = 4;
            this.GetButton.Text = "Get";
            this.GetButton.UseVisualStyleBackColor = true;
            this.GetButton.Click += new System.EventHandler(this.GetButton_Click);
            // 
            // PutButton
            // 
            this.PutButton.Location = new System.Drawing.Point(292, 51);
            this.PutButton.Name = "PutButton";
            this.PutButton.Size = new System.Drawing.Size(75, 23);
            this.PutButton.TabIndex = 5;
            this.PutButton.Text = "Put";
            this.PutButton.UseVisualStyleBackColor = true;
            // 
            // DiscoverButton
            // 
            this.DiscoverButton.Location = new System.Drawing.Point(101, 51);
            this.DiscoverButton.Name = "DiscoverButton";
            this.DiscoverButton.Size = new System.Drawing.Size(75, 23);
            this.DiscoverButton.TabIndex = 6;
            this.DiscoverButton.Text = "Discover";
            this.DiscoverButton.UseVisualStyleBackColor = true;
            this.DiscoverButton.Click += new System.EventHandler(this.DiscoverButton_Click);
            // 
            // CoaperFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 519);
            this.Controls.Add(this.DiscoverButton);
            this.Controls.Add(this.PutButton);
            this.Controls.Add(this.GetButton);
            this.Controls.Add(this.CoapTreeView);
            this.Controls.Add(this.PayloadDataTextBox);
            this.Controls.Add(this.AddressBarLabel);
            this.Controls.Add(this.AddressBarTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CoaperFinder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coaper Resource Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AddressBarTextBox;
        private System.Windows.Forms.Label AddressBarLabel;
        private System.Windows.Forms.RichTextBox PayloadDataTextBox;
        private System.Windows.Forms.TreeView CoapTreeView;
        private System.Windows.Forms.Button GetButton;
        private System.Windows.Forms.Button PutButton;
        private System.Windows.Forms.Button DiscoverButton;
    }
}

