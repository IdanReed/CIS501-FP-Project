namespace FP_Team01
{
    partial class MainMenu
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
            this.uxLabelName = new System.Windows.Forms.Label();
            this.uxLBContacts = new System.Windows.Forms.ListBox();
            this.uxBtnStartChat = new System.Windows.Forms.Button();
            this.uxLabelContacts = new System.Windows.Forms.Label();
            this.uxBtnAddContact = new System.Windows.Forms.Button();
            this.uxBtnRemoveContact = new System.Windows.Forms.Button();
            this.uxBtnSignOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxLabelName
            // 
            this.uxLabelName.AutoSize = true;
            this.uxLabelName.Location = new System.Drawing.Point(12, 9);
            this.uxLabelName.Name = "uxLabelName";
            this.uxLabelName.Size = new System.Drawing.Size(135, 18);
            this.uxLabelName.TabIndex = 0;
            this.uxLabelName.Text = "Welcome, <name>";
            // 
            // uxLBContacts
            // 
            this.uxLBContacts.FormattingEnabled = true;
            this.uxLBContacts.ItemHeight = 18;
            this.uxLBContacts.Location = new System.Drawing.Point(222, 34);
            this.uxLBContacts.Name = "uxLBContacts";
            this.uxLBContacts.Size = new System.Drawing.Size(156, 256);
            this.uxLBContacts.TabIndex = 1;
            // 
            // uxBtnStartChat
            // 
            this.uxBtnStartChat.Location = new System.Drawing.Point(222, 296);
            this.uxBtnStartChat.Name = "uxBtnStartChat";
            this.uxBtnStartChat.Size = new System.Drawing.Size(156, 47);
            this.uxBtnStartChat.TabIndex = 2;
            this.uxBtnStartChat.Text = "Chat With Contact";
            this.uxBtnStartChat.UseVisualStyleBackColor = true;
            this.uxBtnStartChat.Click += new System.EventHandler(this.BtnStartChat_Click);
            // 
            // uxLabelContacts
            // 
            this.uxLabelContacts.AutoSize = true;
            this.uxLabelContacts.Location = new System.Drawing.Point(219, 9);
            this.uxLabelContacts.Name = "uxLabelContacts";
            this.uxLabelContacts.Size = new System.Drawing.Size(103, 18);
            this.uxLabelContacts.TabIndex = 3;
            this.uxLabelContacts.Text = "Your Contacts";
            // 
            // uxBtnAddContact
            // 
            this.uxBtnAddContact.Location = new System.Drawing.Point(15, 73);
            this.uxBtnAddContact.Name = "uxBtnAddContact";
            this.uxBtnAddContact.Size = new System.Drawing.Size(132, 39);
            this.uxBtnAddContact.TabIndex = 4;
            this.uxBtnAddContact.Text = "Add Contact";
            this.uxBtnAddContact.UseVisualStyleBackColor = true;
            this.uxBtnAddContact.Click += new System.EventHandler(this.BtnAddContact_Click);
            // 
            // uxBtnRemoveContact
            // 
            this.uxBtnRemoveContact.Location = new System.Drawing.Point(15, 138);
            this.uxBtnRemoveContact.Name = "uxBtnRemoveContact";
            this.uxBtnRemoveContact.Size = new System.Drawing.Size(132, 38);
            this.uxBtnRemoveContact.TabIndex = 5;
            this.uxBtnRemoveContact.Text = "Remove Contact";
            this.uxBtnRemoveContact.UseVisualStyleBackColor = true;
            this.uxBtnRemoveContact.Click += new System.EventHandler(this.BtnRemoveContact_Click);
            // 
            // uxBtnSignOut
            // 
            this.uxBtnSignOut.Location = new System.Drawing.Point(13, 296);
            this.uxBtnSignOut.Name = "uxBtnSignOut";
            this.uxBtnSignOut.Size = new System.Drawing.Size(134, 46);
            this.uxBtnSignOut.TabIndex = 6;
            this.uxBtnSignOut.Text = "Sign Out";
            this.uxBtnSignOut.UseVisualStyleBackColor = true;
            this.uxBtnSignOut.Click += new System.EventHandler(this.BtnSignOut_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 354);
            this.Controls.Add(this.uxBtnSignOut);
            this.Controls.Add(this.uxBtnRemoveContact);
            this.Controls.Add(this.uxBtnAddContact);
            this.Controls.Add(this.uxLabelContacts);
            this.Controls.Add(this.uxBtnStartChat);
            this.Controls.Add(this.uxLBContacts);
            this.Controls.Add(this.uxLabelName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxLabelName;
        private System.Windows.Forms.ListBox uxLBContacts;
        private System.Windows.Forms.Button uxBtnStartChat;
        private System.Windows.Forms.Label uxLabelContacts;
        private System.Windows.Forms.Button uxBtnAddContact;
        private System.Windows.Forms.Button uxBtnRemoveContact;
        private System.Windows.Forms.Button uxBtnSignOut;
    }
}