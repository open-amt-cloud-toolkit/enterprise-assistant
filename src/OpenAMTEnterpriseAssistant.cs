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

using CERTENROLLLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace OpenAMTEnterpriseAssistant
{
    public class OpenAMTEnterpriseAssistantServer
    {
        private DomainControllerServices dc = null;
        public RemoteProvisioningServer rps = null;
        private string host = null;
        private string user = null;
        private string pass = null;
        private string loginkey = null;
        public string devNameType = null;
        public string devLocation = null;
        public List<string> devSecurityGroups = null;
        public bool debug = false;
        public bool ignoreCert = false;
        private bool autoReconnect = true;
        public int connectionState { get { if (rps == null) { return 0; } else { return rps.connectionState; } } }

        // Certificate Authority
        private string caName = null;
        private string caTemplate = null;
        private X509Certificate2 caRootCert = null;
        private string caCommonName = null;
        private string certCommonName = null;
        private string certAltNames = null;

        public delegate void onStateChangedHandler(int state);
        public event onStateChangedHandler onStateChanged;

        public delegate void onMessageHandler(string msg);
        public event onMessageHandler onMessage;

        public delegate void onEventHandler(ServerEvent e);
        public event onEventHandler onEvent;
        private List<ServerEvent> events = new List<ServerEvent>();

        public class ServerEvent
        {
            public ServerEvent(int icon, DateTime time, string msg) { this.icon = icon; this.time = time; this.msg = msg; }
            public int icon;
            public DateTime time;
            public string msg;
        }

        private readonly string[] netAuthStrings = { "eap-tls", "eap-ttls/mschapv2", "peapv0/eap-mschapv2", "peapv1/eap-gtc", "eap-fast/mschapv2", "eap-fast/gtc", "eap-md5", "eap-psk", "eap-sim", "eap-aka", "eap-fast/tls" };

        public OpenAMTEnterpriseAssistantServer(string host, string user, string pass, string loginkey, string devLocation)
        {
            this.host = host;
            this.user = user;
            this.pass = pass;
            this.loginkey = loginkey;

            string devLocationReversed = null;
            if (devLocation != null) { devLocationReversed = String.Join(",", DomainControllerServices.reverseStringArray(devLocation.Split(','))); }
            if (DomainControllerServices.isComputerJoinedToDomain()) { dc = new DomainControllerServices(devLocationReversed); }
        }

        // caName must be of format: <COMPUTERNAME>\\<CANAME>
        public bool SetCertificateAuthority(string caName, string caTemplate, string certCommonName, string certAltNames)
        {
            if ((caName == null) || (caName == ""))
            {
                // Clear CA
                caRootCert = null;
                this.caName = null;
                this.caTemplate = null;
                caCommonName = null;
                certCommonName = null;
                certAltNames = null;
                return true;
            }
            else
            {
                // Test Certificate Authority Connectivity
                try { caRootCert = CertificationAuthorityService.GetRootCertificate(caName); } catch (Exception) { }
                if (caRootCert == null)
                {
                    // CA does not work
                    this.caName = null;
                    caCommonName = null;
                    Log("ERROR: Unable to contact certificate authority: " + caName);
                    return false;
                }
                else
                {
                    // CA works
                    this.caName = caName;
                    this.caTemplate = caTemplate;
                    caCommonName = CertificationAuthorityService.GetCommonNameFromSubject(caRootCert.Subject);
                    Log("Contacted certificate authority: " + caCommonName);
                    this.certCommonName = certCommonName;
                    this.certAltNames = certAltNames;
                    return true;
                }
            }
        }

        public void AddTestComputer()
        {
            string testComputerName = "TestDevice";

            if (dc == null) { Log("Unable to add computer, not part of a domain."); return; }
            DomainControllerServices.ActiveDirectoryComputerObject computer = dc.CreateComputer(testComputerName, "Satellite Test Device", devSecurityGroups);
            if (computer != null)
            {
                if (computer.AlreadyPresent)
                {
                    LogEvent(1, "Reset computer: " + testComputerName);
                }
                else
                {
                    LogEvent(1, "Added computer: " + testComputerName);
                }
            }
            else
            {
                LogEvent(1, "Failed to add computer: " + testComputerName);
            }
        }

        public void RemoveTestComputer()
        {
            string testComputerName = "TestDevice";

            if (dc == null) { Log("Unable to remove computer, not part of a domain."); return; }
            if (dc.RemoveComputer(testComputerName))
            {
                LogEvent(1, "Removed computer: " + testComputerName);
            }
            else
            {
                LogEvent(1, "Failed to removed computer: " + testComputerName);
            }
        }

        public void TestCertificateAuthority()
        {
            if ((caName == null) || (caName == ""))
            {
                Log("No certificate authority setup.");
            }
            else
            {
                X509Certificate2 cert = null;
                try { cert = CertificationAuthorityService.GetRootCertificate(caName); } catch (Exception) { }
                if (cert != null)
                {
                    Log("Succesfuly contacted CA: " + caName);
                }
                else
                {
                    Log("Failed to contact CA: " + caName);
                }
            }
        }

        public void EventCertificateAuthorities()
        {
            if (dc == null) { Log("Unable to enumerate CA's, not part of a domain."); return; }
            List<DomainControllerServices.CertificateAuthority> CAs = dc.GetCertificateAuthoritiesTemplatesAndTrustedRoots();
            if (CAs.Count == 0)
            {
                Log("No certificate authority found.");
            }
            else
            {
                Log("Certificate authority found: " + CAs.Count);
                foreach (DomainControllerServices.CertificateAuthority ca in CAs)
                {
                    Log("Certificate authority: \"" + ca.CAName + "\n, IsRoot: " + ca.IsRoot);
                }
            }
        }

        public List<DomainControllerServices.CertificateAuthority> GetCertificateAuthoritiesTemplatesAndTrustedRoots()
        {
            if (dc == null) return null;
            return dc.GetCertificateAuthoritiesTemplatesAndTrustedRoots();
        }

        private void Log(string msg)
        {
            if (onMessage != null) { onMessage(msg); }
        }

        private void LogEvent(int icon, string msg)
        {
            ServerEvent e = new ServerEvent(icon, DateTime.Now, msg);
            events.Add(e);
            if (onEvent != null) { onEvent(e); }
        }

        public void Start()
        {
            Log("Open AMT Enterprise Assistant - Start();");
            autoReconnect = true;

            if (rps != null)
            {
                // Already connected instance
                rps.onStateChanged += Meshcentral_onStateChanged;
                rps.onTwoFactorCookie += Meshcentral_onTwoFactorCookie;
                rps.onSatelliteMessage += Meshcentral_onSatelliteMessage;
                if (onStateChanged != null) { onStateChanged(rps.connectionState); }
            }
            else
            {
                // Need to perform connection
                rps = new RemoteProvisioningServer();
                rps.onStateChanged += Meshcentral_onStateChanged;
                rps.onTwoFactorCookie += Meshcentral_onTwoFactorCookie;
                rps.onSatelliteMessage += Meshcentral_onSatelliteMessage;
                rps.debug = debug;
                rps.ignoreCert = ignoreCert;
                if (loginkey == null)
                {
                    rps.connect(new Uri(host), user, pass, null);
                }
                else
                {
                    rps.connect(new Uri(host + "?key=" + loginkey), user, pass, null);
                }
            }
        }

        private string NodeIdToComputerId(string nodeid) { return nodeid.Split('/')[2].Substring(0, 12); }

        private string ComputerName(string devname, string nodeid) {
            if (devNameType.ToLower() == "nodeid") { return NodeIdToComputerId(nodeid); }
            return devname;
        }

        private string ComputerDesciption(string devname, string nodeid, string devVersion)
        {
            if (devVersion == null) {
                if (devNameType.ToLower() == "nodeid") { return "Intel® AMT device - " + devname; }
                return "Intel® AMT device - " + nodeid;
            }
            else
            {
                if (devNameType.ToLower() == "nodeid") { return "Intel® AMT v" + devVersion + " - " + devname; }
                return "Intel® AMT v" + devVersion + " - " + nodeid;
            }
        }


        private void Meshcentral_onSatelliteMessage(Dictionary<string, object> message)
        {
            string subaction = null;
            try { subaction = (string)message["subaction"]; } catch (Exception) { return; }
            if (subaction == null) return;
            switch (subaction)
            {
                case "802.1x-ProFile-Request": { RequestFor8021xProfile(message); break; }
                case "802.1x-KeyPair-Response": { ResponseFor8021xKeyPairGeneration(message); break; }
                case "802.1x-CSR-Response": { ResponseFor8021xCSR(message); break; }
                case "802.1x-Profile-Remove": { RequestFor8021xProfileRemoval(message); break; }
                default: { Log("Unknown request: " + subaction); break; }
            }
        }

        public Dictionary<string, object> RequestFor8021xProfile(Dictionary<string, object> message, bool isHttpRequest = false)
        {
            int satelliteFlags = 0;
            string nodeid = null;
            string domain = null;
            string reqid = null;
            int authProtocol = 0;
            string devname = null;
            string osname = null;
            int devIcon = 1;
            string clientCert = null;
            string clientCertId = null;
            string devVersion = null;
            Dictionary<string, object> response = new Dictionary<string, object>();
            try
            {
                try
                {
                    satelliteFlags = Convert.ToInt32(message["satelliteFlags"]);
                    nodeid = (string)message["nodeid"];
                    domain = (string)message["domain"];
                    reqid = (string)message["reqid"];
                    authProtocol = Convert.ToInt32(message["authProtocol"]);
                    if (message.ContainsKey("devname")) { devname = (string)message["devname"]; }
                    if (message.ContainsKey("osname")) { osname = (string)message["osname"]; }
                    if (message.ContainsKey("icon")) { devIcon = Convert.ToInt32(message["icon"]); }
                    if (message.ContainsKey("cert")) { clientCert = (string)message["cert"]; }
                    if (message.ContainsKey("certid")) { clientCertId = (string)message["certid"]; }
                    if (message.ContainsKey("ver")) { devVersion = (string)message["ver"]; }
                }
                catch (Exception ex)
                {
                    Log("Error :" + ex);
                    satelliteFlags = 0; 
                }        

                if (devname == null) {
                    devname = nodeid; 
                }

                if ((satelliteFlags != 2) || (nodeid == null) || (domain == null) || (reqid == null) || (authProtocol > 10) || (authProtocol < 0))
                {
                    response["status"] = "Error";
                    response["details"] = "Invalid request for profile.";
                    Log("Open AMT Enterprise Assistant - Invalid request for profile.");
                    return response;
                }

                if (devname != null) {
                    Log("Open AMT Enterprise Assistant - " + devname + " - " +netAuthStrings[authProtocol] + " request."); 
                }

                switch (authProtocol)
                {
                    case 0: // eap-tls
                        {
                            if (caName == null)
                            {
                                response["status"] = "Error";
                                response["details"] = "ERROR: " + devname + " requested a EAP-TLS profile with no CA configured.";
                                LogEvent(devIcon, "ERROR: " + devname + " requested a EAP-TLS profile with no CA configured.");
                                return response; // We dont have a CA, EAP-TLS is not supported.
                            }

                            // Check that this computer is allowed to have a profile
                            // TODO

                            // If Intel AMT already has a client certificate, check if it's correct
                            bool certOk = false;
                            string certRovokeSerialNumber = null;
                            if ((clientCert != null) && (clientCertId != null))
                            {
                                try
                                {
                                    // Decode the certificate
                                    X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(clientCert));
                                    certRovokeSerialNumber = cert.GetSerialNumberString();
                                    long certStart = cert.NotBefore.Ticks;
                                    long certEnd = cert.NotAfter.Ticks;
                                    long certMidPoint = certStart + ((certEnd - certStart) / 2);
                                    long now = DateTime.Now.Ticks;
                                    if ((now > certStart) && (now < certMidPoint))
                                    {
                                        // Certificate is within validity period, check issuer name
                                        if (cert.Issuer == caRootCert.Subject)
                                        {
                                            // Correct issuer, check that it's correctly signed by the CA root.
                                            certOk = true;
                                        }
                                    }
                                }
                                catch (Exception) { }
                            }

                            if (certOk)
                            {
                                // Existing client certificate is ok, just renew the profile
                                DomainControllerServices.ActiveDirectoryComputerObject computer = null;
                                try { computer = dc.CreateComputer(ComputerName(devname, nodeid), ComputerDesciption(devname, nodeid, devVersion), devSecurityGroups); } catch (Exception ex) { Log("MeshCentralSatelliteServer: " + ex.ToString()); }
                                if (computer != null)
                                {
                                    if (computer.AlreadyPresent) { LogEvent(devIcon, "Reset computer: " + devname); } else { LogEvent(devIcon, "Added computer: " + devname); }
                                    response["authProtocol"] = authProtocol;
                                    response["domain"] = dc.DomainName;
                                    response["username"] = computer.SamAccountName;
                                    response["password"] = computer.Password;
                                    if (caRootCert != null) { response["rootcert"] = Convert.ToBase64String(caRootCert.GetRawCertData(), Base64FormattingOptions.None); }
                                    response["certid"] = clientCertId;
                                    message["subaction"] = "Profile-Completed";
                                    message["response"] = response;

                                    if (!isHttpRequest)
                                    {
                                        rps.sendCommand(message);
                                    }
                                    Log("Open AMT Enterprise Assistant - " + devname + " - Cert OK, Sent response.");
                                }
                                else
                                {
                                    response["status"] = "Error";
                                    response["details"] = "Failed to add computer: " + devname;
                                    LogEvent(devIcon, "Failed to add computer: " + devname);
                                }
                            }
                            else
                            {
                                // Revoke the old certificate, we will be getting a new one
                                if (certRovokeSerialNumber != null)
                                {
                                    CertificationAuthorityService.RevokeCertificateFromCa(caName, certRovokeSerialNumber, DomainControllerServices.CertRevokeReason.CrlReasonCessationOfOperation);
                                }

                                // Request that Intel AMT generate a key pair
                                response["action"] = "satellite";
                                response["satelliteFlags"] = 2; // Indicate operation
                                response["nodeid"] = nodeid;
                                response["domain"] = domain;
                                response["subaction"] = "KeyPair-Request";
                                response["reqid"] = reqid;
                                if (!isHttpRequest)
                                {
                                    rps.sendCommand(message);
                                    Log("Open AMT Enterprise Assistant - " + devname + " - Requesting key pair generation...");
                                }
                            }
                            break;
                        }
                    case 2: // peapv0/eap-mschapv2
                        {
                            if (dc == null)
                            {
                                LogEvent(devIcon, "Failed to add computer: " + devname);
                            }
                            else
                            {
                                // Request the computer be created or reset in the domain
                                DomainControllerServices.ActiveDirectoryComputerObject computer = null;
                                try { computer = dc.CreateComputer(ComputerName(devname, nodeid), ComputerDesciption(devname, nodeid, devVersion), devSecurityGroups); } catch (Exception ex) { Log("MeshCentralSatelliteServer: " + ex.ToString()); }
                                if (computer != null)
                                {
                                    if (computer.AlreadyPresent) { LogEvent(devIcon, "Reset computer: " + devname); } else { LogEvent(devIcon, "Added computer: " + devname); }
                                    response["authProtocol"] = authProtocol;
                                    response["domain"] = dc.DomainName;
                                    response["username"] = computer.SamAccountName;
                                    response["password"] = computer.Password;
                                    if (caRootCert != null) { response["rootcert"] = Convert.ToBase64String(caRootCert.GetRawCertData(), Base64FormattingOptions.None); }
                                    message["subaction"] = "Profile-Completed";
                                    message["response"] = response;
                                    if (!isHttpRequest)
                                    {
                                        rps.sendCommand(message);
                                        Log("Open AMT Enterprise Assistant - " + devname + " - Sent response.");
                                    }
                                }
                                else
                                {
                                    response["status"] = "Error";
                                    response["details"] = "Failed to add computer: " + devname;
                                    LogEvent(devIcon, "Failed to add computer: " + devname);
                                }
                            }
                            break;
                        }
                    default:
                        {
                            response["status"] = "Error";
                            response["details"] = "Unsupported protocol";
                            Log("Open AMT Enterprise Assistant - " + devname + " - Unsupported protocol: " + netAuthStrings[authProtocol]);
                            break;
                        }
                }

            }
            catch (Exception ex) {
                response["status"] = "Error";
                response["details"] = "Exception occurred: " + ex.Message;
                Log("Error in RequestFor8021xProfile: " + ex.Message);
            }
            return message;
        }


        public Dictionary<string, object> ResponseFor8021xKeyPairGeneration(Dictionary<string, object> message, bool isHttpRequest = false)
        {
            int satelliteFlags = 0;
            string nodeid = null;
            string domain = null;
            string reqid = null;
            int authProtocol = 0;
            string devname = null;
            string osname = null;
            int devIcon = 1;
            string DERKey = null;
            string keyInstanceId = null;
            string devVersion = null;
            Dictionary<string, object> rmessage = new Dictionary<string, object>();
            Dictionary<string, object> errmessage = new Dictionary<string, object>();
            try
            {
                satelliteFlags = Convert.ToInt32(message["satelliteFlags"]);
                nodeid = (string)message["nodeid"];
                domain = (string)message["domain"];
                reqid = (string)message["reqid"];
                authProtocol = Convert.ToInt32(message["authProtocol"]);
                if (message.ContainsKey("devname")) { devname = (string)message["devname"]; }
                if (message.ContainsKey("osname")) { osname = (string)message["osname"]; }
                if (message.ContainsKey("icon")) { devIcon = Convert.ToInt32(message["icon"]); }
                if (message.ContainsKey("DERKey")) { DERKey = (string)message["DERKey"]; }
                if (message.ContainsKey("keyInstanceId")) { 
                    keyInstanceId = (string)message["keyInstanceId"];
                }
                if (message.ContainsKey("ver")) { devVersion = (string)message["ver"]; }
            }
            catch (Exception) { satelliteFlags = 0; }

            if (devname == null) { devname = nodeid; }

            if ((satelliteFlags != 2) || (nodeid == null) || (domain == null) || (reqid == null) || (authProtocol > 10) || (authProtocol < 0))
            {
                errmessage["status"] = "Error";
                errmessage["details"] = "Invalid response for key pair generation.";
                Log("Open AMT Enterprise Assistant -  Invalid response for key pair generation.");
                return errmessage;
            }
            
            switch (authProtocol)
            {
                case 0: // eap-tls
                    {
                        if (caName == null)
                        {
                            errmessage["status"] = "Error";
                            errmessage["details"] = "ERROR: " + devname + " requested a EAP-TLS profile with no CA configured.";
                            LogEvent(devIcon, "ERROR: " + devname + " requested a EAP-TLS profile with no CA configured.");
                            return errmessage; // We dont have a CA, EAP-TLS is not supported.
                        }

                        // Check that this computer is allowed to have a profile
                        // TODO

                        // Generate a certificate for this device
                        DomainControllerServices.ActiveDirectoryComputerObject computer = null;
                        try { computer = dc.CreateComputer(ComputerName(devname, nodeid), ComputerDesciption(devname, nodeid, devVersion), devSecurityGroups); } catch (Exception ex) { Log("MeshCentralSatelliteServer: " + ex.ToString()); }

                        string[] xCertAltNames = null;
                        if (certAltNames == null) { xCertAltNames = "DistinguishedName,DNSFQDN,Hostname,UserPrincipalName,SAMAccountName,UUID".ToLower().Split(','); } else { xCertAltNames = certAltNames.ToLower().Split(','); }
                        Dictionary<CertificationAuthorityService.CommonNameTypes, string> altNames = new Dictionary<CertificationAuthorityService.CommonNameTypes, string>();
                        if ((xCertAltNames.Contains("distinguishedname")) && ((certCommonName.ToLower() != "distinguishedname"))) { altNames[CertificationAuthorityService.CommonNameTypes.DistinguishedName] = computer.DistinguishedName; }
                        if ((xCertAltNames.Contains("dnsfqdn")) && ((certCommonName.ToLower() != "dnsfqdn"))) { altNames[CertificationAuthorityService.CommonNameTypes.DNSFQDN] = computer.DnsFqdn; }
                        if ((xCertAltNames.Contains("hostname")) && ((certCommonName.ToLower() != "hostname"))) { altNames[CertificationAuthorityService.CommonNameTypes.Hostname] = computer.HostName; }
                        if ((xCertAltNames.Contains("userprincipalname")) && ((certCommonName.ToLower() != "userprincipalname"))) { altNames[CertificationAuthorityService.CommonNameTypes.UserPrincipalName] = computer.UserPrincipalName; }
                        if ((xCertAltNames.Contains("samaccountname")) && ((certCommonName.ToLower() != "samaccountname"))) { altNames[CertificationAuthorityService.CommonNameTypes.SAMAccountName] = computer.SamAccountName; }
                        if ((xCertAltNames.Contains("uuid")) && ((certCommonName.ToLower() != "uuid"))) { altNames[CertificationAuthorityService.CommonNameTypes.UUID] = computer.Uuid.ToString(); }

                        // Look at the common name that will be used to create the certificate
                        var objDistinguishedName = new CX500DistinguishedName();
                        if (certCommonName.ToLower() == "dnsfqdn") { objDistinguishedName.Encode("CN=" + computer.DnsFqdn); }
                        else if (certCommonName.ToLower() == "hostname") { objDistinguishedName.Encode("CN=" + computer.HostName); }
                        else if (certCommonName.ToLower() == "userprincipalname") { objDistinguishedName.Encode("CN=" + computer.UserPrincipalName); }
                        else if (certCommonName.ToLower() == "samaccountname") { objDistinguishedName.Encode("CN=" + computer.SamAccountName); }
                        else if (certCommonName.ToLower() == "uuid") { objDistinguishedName.Encode("CN=" + computer.Uuid); }
                        else { objDistinguishedName.Encode(computer.DistinguishedName, X500NameFlags.XCN_CERT_NAME_STR_COMMA_FLAG); } // "distinguishedname"

                        // You can use "Get-CATemplate" in PowerShell to get a list of supported CA templates.
                        string csr = CertificationAuthorityService.GenerateNullCsr(objDistinguishedName, altNames, caTemplate, Convert.FromBase64String(DERKey));
                        if (csr == null)
                        {
                            Log("Open AMT Enterprise Assistant - " + devname + " - Unable to generate NULL CSR.");
                        }
                        else
                        {
                            csr = csr.Replace("\r", "").Replace("\n", "");

                            // Request that Intel AMT sign the CSR
                            Dictionary<string, object> response = new Dictionary<string, object>();
                            response["csr"] = csr;
                            response["keyInstanceId"] = keyInstanceId;
                            rmessage["action"] = "satellite";
                            rmessage["satelliteFlags"] = 2; // Indicate operation
                            rmessage["nodeid"] = nodeid;
                            rmessage["domain"] = domain;
                            rmessage["subaction"] = "CSR-Request";
                            rmessage["reqid"] = reqid;
                            rmessage["response"] = response;
                            if (!isHttpRequest)
                            {
                                rps.sendCommand(rmessage);
                            }
                            Log("Open AMT Enterprise Assistant - " + devname + " - Requesting CSR signature...");
                        }
                        break;
                    }
                default:
                    {
                        errmessage["status"] = "Error";
                        errmessage["details"] = "ERROR: " + devname + " - Unsupported protocol: " + netAuthStrings[authProtocol];
                        Log("Open AMT Enterprise Assistant - " + devname + " - Unsupported protocol: " + netAuthStrings[authProtocol]);
                        return errmessage;
                    }
            }
            return rmessage;
        }

        public Dictionary<string, object> ResponseFor8021xCSR(Dictionary<string, object> message, bool isHttpRequest = false)
        {
            int satelliteFlags = 0;
            string nodeid = null;
            string domain = null;
            string reqid = null;
            int authProtocol = 0;
            string devname = null;
            string osname = null;
            int devIcon = 1;
            string signedcsr = null;
            string devVersion = null;
            Dictionary<string, object> errmessage = new Dictionary<string, object>();
            try
            {
                satelliteFlags = Convert.ToInt32(message["satelliteFlags"]);
                nodeid = (string)message["nodeid"];
                domain = (string)message["domain"];
                reqid = (string)message["reqid"];
                authProtocol = Convert.ToInt32(message["authProtocol"]);
                if (message.ContainsKey("devname")) { devname = (string)message["devname"]; }
                if (message.ContainsKey("osname")) { osname = (string)message["osname"]; }
                if (message.ContainsKey("icon")) { devIcon = Convert.ToInt32(message["icon"]); }
                if (message.ContainsKey("signedcsr")) { signedcsr = (string)message["signedcsr"]; }
                if (message.ContainsKey("ver")) { devVersion = (string)message["ver"]; }
            }
            catch (Exception) { satelliteFlags = 0; }

            if (devname == null) { devname = NodeIdToComputerId(nodeid); }

            if ((satelliteFlags != 2) || (nodeid == null) || (domain == null) || (reqid == null) || (authProtocol > 10) || (authProtocol < 0) || (signedcsr == null))
            {
                errmessage["status"] = "Error";
                errmessage["details"] = "Invalid response for CSR.";
                Log("Open AMT Enterprise Assistant - Invalid response for CSR.");
                return errmessage;
            }

            switch (authProtocol)
            {
                case 0: // eap-tls
                    {
                        if (caName == null)
                        {
                            errmessage["status"] = "Error";
                            errmessage["details"] = "ERROR: " + devname + " requested a EAP-TLS profile with no CA configured.";
                            LogEvent(devIcon, "ERROR: " + devname + " requested a EAP-TLS profile with no CA configured.");
                            return errmessage; // We dont have a CA, EAP-TLS is not supported.
                        }

                        // Check that this computer is allowed to have a profile
                        // TODO

                        // Sign the certificate request
                        X509Certificate2 cert = null;
                        cert = CertificationAuthorityService.GetClientCertFromCsr(signedcsr, caName);
                        if (cert != null)
                        {
                            // Request the computer be created or reset in the domain
                            DomainControllerServices.ActiveDirectoryComputerObject computer = null;
                            try { computer = dc.CreateComputer(ComputerName(devname, nodeid), ComputerDesciption(devname, nodeid, devVersion), devSecurityGroups); } catch (Exception ex) { Log("MeshCentralSatelliteServer: " + ex.ToString()); }
                            if (computer != null)
                            {
                                if (computer.AlreadyPresent) { LogEvent(devIcon, "Reset computer: " + devname); } else { LogEvent(devIcon, "Added computer: " + devname); }
                                Dictionary<string, object> response = new Dictionary<string, object>();
                                response["authProtocol"] = authProtocol;
                                response["certificate"] = Convert.ToBase64String(cert.GetRawCertData(), Base64FormattingOptions.None);
                                if (caRootCert != null) { response["rootcert"] = Convert.ToBase64String(caRootCert.GetRawCertData(), Base64FormattingOptions.None); }
                                response["domain"] = dc.DomainName;
                                response["username"] = computer.SamAccountName;
                                //response["password"] = computer.Password;
                                message["subaction"] = "Profile-Completed";
                                message["response"] = response;
                                if (!isHttpRequest)
                                {
                                    rps.sendCommand(message);
                                }
                                Log("Open AMT Enterprise Assistant - " + devname + " - Sent response.");
                            }
                            else
                            {
                                errmessage["status"] = "Error";
                                errmessage["details"] = "ERROR: Failed to add computer: " + devname;
                                LogEvent(devIcon, "Failed to add computer: " + devname);
                                return errmessage;
                            }
                        }
                        else
                        {
                            errmessage["status"] = "Error";
                            errmessage["details"] = "ERROR: Failed to sign the certificate: " + devname;
                            LogEvent(devIcon, "Failed to sign the certificate: " + devname);
                            return errmessage;
                        }
                        break;
                    }
                default:
                    {
                        errmessage["status"] = "Error";
                        errmessage["details"] = "ERROR: " + devname + " - Unsupported protocol: " + netAuthStrings[authProtocol];
                        Log("Open AMT Enterprise Assistant - " + devname + " - Unsupported protocol: " + netAuthStrings[authProtocol]);
                        return errmessage;
                    }
            }
            return message;
        }

        public void RequestFor8021xProfileRemoval(Dictionary<string, object> message)
        {
            int satelliteFlags = 0;
            string nodeid = null;
            string domain = null;
            string devname = null;
            int devIcon = 1;

            try
            {
                satelliteFlags = Convert.ToInt32(message["satelliteFlags"]);
                nodeid = (string)message["nodeid"];
                domain = (string)message["domain"];
            }
            catch (Exception) { satelliteFlags = 0; }

            if (devname == null) { devname = NodeIdToComputerId(nodeid); }

            if ((satelliteFlags != 2) || (nodeid == null) || (domain == null))
            {
                Log("Open AMT Enterprise Assistant - Invalid removal request.");
                return;
            }

            if (devname != null) { Log("Open AMT Enterprise Assistant - " + devname + " - removal request."); }

            if ((dc != null) && (dc.RemoveComputer(NodeIdToComputerId(nodeid))))
            {
                LogEvent(devIcon, "Removed computer: " + devname);
            }
            else
            {
                LogEvent(devIcon, "Failed to remove computer: " + devname);
            }
        }

        public void Stop()
        {
            Log("Open AMT Enterprise Assistant - Stop();");
            autoReconnect = false;
            if (rps == null) return;
            rps.onStateChanged -= Meshcentral_onStateChanged;
            rps.onTwoFactorCookie -= Meshcentral_onTwoFactorCookie;
            rps.onSatelliteMessage -= Meshcentral_onSatelliteMessage;
            try { rps.disconnect(); } catch (Exception) { }
            rps = null;
        }

        public void Dispose()
        {
            Stop();
        }

        private void Meshcentral_onTwoFactorCookie(string cookie)
        {
            Log("Saving 2FA cookie");
            Settings.SetRegValue("TwoFactorCookie", cookie);
        }

        private void Meshcentral_onStateChanged(int state)
        {
            switch (state)
            {
                case 0:
                    Log("Disconnected");
                    if (autoReconnect)
                    {
                        if (rps == null) return;
                        rps.onStateChanged -= Meshcentral_onStateChanged;
                        rps.onTwoFactorCookie -= Meshcentral_onTwoFactorCookie;
                        rps.onSatelliteMessage -= Meshcentral_onSatelliteMessage;
                        rps = null;
                        Start();
                        return;
                    }
                    break;
                case 1:
                    Log("Connecting to: " + host + ", user: " + user);
                    break;
                case 2:
                    Log("Connected");
                    rps.sendSatelliteSetFlags(3);
                    break;
            }
            if (onStateChanged != null) { onStateChanged(state); }
        }

    }
}
