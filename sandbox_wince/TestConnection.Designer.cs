namespace sandbox_wince {
    partial class TestConnection {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtQueryName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtQueryResult = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCreateLogo = new System.Windows.Forms.TextBox();
            this.txtCreateTaxID = new System.Windows.Forms.TextBox();
            this.txtCreateName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCreateValue = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.Text = "Url";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(63, 4);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(174, 21);
            this.txtUrl.TabIndex = 3;
            this.txtUrl.Text = "https://172.16.2.136:8443";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 157);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.imgLogo);
            this.tabPage1.Controls.Add(this.txtQueryName);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.btnQuery);
            this.tabPage1.Controls.Add(this.txtQueryResult);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 134);
            this.tabPage1.Text = "Query BP";
            // 
            // txtQueryName
            // 
            this.txtQueryName.Location = new System.Drawing.Point(62, 2);
            this.txtQueryName.Name = "txtQueryName";
            this.txtQueryName.Size = new System.Drawing.Size(174, 21);
            this.txtQueryName.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.Text = "Name";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(148, 28);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(89, 20);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "Query";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtQueryResult
            // 
            this.txtQueryResult.Location = new System.Drawing.Point(3, 28);
            this.txtQueryResult.Multiline = true;
            this.txtQueryResult.Name = "txtQueryResult";
            this.txtQueryResult.Size = new System.Drawing.Size(139, 103);
            this.txtQueryResult.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Controls.Add(this.txtCreateLogo);
            this.tabPage2.Controls.Add(this.txtCreateTaxID);
            this.tabPage2.Controls.Add(this.txtCreateName);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtCreateValue);
            this.tabPage2.Controls.Add(this.btnCreate);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(240, 134);
            this.tabPage2.Text = "Create BP";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(216, 79);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(21, 21);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "...";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCreateLogo
            // 
            this.txtCreateLogo.Location = new System.Drawing.Point(63, 79);
            this.txtCreateLogo.Name = "txtCreateLogo";
            this.txtCreateLogo.Size = new System.Drawing.Size(147, 21);
            this.txtCreateLogo.TabIndex = 17;
            // 
            // txtCreateTaxID
            // 
            this.txtCreateTaxID.Location = new System.Drawing.Point(63, 54);
            this.txtCreateTaxID.Name = "txtCreateTaxID";
            this.txtCreateTaxID.Size = new System.Drawing.Size(174, 21);
            this.txtCreateTaxID.TabIndex = 16;
            // 
            // txtCreateName
            // 
            this.txtCreateName.Location = new System.Drawing.Point(63, 27);
            this.txtCreateName.Name = "txtCreateName";
            this.txtCreateName.Size = new System.Drawing.Size(174, 21);
            this.txtCreateName.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.Text = "Logo";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.Text = "TaxID";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.Text = "Value";
            // 
            // txtCreateValue
            // 
            this.txtCreateValue.Location = new System.Drawing.Point(63, 0);
            this.txtCreateValue.Name = "txtCreateValue";
            this.txtCreateValue.Size = new System.Drawing.Size(174, 21);
            this.txtCreateValue.TabIndex = 10;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(165, 106);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(72, 20);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // imgLogo
            // 
            this.imgLogo.Location = new System.Drawing.Point(148, 54);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(89, 77);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // TestConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "TestConnection";
            this.Text = "sandbox_wince";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtQueryResult;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCreateValue;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCreateLogo;
        private System.Windows.Forms.TextBox txtCreateTaxID;
        private System.Windows.Forms.TextBox txtCreateName;
        private System.Windows.Forms.TextBox txtQueryName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox imgLogo;
    }
}