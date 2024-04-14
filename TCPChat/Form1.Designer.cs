namespace TCPChat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtIP = new TextBox();
            txtInput = new TextBox();
            label2 = new Label();
            btnConnect = new Button();
            btnSend = new Button();
            DisplayChat = new RichTextBox();
            btnChoosseImage = new Button();
            btnEmoji = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 49);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 0;
            label1.Text = "Server IP Address ";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(132, 45);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(494, 23);
            txtIP.TabIndex = 1;
            txtIP.Text = "127.0.0.1:3000";
            // 
            // txtInput
            // 
            txtInput.Location = new Point(129, 556);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(494, 23);
            txtInput.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 558);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 3;
            label2.Text = "Write Meassage: ";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(650, 45);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSend.Location = new Point(629, 558);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(127, 23);
            btnSend.TabIndex = 6;
            btnSend.Text = "Send Meassage";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // DisplayChat
            // 
            DisplayChat.Location = new Point(50, 92);
            DisplayChat.Name = "DisplayChat";
            DisplayChat.Size = new Size(576, 428);
            DisplayChat.TabIndex = 7;
            DisplayChat.Text = "";
            // 
            // btnChoosseImage
            // 
            btnChoosseImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChoosseImage.Location = new Point(22, 526);
            btnChoosseImage.Name = "btnChoosseImage";
            btnChoosseImage.Size = new Size(101, 29);
            btnChoosseImage.TabIndex = 8;
            btnChoosseImage.Text = "Choose Image";
            btnChoosseImage.UseVisualStyleBackColor = true;
            btnChoosseImage.Click += btnChoosseImage_Click;
            // 
            // btnEmoji
            // 
            btnEmoji.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEmoji.Location = new Point(129, 529);
            btnEmoji.Name = "btnEmoji";
            btnEmoji.Size = new Size(54, 26);
            btnEmoji.TabIndex = 9;
            btnEmoji.Text = "Emoji";
            btnEmoji.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 593);
            Controls.Add(btnEmoji);
            Controls.Add(btnChoosseImage);
            Controls.Add(DisplayChat);
            Controls.Add(btnSend);
            Controls.Add(btnConnect);
            Controls.Add(txtInput);
            Controls.Add(label2);
            Controls.Add(txtIP);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Client";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIP;
        private TextBox txtInput;
        private Label label2;
        private Button btnConnect;
        private Button btnSend;
        private RichTextBox DisplayChat;
        private Button btnChoosseImage;
        private Button btnEmoji;
    }
}
