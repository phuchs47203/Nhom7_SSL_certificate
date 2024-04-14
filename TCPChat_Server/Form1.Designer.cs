namespace TCPChat_Server
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
            btnStart = new Button();
            btnSend = new Button();
            lstClientConnted = new ListBox();
            label3 = new Label();
            btnChooseImage = new Button();
            button2 = new Button();
            DisplayChat = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(49, 48);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Server: ";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(132, 48);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(494, 23);
            txtIP.TabIndex = 1;
            txtIP.Text = "127.0.0.1:3000";
            // 
            // txtInput
            // 
            txtInput.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtInput.Location = new Point(119, 566);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(516, 25);
            txtInput.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 571);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 3;
            label2.Text = "Write Meassage: ";
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.Location = new Point(641, 45);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(152, 23);
            btnStart.TabIndex = 5;
            btnStart.Text = "Start Server";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSend.Location = new Point(641, 562);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 31);
            btnSend.TabIndex = 6;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // lstClientConnted
            // 
            lstClientConnted.FormattingEnabled = true;
            lstClientConnted.ItemHeight = 15;
            lstClientConnted.Location = new Point(671, 105);
            lstClientConnted.Name = "lstClientConnted";
            lstClientConnted.Size = new Size(247, 424);
            lstClientConnted.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(779, 87);
            label3.Name = "label3";
            label3.Size = new Size(144, 15);
            label3.TabIndex = 8;
            label3.Text = "List of Client connecting:";
            // 
            // btnChooseImage
            // 
            btnChooseImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChooseImage.Location = new Point(20, 535);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(93, 28);
            btnChooseImage.TabIndex = 9;
            btnChooseImage.Text = "Choose Image";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(119, 538);
            button2.Name = "button2";
            button2.Size = new Size(47, 23);
            button2.TabIndex = 10;
            button2.Text = "Emoji";
            button2.UseVisualStyleBackColor = true;
            // 
            // DisplayChat
            // 
            DisplayChat.Location = new Point(126, 87);
            DisplayChat.Name = "DisplayChat";
            DisplayChat.Size = new Size(509, 445);
            DisplayChat.TabIndex = 11;
            DisplayChat.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 605);
            Controls.Add(DisplayChat);
            Controls.Add(button2);
            Controls.Add(btnChooseImage);
            Controls.Add(label3);
            Controls.Add(lstClientConnted);
            Controls.Add(btnSend);
            Controls.Add(btnStart);
            Controls.Add(txtInput);
            Controls.Add(label2);
            Controls.Add(txtIP);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Server";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIP;
        private TextBox txtInput;
        private Label label2;
        private Button btnStart;
        private Button btnSend;
        private ListBox lstClientConnted;
        private Label label3;
        private Button btnChooseImage;
        private Button button2;
        private RichTextBox DisplayChat;
    }
}
