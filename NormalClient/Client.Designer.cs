namespace NormalClient
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
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lvLabel = new System.Windows.Forms.Label();
            this.txtHistory = new System.Windows.Forms.RichTextBox();
            this.connectedClientCountButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11F);
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "서버주소";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11F);
            this.label2.Location = new System.Drawing.Point(270, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "포트";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 11F);
            this.label3.Location = new System.Drawing.Point(12, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "메세지:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(103, 17);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(147, 25);
            this.txtAddress.TabIndex = 3;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(323, 17);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(126, 25);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "5000";
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(90, 404);
            this.txtSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(535, 25);
            this.txtSend.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(469, 14);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(86, 69);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "연결";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(631, 404);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(96, 25);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "전송";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 11F);
            this.label4.Location = new System.Drawing.Point(71, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "ID";
            // 
            // txtNameID
            // 
            this.txtNameID.Location = new System.Drawing.Point(103, 58);
            this.txtNameID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNameID.Name = "txtNameID";
            this.txtNameID.Size = new System.Drawing.Size(147, 25);
            this.txtNameID.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 11F);
            this.label5.Location = new System.Drawing.Point(12, 452);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "현재등급:";
            this.label5.Visible = false;
            // 
            // lvLabel
            // 
            this.lvLabel.AutoSize = true;
            this.lvLabel.Font = new System.Drawing.Font("굴림", 11F);
            this.lvLabel.Location = new System.Drawing.Point(103, 452);
            this.lvLabel.Name = "lvLabel";
            this.lvLabel.Size = new System.Drawing.Size(214, 19);
            this.lvLabel.TabIndex = 13;
            this.lvLabel.Text = "서버와 연결해주세요 ^^";
            // 
            // txtHistory
            // 
            this.txtHistory.Font = new System.Drawing.Font("굴림", 11F);
            this.txtHistory.Location = new System.Drawing.Point(16, 91);
            this.txtHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtHistory.Size = new System.Drawing.Size(711, 294);
            this.txtHistory.TabIndex = 14;
            this.txtHistory.Text = "";
            // 
            // connectedClientCountButton
            // 
            this.connectedClientCountButton.Location = new System.Drawing.Point(571, 14);
            this.connectedClientCountButton.Name = "connectedClientCountButton";
            this.connectedClientCountButton.Size = new System.Drawing.Size(156, 69);
            this.connectedClientCountButton.TabIndex = 15;
            this.connectedClientCountButton.Text = "현재 접속자";
            this.connectedClientCountButton.UseVisualStyleBackColor = true;
            this.connectedClientCountButton.Click += new System.EventHandler(this.connectedClientCountButton_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 485);
            this.Controls.Add(this.connectedClientCountButton);
            this.Controls.Add(this.txtHistory);
            this.Controls.Add(this.lvLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNameID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Client";
            this.Text = "UserClient";
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
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNameID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lvLabel;
        private System.Windows.Forms.RichTextBox txtHistory;
        private System.Windows.Forms.Button connectedClientCountButton;
    }
}

