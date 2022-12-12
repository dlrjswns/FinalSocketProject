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
using System.IO;
using System.Text.RegularExpressions;

namespace NormalClient
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
            FilterService.FilterLoad();
        }

        void AppendText(Control ctrl, string s)
        {
            string filterS = FilterService.MessageFilter(s);
            if (ctrl.InvokeRequired)
                ctrl.Invoke(_textAppend, ctrl, filterS);
            else
            {
                string source = ctrl.Text;
                ctrl.Text = source + Environment.NewLine + filterS;
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

            /*
                서버연결된 이후 사용자에 대한 등급을 배정
             */
            lvLabel.Text = "새싹이";
            label5.Visible = true;

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
            byte[] bDts = Encoding.UTF8.GetBytes("ID:" + nameID + ":");
            server.Send(bDts);
            AppendText(txtHistory, "-------------------------서버 공지-------------------------");
            AppendText(txtHistory, "유저가 서버와 연결되었습니다.");
            AppendText(txtHistory, "특정 사용자에게 보낼 때는 사용자 TO:ID:메시지로 입력하시고\n" + "브로드캐스드하려면 BR:메시지를 입력하세요");
            AppendText(txtHistory, "등업을 원하신다면 활동 많이 하면 줄지도...?");
            AppendText(txtHistory, "-----------------------------------------------------------");
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
            catch (SocketException ex)
            {
                //Console.WriteLine(ex.Message);
            }



            string text = Encoding.UTF8.GetString(obj.Buffer);
            
            //AppendText(txtHistory, text);
            string[] tokens = text.Split(':');
            if (tokens[0].Equals("ID"))
            {
                string id = tokens[1];
                AppendText(txtHistory, string.Format("[유저접속]ID---> {0} {1}", id, FormatterService.GetCurrentDateToString()));
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
            else if (tokens[0].Equals("Success_ToBeginner"))
            {
                AppendText(txtHistory, "-------------------------서버 공지-------------------------");
                AppendText(txtHistory, string.Format("[초보자]로 등업을 축하드립니다.\n [고인물]로 등업을 원하시면 열심히 활동해주세요 ^^"));
                AppendText(txtHistory, "-----------------------------------------------------------");
                lvLabel.Text = "초보자";
            }
            else if (tokens[0].Equals("Success_ToMaster"))
            {
                AppendText(txtHistory, "-------------------------서버 공지-------------------------");
                AppendText(txtHistory, string.Format("[고인물]로 등업을 축하드립니다.\n 이제 사용자들에게 [고인물]이라는걸 마음껏 뽐내보세요 ^^"));
                AppendText(txtHistory, "-----------------------------------------------------------");
                lvLabel.Text = "고인물";
            }
            else if (tokens[0].Equals("M_GM"))
            {
                string fromID = tokens[1];
                string level = tokens[2];
                string msg = tokens[3];
                if (level == "S")
                {
                    AppendText(txtHistory, string.Format("[{0}운영진의 새싹이등급메시지]---> {1} {2}", fromID, msg, FormatterService.GetCurrentDateToString()));
                }
                else if (level == "B")
                {
                    AppendText(txtHistory, string.Format("[{0}운영진의 초보자등급메시지]---> {1} {2}", fromID, msg, FormatterService.GetCurrentDateToString()));
                }
                else if (level == "M")
                {
                    AppendText(txtHistory, string.Format("[{0}운영진의 고인물등급메시지]---> {1} {2}", fromID, msg, FormatterService.GetCurrentDateToString()));
                }
            }
            else if (tokens[0].Equals("Server"))
            {
                string msg = tokens[1];
                AppendText(txtHistory, "-------------------------서버 공지-------------------------");
                AppendText(txtHistory, string.Format("[server공지]---> {0} {1}", msg, FormatterService.GetCurrentDateToString()));
                AppendText(txtHistory, "-----------------------------------------------------------");
            }
            else if (tokens[0].Equals("WHO"))
            {
                string connectedClientsCount = tokens[2];
                AppendText(txtHistory, string.Format("[현재 연결된 사용자 수]---> {0}명 접속중...", connectedClientsCount));
            }
            else if (tokens[0].Equals("M_BANNED"))
            {
                AppendText(txtHistory, "여기로와 시부ㅏㄹㅇ나ㅣㄼ;ㅣㅏㄹ;");
                try
                {
                    server.Disconnect(false);
                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                    NotificationService.Show("운영진에 의해 강퇴당했습니다 ^^");
                    this.Close();
                }
                catch
                { }
            }
            else if (tokens[0].Equals("HELP"))
            {
                txtHistory.Clear();
                AppendText(txtHistory, "---------------------도움말----------------------");
                AppendText(txtHistory, "[서버 접속]---> ID: nameID :");
                AppendText(txtHistory, "[초보자등업요청]---> LV: nameID : B :");
                AppendText(txtHistory, "[고인물등업요청]---> LV: nameID : M :");
                AppendText(txtHistory, "[전체메세지전송]---> BR: nameID : 전체메세지 :");
                AppendText(txtHistory, "[특정사용자메세지전송]---> TO: nameID : 받는사용자ID : 메세지:");
                AppendText(txtHistory, "[현재접속사용자 수]---> WHO: nameID :");
                AppendText(txtHistory, "------------------------------------------------");
            }
            else
            {
                NotificationService.Warn("userclient DataReceived 오류");
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
        int count;
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!server.IsBound)
            {
                NotificationService.Warn("서버 연결을 하세요");
                return;
            }
            string text = txtSend.Text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                NotificationService.Warn("텍스트를 입력하세요!");
                return;
            }


            //byte[] bDts = Encoding.UTF8.GetBytes(nameID + " : " + text);
            string[] tokens = text.Split(':');
            byte[] bDts = new byte[4096];

            // 메세지보낸 횟수에 따라 등급을 얻게 됨
            count++;
            if (count == 2) // 초보자로 승격
            {
                bDts = Encoding.UTF8.GetBytes("LV:" + nameID + ":B:");
                server.Send(bDts);
            }
            if (count == 3) // 고인물로 승격
            {
                bDts = Encoding.UTF8.GetBytes("LV:" + nameID + ":M:");
                server.Send(bDts);
            }

            //AppendText(txtHistory, "Client:" + text);
            if (tokens[0].Equals("BR"))
            {
                bDts = Encoding.UTF8.GetBytes("BR:" + nameID + ':' + tokens[1] + ':');
                AppendText(txtHistory, string.Format("[유저의 전체전송]---> {0} {1}", tokens[1], FormatterService.GetCurrentDateToString()));

            }
            else if(tokens[0].Equals("TO"))
            {
                bDts = Encoding.UTF8.GetBytes("TO:" + nameID + ":" + tokens[1] + ':' + tokens[2] + ':');
                AppendText(txtHistory, string.Format("[유저가 {0}에게 전송]---> {1} {2}", tokens[1], tokens[2], FormatterService.GetCurrentDateToString()));

            }
            else
            {
                NotificationService.Warn("userclient btnSend 오류");
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
        

        private void connectedClientCountButton_Click(object sender, EventArgs e)
        {
            byte[] bDts = new byte[4096];
            try
            {
                bDts = Encoding.UTF8.GetBytes("WHO:" + nameID + ":");
                server.Send(bDts);
            }
            catch { }
            txtSend.Clear();
        }

        private void asistButton_Click(object sender, EventArgs e)
        {
            byte[] bDts = new byte[4096];
            try
            {
                bDts = Encoding.UTF8.GetBytes("HELP:" + nameID + ":");
                server.Send(bDts);
            }
            catch { }
            txtSend.Clear();
        }
    }

    public class FormatterService // Format을 위한 클래스
    {
        public static string GetCurrentDateToString(string formatter = "[yyyy-MM-dd HH시mm분]")
        {
            return DateTime.Now.ToString(formatter); // 현재 날짜를 가져오는 함수
        }
    }

    public class FilterService
    {
        private static List<string> words = new List<string>();
        private static string masking;
        // 비속어 설정 파일 로딩

        private static StreamReader reader = new StreamReader(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\york.txt");
        private static int maxLength = 1;

        public static void FilterLoad()
        {
            // 파일 읽기
            // 마스킹 처리 길이 계산
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                words.Add(line);

                if (maxLength < line.Length)
                    maxLength = line.Length;
            }
            for (int i = 0; i <= maxLength; i++)
                masking += "*";
        }

        public static string MessageFilter(string message)
        {
            // 필터 확인을 위한 공백 제거
            string replaceMessage = message.Replace(" ", "");
            // 메시지 공백 원복을 위한 공백 위치 정보 저장
            List<int> blankIndex = new List<int>();
            var matches = Regex.Matches(message, " ");
            // 공백 위치 확인
            foreach (Match item in matches)
            {
                blankIndex.Add(item.Index);
            }
            // 메시지 첫자부터 비교
            for (int i = 0; i < replaceMessage.Length; i++)
            {
                for (int j = replaceMessage.Length - i; j > 1; j--)
                {
                    // 비속어 목록 비교
                    for (int k = 0; k < words.Count; k++)
                    {
                        // 비속어 포함 여부
                        if (words[k] == replaceMessage.Substring(i, j))
                        {
                            // 비속어 길이만큼 ** 변경
                            replaceMessage = replaceMessage.Replace(words[k], "*");
                        }
                    }
                }
            }
            foreach (int i in blankIndex)
            {
                // 기존 공백 복구
                replaceMessage = replaceMessage.Insert(i, " ");
            }
            return replaceMessage;
        }
    }
}
