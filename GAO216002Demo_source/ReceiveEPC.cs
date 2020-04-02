using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;

namespace UHFAPP
{
    public partial class ReceiveEPC : Form
    {
       private const int max =1024 * 1024;
       private byte[] uhfOriginalData = new byte[max];
       private int wIndex = 0;
       private int rIndex = 0;
       private bool isRuning = true;
       private bool isOpen = false;
       private IPEndPoint remote = null;
       private UdpClient ReceiveUdpClient = null;
       private Thread threadEPC = null;
       private Thread threadReceiveOriginalData;
       Hashtable epcList = new Hashtable();
       // 
       delegate void GetUHFDataCallback(string epc, string tid, string rssi, string count, string ant);
       GetUHFDataCallback getUHFDataCallback;

       delegate void GetRemotelyIPCallback(string remoteip);
       GetRemotelyIPCallback getRemotelyIPCallback;
        public ReceiveEPC()
        {
            InitializeComponent();
        }
        private void ReceiveEPC_Load(object sender, EventArgs e)
        {
            getUHFDataCallback = new GetUHFDataCallback(UpdataEPC);
            getRemotelyIPCallback = new GetRemotelyIPCallback(getIP);
            initIP();
        }
        private void btnScanEPC_Click(object sender, EventArgs e)
        {
            if (btnScanEPC.Text == "Start")
            {
                if (start())
                    btnScanEPC.Text = "Stop";
                else {
                    MessageBox.Show("fail");
                }
            }
            else
            {
                btnScanEPC.Text = "Start";
                DisConnectUDP();
            }
        }

        private void ReceiveEPC_FormClosing(object sender, FormClosingEventArgs e)
        {
            isOpen = false;
            isRuning = false;
            DisConnectUDP();
        }


        private void initIP()
        {
            try
            {

                IPAddress[] ipArray = Dns.GetHostAddresses(Dns.GetHostName());
                if (ipArray != null) {
                    for (int k = 0; k < ipArray.Length; k++) {
                        string ip = ipArray[k].ToString();
                        if (StringUtils.isIP(ip))
                        {
                            cmbIP.Items.Add(ip);
                            cmbIP.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
           
        }
 
        private bool start()
        {
            string ip = cmbIP.SelectedItem.ToString();
            if (textBox2.Text == "") return false;
            if (!StringUtils.isIP(ip)) return false;
            int port = int.Parse(textBox2.Text);

            if (ConnectUDP(ip, port))
            {
                if (threadEPC == null)
                {
                    threadEPC = new Thread(new ThreadStart(ReadEPC));
                    threadEPC.IsBackground = true;
                    threadEPC.Start();

                    threadReceiveOriginalData = new Thread(new ThreadStart(ReceiveOriginalData));
                    threadReceiveOriginalData.IsBackground = true;
                    threadReceiveOriginalData.Start();
                }
                return true;
            }
            return false;
        }
      
        

        //epc
        private void ReceiveOriginalData ()
        {
            try
            {
                while (isRuning)
                {
                    if (isOpen)
                    {
                        try
                        {
                            // 
                            byte[] receiveBytes = ReceiveUdpClient.Receive(ref remote);//Receive the original 
                            if (receiveBytes != null)
                            {
                                for (int k = 0; k < receiveBytes.Length; k++)
                                {
                                    uhfOriginalData[++wIndex] = receiveBytes[k];
                                    if (wIndex == max - 1)
                                    {
                                        //
                                        wIndex = 0;
                                    }
                                }
                                this.BeginInvoke(getRemotelyIPCallback, new object[] { remote.Address.ToString() });
                               
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
        //epc
        private void ReadEPC()
        {
            try
            {
              const int STATUS_START = 0;
              const int STATUS_5A = 1;
              const int STATUS_LEN_H = 2;
              const int STATUS_LEN_L = 3;
              const int STATUS_CMD = 4;
              const int STATUS_DATA = 5;
              const int STATUS_XOR = 6;
              const int STATUS_END_0D = 7;
              const int STATUS_END_0A = 8;

                int tempxor = 0;
                int tempidx = 0;
                int templen = 0;
                int rxstatus = 0;
                bool closeingflag = false;
                byte[] tempbuf=new byte[256];
                while (isRuning && (!closeingflag))
                {
                    byte tempdata = 0;
                    if (wIndex > rIndex) {
                          tempdata = uhfOriginalData[rIndex];
                    }
                    else if (wIndex < rIndex)
                    {
                        if (rIndex >= max)
                        {
                            rIndex = 0;
                        }
                          tempdata = uhfOriginalData[rIndex];
                    }
                    else {
                        continue;
                    }
                        switch (rxstatus)
                        {
                            case STATUS_START:
                                if (tempdata == 0xA5)
                                {
                                    rxstatus = STATUS_5A;
                                }
                                else
                                {
                                    rxstatus = STATUS_START;
                                }
                                tempxor = 0;
                                tempidx = 0;
                                templen = 0;
                                Array.Clear(tempbuf,0, tempbuf.Length);
                                break;
                            case STATUS_5A:
                                if (tempdata == 0x5A)
                                {
                                    rxstatus = STATUS_LEN_H;
                                }
                                else
                                {
                                    rxstatus = STATUS_START;
                                }
                                break;
                            case STATUS_LEN_H:
                                tempxor = tempxor ^ tempdata;
                                if (tempdata == 0)
                                {
                                    rxstatus = STATUS_LEN_L;
                                }
                                else
                                {
                                    rxstatus = STATUS_START;
                                }
                                break;
                            case STATUS_LEN_L:
                                {
                                    tempxor = tempxor ^ tempdata;
                                    templen = tempdata;
                                    if ((templen < 8) || (templen > 0xFF))
                                    {
                                        rxstatus = STATUS_START;
                                    }

                                    else
                                    {
                                        templen = templen - 8;
                                        rxstatus = STATUS_CMD;
                                    }

                                }
                                break;
                            case STATUS_CMD:
                                {
                                    tempxor = tempxor ^ tempdata;
                                    if (tempdata == 0x83)
                                    {
                                        if (templen > 0)
                                        {
                                            rxstatus = STATUS_DATA;
                                        }
                                        else
                                        {
                                            rxstatus = STATUS_XOR;
                                        }

                                    }
                                    else if ((tempdata == 0x8D) && (templen == 1))
                                    {
                                        rxstatus = STATUS_DATA;
                                        closeingflag = true;
                                    }
                                    else
                                    {
                                        rxstatus = STATUS_START;
                                    }
                                }
                                break;
                            case STATUS_DATA:
                                {
                                    if (closeingflag)
                                    {
                                        if (tempdata != 0)
                                        {
                                           // closeflag = 1;  zp 
                                        }
                                        else
                                        {
                                            // closeflag = 0;  zp 
                                        }
                                        tempxor = tempxor ^ tempdata;
                                        rxstatus = STATUS_XOR;
                                    }
                                    else if (tempidx < templen)
                                    {
                                        tempxor = tempxor ^ tempdata;
                                        tempbuf[tempidx++] = tempdata;
                                        if (tempidx >= templen)
                                        {
                                            rxstatus = STATUS_XOR;
                                        }
                                    }
                                    break;
                                }
                            case STATUS_XOR:
                                {
                                    if (tempxor == tempdata)
                                    {
                                        rxstatus = STATUS_END_0D;
                                    }
                                    else
                                    {
                                        rxstatus = STATUS_START;
                                    }
                                    break;
                                }
                            case STATUS_END_0D:
                                {
                                    if (tempdata == 0x0D)
                                    {
                                        rxstatus = STATUS_END_0A;
                                    }
                                    else
                                    {
                                        rxstatus = STATUS_START;
                                    }
                                }
                                break;
                            case STATUS_END_0A:
                                {
                                    if (tempdata == 0x0A)
                                    {
                                        if (templen <= 0)
                                        {
                                            continue;
                                        }

                                        string epc = "";
                                        string tid = "";
                                        string rssi = "";
                                        string ant = "";
                                        bool result = UHFGetReceived(ref epc, ref tid, ref rssi, ref ant, tempbuf, templen);
                                        if (result)
                                        {
                                            this.BeginInvoke(getUHFDataCallback, new object[] { epc, tid, rssi, "1", ant });
                                          
                                        }
                                    }
                                    rxstatus = STATUS_START;

                                }
                                break;
                            default:
                                {
                                    rxstatus = STATUS_START;
                                }
                                break;

                        }

                        rIndex++;
                  
                    
                }
            }
            catch (Exception ex)
            {

            }

        }

        private bool ConnectUDP(string MyIPAddress, int PortName)
        {
            try
            {
                IPEndPoint local = new IPEndPoint(IPAddress.Parse(MyIPAddress), PortName);
                ReceiveUdpClient = new UdpClient(local);
                remote = new IPEndPoint(IPAddress.Any, 0);
                isOpen = true;
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private void DisConnectUDP() {
            if (ReceiveUdpClient != null) {
                try
                {
                    isOpen = false;
                    ReceiveUdpClient.Close();
                }
                catch (Exception ex) { 
                
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            epcList.Clear();
            lvEPC.Items.Clear();
            lblTime.Text = "0";
            lblTotal.Text = "0";
           
        }



        //epc
        public bool UHFGetReceived(ref string epc, ref string tid, ref string rssi, ref string ant, byte[] originalData,int len)
        {
            try
            {
                int uLen = len;
                byte[] bufData = originalData;
                if (bufData != null && bufData.Length > 0 && uLen > 0 && (bufData.Length >= uLen))
                {

                    byte[] bUii = null;
                    byte[] bTid = null;
                    byte[] bRssi = null;
                    byte[] bAnt =null;

                    if (((uLen - 3) < 1) || ((uLen - 3) > 250))
                        return false;

                    int uiilen = ((bufData[0] >> 3) + 1) * 2;

                    if (uiilen == 0) return false;

                    bUii = new byte[uiilen];
                    if ((len - uiilen == 3) || (len - uiilen == 15)) //uii + rssi + ant
                    {

                        for (int i = 0; i < uiilen; i++)
                        {
                            bUii[i] = bufData[i];
                        }
                        if (len - uiilen == 15)
                        {
                            bTid = new byte[12];
                            //tid
                            for (int i = 0; i < 12; i++)
                            {
                                bTid[i] = bufData[uiilen+i];
                            }
                        }
                        bRssi = new byte[2];
                        bAnt = new byte[1];
                        bRssi[0] = bufData[uLen - 3];
                        bRssi[1] = bufData[uLen - 2];
                        bAnt[0] = bufData[uLen - 1];

                        int tempRSSIH = bRssi[0];
                        int tempRSSIL = bRssi[1];

                        int tempRSSI = tempRSSIH * 256 + tempRSSIL;
                        tempRSSI = 65535 - tempRSSI + 1;
                        if ((tempRSSI < 250) || (tempRSSI > 850))
                        {
                            return false;
                        }
                    }
                    else if ((len - uiilen == 2) || (len - uiilen == 14)) //uii + rssi 
                    {
                        for (int i = 0; i < uiilen; i++)
                        {
                            bUii[i] = bufData[i];
                        }

                        if (len - uiilen == 14)
                        {
                            bTid = new byte[12];
                            //tid
                            for (int i = 0; i < 12; i++)
                            {
                                bTid[i] = bufData[uiilen + i];
                            }
                        }
                        bRssi = new byte[2];
                        bRssi[0] = bufData[uLen - 2];
                        bRssi[1] = bufData[uLen - 1];

                        int tempRSSIH = bRssi[0];
                        int tempRSSIL = bRssi[1];

                        int tempRSSI = tempRSSIH * 256 + tempRSSIL;
                        tempRSSI = 65535 - tempRSSI + 1;
                        if ((tempRSSI < 250) || (tempRSSI > 850))
                        {
                            return false;
                        }

                    }
                    else if ((len - uiilen == 1) || (len - uiilen == 13)) //uii + ant
                    {
                        for (int i = 0; i < uiilen; i++)
                        {
                            bUii[i] = bufData[i];
                        }
                        if (len - uiilen == 13)
                        {
                            bTid = new byte[12];
                            //tid
                            for (int i = 0; i < 12; i++)
                            {
                                bTid[i] = bufData[uiilen + i];
                            }
                        }
                        bAnt = new byte[1];
                        bAnt[0] = bufData[uLen - 1];
                    }
                    else if ((len - uiilen == 0) || (len - uiilen == 12)) //uii 
                    {
                        for (int i = 0; i < uiilen; i++)
                        {
                            bUii[i] = bufData[i];
                        }
                        if (len - uiilen == 12)
                        {
                            bTid = new byte[12];
                            //tid
                            for (int i = 0; i < 12; i++)
                            {
                                bTid[i] = bufData[uiilen + i];
                            }
                        }
                    }
 
                    //  uUii = 1byteUII+UII+1byteTID+TID+2bytesRSSI
                    string epc_data = BitConverter.ToString(bUii, 2, bUii.Length-2).Replace("-", "");
                    string uii_data = BitConverter.ToString(bUii, 0, bUii.Length).Replace("-", "");
                    string tid_data = string.Empty; //tid
                    string rssi_data = string.Empty;
                    string ant_data = string.Empty;
                    if (bTid != null) {
                        tid_data = BitConverter.ToString(bTid, 0, bTid.Length).Replace("-", "");
                    }
                    if (bRssi != null)
                    {
                        string temprssi = BitConverter.ToString(bRssi, 0, bRssi.Length).Replace("-", "");
                        rssi_data = ((Convert.ToInt32(temprssi, 16) - 65535) / 10).ToString();// RSSI  =  (0xFED6   -65535)/10 
                    }
                    if (bAnt != null)
                    {
                        string tempAnt = BitConverter.ToString(bAnt, 0, bAnt.Length).Replace("-", "");
                        ant_data = Convert.ToInt32(tempAnt, 16).ToString();
                    }

                    epc = epc_data;
                    tid = tid_data;
                    rssi = rssi_data;
                    ant = ant_data;

                 
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) {
                return false;
            
            }
        }

        int total = 0;
        long beginTime = System.Environment.TickCount;
        private void UpdataEPC(string epc, string tid, string rssi, string count, string ant)
        {
            if (epcList[epc] != null)
            {
                for (int i = 0; i < lvEPC.Items.Count; i++)
                {
                    if (this.lvEPC.Items[i].SubItems[1].Text == epc)
                    {
                        lvEPC.Items[i].SubItems[2].Text = tid;
                        lvEPC.Items[i].SubItems[3].Text = rssi;
                        lvEPC.Items[i].SubItems[4].Text = (int.Parse(lvEPC.Items[i].SubItems[4].Text) + int.Parse(count)).ToString();
                        lvEPC.Items[i].SubItems[5].Text = ant;
                        break;
                    }
                }
            }
            else
            {
                total++;
                ListViewItem lv = new ListViewItem();
                int index=lvEPC.Items.Count+1;
                lv.Text = index.ToString();
                lv.SubItems.Add(epc);
                lv.SubItems.Add(tid);
                lv.SubItems.Add(rssi);
                lv.SubItems.Add(count);
                lv.SubItems.Add(ant);
                lvEPC.Items.Add(lv);
                lblTotal.Text = total.ToString();
                epcList.Add(epc, "1");
            }
            lblTime.Text = ((System.Environment.TickCount - beginTime) / 1000) + "(s)";
        }

        private void getIP(string ip) {
            textBox1.Text = ip;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                char[] port = textBox2.Text.ToCharArray();
                for (int k = 0; k < port.Length; k++)
                {
                    if (port[k] != '0' && port[k] != '1' && port[k] != '2' && port[k] != '3' && port[k] != '4' &&
                        port[k] != '5' && port[k] != '6' && port[k] != '7' && port[k] != '8' && port[k] != '9')
                    {
                        textBox2.Text = "";
                        return;
                    }
                }
            }
              
        }
    }
}
