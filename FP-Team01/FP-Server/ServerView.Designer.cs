namespace FP_Server
{
    partial class ServerView
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
            this.uxServerLogBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.uxChatRoomLabel = new System.Windows.Forms.Label();
            this.uxChatroomBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.uxInfoLabel = new System.Windows.Forms.Label();
            this.uxUserInfoBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.uxUserLabel = new System.Windows.Forms.Label();
            this.uxUsersListbox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxServerLogBox
            // 
            this.uxServerLogBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uxServerLogBox.Location = new System.Drawing.Point(0, 443);
            this.uxServerLogBox.Name = "uxServerLogBox";
            this.uxServerLogBox.ReadOnly = true;
            this.uxServerLogBox.Size = new System.Drawing.Size(884, 146);
            this.uxServerLogBox.TabIndex = 0;
            this.uxServerLogBox.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 274F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(860, 425);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.uxChatRoomLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.uxChatroomBox, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(589, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(268, 419);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // uxChatRoomLabel
            // 
            this.uxChatRoomLabel.AutoSize = true;
            this.uxChatRoomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxChatRoomLabel.Location = new System.Drawing.Point(3, 0);
            this.uxChatRoomLabel.Name = "uxChatRoomLabel";
            this.uxChatRoomLabel.Size = new System.Drawing.Size(165, 31);
            this.uxChatRoomLabel.TabIndex = 0;
            this.uxChatRoomLabel.Text = "Chat Rooms";
            // 
            // uxChatroomBox
            // 
            this.uxChatroomBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxChatroomBox.Location = new System.Drawing.Point(3, 47);
            this.uxChatroomBox.Name = "uxChatroomBox";
            this.uxChatroomBox.Size = new System.Drawing.Size(262, 369);
            this.uxChatroomBox.TabIndex = 1;
            this.uxChatroomBox.Text = "";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.uxInfoLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.uxUserInfoBox, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(296, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(287, 419);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // uxInfoLabel
            // 
            this.uxInfoLabel.AutoSize = true;
            this.uxInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxInfoLabel.Location = new System.Drawing.Point(3, 0);
            this.uxInfoLabel.Name = "uxInfoLabel";
            this.uxInfoLabel.Size = new System.Drawing.Size(125, 31);
            this.uxInfoLabel.TabIndex = 0;
            this.uxInfoLabel.Text = "User Info";
            // 
            // uxUserInfoBox
            // 
            this.uxUserInfoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxUserInfoBox.Location = new System.Drawing.Point(3, 47);
            this.uxUserInfoBox.Name = "uxUserInfoBox";
            this.uxUserInfoBox.Size = new System.Drawing.Size(281, 369);
            this.uxUserInfoBox.TabIndex = 1;
            this.uxUserInfoBox.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.uxUserLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.uxUsersListbox, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(287, 419);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // uxUserLabel
            // 
            this.uxUserLabel.AutoSize = true;
            this.uxUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxUserLabel.Location = new System.Drawing.Point(3, 0);
            this.uxUserLabel.Name = "uxUserLabel";
            this.uxUserLabel.Size = new System.Drawing.Size(86, 31);
            this.uxUserLabel.TabIndex = 0;
            this.uxUserLabel.Text = "Users";
            // 
            // uxUsersListbox
            // 
            this.uxUsersListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxUsersListbox.FormattingEnabled = true;
            this.uxUsersListbox.Location = new System.Drawing.Point(3, 47);
            this.uxUsersListbox.Name = "uxUsersListbox";
            this.uxUsersListbox.Size = new System.Drawing.Size(281, 368);
            this.uxUsersListbox.TabIndex = 1;
            this.uxUsersListbox.SelectedIndexChanged += new System.EventHandler(this.userInfoUpdate);
            // 
            // ServerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 589);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.uxServerLogBox);
            this.Name = "ServerView";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox uxServerLogBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label uxInfoLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label uxUserLabel;
        private System.Windows.Forms.ListBox uxUsersListbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label uxChatRoomLabel;
        private System.Windows.Forms.RichTextBox uxChatroomBox;
        private System.Windows.Forms.RichTextBox uxUserInfoBox;
    }
}

