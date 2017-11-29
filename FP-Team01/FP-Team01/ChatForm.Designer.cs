namespace FP_Team01
{
    partial class ChatForm
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
            this.uxLBChatHistory = new System.Windows.Forms.ListBox();
            this.uxLabelMessage = new System.Windows.Forms.Label();
            this.uxTBMessage = new System.Windows.Forms.TextBox();
            this.uxBtnSend = new System.Windows.Forms.Button();
            this.uxBtnSeeMembers = new System.Windows.Forms.Button();
            this.uxBtnAddContact = new System.Windows.Forms.Button();
            this.uxBtnSignOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxLBChatHistory
            // 
            this.uxLBChatHistory.FormattingEnabled = true;
            this.uxLBChatHistory.ItemHeight = 18;
            this.uxLBChatHistory.Location = new System.Drawing.Point(13, 13);
            this.uxLBChatHistory.Name = "uxLBChatHistory";
            this.uxLBChatHistory.Size = new System.Drawing.Size(673, 202);
            this.uxLBChatHistory.TabIndex = 0;
            // 
            // uxLabelMessage
            // 
            this.uxLabelMessage.AutoSize = true;
            this.uxLabelMessage.Location = new System.Drawing.Point(13, 245);
            this.uxLabelMessage.Name = "uxLabelMessage";
            this.uxLabelMessage.Size = new System.Drawing.Size(108, 18);
            this.uxLabelMessage.TabIndex = 1;
            this.uxLabelMessage.Text = "Your Message:";
            // 
            // uxTBMessage
            // 
            this.uxTBMessage.Location = new System.Drawing.Point(128, 242);
            this.uxTBMessage.Name = "uxTBMessage";
            this.uxTBMessage.Size = new System.Drawing.Size(461, 24);
            this.uxTBMessage.TabIndex = 2;
            // 
            // uxBtnSend
            // 
            this.uxBtnSend.Location = new System.Drawing.Point(595, 240);
            this.uxBtnSend.Name = "uxBtnSend";
            this.uxBtnSend.Size = new System.Drawing.Size(91, 26);
            this.uxBtnSend.TabIndex = 3;
            this.uxBtnSend.Text = "Send";
            this.uxBtnSend.UseVisualStyleBackColor = true;
            this.uxBtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // uxBtnSeeMembers
            // 
            this.uxBtnSeeMembers.Location = new System.Drawing.Point(128, 273);
            this.uxBtnSeeMembers.Name = "uxBtnSeeMembers";
            this.uxBtnSeeMembers.Size = new System.Drawing.Size(159, 30);
            this.uxBtnSeeMembers.TabIndex = 4;
            this.uxBtnSeeMembers.Text = "See Chat Members";
            this.uxBtnSeeMembers.UseVisualStyleBackColor = true;
            this.uxBtnSeeMembers.Click += new System.EventHandler(this.BtnSeeMembers_Click);
            // 
            // uxBtnAddContact
            // 
            this.uxBtnAddContact.Location = new System.Drawing.Point(323, 273);
            this.uxBtnAddContact.Name = "uxBtnAddContact";
            this.uxBtnAddContact.Size = new System.Drawing.Size(146, 30);
            this.uxBtnAddContact.TabIndex = 5;
            this.uxBtnAddContact.Text = "Add New Contact";
            this.uxBtnAddContact.UseVisualStyleBackColor = true;
            this.uxBtnAddContact.Click += new System.EventHandler(this.BtnAddContact_Click);
            // 
            // uxBtnSignOut
            // 
            this.uxBtnSignOut.Location = new System.Drawing.Point(503, 273);
            this.uxBtnSignOut.Name = "uxBtnSignOut";
            this.uxBtnSignOut.Size = new System.Drawing.Size(105, 30);
            this.uxBtnSignOut.TabIndex = 6;
            this.uxBtnSignOut.Text = "Sign Out";
            this.uxBtnSignOut.UseVisualStyleBackColor = true;
            this.uxBtnSignOut.Click += new System.EventHandler(this.BtnSignOut_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 315);
            this.Controls.Add(this.uxBtnSignOut);
            this.Controls.Add(this.uxBtnAddContact);
            this.Controls.Add(this.uxBtnSeeMembers);
            this.Controls.Add(this.uxBtnSend);
            this.Controls.Add(this.uxTBMessage);
            this.Controls.Add(this.uxLabelMessage);
            this.Controls.Add(this.uxLBChatHistory);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChatForm";
            this.Text = "Chat Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox uxLBChatHistory;
        private System.Windows.Forms.Label uxLabelMessage;
        private System.Windows.Forms.TextBox uxTBMessage;
        private System.Windows.Forms.Button uxBtnSend;
        private System.Windows.Forms.Button uxBtnSeeMembers;
        private System.Windows.Forms.Button uxBtnAddContact;
        private System.Windows.Forms.Button uxBtnSignOut;
    }
}