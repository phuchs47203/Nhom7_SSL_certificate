using SuperSimpleTcp;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace TCPChat
{
    public partial class Form1 : Form
    {
        TcpClient tcp_Client;
        private string selectImageString;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            /*try
            {
                tcpClient.Connect();
                btnSend.Enabled = true;
                btnConnect.Enabled = false;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa thiết lập kết nối, không gửi được tin nhắn
            try
            {
                // Tạo TCP client nếu chưa có
                if (tcp_Client == null)
                {
                    tcp_Client = new TcpClient("127.0.0.1", 3000);
                }

                // Tạo SSL Stream với TCP client
                SslStream sslStream = new SslStream(tcp_Client.GetStream(), false);

                // Tải SSL certificate vào X509Certificate2 object
                X509Certificate2 certificate = new X509Certificate2("C:\\Users\\21522\\OneDrive\\Desktop\\ssl1.pfx", "Nhom7_123");

                // Thiết lập kết nối SSL
                sslStream.AuthenticateAsClient("localhost", new X509Certificate2Collection(new X509Certificate2[] { certificate }), SslProtocols.Tls12, false);

                // Chuyển đổi dữ liệu văn bản sang dạng byte array
                byte[] data = Encoding.UTF8.GetBytes(txtInput.Text);

                // Gửi dữ liệu qua SSL Stream
                sslStream.Write(data);
                AddTextToDisplayChat($"Client: {txtInput.Text}");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi tin nhắn: " + ex.Message);
            }
            // kieemr tra xem đã kết nôi chauw thì mới gửi được tin nhắn
            /* if (tcpClient.IsConnected)
             {
                 if (txtInput.Text.StartsWith("[Image]") && selectImageString != null)
                 {
                     Image image = Image.FromFile(selectImageString);
                     tcpClient.Send(selectImageString);

                     Bitmap myBitmap = new Bitmap(selectImageString);

                     DisplayChat.SelectionAlignment = HorizontalAlignment.Right;

                     AddImageToDisplayChat(myBitmap);
                     AddTextToDisplayChat("You: ");


                     txtInput.Clear();


                     DisplayChat.ScrollToCaret();

                     // restore the editing capability of the textbox
                     txtInput.ReadOnly = false;
                     selectImageString = null;
                     return;
                 }
                 tcpClient.Send(txtInput.Text);
                 DisplayChat.SelectionAlignment = HorizontalAlignment.Right;
                 AddTextToDisplayChat($"You: {txtInput.Text}");
                 *//*    DisplayChat.Text += $"You: {txtInput.Text}{Environment.NewLine}";
                 *//*
                 txtInput.Text = string.Empty;
                 DisplayChat.AppendText(Environment.NewLine);*/

            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcp_Client = new TcpClient("127.0.0.1", 3000);
            SslStream sslStream = new SslStream(tcp_Client.GetStream(), false, (sender, certificate, chain, sslPolicyErrors) => true);

            X509Certificate2 certificate = new X509Certificate2("C:\\Users\\21522\\OneDrive\\Desktop\\ssl1.pfx", "Nhom7_123");

            sslStream.AuthenticateAsClient("localhost", new X509Certificate2Collection(new X509Certificate2[] { certificate }), SslProtocols.Tls12, false);
            byte[] data = Encoding.UTF8.GetBytes("Hello from client");
            sslStream.Write(data);
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


                    DisplayChat.Paste(myFormat);
                }

                // disable editing again
                DisplayChat.ReadOnly = true;
            }));
            DisplayChat.AppendText(Environment.NewLine);
            DisplayChat.AppendText(Environment.NewLine);


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
        private void Events_Disconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                AddTextToDisplayChat($"Disconnencted.");

            });
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
                    AddTextToDisplayChat("Server: ");

                    DisplayChat.ScrollToCaret();

                    return;
                }
                DisplayChat.SelectionAlignment = HorizontalAlignment.Left;
                AddTextToDisplayChat($"Server: {Encoding.UTF8.GetString(e.Data)}");

/*                DisplayChat.Text += $"Server: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
*/            });
        }

        private void Events_Connected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                AddTextToDisplayChat("Connect Successfully.");
            });
        }

        private void btnChoosseImage_Click(object sender, EventArgs e)
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
