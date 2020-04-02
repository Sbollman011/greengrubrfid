using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm_Test;
using System.Net;
using System.Threading;

namespace UHFAPP
{
    public partial class MainForm : Form
    {
        public delegate void DelegateOpen(bool open);
        public static event DelegateOpen eventOpen = null;

        public delegate void DelegateSwitchUI();
        public static event DelegateSwitchUI eventSwitchUI = null;

        string strOpen1 = "  Open  ";
        string strClose1 = "  Close  ";

        private int currentType = 0;
        private bool isOpen = false;
        public MainForm mainform = null;
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            mainform = this;
            toolStripComboBox1.Items.Add("Chinese");
            toolStripComboBox1.Items.Add("English");
            toolStripComboBox1.SelectedIndex = 0;
            //toolStripOpen.Text = "  Open  ";
            SwitchShowUI();
            toolStripComboBox1.SelectedIndex = 1;
            UHFAPP.IPConfig.IPEntity  ipEntity= IPConfig.getIPConfig();
            if (ipEntity != null)
            {
                txtPort.Text = ipEntity.Port.ToString();
                ipControl1.IpData = new string[] { ipEntity.Ip[0], ipEntity.Ip[1], ipEntity.Ip[2], ipEntity.Ip[3] };
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           ScanEPC();
           getComPort();
           MenuItemScanEPC.Enabled = false;
           MenuItemReadWriteTag.Enabled = false;
           configToolStripMenuItem.Enabled = false;
           uHFVersionToolStripMenuItem.Enabled = false;
           killLockToolStripMenuItem.Enabled = false;
           toolStripMenuItem1.Enabled = false;
          // MenuItemReceiveEPC.Enabled = false;
           combCommunicationMode.SelectedIndex = 1;
         

        }
        public void enableControls()
        {
            menuStrip1.Enabled = true;
        }
        public void disableControls()
        {
            menuStrip1.Enabled = false;
        }


        private void MenuItemReadWriteTag_Click(object sender, EventArgs e)
        {
             ReadWriteTag("");
        }

        private void MenuItemScanEPC_Click(object sender, EventArgs e)
        {
            ScanEPC();
        }
        private void menuStrip1_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item.Text.Length == 0             
              || e.Item.Text == "Min(&N)"      
              || e.Item.Text == "Restore(&R)"        
              || e.Item.Text == "Close(&C)")       
            {
                e.Item.Visible = false;
            }
        }

        private void ScanEPC()
        {
            try
            {
                toolStripStatusLabel1.Visible = true;
               Form currForm= this.ActiveMdiChild;
               if (currForm == null || currentType != 0)
                {
                    //currentType = 0;
                    //ReadEPCForm frm_epcScan = new ReadEPCForm(isOpen, mainform);
                    //frm_epcScan.WindowState = FormWindowState.Maximized;
                    //frm_epcScan.MdiParent = this;
                    //frm_epcScan.Show();
                    //if (currForm != null)
                    //    currForm.Close();

                    int old = currentType;
                    currentType = 0;
                    ReadEPCForm frm_epcScan = new ReadEPCForm(isOpen, mainform);// ReadEPCForm frm_epcScan = (ReadEPCForm)Common.getForm("ReadEPCForm",this);
                    frm_epcScan.WindowState = FormWindowState.Maximized;
                    frm_epcScan.MdiParent = this;
                    frm_epcScan.Show();
                    if (currForm != null)
                    {
                        if (old == 0 || old == 2)
                        {
                            currForm.Close();
                        }
                        else
                        {
                            currForm.Hide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        
        public void ReadWriteTag(string tag)
        {
            toolStripStatusLabel1.Visible = false;
            try
            {
                Form currForm = this.ActiveMdiChild;
                if (currForm == null || currentType != 1)
                {
                   
                    //currentType = 1;
                     //ReadWriteTagForm frm_readWriter = new ReadWriteTagForm(isOpen,tag);
                    //frm_readWriter.WindowState = FormWindowState.Maximized;
                    //frm_readWriter.MdiParent = this;
                    //frm_readWriter.Show();
                    //if (currForm != null)
                    //    currForm.Close();

                    int old = currentType;
                    currentType = 1;
                    ReadWriteTagForm frm_readWriter = (ReadWriteTagForm)Common.getForm("ReadWriteTagForm", this);
                    frm_readWriter.setTAG(isOpen, tag);
                    frm_readWriter.WindowState = FormWindowState.Maximized;
                    frm_readWriter.MdiParent = this;
                    frm_readWriter.Show();
                    if (currForm != null)
                    {
                        if (old == 0 || old == 2)
                        {
                            currForm.Close();
                        }
                        else
                        {
                            currForm.Hide();
                        }
                    }
                }
                
             
            }
            catch (Exception ex)
            {

            }
        }

        
        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Visible = false;
            try
            {
               Form currForm= this.ActiveMdiChild;
               if (currForm == null || currentType != 2)
                {
                    //currentType =2;
                    //ConfigForm configForm = new ConfigForm(isOpen);
                    //configForm.WindowState = FormWindowState.Maximized;
                    //configForm.MdiParent = this;
                    //configForm.Show();
                    //if (currForm != null)
                    //    currForm.Close();

                    int old = currentType;
                    currentType = 2;
                    ConfigForm configForm = new ConfigForm(isOpen);// ConfigForm configForm = (ConfigForm)Common.getForm("ConfigForm", this);
                    configForm.WindowState = FormWindowState.Maximized;
                    configForm.MdiParent = this;
                    configForm.Show();
                    if (currForm != null)
                    {
                        if (old == 0 || old == 2)
                        {
                            currForm.Close();
                        }
                        else
                        {
                            currForm.Hide();
                        }
                    }
                      
                 
                }
            }
            catch (Exception ex)
            {

            }  
        }


        
        private void Lock()
        {
            toolStripStatusLabel1.Visible = false;
            try
            {
                Form currForm = this.ActiveMdiChild;
                if (currForm == null || currentType != 3)
                {
                    //currentType = 3;
                    //Kill_LockForm frm_readWriter = new Kill_LockForm(isOpen);
                    //frm_readWriter.WindowState = FormWindowState.Maximized;
                    //frm_readWriter.MdiParent = this;
                    //frm_readWriter.Show();
                    //if (currForm != null)
                    //    currForm.close();

                    int old = currentType;
                    currentType = 3;
                    Kill_LockForm frm_readWriter = (Kill_LockForm)Common.getForm("Kill_LockForm", this);
                    frm_readWriter.WindowState = FormWindowState.Maximized;
                    frm_readWriter.MdiParent = this;
                    frm_readWriter.Show();
                    if (currForm != null)
                    {
                        if (old == 0 || old == 2)
                        {
                            currForm.Close();
                        }
                        else
                        {
                            currForm.Hide();
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        
        private void uHFVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isOpen)
            {
                StringBuilder sb = new StringBuilder();
                frmWaitingBox f = new frmWaitingBox((obj, args) =>
                {
                    string hardwareV = UHFAPI.getInstance().GetHardwareVersion();
                    string softWareV = UHFAPI.getInstance().GetSoftwareVersion();
                    int id = UHFAPI.getInstance().GetUHFGetDeviceID();


                    sb.Append("Hardware version:  ");
                    sb.Append(hardwareV);
                    sb.Append("\r\nFirmware  version:  ");
                    sb.Append(softWareV);
                    sb.Append("\r\nDevice ID:  ");
                    sb.Append(id);

                });
                f.ShowDialog(this);

                MessageBoxEx.Show(this,sb.ToString());
             
            }
        }

        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            //if (toolStripOpen.Text == strOpen1 || toolStripOpen.Text == strOpen2)
            if (toolStripOpen.Text == strOpen1)
            {
                //----------------------------
       
                int com = 0;
                string ip = "";
                uint portData = 0;
                int type = combCommunicationMode.SelectedIndex;//0

                if (type == 0)
                {
                    
                    com = int.Parse(cmbComPort.SelectedItem.ToString().Replace("COM", ""));
                }
                else if (type == 1)
                {
                    if (txtPort.Text == "")
                    {
                        MessageBox.Show("fail!");
                        return;
                    }
                    
                    char[] port = txtPort.Text.ToCharArray();
                    for (int k = 0; k < port.Length; k++)
                    {
                        if (port[k] != '0' && port[k] != '1' && port[k] != '2' && port[k] != '3' && port[k] != '4' &&
                            port[k] != '5' && port[k] != '6' && port[k] != '7' && port[k] != '8' && port[k] != '9')
                        {
                            MessageBox.Show("fail!");
                            return;
                        }
                    }
                    portData = uint.Parse(txtPort.Text);
                    ip = cmbComPort.Text;
                }
                else
                {
                    MessageBox.Show("fail!");
                    return;

                }
                //---------------------------
                string msg = Common.isEnglish ? "connecting..." : "connecting...";
                frmWaitingBox f = new frmWaitingBox((obj, args) =>
                {

                    bool result = false;// UHFOpen();

                    if (type == 0)
                    {
                        result = UHFAPI.getInstance().Open(com);
                    }
                    else
                    {
                        result = UHFAPI.getInstance().TcpConnect(ip, portData);
                    }
                    if (result)
                    {
                        this.Invoke(new EventHandler(delegate
                        {
                            combCommunicationMode.Enabled = false;
                            cmbComPort.Enabled = false;
                            //if (toolStripOpen.Text == strOpen1)
                                toolStripOpen.Text = strClose1;
                            /*else
                                toolStripOpen.Text = strClose2;*/

                            isOpen = true;
                            if (eventOpen != null)
                            {
                                eventOpen(true);
                            }

                            MenuItemScanEPC.Enabled = true;
                            MenuItemReadWriteTag.Enabled = true;
                            configToolStripMenuItem.Enabled = true;
                            uHFVersionToolStripMenuItem.Enabled = true;
                            killLockToolStripMenuItem.Enabled = true;
                          //  MenuItemReceiveEPC.Enabled = true;
                            toolStripMenuItem1.Enabled = true;
                        }));
                    }
                    else
                    {
                        //MessageBox.Show("f");
                          frmWaitingBox.message = "fail";
                          Thread.Sleep(1000);
                    }
                }, msg);
                f.ShowDialog(this);

            }
            else {
                if (UHFClose())
                {
                    combCommunicationMode.Enabled = true;
                    cmbComPort.Enabled = true;
                    //if (toolStripOpen.Text == strClose1)
                        toolStripOpen.Text = strOpen1;
                    /*else
                        toolStripOpen.Text = strOpen2;*/

                    isOpen = false;
                    if (eventOpen != null)
                    {
                        eventOpen(false);
                    }
                    MenuItemScanEPC.Enabled = false;
                    MenuItemReadWriteTag.Enabled = false;
                    configToolStripMenuItem.Enabled = false;
                    uHFVersionToolStripMenuItem.Enabled = false;
                    killLockToolStripMenuItem.Enabled = false;
                    toolStripMenuItem1.Enabled = false;
                   // MenuItemReceiveEPC.Enabled = false;

                
                }
            }

        }
        
        private void getComPort()
        {
            string[] ArryPort = System.IO.Ports.SerialPort.GetPortNames();
            cmbComPort.Items.Clear();
            for (int i = 0; i < ArryPort.Length; i++)
            {
                cmbComPort.Items.Add(ArryPort[i]);
            }
            if (cmbComPort.Items.Count > 0)
                cmbComPort.SelectedIndex = cmbComPort.Items.Count-1;

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UHFClose();
        }

        private void killLockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lock();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (isOpen)
            {
             
                frmWaitingBox f = new frmWaitingBox((obj, args) =>
                {
                    string Temperature = UHFAPI.getInstance().GetTemperature();
                    string temp =(Common.isEnglish?"Temperature:":"Temperature:") + Temperature + "℃";
                    frmWaitingBox.message = temp;
                    System.Threading.Thread.Sleep(1500);
                });
                f.ShowDialog(this);
   
          

            }
        }




        private void SwitchShowUI()
        {

            toolStripStatusLabel1.Text = "";//"                                                         "+ "                                                          tip: 1. right key can copy the selected label.     2. double-click the selected label can jump to the r/w  UI.";
            MenuItemScanEPC.Text = "ReadEPC";
            MenuItemReadWriteTag.Text = "ReadWriteTag";
            configToolStripMenuItem.Text = "Configuration";
            killLockToolStripMenuItem.Text = "Kill-Lock";
            uHFVersionToolStripMenuItem.Text = "UHF Info";
            toolStripMenuItem1.Text = "Temperature";
            MenuItemReceiveEPC.Text = "UDP-ReceiveEPC";

            toolStripLabel4.Text = "Mode";
            int index = combCommunicationMode.SelectedIndex;
            combCommunicationMode.Items.Clear();
            combCommunicationMode.Items.Add("SerialPort");
            combCommunicationMode.Items.Add("network");
            combCommunicationMode.SelectedIndex = index;
            toolStripLabel3.Text = "Language";

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {


        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex == 0)
            {
                Common.isEnglish = false;
            }
            else
            {
                Common.isEnglish = true;
            }
            SwitchShowUI();

            if (eventSwitchUI != null)
            {
                eventSwitchUI();
            }
        }

        private void toolStripComboBox2_TextChanged(object sender, EventArgs e)
        {
            if (combCommunicationMode.SelectedIndex == 0)
            {
                getComPort();
                panel1.Visible = false;
            }
            else if (combCommunicationMode.SelectedIndex == 1)
            {
                panel1.Visible = true;
            }
        }

       
        private void getIP() {

            string[] ArryPort = System.IO.Ports.SerialPort.GetPortNames();
            cmbComPort.Items.Clear();

            IPHostEntry myEntry = Dns.GetHostByName(Dns.GetHostName());
            for (int k = 0; k < myEntry.AddressList.Length; k++) {

                IPAddress myIPAddress = new IPAddress(myEntry.AddressList[k].Address);

                cmbComPort.Items.Add(myIPAddress.ToString());
            }

            if (cmbComPort.Items.Count > 0)
                cmbComPort.SelectedIndex = cmbComPort.Items.Count - 1;
        }
          


        private bool UHFOpen()
        {
            bool result = false;
            result = UHFAPI.getInstance().Open(int.Parse(cmbComPort.SelectedItem.ToString().Replace("COM", "")));
            return result;
        }
    
        private bool UHFClose() {

            UHFAPI.getInstance().Close();
            UHFAPI.getInstance().TcpDisconnect();
            return true;
        }

     

        private void btnConnect_Click(object sender, EventArgs e)
        {

            //if (btnConnect.Text == strOpen1 || btnConnect.Text == strOpen2)
            if (btnConnect.Text == strOpen1)
            {
                //----------------------------
                if (txtPort.Text == "")
                {
                    MessageBox.Show("fail!");
                    return;
                }
                char[] port = txtPort.Text.ToCharArray();
                for (int k = 0; k < port.Length; k++)
                {
                    if (port[k] != '0' && port[k] != '1' && port[k] != '2' && port[k] != '3' && port[k] != '4' &&
                        port[k] != '5' && port[k] != '6' && port[k] != '7' && port[k] != '8' && port[k] != '9')
                    {

                        MessageBox.Show("only numbers are allowed!");
                        return;
                    }
                }
              

                uint portData = uint.Parse(txtPort.Text);
                string[] tempIp = ipControl1.IpData;
                StringBuilder sb = new StringBuilder();
                sb.Append(tempIp[0]);
                sb.Append(".");
                sb.Append(tempIp[1]);
                sb.Append(".");
                sb.Append(tempIp[2]);
                sb.Append(".");
                sb.Append(tempIp[3]);
                string ip = sb.ToString();

          
                //---------------------------
                string msg = Common.isEnglish ? "connecting..." : "connecting...";
                frmWaitingBox f = new frmWaitingBox((obj, args) =>
                {

                    bool result = false;
                    result = UHFAPI.getInstance().TcpConnect(ip, portData);
                    if (result)
                    {
                        this.Invoke(new EventHandler(delegate
                        {
                            combCommunicationMode.Enabled = false;
                            txtPort.Enabled = false;
                            ipControl1.Enabled = false;
                            //if (btnConnect.Text == strOpen1)
                                btnConnect.Text = strClose1;
                            /*else
                                btnConnect.Text = strClose2;*/

                            isOpen = true;
                            if (eventOpen != null)
                            {
                                eventOpen(true);
                            }

                            UHFAPP.IPConfig.IPEntity entity = new IPConfig.IPEntity();
                            entity.Port = (int)portData;
                            entity.Ip = ipControl1.IpData;
                            IPConfig.setIPConfig(entity);

                            MenuItemScanEPC.Enabled = true;
                            MenuItemReadWriteTag.Enabled = true;
                            configToolStripMenuItem.Enabled = true;
                            uHFVersionToolStripMenuItem.Enabled = true;
                            killLockToolStripMenuItem.Enabled = true;
                            toolStripMenuItem1.Enabled = true;
                          //  MenuItemReceiveEPC.Enabled = true;
                        }));
                    }
                    else
                    {
                        //MessageBox.Show("f");
                        frmWaitingBox.message = "fail";
                        Thread.Sleep(1000);
                    }
                }, msg);
                f.ShowDialog(this);

            }
            else
            {

                    UHFAPI.getInstance().TcpDisconnect();
                    combCommunicationMode.Enabled = true;
                    txtPort.Enabled = true;
                    ipControl1.Enabled = true;
                    //if (btnConnect.Text == strClose1)
                        btnConnect.Text = strOpen1;
                    /*else
                        btnConnect.Text = strOpen2;*/

                    isOpen = false;
                    if (eventOpen != null)
                    {
                        eventOpen(false);
                    }
                    MenuItemScanEPC.Enabled = false;
                    MenuItemReadWriteTag.Enabled = false;
                    configToolStripMenuItem.Enabled = false;
                    uHFVersionToolStripMenuItem.Enabled = false;
                    killLockToolStripMenuItem.Enabled = false;
                    toolStripMenuItem1.Enabled = false;
                    //MenuItemReceiveEPC.Enabled = false;
            }
           
        }

        private void receiveEPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Visible = false;
            try
            {
                Form currForm = this.ActiveMdiChild;
                if (currForm == null || currentType != 4)
                {
                    //currentType = 4;
                    //ReceiveEPC configForm = new ReceiveEPC();
                    //configForm.WindowState = FormWindowState.Maximized;
                    //configForm.MdiParent = this;
                    //configForm.Show();
                    //if (currForm != null)
                    //    currForm.Close();

                    int old = currentType;
                    currentType = 4;
                    ReceiveEPC configForm = (ReceiveEPC)Common.getForm("ReceiveEPC", this);
                    configForm.WindowState = FormWindowState.Maximized;
                    configForm.MdiParent = this;
                    configForm.Show();
                    if (currForm != null)
                    {
                         if (old == 0 || old == 2)
                        {
                            currForm.Close();
                        }
                        else
                        {
                            currForm.Hide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }  
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripStatusLabel1.Visible = false;
                Form currForm = this.ActiveMdiChild;
                if (currForm == null || currentType != 5)
                {
                    currentType = 5;
                    TestForm configForm = new TestForm(isOpen, mainform);
                    configForm.WindowState = FormWindowState.Maximized;
                    configForm.MdiParent = this;
                    configForm.Show();
                    if (currForm != null)
                        currForm.Close();
                }
            }
            catch (Exception ex)
            {

            } 
        }
    }
}
