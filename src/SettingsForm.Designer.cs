﻿namespace OpenAMTEnterpriseAssistant
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.devNameComboBox = new System.Windows.Forms.ComboBox();
            this.skipTlsCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.caTextBox = new System.Windows.Forms.TextBox();
            this.logCheckBox = new System.Windows.Forms.CheckBox();
            this.debugCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.templateComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkCaButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.certCommonNameComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uuidCheckBox = new System.Windows.Forms.CheckBox();
            this.samCheckBox = new System.Windows.Forms.CheckBox();
            this.userCheckBox = new System.Windows.Forms.CheckBox();
            this.hostCheckBox = new System.Windows.Forms.CheckBox();
            this.dnsCheckBox = new System.Windows.Forms.CheckBox();
            this.dnCheckBox = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.devLocationComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.warnlbl = new System.Windows.Forms.Label();
            this.cbAddress = new System.Windows.Forms.ComboBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.MaskedTextBox();
            this.Port = new System.Windows.Forms.Label();
            this.securityKeyTextBox = new System.Windows.Forms.TextBox();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.securityGroupsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.devNameComboBox);
            this.groupBox1.Controls.Add(this.skipTlsCheckBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.hostTextBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RPS Server";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Device Name";
            // 
            // devNameComboBox
            // 
            this.devNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.devNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devNameComboBox.FormattingEnabled = true;
            this.devNameComboBox.Items.AddRange(new object[] {
            "Operating System Name",
            "Node Identifier"});
            this.devNameComboBox.Location = new System.Drawing.Point(116, 38);
            this.devNameComboBox.Name = "devNameComboBox";
            this.devNameComboBox.Size = new System.Drawing.Size(412, 21);
            this.devNameComboBox.TabIndex = 14;
            // 
            // skipTlsCheckBox
            // 
            this.skipTlsCheckBox.AutoSize = true;
            this.skipTlsCheckBox.Location = new System.Drawing.Point(116, 67);
            this.skipTlsCheckBox.Name = "skipTlsCheckBox";
            this.skipTlsCheckBox.Size = new System.Drawing.Size(159, 21);
            this.skipTlsCheckBox.TabIndex = 6;
            this.skipTlsCheckBox.Text = "Skip TLS certificate check";
            this.skipTlsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server Hostname";
            // 
            // hostTextBox
            // 
            this.hostTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hostTextBox.Location = new System.Drawing.Point(116, 12);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(412, 20);
            this.hostTextBox.TabIndex = 0;
            this.hostTextBox.TextChanged += new System.EventHandler(this.hostTextBox_TextChanged);
            this.hostTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.hostTextBox_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Authority Name";
            // 
            // caTextBox
            // 
            this.caTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.caTextBox.Location = new System.Drawing.Point(117, 24);
            this.caTextBox.Name = "caTextBox";
            this.caTextBox.Size = new System.Drawing.Size(389, 20);
            this.caTextBox.TabIndex = 9;
            this.caTextBox.TextChanged += new System.EventHandler(this.hostTextBox_TextChanged);
            this.caTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.hostTextBox_KeyUp);
            // 
            // logCheckBox
            // 
            this.logCheckBox.AutoSize = true;
            this.logCheckBox.Location = new System.Drawing.Point(10, 28);
            this.logCheckBox.Name = "logCheckBox";
            this.logCheckBox.Size = new System.Drawing.Size(89, 21);
            this.logCheckBox.TabIndex = 7;
            this.logCheckBox.Text = "Write log.txt";
            this.logCheckBox.UseVisualStyleBackColor = true;
            // 
            // debugCheckBox
            // 
            this.debugCheckBox.AutoSize = true;
            this.debugCheckBox.Location = new System.Drawing.Point(184, 28);
            this.debugCheckBox.Name = "debugCheckBox";
            this.debugCheckBox.Size = new System.Drawing.Size(105, 21);
            this.debugCheckBox.TabIndex = 8;
            this.debugCheckBox.Text = "Write debug.txt";
            this.debugCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(1032, 426);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(951, 426);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "TLS Template";
            // 
            // templateComboBox
            // 
            this.templateComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateComboBox.FormattingEnabled = true;
            this.templateComboBox.Location = new System.Drawing.Point(117, 49);
            this.templateComboBox.Name = "templateComboBox";
            this.templateComboBox.Size = new System.Drawing.Size(419, 21);
            this.templateComboBox.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkCaButton);
            this.groupBox2.Controls.Add(this.templateComboBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.caTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(542, 101);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Certificate Authority";
            // 
            // checkCaButton
            // 
            this.checkCaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkCaButton.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.checkCaButton.Location = new System.Drawing.Point(510, 24);
            this.checkCaButton.Name = "checkCaButton";
            this.checkCaButton.Size = new System.Drawing.Size(26, 20);
            this.checkCaButton.TabIndex = 7;
            this.checkCaButton.Text = "";
            this.checkCaButton.UseVisualStyleBackColor = true;
            this.checkCaButton.Click += new System.EventHandler(this.checkCaButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.logCheckBox);
            this.groupBox3.Controls.Add(this.debugCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(3, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(542, 54);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logging";
            // 
            // certCommonNameComboBox
            // 
            this.certCommonNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.certCommonNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.certCommonNameComboBox.FormattingEnabled = true;
            this.certCommonNameComboBox.Items.AddRange(new object[] {
            "Distinguished Name",
            "DNS FQDN",
            "Hostname",
            "User Principal Name",
            "SAM Account Name",
            "UUID"});
            this.certCommonNameComboBox.Location = new System.Drawing.Point(118, 19);
            this.certCommonNameComboBox.Name = "certCommonNameComboBox";
            this.certCommonNameComboBox.Size = new System.Drawing.Size(418, 21);
            this.certCommonNameComboBox.TabIndex = 13;
            this.certCommonNameComboBox.SelectedIndexChanged += new System.EventHandler(this.hostTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Common Name";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.certCommonNameComboBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.uuidCheckBox);
            this.groupBox4.Controls.Add(this.samCheckBox);
            this.groupBox4.Controls.Add(this.userCheckBox);
            this.groupBox4.Controls.Add(this.hostCheckBox);
            this.groupBox4.Controls.Add(this.dnsCheckBox);
            this.groupBox4.Controls.Add(this.dnCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(3, 104);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(542, 147);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Certificate Configuration";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Alternative Names";
            // 
            // uuidCheckBox
            // 
            this.uuidCheckBox.AutoSize = true;
            this.uuidCheckBox.Checked = true;
            this.uuidCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uuidCheckBox.Location = new System.Drawing.Point(183, 121);
            this.uuidCheckBox.Name = "uuidCheckBox";
            this.uuidCheckBox.Size = new System.Drawing.Size(60, 21);
            this.uuidCheckBox.TabIndex = 7;
            this.uuidCheckBox.Text = "UUID";
            this.uuidCheckBox.UseVisualStyleBackColor = true;
            // 
            // samCheckBox
            // 
            this.samCheckBox.AutoSize = true;
            this.samCheckBox.Checked = true;
            this.samCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.samCheckBox.Location = new System.Drawing.Point(183, 98);
            this.samCheckBox.Name = "samCheckBox";
            this.samCheckBox.Size = new System.Drawing.Size(130, 21);
            this.samCheckBox.TabIndex = 6;
            this.samCheckBox.Text = "SAM Account Name";
            this.samCheckBox.UseVisualStyleBackColor = true;
            // 
            // userCheckBox
            // 
            this.userCheckBox.AutoSize = true;
            this.userCheckBox.Checked = true;
            this.userCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.userCheckBox.Location = new System.Drawing.Point(183, 75);
            this.userCheckBox.Name = "userCheckBox";
            this.userCheckBox.Size = new System.Drawing.Size(129, 21);
            this.userCheckBox.TabIndex = 5;
            this.userCheckBox.Text = "User Principal Name";
            this.userCheckBox.UseVisualStyleBackColor = true;
            // 
            // hostCheckBox
            // 
            this.hostCheckBox.AutoSize = true;
            this.hostCheckBox.Checked = true;
            this.hostCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hostCheckBox.Location = new System.Drawing.Point(9, 121);
            this.hostCheckBox.Name = "hostCheckBox";
            this.hostCheckBox.Size = new System.Drawing.Size(81, 21);
            this.hostCheckBox.TabIndex = 4;
            this.hostCheckBox.Text = "Hostname";
            this.hostCheckBox.UseVisualStyleBackColor = true;
            // 
            // dnsCheckBox
            // 
            this.dnsCheckBox.AutoSize = true;
            this.dnsCheckBox.Checked = true;
            this.dnsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dnsCheckBox.Location = new System.Drawing.Point(9, 98);
            this.dnsCheckBox.Name = "dnsCheckBox";
            this.dnsCheckBox.Size = new System.Drawing.Size(89, 21);
            this.dnsCheckBox.TabIndex = 3;
            this.dnsCheckBox.Text = "DNS FQDN";
            this.dnsCheckBox.UseVisualStyleBackColor = true;
            // 
            // dnCheckBox
            // 
            this.dnCheckBox.AutoSize = true;
            this.dnCheckBox.Checked = true;
            this.dnCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dnCheckBox.Location = new System.Drawing.Point(9, 75);
            this.dnCheckBox.Name = "dnCheckBox";
            this.dnCheckBox.Size = new System.Drawing.Size(127, 21);
            this.dnCheckBox.TabIndex = 2;
            this.dnCheckBox.Text = "Distinguished Name";
            this.dnCheckBox.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox6);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox7);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(1095, 408);
            this.splitContainer1.SplitterDistance = 543;
            this.splitContainer1.TabIndex = 16;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.devLocationComboBox);
            this.groupBox6.Location = new System.Drawing.Point(3, 201);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(534, 49);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Domain";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Location";
            // 
            // devLocationComboBox
            // 
            this.devLocationComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.devLocationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devLocationComboBox.FormattingEnabled = true;
            this.devLocationComboBox.Location = new System.Drawing.Point(115, 22);
            this.devLocationComboBox.Name = "devLocationComboBox";
            this.devLocationComboBox.Size = new System.Drawing.Size(412, 21);
            this.devLocationComboBox.TabIndex = 16;
            this.devLocationComboBox.SelectedIndexChanged += new System.EventHandler(this.devLocationComboBox_SelectedIndexChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.warnlbl);
            this.groupBox7.Controls.Add(this.cbAddress);
            this.groupBox7.Controls.Add(this.lblAddress);
            this.groupBox7.Controls.Add(this.portTextBox);
            this.groupBox7.Controls.Add(this.Port);
            this.groupBox7.Controls.Add(this.securityKeyTextBox);
            this.groupBox7.Controls.Add(this.passTextBox);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.userTextBox);
            this.groupBox7.Location = new System.Drawing.Point(3, 104);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(534, 96);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "RPC Client";
            // 
            // warnlbl
            // 
            this.warnlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warnlbl.AutoSize = true;
            this.warnlbl.Location = new System.Drawing.Point(110, 76);
            this.warnlbl.Name = "warnlbl";
            this.warnlbl.Size = new System.Drawing.Size(274, 13);
            this.warnlbl.TabIndex = 25;
            this.warnlbl.Text = "Security key should be of length 32 or 64 characters";
            // 
            // cbAddress
            // 
            this.cbAddress.FormattingEnabled = true;
            this.cbAddress.Items.AddRange(new object[] {
            "*"});
            this.cbAddress.Location = new System.Drawing.Point(115, 9);
            this.cbAddress.Name = "cbAddress";
            this.cbAddress.Size = new System.Drawing.Size(157, 21);
            this.cbAddress.TabIndex = 24;
            this.cbAddress.SelectedIndexChanged += new System.EventHandler(this.cbAddress_SelectedIndexChanged);
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(6, 15);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(62, 13);
            this.lblAddress.TabIndex = 23;
            this.lblAddress.Text = "EA Address";
            // 
            // portTextBox
            // 
            this.portTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.portTextBox.Location = new System.Drawing.Point(370, 10);
            this.portTextBox.Mask = "9999?9";
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.PromptChar = ' ';
            this.portTextBox.Size = new System.Drawing.Size(157, 20);
            this.portTextBox.TabIndex = 22;
            this.portTextBox.Text = "8000";
            this.portTextBox.MaskChanged += new System.EventHandler(this.portTextBox_MaskChanged);
            // 
            // Port
            // 
            this.Port.AutoSize = true;
            this.Port.Location = new System.Drawing.Point(299, 14);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(26, 13);
            this.Port.TabIndex = 20;
            this.Port.Text = "Port";
            // 
            // securityKeyTextBox
            // 
            this.securityKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.securityKeyTextBox.Location = new System.Drawing.Point(115, 54);
            this.securityKeyTextBox.Name = "securityKeyTextBox";
            this.securityKeyTextBox.PasswordChar = '*';
            this.securityKeyTextBox.Size = new System.Drawing.Size(412, 20);
            this.securityKeyTextBox.TabIndex = 18;
            this.securityKeyTextBox.TextChanged += new System.EventHandler(this.securityKeyTextBox_TextChanged);
            // 
            // passTextBox
            // 
            this.passTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passTextBox.Location = new System.Drawing.Point(370, 32);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.PasswordChar = '*';
            this.passTextBox.Size = new System.Drawing.Size(157, 20);
            this.passTextBox.TabIndex = 17;
            this.passTextBox.TextChanged += new System.EventHandler(this.passTextBox_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Security Key";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username";
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(115, 32);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(157, 20);
            this.userTextBox.TabIndex = 0;
            this.userTextBox.TextChanged += new System.EventHandler(this.userTextBox_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.securityGroupsCheckedListBox);
            this.groupBox5.Location = new System.Drawing.Point(3, 256);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(534, 148);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Security Groups";
            // 
            // securityGroupsCheckedListBox
            // 
            this.securityGroupsCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.securityGroupsCheckedListBox.FormattingEnabled = true;
            this.securityGroupsCheckedListBox.Location = new System.Drawing.Point(9, 19);
            this.securityGroupsCheckedListBox.Name = "securityGroupsCheckedListBox";
            this.securityGroupsCheckedListBox.Size = new System.Drawing.Size(519, 123);
            this.securityGroupsCheckedListBox.Sorted = true;
            this.securityGroupsCheckedListBox.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1119, 461);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox debugCheckBox;
        private System.Windows.Forms.CheckBox skipTlsCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.CheckBox logCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox caTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox templateComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox certCommonNameComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox uuidCheckBox;
        private System.Windows.Forms.CheckBox samCheckBox;
        private System.Windows.Forms.CheckBox userCheckBox;
        private System.Windows.Forms.CheckBox hostCheckBox;
        private System.Windows.Forms.CheckBox dnsCheckBox;
        private System.Windows.Forms.CheckBox dnCheckBox;
        private System.Windows.Forms.Button checkCaButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox devNameComboBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox securityGroupsCheckedListBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox devLocationComboBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox securityKeyTextBox;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.Label Port;
        private System.Windows.Forms.MaskedTextBox portTextBox;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.ComboBox cbAddress;
        private System.Windows.Forms.Label warnlbl;
    }
}