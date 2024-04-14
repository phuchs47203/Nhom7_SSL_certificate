using Microsoft.VisualBasic.ApplicationServices;
using SuperSimpleTcp;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TCPChat_Server
{
    public partial class Form1 : Form
    {
        TcpListener server;
        private string selectImageString;
        public Form1()
        {
            InitializeComponent();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Any, 3000);
            server.Start();
            AddTextToDisplayChat($"Server is running...");

            
            
            TcpClient client = server.AcceptTcpClient();
            SslStream sslStream = new SslStream(client.GetStream(), false);


            X509Certificate2 certificate = new X509Certificate2("C:\\Users\\21522\\OneDrive\\Desktop\\ssl1.pfx", "Nhom7_123");

            // Xác thực và thiết lập kết nối SSL với client
            sslStream.AuthenticateAsServer(certificate, false, SslProtocols.Tls12, false);

            byte[] data = new byte[client.ReceiveBufferSize];
            int bytesRead = sslStream.Read(data, 0, client.ReceiveBufferSize);
            string receivedData = Encoding.UTF8.GetString(data, 0, bytesRead);
            AddTextToDisplayChat("Client: " + receivedData);

        }
        private void AddTextToDisplayChat(String mesage)
        {
            DisplayChat.Invoke((MethodInvoker)(() =>
            {
                DisplayChat.AppendText("  ");
                DisplayChat.AppendText(" " + mesage + " ");
                DisplayChat.AppendText(Environment.NewLine);
                DisplayChat.AppendText(Environment.NewLine);

            }
            ));
        }
        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {

            this.Invoke((MethodInvoker)delegate
            {
                string dataString = Encoding.UTF8.GetString(e.Data);

                if (dataString.StartsWith("D:\\"))
                {
                    Image image = Image.FromFile(dataString);

                    Bitmap myBitmap = new Bitmap(image);
                    DisplayChat.SelectionAlignment = HorizontalAlignment.Left;

                    AddImageToDisplayChat(myBitmap);

                    AddTextToDisplayChat($"{e.IpPort}: ");

/*                    DisplayChat.Text += $"{e.IpPort}: {Environment.NewLine}";
*/


                    DisplayChat.ScrollToCaret();

                    return;
                }
                // lấy dữ liệu nhận được bỏ vào ô text
                DisplayChat.SelectionAlignment = HorizontalAlignment.Left;
                AddTextToDisplayChat($"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}");
/*                DisplayChat.Text += $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
*/            });
        }

        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {

                AddTextToDisplayChat($"{e.IpPort} disconnected.");

/*                DisplayChat.Text += $"{e.IpPort} disconnected.{Environment.NewLine}";
*/
                // xóa địa chỉ ip hiển thị khi không kết nối đến đó
                lstClientConnted.Items.Remove(e.IpPort);
            });

        }

        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                AddTextToDisplayChat($"{e.IpPort} connected.");

/*                DisplayChat.Text += $"{e.IpPort} connected.{Environment.NewLine}";
*/
                lstClientConnted.Items.Add(e.IpPort);
            });

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (true)
            {
                // kieemr tra thoong tin truocs khi gửi
                if (!string.IsNullOrEmpty(txtInput.Text) && lstClientConnted.SelectedItem != null)
                {
                    if (txtInput.Text.StartsWith("[Image]") && selectImageString != null)
                    {
                        Image image = Image.FromFile(selectImageString);
/*                        server.Send(lstClientConnted.SelectedItem.ToString(), selectImageString);
*/
                        Bitmap myBitmap = new Bitmap(selectImageString);

                        DisplayChat.SelectionAlignment = HorizontalAlignment.Right;

                        AddImageToDisplayChat(myBitmap);

                        AddTextToDisplayChat("You: ");

/*                        DisplayChat.Text += $"You: {Environment.NewLine}";
*/

                        txtInput.Clear();


                        DisplayChat.ScrollToCaret();

                        // restore the editing capability of the textbox
                        txtInput.ReadOnly = false;
                        selectImageString = null;
                        return;
                    }
                    //gửi tin nhắn thông thường

/*                    server.Send(lstClientConnted.SelectedItem.ToString(), txtInput.Text);
*/                   
                    DisplayChat.SelectionAlignment = HorizontalAlignment.Right;

                    AddTextToDisplayChat($"You: {txtInput.Text}");

/*                    DisplayChat.Text += $"Server: {txtInput.Text}{Environment.NewLine}";
*/                    // gửi thành công thì xóa dữ liệu trong ô nhập
                    txtInput.Text = string.Empty;
                    DisplayChat.AppendText(Environment.NewLine);

                }
            }
        }
        private void AddImageToDisplayChat(Bitmap bitmap)
        {
            DisplayChat.Invoke((MethodInvoker)(() =>
            {
                int maxWidth = 150;
                int maxHeight = 150;

                int newWidth, newHeight;
                double aspectRatio = (double)bitmap.Width / bitmap.Height;

                if (aspectRatio > 1)
                {
                    newWidth = maxWidth;
                    newHeight = (int)(maxWidth / aspectRatio);
                }
                else
                {
                    // Portrait or square image
                    newHeight = maxHeight;
                    newWidth = (int)(maxHeight * aspectRatio);
                }

                Bitmap resized = new Bitmap(bitmap, new Size(newWidth, newHeight));
                Clipboard.SetDataObject(resized);
                DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);

                DisplayChat.ReadOnly = false; // enable editing to allow image pasting

                // move the caret to the end of the text
                DisplayChat.Select(DisplayChat.Text.Length, 0);

                if (DisplayChat.CanPaste(myFormat))
                {
/*                    DisplayChat.SelectionAlignment = HorizontalAlignment.Right;
*/                    /*                    DisplayChat.SelectionAlignment = HorizontalAlignment.Right : HorizontalAlignment.Left;
                    */
                    DisplayChat.Paste(myFormat);
                }
                // disable editing again
                DisplayChat.ReadOnly = true;
            }));
            DisplayChat.AppendText(Environment.NewLine);
            DisplayChat.AppendText(Environment.NewLine);
            
        }
            private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select image";
            fileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = $"[Image] {fileDialog.SafeFileName}";
                txtInput.ReadOnly = true;

                selectImageString = fileDialog.FileName;
            }
        }
    }
}
