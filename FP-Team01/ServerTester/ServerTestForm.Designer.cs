namespace ServerTester
{
    partial class ServerTestForm
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
            this.uxCreateAccountButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uxPassword = new System.Windows.Forms.TextBox();
            this.uxUsername = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uxLoginButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uxAddContactButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxCreateAccountButton
            // 
            this.uxCreateAccountButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxCreateAccountButton.Location = new System.Drawing.Point(3, 27);
            this.uxCreateAccountButton.Name = "uxCreateAccountButton";
            this.uxCreateAccountButton.Size = new System.Drawing.Size(128, 19);
            this.uxCreateAccountButton.TabIndex = 3;
            this.uxCreateAccountButton.Text = "Create";
            this.uxCreateAccountButton.UseVisualStyleBackColor = true;
            this.uxCreateAccountButton.Click += new System.EventHandler(this.uxCreateAccountButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account";
            // 
            // uxPassword
            // 
            this.uxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxPassword.Location = new System.Drawing.Point(137, 27);
            this.uxPassword.Name = "uxPassword";
            this.uxPassword.Size = new System.Drawing.Size(128, 20);
            this.uxPassword.TabIndex = 1;
            // 
            // uxUsername
            // 
            this.uxUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxUsername.Location = new System.Drawing.Point(137, 3);
            this.uxUsername.Name = "uxUsername";
            this.uxUsername.Size = new System.Drawing.Size(128, 20);
            this.uxUsername.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.uxUsername, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uxPassword, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uxCreateAccountButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(268, 49);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // uxLoginButton
            // 
            this.uxLoginButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.uxLoginButton.Location = new System.Drawing.Point(0, 0);
            this.uxLoginButton.Name = "uxLoginButton";
            this.uxLoginButton.Size = new System.Drawing.Size(268, 23);
            this.uxLoginButton.TabIndex = 3;
            this.uxLoginButton.Text = "Login";
            this.uxLoginButton.UseVisualStyleBackColor = true;
            this.uxLoginButton.Click += new System.EventHandler(this.uxLoginButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.uxAddContactButton);
            this.panel1.Controls.Add(this.uxLoginButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 419);
            this.panel1.TabIndex = 4;
            // 
            // uxAddContactButton
            // 
            this.uxAddContactButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.uxAddContactButton.Location = new System.Drawing.Point(0, 23);
            this.uxAddContactButton.Name = "uxAddContactButton";
            this.uxAddContactButton.Size = new System.Drawing.Size(268, 23);
            this.uxAddContactButton.TabIndex = 4;
            this.uxAddContactButton.Text = "Add Contact";
            this.uxAddContactButton.UseVisualStyleBackColor = true;
            this.uxAddContactButton.Click += new System.EventHandler(this.uxAddContactButton_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 26);
            this.button1.TabIndex = 6;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(0, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(268, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Add chat";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Location = new System.Drawing.Point(0, 95);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(268, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Send Message";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ServerTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 468);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ServerTestForm";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxCreateAccountButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uxPassword;
        private System.Windows.Forms.TextBox uxUsername;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button uxLoginButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button uxAddContactButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}

