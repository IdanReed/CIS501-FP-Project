﻿namespace FP_Team01
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
            this.uxTBMessage = new System.Windows.Forms.TextBox();
            this.uxBtnSend = new System.Windows.Forms.Button();
            this.uxBtnAddContact = new System.Windows.Forms.Button();
            this.uxBtnSignOut = new System.Windows.Forms.Button();
            this.uxtxtChat = new System.Windows.Forms.RichTextBox();
            this.uxLbContacts = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxTBMessage
            // 
            this.uxTBMessage.Location = new System.Drawing.Point(13, 218);
            this.uxTBMessage.Name = "uxTBMessage";
            this.uxTBMessage.Size = new System.Drawing.Size(576, 24);
            this.uxTBMessage.TabIndex = 2;
            this.uxTBMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uxTBMessage_KeyPress);
            // 
            // uxBtnSend
            // 
            this.uxBtnSend.Location = new System.Drawing.Point(595, 217);
            this.uxBtnSend.Name = "uxBtnSend";
            this.uxBtnSend.Size = new System.Drawing.Size(91, 26);
            this.uxBtnSend.TabIndex = 3;
            this.uxBtnSend.Text = "Send";
            this.uxBtnSend.UseVisualStyleBackColor = true;
            this.uxBtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // uxBtnAddContact
            // 
            this.uxBtnAddContact.Location = new System.Drawing.Point(13, 248);
            this.uxBtnAddContact.Name = "uxBtnAddContact";
            this.uxBtnAddContact.Size = new System.Drawing.Size(159, 56);
            this.uxBtnAddContact.TabIndex = 5;
            this.uxBtnAddContact.Text = "Invite Contact";
            this.uxBtnAddContact.UseVisualStyleBackColor = true;
            this.uxBtnAddContact.Click += new System.EventHandler(this.BtnAddContact_Click);
            // 
            // uxBtnSignOut
            // 
            this.uxBtnSignOut.Location = new System.Drawing.Point(13, 310);
            this.uxBtnSignOut.Name = "uxBtnSignOut";
            this.uxBtnSignOut.Size = new System.Drawing.Size(159, 56);
            this.uxBtnSignOut.TabIndex = 6;
            this.uxBtnSignOut.Text = "Leave Chatroom";
            this.uxBtnSignOut.UseVisualStyleBackColor = true;
            this.uxBtnSignOut.Click += new System.EventHandler(this.BtnSignOut_Click);
            // 
            // uxtxtChat
            // 
            this.uxtxtChat.Location = new System.Drawing.Point(13, 12);
            this.uxtxtChat.Name = "uxtxtChat";
            this.uxtxtChat.Size = new System.Drawing.Size(673, 199);
            this.uxtxtChat.TabIndex = 7;
            this.uxtxtChat.Text = "";
            // 
            // uxLbContacts
            // 
            this.uxLbContacts.FormattingEnabled = true;
            this.uxLbContacts.ItemHeight = 18;
            this.uxLbContacts.Location = new System.Drawing.Point(453, 248);
            this.uxLbContacts.Name = "uxLbContacts";
            this.uxLbContacts.Size = new System.Drawing.Size(233, 112);
            this.uxLbContacts.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Online Contacts:";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 376);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxLbContacts);
            this.Controls.Add(this.uxtxtChat);
            this.Controls.Add(this.uxBtnSignOut);
            this.Controls.Add(this.uxBtnAddContact);
            this.Controls.Add(this.uxBtnSend);
            this.Controls.Add(this.uxTBMessage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChatForm";
            this.Text = "Chat Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox uxTBMessage;
        private System.Windows.Forms.Button uxBtnSend;
        private System.Windows.Forms.Button uxBtnAddContact;
        private System.Windows.Forms.Button uxBtnSignOut;
        private System.Windows.Forms.RichTextBox uxtxtChat;
        private System.Windows.Forms.ListBox uxLbContacts;
        private System.Windows.Forms.Label label1;
    }
}