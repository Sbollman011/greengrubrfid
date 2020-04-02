using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace UHFAPP
{
    public partial class ReadEPCForm : Form
    {
        bool isPz = false;
        MainForm mainform;
        string strStart = "Start";
        string strStart2 = "Start";
        string strStop = "Stop";
        string strStop2 = "Stop";
        bool isRuning = false;
        bool isComplete = true;
        long beginTime = 0;
        int total = 0;
        Hashtable epcList = new Hashtable();
        // 
        delegate void SetTextCallback(string epc, string tid, string rssi, string count,string ant);
        SetTextCallback setTextCallback;
        public ReadEPCForm()
        {
            InitializeComponent();
        }
        public ReadEPCForm(bool isOpen)
        {
            InitializeComponent();
            if (isOpen)
            {
                panel1.Enabled = true;
            }
            else {
                panel1.Enabled = false;
            }
        }
        public ReadEPCForm(bool isOpen, MainForm mainform)
        {
            InitializeComponent();
            if (isOpen)
            {
                panel1.Enabled = true;
            }
            else {
                panel1.Enabled = false;
            }
            this.mainform = mainform;
        }
        
        void MainForm_eventOpen(bool open)
        {
            if (open)
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
                if (btnScanEPC.Text == strStop)
                {
                    StopEPC(true);
                }
            }
        }
        void MainForm_eventSwitchUI()
        {
            //if (Common.isEnglish)
            {
                contextMenuStrip1.Items[0].Text = "Copy Tag";
                groupBox8.Text = "Filter";
                label29.Text = "Data:";
                label30.Text = "Ptr:";
                cbSave.Text = "Save";
                btnSet.Text = "Set";
                button2.Text = "reset";
                lto.Text = "Total:";
                label2.Text = "Time:";
                button1.Text = "Clear";
                label1.Text = "Length:";
                label8.Text = "Speed:";
                label7.Text = "Count:";
                if (btnScanEPC.Text == strStart2)
                {
                    btnScanEPC.Text = strStart;
                }
                else if (btnScanEPC.Text == strStop2)
                {
                    btnScanEPC.Text = strStop;
                }

                label30.Location = new Point(669, 33);
                label1.Location = new Point(785, 34); 
            }
            
        }
        

        private void ScanEPCForm_Load(object sender, EventArgs e)
        {
            MainForm.eventOpen += MainForm_eventOpen;
            setTextCallback = new SetTextCallback(UpdataEPC);

             MainForm.eventSwitchUI += MainForm_eventSwitchUI;
             MainForm_eventSwitchUI();
      
              //

                  filerLen.Text = ReadEPCFormData.filter_len;
                 txtData.Text = ReadEPCFormData.filter_Data;
                 txtPtr.Text = ReadEPCFormData.filter_Ptr;
                 cbSave.Checked =ReadEPCFormData.filter_save;
                 lblTime.Text = ReadEPCFormData.Time;
                 lblTotal.Text = ReadEPCFormData.Total ;
                 if (ReadEPCFormData.epcList!=null)
                    epcList = ReadEPCFormData.epcList;
                 switch (ReadEPCFormData.filter_bank) { 
                     case 1:
                         rbEPC.Checked = true;
                         break;
                     case 2:
                         rbTID.Checked = true;
                         break;
                     case 3:
                         rbUser.Checked = true;
                         break;
                 }
               
                 lvEPC.Select();
                 for (int k = 0; k < ReadEPCFormData.listviewdata.Count; k++) {
                     lvEPC.Items.Add(ReadEPCFormData.listviewdata[k]);
                     if (ReadEPCFormData.listviewdata[k].Text == ReadEPCFormData.selectedText) {
                         lvEPC.Items[k].Selected = true;
                     }
                 }
                 if (!isPz) {
                     button3.Visible = false;
                 }
                 //private void UpdataEPC(string epc, string tid, string rssi, string count,string ant)
                // UpdataEPC("112233","","","1","1");
                //sUpdataEPC("445566778899", "", "", "1", "1");
        }

        private void ScanEPCForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.eventOpen -= MainForm_eventOpen;
            MainForm.eventSwitchUI -= MainForm_eventSwitchUI;

            //
            try
            {
                ReadEPCFormData.filter_len = filerLen.Text;
                ReadEPCFormData.filter_Data = txtData.Text;
                ReadEPCFormData.filter_Ptr = txtPtr.Text;
                ReadEPCFormData.filter_save = cbSave.Checked;
                ReadEPCFormData.Time = lblTime.Text;
                ReadEPCFormData.Total = lblTotal.Text;
                ReadEPCFormData.epcList = epcList;
                if (rbEPC.Checked)
                {
                    ReadEPCFormData.filter_bank = 1;
                }
                else if (rbTID.Checked)
                {
                    ReadEPCFormData.filter_bank = 2;
                }
                else if (rbUser.Checked)
                {
                    ReadEPCFormData.filter_bank = 3;
                }

                ReadEPCFormData.listviewdata.Clear();
                ReadEPCFormData.selectedText = "";
                if (lvEPC != null && lvEPC.Items.Count > 0)
                {
                    for (int k = 0; k < lvEPC.Items.Count; k++)
                    {
                        ReadEPCFormData.listviewdata.Add(lvEPC.Items[k]);
                    }
                    if (lvEPC.SelectedItems.Count>0)
                    {
                        ReadEPCFormData.selectedText = lvEPC.SelectedItems[0].Text;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            if (btnScanEPC.Text == strStop || btnScanEPC.Text == strStop2)
            {
                StopEPC(true);
            }
        }
        #region  SetFilter

        private void btnSet_Click(object sender, EventArgs e)
        {
            int ptr = int.Parse(txtPtr.Text);
            int leng = int.Parse(filerLen.Text);
            int save = cbSave.Checked ? 1 : 0;

            string txtPtr1 = txtPtr.Text;
            string data = txtData.Text.Replace(" ","") ;
            if (!StringUtils.IsHexNumber(data) && leng>0)
            {            
                MessageBoxEx.Show(this, "Please input filter hexadecimal data!");
                return;
            }
            if ((leng / 8 + (leng % 8 == 0 ? 0 : 1)) * 2 > data.Length)
            {
                MessageBox.Show("filter data length error!");  //to do
                return;
            }
            byte bank=0x01;
            if (rbEPC.Checked)
            {
                 bank=0x01;
            }else if(rbTID.Checked){
                 bank=0x02;
            }else if(rbUser.Checked){
                 bank=0x03;
            }

            if (leng == 0) {
                data = "00";
            }
          
            byte[] buff = DataConvert.HexStringToByteArray(data);
            if (UHFAPI.getInstance().SetFilter((byte)save, bank, ptr, leng, buff))
            {
                MessageBoxEx.Show(this, "Success!");
            }
            else {
                MessageBoxEx.Show(this, "failure!");
            }
        }
        private void txtData_TextChanged(object sender, EventArgs e)
        {
            FormatHex(txtData);
            string data = txtData.Text.Replace(" ", "");
            if (data.Length > 0)
            {
                label5.Text = ((data.Length / 2) + ((data.Length % 2) == 0 ? 0 : 1)).ToString();  // txtRead_Length.Text = ((data.Length / 4) + ((data.Length % 4) == 0 ? 0 : 1)).ToString();
            }
            else
            {
                label5.Text = "0";
            }

        }
        private void FormatHex(TextBox txt)
        {
            if (isDelete) return;
            string data = txt.Text.Trim().Replace(" ", "");
            if (data != string.Empty)
            {
                int SelectIndex = txt.SelectionStart - 1;
                char[] charData = data.ToCharArray(0, data.Length);
                char[] newChar = new char[charData.Length];
                int index = 0;
                for (int k = 0; k < charData.Length; k++)
                {
                    if (StringUtils.IsHexNumber2(charData[k]))
                    {
                        newChar[index] = charData[k];
                        index++;
                    }
                }
                string newData = new string(newChar, 0, index);
                StringBuilder sb = new StringBuilder();
                int count = (newData.Length / 2) + (newData.Length % 2);

                for (int k = 0; k < count; k++)
                {
                    if ((k * 2 + 2) <= newData.Length)
                    {
                        sb.Append(newData.Substring(k * 2, 2));
                    }
                    else
                    {
                        sb.Append(newData.Substring(k * 2, 1));
                    }
                    sb.Append(" ");
                }
                txt.Text = sb.ToString();

                if (SelectIndex >= 0)
                    txt.SelectionStart = SelectIndex + 2;
                //txt.Select(txt.Text.Length - 1, 0);

            }
        }
        private void txtPtr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string ptr = txtPtr.Text;
                if (!StringUtils.IsNumber(ptr))
                {
                    if (rbEPC.Checked)
                    {
                        txtPtr.Text = "32";
                    }
                    else
                    {
                        txtPtr.Text = "0";
                    }
                    return;
                }

            }
            catch (Exception ex)
            {
                if (rbEPC.Checked)
                {
                    txtPtr.Text = "32";
                }
                else
                {
                    txtPtr.Text = "0";
                }
            }
        }
        #endregion
        //start
        private void btnScanEPC_Click(object sender, EventArgs e)
        {
            if (btnScanEPC.Text == strStop || btnScanEPC.Text == strStop2)
            {
                StopEPC(true);
            }
            else
            {
                if (!isRuning && isComplete)
                {
                    mainform.disableControls();
                    isRuning = true;
                    isComplete = false;
                    if (UHFAPI.getInstance().Inventory())
                    {
                        label9.Text = "";
                        StartEPC();
                    }
                    else
                    {
                        MessageBoxEx.Show(this,"Inventory failure!");
                        isRuning = false;
                        isComplete = true;
                        mainform.enableControls();
                    }
                }
            }
        }
  
        //Clear
        private void button1_Click(object sender, EventArgs e)
        {
            tempCount = 0;
            label6.Text = "0";
            epcList.Clear();
            lvEPC.Items.Clear();
            lblTime.Text = "0";
            lblTotal.Text = "0";
            total = 0;
            beginTime = System.Environment.TickCount;
        }

        //epc
        private void StartEPC() {
            groupBox8.Enabled = false;
            btnScanEPC.Text = Common.isEnglish ? strStop : strStop2;
            new Thread(new ThreadStart(delegate { ReadEPC(); })).Start();
           
        }
        //epc
        private void StopEPC(bool isStop) {
            UHFAPI.getInstance().StopGet(); 
            isRuning = false;   
            groupBox8.Enabled = true;
            btnScanEPC.Text = Common.isEnglish ? strStart : strStart2;
            mainform.enableControls();
        }

        //epc
        private void ReadEPC()
        {
            try
            {
                beginTime = System.Environment.TickCount;
                while (isRuning)
                {
                    string epc ="";
                    string tid = "";
                    string rssi = "";
                    string ant = "";
                    bool result = UHFAPI.getInstance().uhfGetReceived(ref epc, ref tid, ref rssi, ref ant);
                    if (result)
                    {
                        this.BeginInvoke(setTextCallback, new object[] { epc, tid, rssi, "1", ant });
                    }
                }

                if (isPz)
                {
                    bool result = false;
                    for (int k = 0; (k < 2) || result; k++)
                    {
                        Thread.Sleep(1);
                        // k =  random.Next(1,300);
                        string epc = "";
                        string tid = "";
                        string rssi = "";
                        string ant = "";
                        result = UHFAPI.getInstance().uhfGetReceived(ref epc, ref tid, ref rssi, ref ant);
                        if (result)
                        {
                            this.BeginInvoke(setTextCallback, new object[] { epc, tid, rssi, "1", ant });
                            
                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }
            isComplete = true;
         
        }

        int tempCount = 0;
        StringBuilder sb = new StringBuilder(100);
        private void UpdataEPC(string epc, string tid, string rssi, string count,string ant)
        {
            long time = System.Environment.TickCount - beginTime;
            lblTime.Text = (time) + "ms"; ;// (System.Environment.TickCount - beginTime) + "ms";//((System.Environment.TickCount - beginTime) / 1000) + "(s)";// sb.ToString();//
            label6.Text = (tempCount += int.Parse(count)).ToString();
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
            }else{
                total++;
                ListViewItem lv = new ListViewItem();
                lv.Text = (lvEPC.Items.Count+1).ToString();
                lv.SubItems.Add(epc);
                lv.SubItems.Add(tid);
                lv.SubItems.Add(rssi);
                lv.SubItems.Add(count);
                lv.SubItems.Add(ant);
                lvEPC.Items.Add(lv);
                epcList.Add(epc, count);
                lblTotal.Text = epcList.Count + "";
            }
            if (time < 1000) {
                label9.Text = (tempCount+"/s");
            }
            else
            {
                label9.Text = (tempCount / (time / 1000)) + "/s";

            }
     

        }


        private void lblTotal1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int save = cbSave.Checked ? 1 : 0;
            if (UHFAPI.getInstance().SetFilter((byte)save, 1, 4, 0, new byte[] { 0 }) && 
                UHFAPI.getInstance().SetFilter((byte)save, 2, 4, 0, new byte[] { 0 })&&
                UHFAPI.getInstance().SetFilter((byte)save, 3, 4, 0, new byte[] { 0 }))
            {
                MessageBoxEx.Show(this, "Success!");
            }
            else
            {
                MessageBoxEx.Show(this, "failure!");
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {

        }

        private void lvEPC_DoubleClick(object sender, EventArgs e)
        {
            if (lvEPC.SelectedItems.Count <= 0) {
                return;
            }
            if (btnScanEPC.Text == strStop || btnScanEPC.Text == strStop2)
            {
                StopEPC(true);
            }
            string tag = lvEPC.SelectedItems[0].SubItems[1].Text;
            Common.tag = tag;
            mainform.ReadWriteTag(tag);
        }
 

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (lvEPC.SelectedItems.Count <= 0)
            {
                return;
            }
            string str = lvEPC.SelectedItems[0].SubItems[1].Text;
            Clipboard.SetDataObject(str);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string ptr = filerLen.Text;
                if (!StringUtils.IsNumber(ptr))
                {
                    filerLen.Text = "0";
                    return;
                }
            }
            catch (Exception ex)
            {
                filerLen.Text = "0";
            }
        }

        private void rbTID_Click(object sender, EventArgs e)
        {
            txtPtr.Text = "0";
        }

        private void rbUser_Click(object sender, EventArgs e)
        {
            txtPtr.Text = "0";
        }

        private void rbEPC_Click(object sender, EventArgs e)
        {
            txtPtr.Text = "32";
        }

        private void lto_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }
        bool isDelete = false;
        private void ReadEPCForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                isDelete = true;
            }
            else
            {
                isDelete = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (btnScanEPC.Text == strStop || btnScanEPC.Text == strStop2)
            {
                StopEPC(true);
            }
            else
            {
                if (!isRuning && isComplete)
                {
                    mainform.disableControls();
                    isRuning = true;
                    isComplete = false;
                    beginTime = System.Environment.TickCount;
                    if (UHFAPI.getInstance().Inventory())
                    {
                        StartEPC();
                        new Thread(new ThreadStart(delegate
                        {
                            Thread.Sleep(2000);
                            this.Invoke(new EventHandler(delegate
                            {
                                StopEPC(true);

                            }));

                        })).Start();
                    }
                    else
                    {
                        MessageBoxEx.Show(this, "Inventory failure!");
                        isRuning = false;
                        isComplete = true;
                        mainform.enableControls();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = (System.Environment.TickCount - beginTime) + "(ms)";
        }

        //epc
        private void ReadEPC2()
        {
            try
            {
                List<string> listEPC = new List<string>();
                List<int> listCount = new List<int>();
                List<string> listTID = new List<string>();
                List<string> listRssi = new List<string>();
                List<string> listAnt = new List<string>();

                int epcStart = System.Environment.TickCount;
                Random random = new Random();
                int bengin = System.Environment.TickCount;
                while (isRuning)
                {
                    string epc = "";
                    string tid = "";
                    string rssi = "";
                    string ant = "";
                    bool result = UHFAPI.getInstance().uhfGetReceived(ref epc, ref tid, ref rssi, ref ant);
                    if (result)
                    {
                        /*
                        if (listEPC.Contains(epc))
                        {
                            int index = listEPC.IndexOf(epc);
                            listRssi[index] = rssi;
                            listAnt[index] = ant;
                            listCount[index] = listCount.Count + 1;
                        }
                        else {
                            listEPC.Add(epc);
                            listTID.Add(tid);
                            listRssi.Add(rssi);
                            listAnt.Add(ant);
                            listCount.Add(1);
                        }
                        */
                        this.BeginInvoke(setTextCallback, new object[] { epc, tid, rssi, "1", ant });
                    }
                    if (System.Environment.TickCount - bengin > -1)
                    {
                        if (listEPC.Count > 0)
                        {
                            for (int k = 0; k < listEPC.Count; k++)
                            {
                                // this.BeginInvoke(setTextCallback, new object[] { epc, tid, rssi, "1", ant });
                                this.BeginInvoke(setTextCallback, new object[] { listEPC[k], listTID[k], listRssi[k], listCount[k] + "", listAnt[k] });
                            }
                            listEPC.Clear();
                            listTID.Clear();
                            listRssi.Clear();
                            listAnt.Clear();
                            listCount.Clear();

                        }
                    }
                }
                if (listEPC.Count > 0)
                {
                    for (int k = 0; k < listEPC.Count; k++)
                    {
                        this.BeginInvoke(setTextCallback, new object[] { listEPC[k], listTID[k], listRssi[k], listCount[k] + "", listAnt[k] });
                    }
                }


                if (isPz)
                {
                    bool result = false;
                    for (int k = 0; (k < 2) || result; k++)
                    {
                        Thread.Sleep(1);
                        // k =  random.Next(1,300);
                        string epc = "";
                        string tid = "";
                        string rssi = "";
                        string ant = "";
                        result = UHFAPI.getInstance().uhfGetReceived(ref epc, ref tid, ref rssi, ref ant);
                        if (result)
                        {
                            this.BeginInvoke(setTextCallback, new object[] { epc, tid, rssi, "1", ant });
                            
                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }
            isComplete = true;

        }

    }
}
