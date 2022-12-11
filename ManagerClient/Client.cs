using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ManagerClient
{
    public partial class Client : Form
    {
        Socket server;
        IPAddress serverIPAddress;

        delegate void AppendTextDelegate(Control ctrl, string s);
        AppendTextDelegate _textAppend;

        string nameID;

        public Client()
        {
            InitializeComponent();
            server = new Socket(AddressFamily.InterNetwork,
    SocketType.Stream, ProtocolType.Tcp);
            _textAppend = new AppendTextDelegate(AppendText);
            //checkedListBox1.Items.
        }

        void AppendText(Control ctrl, string s)
        {
            if (ctrl.InvokeRequired)
                ctrl.Invoke(_textAppend, ctrl, s);
            else
            {
                string source = ctrl.Text;
                ctrl.Text = source + Environment.NewLine + s;
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (server.Connected)
            {
                NotificationService.Error("이미 연결되어 있습니다.");
                return;
            }
            int port;
            if (!int.TryParse(txtPort.Text, out port))
            {  // port 입력 안 함
                NotificationService.Warn("포트를 입력하세요");
                txtPort.Focus();
                txtPort.SelectAll();
                return;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                serverIPAddress = IPAddress.Loopback;
                txtAddress.Text = serverIPAddress.ToString();
            }
            else
            {
                serverIPAddress = IPAddress.Parse(txtAddress.Text);
            }
            IPEndPoint serverEP = new IPEndPoint(serverIPAddress, port);

            if (string.IsNullOrEmpty(txtNameID.Text))
            {
                NotificationService.Warn("ID를 입력하세요");
                return;
            }

            nameID = txtNameID.Text;

            try
            {
                server.Connect(serverEP);
                AppendText(txtHistory, "서버와 연결되었습니다");

            } catch (Exception ex) { 
                NotificationService.Error("연결에 실패했습니다!\n 오류내용: {0}",
                    MessageBoxButtons.OK, ex.Message);
                return;
            }

            SendID();

            AsyncObject obj = new AsyncObject(4096);
            obj.workingSocket = server;
            server.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0,
                DataReceived, obj);
        }

        void SendID()
        {
            byte[] bDts = Encoding.UTF8.GetBytes("M_ID:" + nameID + ":");
            server.Send(bDts);
            AppendText(txtHistory, "운영진이 서버와 연결되었습니다.");
            AppendText(txtHistory, "특정 사용자에게 보낼 때는 사용자 M_TO:ID:메시지로 입력하시고\n" + "브로드캐스드하려면 M_BR:메시지를 입력하세요");
            AppendText(txtHistory, "특정 그룹에게 보내실려면 M_MT:LEVEL:메시지로 입력하세요\n");
        }
        void DataReceived(IAsyncResult ar)
        {
            
            AsyncObject obj = ar.AsyncState as AsyncObject;
            try
            {
                int received = obj.workingSocket.EndReceive(ar);
                if (received <= 0)
                {
                    obj.workingSocket.Disconnect(false);
                    obj.workingSocket.Close();
                    return;
                }
            }
            catch(SocketException ex)
            {
                //Console.WriteLine(ex.Message);
            }



            string text = Encoding.UTF8.GetString(obj.Buffer);
            Console.WriteLine("hfhgf" + text);
            //AppendText(txtHistory, text);
            string[] tokens = text.Split(':');
            if (tokens[0].Equals("ID"))
            {
                string id = tokens[1];
                AppendText(txtHistory, string.Format("[유저접속]ID---> {0} {1}", id, FormatterService.GetCurrentDateToString()));
            }
            else if (tokens[0].Equals("M_WHO"))
            {
                checkedListBox1.Items.Clear(); // 접속한 사용자를 가져오기전 리스트박스비우는 코드
                string firstToken = tokens[1];
                string[] connectedClients = firstToken.TrimEnd(',').Split(',');
                foreach(string connectedClient in connectedClients)
                {
                    checkedListBox1.Items.Add(connectedClient);
                }
                checkedListBox1.Items.RemoveAt(connectedClients.Length - 1);
                //AppendText(txtHistory, string.Format("[현재 접속한 사용자] {0} {1}", connectedClients, FormatterService.GetCurrentDateToString()));
            }
            else if (tokens[0].Equals("M_ID"))
            {
                string id = tokens[1];
                AppendText(txtHistory, string.Format("[운영진접속]ID---> {0} {1}", id, FormatterService.GetCurrentDateToString()));
            }
            else if (tokens[0].Equals("BR"))
            {
                string fromID = tokens[1];
                string msg = tokens[2];
                AppendText(txtHistory, string.Format("[{0}유저의 전체메시지]---> {1} {2}", fromID, msg, FormatterService.GetCurrentDateToString()));
            }
            else if (tokens[0].Equals("M_BR"))
            {
                string fromID = tokens[1];
                string msg = tokens[2];
                AppendText(txtHistory, string.Format("[{0}운영진의 전체메시지]---> {1} {2}", fromID, msg, FormatterService.GetCurrentDateToString()));
            }
            else if (tokens[0].Equals("TO"))
            {
                string fromID = tokens[1];
                string toID = tokens[2];
                string msg = tokens[3];
                AppendText(txtHistory, string.Format("[{0}유저의 귓속말]---> {1} {2}", fromID, msg, FormatterService.GetCurrentDateToString()));
            }
            else if (tokens[0].Equals("M_TO"))
            {
                string fromID = tokens[1];
                string toID = tokens[2];
                string msg = tokens[3];
                AppendText(txtHistory, string.Format("[{0}운영진의 귓속말]---> {1} {2}", fromID, msg, FormatterService.GetCurrentDateToString()));
            }
            else if (tokens[0].Equals("Server"))
            {
                string msg = tokens[1];
                AppendText(txtHistory, string.Format("[server공지]---> {0} {1}", msg, FormatterService.GetCurrentDateToString()));
            }
            else
            {
                NotificationService.Warn("adminclient DataReceived 오류");
                return;
            }

            obj.clearBuffer();
            try
            {
                obj.workingSocket.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0,
                DataReceived, obj);
            }
            catch
            {

            }


        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!server.IsBound) // 만약에 서버와 연결이 되지않은상태에서 전송버튼을 누른다면
            {
                NotificationService.Warn("서버 연결을 하세요");
                return;
            }
            string text = txtSend.Text.Trim();
            if (string.IsNullOrEmpty(text)) // 전송버튼을 누를때 보낼 메세지가 아무것도 입력되지않았다면
            {
                NotificationService.Warn("텍스트를 입력하세요!");
                return;
            }
            //byte[] bDts = Encoding.UTF8.GetBytes(nameID + " : " + text);
            string[] tokens = text.Split(':');
            byte[] bDts = new byte[4096];

            //AppendText(txtHistory, "Client:" + text);
            if (tokens[0].Equals("M_BR"))
            {
                bDts = Encoding.UTF8.GetBytes("M_BR:" + nameID + ':' + tokens[1] + ':');
                AppendText(txtHistory, string.Format("[운영진의 전체 전송]---> {0} {1}", tokens[1], FormatterService.GetCurrentDateToString()));
            }
            else if (tokens[0].Equals("M_TO"))
            {
                bDts = Encoding.UTF8.GetBytes("M_TO:" + nameID + ':' + tokens[1] + ':' + tokens[2] + ':');
                AppendText(txtHistory, string.Format("[운영진이 {0}에게 전송]---> {1} {2}", tokens[1], tokens[2], FormatterService.GetCurrentDateToString()));
            }
            else if (tokens[0].Equals("M_MT"))
            {
                bDts = Encoding.UTF8.GetBytes("M_MT:" + nameID + ':' + tokens[1] + ':' + tokens[2] + ':' +  FormatterService.GetCurrentDateToString());
                AppendText(txtHistory, string.Format("[운영진의 그룹전송 전송]---> {0}", tokens[2]));
            }
            else
            {
                NotificationService.Warn("adminclient btnSend 오류");
                return;
            }
            try
            {
                server.Send(bDts);
            }
            catch { }
            txtSend.Clear();

        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                server.Disconnect(false);
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            catch
            { }
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void whoButton_Click(object sender, EventArgs e) // 메세지전송을 위한 현재 연결된 client목록가져오기
        {
            byte[] bDts = new byte[4096];
            try
            {
                bDts = Encoding.UTF8.GetBytes("M_WHO:" + nameID + ":");
                server.Send(bDts);
            }
            catch { }
            txtSend.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }

    public class FormatterService // Format을 위한 클래스
    {
        public static string GetCurrentDateToString(string formatter = "[yyyy-MM-dd HH시mm분]")
        {
            return DateTime.Now.ToString(formatter); // 현재 날짜를 가져오는 함수
        }
    }
}
