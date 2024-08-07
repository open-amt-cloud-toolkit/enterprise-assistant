﻿/*
Copyright 2022 Intel Corporation

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Text;

namespace OpenAMTEnterpriseAssistant
{
    public partial class SettingsForm : Form
    {
        public string checkedCA = null;

        private class ListViewItemObj
        {
            public string name;
            public string tag;

            public ListViewItemObj(string name, string tag)
            {
                this.name = name;
                this.tag = tag;
            }

            public override string ToString() { return name; }
        }

        public SettingsForm()
        {
            InitializeComponent();
            certCommonNameComboBox.SelectedIndex = 4;
            devNameComboBox.SelectedIndex = 0;

            if (DomainControllerServices.isComputerJoinedToDomain())
            {
                // Setup the list of possible locations to place Intel AMT computers
                List<string> computerLocations = DomainControllerServices.getDomainComputerLocations();
                foreach (string location in computerLocations) { devLocationComboBox.Items.Add(location); }

                // The default location is "CN=Computers"
                int index = -1;
                for (int i = 0; i < devLocationComboBox.Items.Count; i++) { if (devLocationComboBox.Items[i].ToString() == "CN=Computers") { index = i; } }
                if (index >= 0) { devLocationComboBox.SelectedIndex = index; }
            } else {
                securityGroupsCheckedListBox.Enabled = false;
            }

            // Bind all the avaialable IP addresses
            List<string> items = new List<string>() { };
            // Add default item
            items.Add("*");
            string hostName = Dns.GetHostName();
            // Get the IP address list that resolves to the host names.
            IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
            // Get all IPv4 addresses
            IPAddress[] ipv4Addresses = ipEntry.AddressList
                .Where(addr => addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                .ToArray();
            foreach (IPAddress addr in ipv4Addresses)
            {
                items.Add(addr.ToString());
            }
            cbAddress.DataSource = items;
            cbAddress.SelectedIndex = 0; // Set the default item as selected

        }

        public string host { get { return hostTextBox.Text; } set { hostTextBox.Text = value; updateInfo(); } }
        public string user { get { return userTextBox.Text; } set { userTextBox.Text = value; updateInfo(); } }
        public string pass { get { return passTextBox.Text; } set { passTextBox.Text = value; updateInfo(); } }
        public string securityKey { get { return securityKeyTextBox.Text; } set { securityKeyTextBox.Text = value; updateInfo(); } }
        public string address { 
            get { 
                return cbAddress.SelectedValue?.ToString(); 
            } 
            set {
                if (value != null) {
                    cbAddress.SelectedItem = value;
                }
                updateInfo(); 
            } 
        }
        public int port { get { return Convert.ToInt32(portTextBox.Text); } set { portTextBox.Text = value.ToString(); updateInfo(); } }
        public string caname { get { return caTextBox.Text; } set { caTextBox.Text = value; updateInfo(); } }
        public string catemplate { get { return templateComboBox.Text; } set { templateComboBox.Text = value; updateInfo(); } }
        public Boolean ignoreCert { get { return skipTlsCheckBox.Checked; } set { skipTlsCheckBox.Checked = value; updateInfo(); } }
        public Boolean log { get { return logCheckBox.Checked; } set { logCheckBox.Checked = value; updateInfo(); } }
        public Boolean debug { get { return debugCheckBox.Checked; } set { debugCheckBox.Checked = value; updateInfo(); } }
        public string devNameType {
            get
            {
                if (devNameComboBox.SelectedIndex == 0) { return "OSName"; }
                if (devNameComboBox.SelectedIndex == 1) { return "NodeID"; }
                return "OSName";
            }
            set
            {
                if (value.ToLower() == "osname") { devNameComboBox.SelectedIndex = 0; }
                else if (value.ToLower() == "nodeid") { devNameComboBox.SelectedIndex = 1; }
                else { devNameComboBox.SelectedIndex = 0; }
            }
        }
        public string certCommonName {
            get {
                if (certCommonNameComboBox.SelectedIndex == 0) { return "DistinguishedName"; }
                if (certCommonNameComboBox.SelectedIndex == 1) { return "DNSFQDN"; }
                if (certCommonNameComboBox.SelectedIndex == 2) { return "Hostname"; }
                if (certCommonNameComboBox.SelectedIndex == 3) { return "UserPrincipalName"; }
                if (certCommonNameComboBox.SelectedIndex == 4) { return "SAMAccountName"; }
                if (certCommonNameComboBox.SelectedIndex == 5) { return "UUID"; }
                return "DistinguishedName";
            }
            set {
                if (value == "DistinguishedName") { certCommonNameComboBox.SelectedIndex = 0; }
                else if (value == "DNSFQDN") { certCommonNameComboBox.SelectedIndex = 1; }
                else if (value == "Hostname") { certCommonNameComboBox.SelectedIndex = 2; }
                else if (value == "UserPrincipalName") { certCommonNameComboBox.SelectedIndex = 3; }
                else if (value == "SAMAccountName") { certCommonNameComboBox.SelectedIndex = 4; }
                else if (value == "UUID") { certCommonNameComboBox.SelectedIndex = 5; }
                else { certCommonNameComboBox.SelectedIndex = 0; }
            }
        }

        public List<string> securityGroups
        {
            get
            {
                List<string> r = new List<string>();
                foreach (ListViewItemObj x in securityGroupsCheckedListBox.CheckedItems) { r.Add(x.tag); }
                return r;
            }
            set
            {
                securityGroupsCheckedListBox.ClearSelected();
                List<string> toAdd = new List<string>();
                foreach (string x in value) {
                    bool found = false;
                    List<ListViewItemObj> z = new List<ListViewItemObj>();
                    foreach (ListViewItemObj y in securityGroupsCheckedListBox.Items) { z.Add(y); }
                    foreach (ListViewItemObj y in z)
                    {
                        if (x == y.tag) { securityGroupsCheckedListBox.SetItemChecked(securityGroupsCheckedListBox.Items.IndexOf(y), true); found = true; }
                    }
                    if (!found) { toAdd.Add(x); }
                }
                foreach (string securityGroup in toAdd)
                {
                    ListViewItemObj x = new ListViewItemObj(DomainControllerServices.GetFirstCommonNameFromDistinguishedName(securityGroup), securityGroup);
                    securityGroupsCheckedListBox.Items.Add(x, true);
                }
            }
        }

        public string devLocation
        {
            get
            {
                return devLocationComboBox.Text;
            }
            set
            {
                int index = -1;
                for (int i = 0; i < devLocationComboBox.Items.Count; i++) { if (devLocationComboBox.Items[i].ToString() == value) { index = i; } }
                if (index >= 0) { devLocationComboBox.SelectedIndex = index; } else
                {
                    devLocationComboBox.Items.Add(value);
                    devLocationComboBox.SelectedIndex = (devLocationComboBox.Items.Count - 1);
                }
            }
        }

        public string certAltNames {
            get
            {
                List<string> altNames = new List<string>();
                if (dnCheckBox.Checked) { altNames.Add("DistinguishedName"); }
                if (dnsCheckBox.Checked) { altNames.Add("DNSFQDN"); }
                if (hostCheckBox.Checked) { altNames.Add("Hostname"); }
                if (userCheckBox.Checked) { altNames.Add("UserPrincipalName"); }
                if (samCheckBox.Checked) { altNames.Add("SAMAccountName"); }
                if (uuidCheckBox.Checked) { altNames.Add("UUID"); }
                return string.Join(",", altNames.ToArray());
            }
            set
            {
                string altNamesStr = value;
                if (altNamesStr == null) { altNamesStr = "DistinguishedName,DNSFQDN,Hostname,UserPrincipalName,SAMAccountName,UUID"; }
                string[] altNames = value.Split(',');
                dnCheckBox.Checked = altNames.Contains("DistinguishedName");
                dnsCheckBox.Checked = altNames.Contains("DNSFQDN");
                hostCheckBox.Checked = altNames.Contains("Hostname");
                userCheckBox.Checked = altNames.Contains("UserPrincipalName");
                samCheckBox.Checked = altNames.Contains("SAMAccountName");
                uuidCheckBox.Checked = altNames.Contains("UUID");
            }
        }

        public void setCertificateAuthority(string caname, string catemplate)
        {
            caTextBox.Text = caname;
            checkCaButton_Click(this, null);
            templateComboBox.SelectedIndex = 0;
            if (catemplate != null)
            {
                for (int i = 0; i < templateComboBox.Items.Count; i++)
                {
                    if (templateComboBox.Items[i].ToString() == catemplate) { templateComboBox.SelectedIndex = i; }
                }
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            updateInfo();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void updateInfo()
        {
          templateComboBox.Enabled = certCommonNameComboBox.Enabled = ((checkedCA == caTextBox.Text) && (checkedCA != ""));

            bool ok = true;
            if (caTextBox.Text.Length != 0)
            {
                string[] splitStr = caTextBox.Text.Split('\\');
                if ((splitStr.Length != 2) || (splitStr[0].Length == 0) || (splitStr[1].Length == 0)) { ok = false; }
            }

            checkCaButton.Enabled = ((checkedCA != caTextBox.Text) && (caTextBox.Text != "") && (ok == true));

            if ((hostTextBox.Text.Length == 0) || (userTextBox.Text.Length == 0 && passTextBox.Text.Length == 0 && securityKeyTextBox.Text.Length == 0)) { ok = false; }
            if ((hostTextBox.Text.Length != 0) && (userTextBox.Text.Length == 0 && passTextBox.Text.Length == 0 && securityKeyTextBox.Text.Length == 0)) { ok = true; }
            if ((hostTextBox.Text.Length == 0) && (userTextBox.Text.Length != 0 && passTextBox.Text.Length != 0 && securityKeyTextBox.Text.Length != 0)) { ok = true; }
            if ((caTextBox.Text != "") && (checkedCA != caTextBox.Text)) { ok = false; }
            okButton.Enabled = ok;

            dnCheckBox.Enabled = (certCommonNameComboBox.SelectedIndex != 0) && (checkedCA == caTextBox.Text) && (checkedCA != "");
            dnsCheckBox.Enabled = (certCommonNameComboBox.SelectedIndex != 1) && (checkedCA == caTextBox.Text) && (checkedCA != "");
            hostCheckBox.Enabled = (certCommonNameComboBox.SelectedIndex != 2) && (checkedCA == caTextBox.Text) && (checkedCA != "");
            userCheckBox.Enabled = (certCommonNameComboBox.SelectedIndex != 3) && (checkedCA == caTextBox.Text) && (checkedCA != "");
            samCheckBox.Enabled = (certCommonNameComboBox.SelectedIndex != 4) && (checkedCA == caTextBox.Text) && (checkedCA != "");
            uuidCheckBox.Enabled = (certCommonNameComboBox.SelectedIndex != 5) && (checkedCA == caTextBox.Text) && (checkedCA != "");
        }

        private void hostTextBox_TextChanged(object sender, EventArgs e)
        {
            updateInfo();
        }

        private void hostTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            updateInfo();
        }

        private void checkCaButton_Click(object sender, EventArgs e)
        {
            string previousSelection = null;
            if (templateComboBox.SelectedItem != null) { previousSelection = templateComboBox.SelectedItem.ToString(); }
            if (caTextBox.Text != "")
            {
                string[] t = CertificationAuthorityService.GetCATemplates(caTextBox.Text);
                templateComboBox.Items.Clear();
                if (t != null) {
                    checkedCA = caTextBox.Text;
                    templateComboBox.Items.AddRange(t);
                    if (t.Length > 0) { templateComboBox.SelectedIndex = 0; }
                }
                else
                {
                    checkedCA = null;
                }
                templateComboBox.Enabled = (t != null);
                if (previousSelection != null)
                {
                    for (int i = 0; i < templateComboBox.Items.Count; i++)
                    {
                        if (templateComboBox.Items[i].ToString() == previousSelection) { templateComboBox.SelectedIndex = i; }
                    }
                }
            }
            else
            {
                checkedCA = null;
                templateComboBox.Items.Clear();
            }
            updateInfo();
        }

        private void devLocationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the list of groups that the Intel AMT computers could join
            securityGroupsCheckedListBox.Items.Clear();
            DomainControllerServices dc = new DomainControllerServices(String.Join(",", DomainControllerServices.reverseStringArray(devLocationComboBox.Text.Split(','))));
            List<string> securityGroups = dc.getSecurityGroups();
            if ((securityGroups != null) && (securityGroups.Count > 0))
            {
                foreach (string securityGroup in securityGroups)
                {
                    ListViewItemObj x = new ListViewItemObj(DomainControllerServices.GetFirstCommonNameFromDistinguishedName(securityGroup), securityGroup);
                    securityGroupsCheckedListBox.Items.Add(x);
                }
            }
        }

        private void userTextBox_TextChanged(object sender, EventArgs e)
        {
            updateInfo();
        }

        private void passTextBox_TextChanged(object sender, EventArgs e)
        {
            updateInfo();
        }

        private void securityKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            var keyBytes = Encoding.UTF8.GetBytes(securityKeyTextBox.Text);
            int keyLengthBits = keyBytes.Length * 8; // Convert byte length to bit length
            // Check if the key length is valid for AES
            if (keyLengthBits == 256 || keyLengthBits == 512)
            {
                updateInfo();
                securityKeyTextBox.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                securityKeyTextBox.BackColor = System.Drawing.Color.Red;
            }
        }

        private void portTextBox_MaskChanged(object sender, EventArgs e)
        {
            updateInfo();
        }

        private void cbAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateInfo();
        }

    }
}
