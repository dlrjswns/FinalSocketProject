namespace ManagerClient
{
    partial class Client
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameID = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.whoButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.bannedButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11F);
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "서버주소";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11F);
            this.label2.Location = new System.Drawing.Point(304, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "포트";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 11F);
            this.label3.Location = new System.Drawing.Point(11, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "메세지:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(87, 10);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(191, 21);
            this.txtAddress.TabIndex = 3;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(360, 10);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "5000";
            // 
            // txtHistory
            // 
            this.txtHistory.Font = new System.Drawing.Font("굴림", 11F);
            this.txtHistory.Location = new System.Drawing.Point(14, 80);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHistory.Size = new System.Drawing.Size(567, 213);
            this.txtHistory.TabIndex = 5;
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(74, 303);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(387, 21);
            this.txtSend.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(485, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(95, 63);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "연결";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(466, 303);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(115, 20);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "전송";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 11F);
            this.label4.Location = new System.Drawing.Point(52, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "ID";
            // 
            // txtNameID
            // 
            this.txtNameID.Location = new System.Drawing.Point(87, 51);
            this.txtNameID.Name = "txtNameID";
            this.txtNameID.Size = new System.Drawing.Size(191, 21);
            this.txtNameID.TabIndex = 10;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Font = new System.Drawing.Font("굴림", 11F);
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "전체"});
            this.checkedListBox1.Location = new System.Drawing.Point(603, 41);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(156, 194);
            this.checkedListBox1.TabIndex = 11;
            // 
            // whoButton
            // 
            this.whoButton.Location = new System.Drawing.Point(603, 269);
            this.whoButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.whoButton.Name = "whoButton";
            this.whoButton.Size = new System.Drawing.Size(156, 24);
            this.whoButton.TabIndex = 12;
            this.whoButton.Text = "연결된 사용자 조회";
            this.whoButton.UseVisualStyleBackColor = true;
            this.whoButton.Click += new System.EventHandler(this.whoButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 10F);
            this.label5.Location = new System.Drawing.Point(600, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "현재 연결된 사용자 목록";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // bannedButton
            // 
            this.bannedButton.Location = new System.Drawing.Point(603, 240);
            this.bannedButton.Name = "bannedButton";
            this.bannedButton.Size = new System.Drawing.Size(156, 24);
            this.bannedButton.TabIndex = 14;
            this.bannedButton.Text = "강퇴하기";
            this.bannedButton.UseVisualStyleBackColor = true;
            this.bannedButton.Click += new System.EventHandler(this.bannedButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(603, 303);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(156, 21);
            this.helpButton.TabIndex = 15;
            this.helpButton.Text = "도움말";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 353);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.bannedButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.whoButton);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.txtNameID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.txtHistory);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Client";
            this.Text = "ManagerClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHistory;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNameID;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button whoButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bannedButton;
        private System.Windows.Forms.Button helpButton;
    }
}

