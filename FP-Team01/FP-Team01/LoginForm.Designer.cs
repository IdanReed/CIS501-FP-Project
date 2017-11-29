namespace FP_Team01
{
    partial class LoginForm
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
            this.uxLabelUsername = new System.Windows.Forms.Label();
            this.uxTBUsername = new System.Windows.Forms.TextBox();
            this.uxLabelWelcome1 = new System.Windows.Forms.Label();
            this.uxLabelWelcome2 = new System.Windows.Forms.Label();
            this.uxLabelPassword = new System.Windows.Forms.Label();
            this.uxTBPassword = new System.Windows.Forms.TextBox();
            this.uxBtnCreateAcct = new System.Windows.Forms.Button();
            this.uxBtnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxLabelUsername
            // 
            this.uxLabelUsername.AutoSize = true;
            this.uxLabelUsername.Location = new System.Drawing.Point(120, 84);
            this.uxLabelUsername.Name = "uxLabelUsername";
            this.uxLabelUsername.Size = new System.Drawing.Size(52, 18);
            this.uxLabelUsername.TabIndex = 0;
            this.uxLabelUsername.Text = "Name:";
            // 
            // uxTBUsername
            // 
            this.uxTBUsername.Location = new System.Drawing.Point(215, 81);
            this.uxTBUsername.Name = "uxTBUsername";
            this.uxTBUsername.Size = new System.Drawing.Size(157, 24);
            this.uxTBUsername.TabIndex = 1;
            // 
            // uxLabelWelcome1
            // 
            this.uxLabelWelcome1.AutoSize = true;
            this.uxLabelWelcome1.Location = new System.Drawing.Point(190, 19);
            this.uxLabelWelcome1.Name = "uxLabelWelcome1";
            this.uxLabelWelcome1.Size = new System.Drawing.Size(198, 18);
            this.uxLabelWelcome1.TabIndex = 2;
            this.uxLabelWelcome1.Text = "Welcome to our final project.";
            // 
            // uxLabelWelcome2
            // 
            this.uxLabelWelcome2.AutoSize = true;
            this.uxLabelWelcome2.Location = new System.Drawing.Point(84, 47);
            this.uxLabelWelcome2.Name = "uxLabelWelcome2";
            this.uxLabelWelcome2.Size = new System.Drawing.Size(412, 18);
            this.uxLabelWelcome2.TabIndex = 3;
            this.uxLabelWelcome2.Text = " Please enter your information and create an account or log in";
            // 
            // uxLabelPassword
            // 
            this.uxLabelPassword.AutoSize = true;
            this.uxLabelPassword.Location = new System.Drawing.Point(120, 126);
            this.uxLabelPassword.Name = "uxLabelPassword";
            this.uxLabelPassword.Size = new System.Drawing.Size(79, 18);
            this.uxLabelPassword.TabIndex = 4;
            this.uxLabelPassword.Text = "Password:";
            // 
            // uxTBPassword
            // 
            this.uxTBPassword.Location = new System.Drawing.Point(215, 123);
            this.uxTBPassword.Name = "uxTBPassword";
            this.uxTBPassword.Size = new System.Drawing.Size(157, 24);
            this.uxTBPassword.TabIndex = 5;
            this.uxTBPassword.UseSystemPasswordChar = true;
            // 
            // uxBtnCreateAcct
            // 
            this.uxBtnCreateAcct.Location = new System.Drawing.Point(123, 193);
            this.uxBtnCreateAcct.Name = "uxBtnCreateAcct";
            this.uxBtnCreateAcct.Size = new System.Drawing.Size(125, 30);
            this.uxBtnCreateAcct.TabIndex = 6;
            this.uxBtnCreateAcct.Text = "Create Account";
            this.uxBtnCreateAcct.UseVisualStyleBackColor = true;
            this.uxBtnCreateAcct.Click += new System.EventHandler(this.BtnCreateAcct_Click);
            // 
            // uxBtnLogin
            // 
            this.uxBtnLogin.Location = new System.Drawing.Point(279, 193);
            this.uxBtnLogin.Name = "uxBtnLogin";
            this.uxBtnLogin.Size = new System.Drawing.Size(93, 30);
            this.uxBtnLogin.TabIndex = 7;
            this.uxBtnLogin.Text = "Log In";
            this.uxBtnLogin.UseVisualStyleBackColor = true;
            this.uxBtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 300);
            this.Controls.Add(this.uxBtnLogin);
            this.Controls.Add(this.uxBtnCreateAcct);
            this.Controls.Add(this.uxTBPassword);
            this.Controls.Add(this.uxLabelPassword);
            this.Controls.Add(this.uxLabelWelcome2);
            this.Controls.Add(this.uxLabelWelcome1);
            this.Controls.Add(this.uxTBUsername);
            this.Controls.Add(this.uxLabelUsername);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.Text = "Login Screen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxLabelUsername;
        private System.Windows.Forms.TextBox uxTBUsername;
        private System.Windows.Forms.Label uxLabelWelcome1;
        private System.Windows.Forms.Label uxLabelWelcome2;
        private System.Windows.Forms.Label uxLabelPassword;
        private System.Windows.Forms.TextBox uxTBPassword;
        private System.Windows.Forms.Button uxBtnCreateAcct;
        private System.Windows.Forms.Button uxBtnLogin;
    }
}

