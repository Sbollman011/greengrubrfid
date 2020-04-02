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
    public partial class TestForm : Form
    {
        private static readonly object locker1 = new object();

        Hashtable epcList = new Hashtable();
        // 
        delegate void SetTextCallback(string epc, string tid, string rssi, string count, string ant);
        SetTextCallback setTextCallback;

        delegate void UpdateCallback(string epc,int op);
        UpdateCallback updateCallback;

        MainForm mainform;
        string strStart = "Start";
        string strStart2 = "Start";
        string strStop = "Stop";
        string strStop2 = "Stop";
        bool isRuning = false;
        bool isComplete = true;

        static string path = System.Environment.CurrentDirectory + "\\data.txt";

     
       string[] arrayEPC=null;//epc
       string[] arrayName=null; //
       string[] arrayType = null;//
       long[] arrayTime = null;//
       List<string> alreadyEpc = new List<string>();//
       List<string> xjEpc2 = new List<string>();//
        public TestForm(bool isOpen)
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
                    StopEPC();
                }
            }
        }
        public TestForm(bool isOpen, MainForm mainform)
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
        public   void getData()
        {
            try
            {
                string data = FileManage.ReadFile(path);
                if (data == "") return  ;

                string[] arrData = data.Split('\n');
                int len = arrData.Length;
                 arrayEPC = new string[len];//epc
                 arrayName = new string[len]; //
                 arrayType = new string[len];//
                 arrayTime = new long[len];//

                for (int k = 0; k < len; k++)
                {
                    string[] temp = arrData[k].ToString().Replace("\r", "").Replace(" ", "").Split('=');
                    if (temp[0] != "")
                    {
                        arrayEPC[k] = temp[0];
                        arrayName[k] = temp[1];
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void Test_Load(object sender, EventArgs e)
        {
            getData();
            //arrayEPC[0] = "000000000958";
            //arrayEPC[1] = "000000000992";
            //arrayEPC[2] = "000000000959";
            //arrayEPC[3] = "000000000956";
            //arrayEPC[4] = "000000000955";
            //arrayEPC[5] = "000000000954";
            //arrayEPC[6] = "000000000953";
            //arrayEPC[7] = "000000000921";
            //arrayEPC[8] = "000000000922";
            //arrayEPC[9] = "000000000914";
            //arrayEPC[10] = "000000000947";
            //arrayEPC[11] = "000000000946";
            //arrayEPC[12] = "000000000919";
            //arrayEPC[13] = "000000000945";
            //arrayEPC[14] = "000000000942";
            //arrayEPC[15] = "000000000929";
            //arrayEPC[16] = "000000000913";     
            //arrayEPC[17] = "000000000927";
            //arrayEPC[18] = "000000000926";
            //arrayEPC[19] = "000000000923";
            //arrayEPC[20] = "000000000912";
            //arrayEPC[21] = "000000000920";
            //arrayEPC[22] = "000000000930";


            setTextCallback = new SetTextCallback(UpdataEPC);
            updateCallback = new UpdateCallback(UpdateListView);
            MainForm.eventOpen += MainForm_eventOpen;
        }

        private void btnScanEPC_Click(object sender, EventArgs e)
        {
            if (btnScanEPC.Text == strStop || btnScanEPC.Text == strStop2)
            {
                StopEPC();
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
                        button1.Enabled = false;
                        StartEPC();
                    }
                    else
                    {
                        MessageBoxEx.Show(this, "Inventory failure!");
                        isRuning = false;
                        isComplete = true;
                        mainform.enableControls();
                        button1.Enabled = true;
                    }
                }
            }
        }


        //epc
        private void StartEPC()
        {
            btnScanEPC.Text = strStop2;
            Thread epcT = new Thread(new ThreadStart(ReadEPC));
            epcT.IsBackground = true;
            epcT.Start();

            Thread cheakT = new Thread(new ThreadStart(CheakEPC));
            cheakT.IsBackground = true;
            cheakT.Start();

        }
        //epc
        private void StopEPC()
        {
            button1.Enabled = true;
            btnScanEPC.Text = strStart2;
            isRuning = false;
            Thread.Sleep(100);
            UHFAPI.getInstance().StopGet();
            mainform.enableControls();
        }
        //epc
        private void ReadEPC()
        {
            try
            {
                while (isRuning)
                {
                    // k =  random.Next(1,300);
                    string epc = "";
                    string tid = "";
                    string rssi = "";
                    string ant = "";
                    bool result = UHFAPI.getInstance().uhfGetReceived(ref epc, ref tid, ref rssi, ref ant);
                    if (result)
                    {
                        this.BeginInvoke(setTextCallback, new object[] { epc, tid, rssi, "1", ant });
                        Console.Out.Write("Refresh UI\n"); //This line may be needed to refresh main UI
                    }
                }
            }
            catch (Exception ex)
            {

            }
            isComplete = true;

        }

        private void CheakEPC()
        {
            try
            {
              //  int timeOut = 1000;
                while (isRuning)
                {

                    for (int k = 0; k < arrayTime.Length; k++)
                    {

                        int time = System.Environment.TickCount;
                        if (arrayTime[k] != 0 && (time - arrayTime[k] > Common.time))
                        {
                            string epc = arrayEPC[k];
                            this.BeginInvoke(updateCallback, new object[] { epc, ADD });
                        }
                        else if (arrayTime[k] != 0)
                        {
                            string epc = arrayEPC[k];
                            this.BeginInvoke(updateCallback, new object[] { epc, DELETE });

                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {

            }
            isComplete = true;

        }


        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnScanEPC.Text == strStop || btnScanEPC.Text == strStop2)
            {
                StopEPC();
            }
            MainForm.eventOpen -= MainForm_eventOpen;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int ADD = 0;
        int DELETE = 1;
        private void UpdateListView(string epc,int op)
        {
            try
            {
                if (op == ADD)
                {

                    for (int k = 0; k < xjEpc2.Count; k++)
                    {
                        if (xjEpc2[k] == epc)
                        {
                            
                            return;
                        }
                    }
                    xjEpc2.Add(epc);
                    lock (locker1)
                    {

                        for (int i = 0; i < lvEPC.Items.Count; i++)
                        {
                            if (this.lvEPC.Items[i].SubItems[1].Text == epc)
                            {
                                lvEPC.Items.Remove(this.lvEPC.Items[i]);
                                label3.Text = lvEPC.Items.Count.ToString();
                                break;
                            }
                        }
                    }

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (this.listView1.Items[i].SubItems[1].Text == epc)
                        {
                            return;
                        }
                    }

                    string name = "";
                    for (int k = 0; k < arrayEPC.Length; k++)
                    {
                        if (arrayEPC[k] == epc)
                        {
                            name = arrayName[k];
                            break;
                        }
                    }

                    ListViewItem lv = new ListViewItem();
                    lv.Text = (listView1.Items.Count + 1).ToString();
                    lv.SubItems.Add(epc);
                    lv.SubItems.Add(name);
                    listView1.Items.Add(lv);
                    label4.Text = listView1.Items.Count.ToString();

                }
                else if (op == DELETE)
                {

                    for (int k = 0; k < xjEpc2.Count; k++)
                    {
                        if (xjEpc2[k] == epc)
                        {
                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                if (this.listView1.Items[i].SubItems[1].Text == epc)
                                {
                                    listView1.Items.Remove(this.listView1.Items[i]);
                                    break;
                                }
                            }
                            label4.Text = listView1.Items.Count.ToString();
                            xjEpc2.RemoveAt(k);
                            return;
                        }
                    }

                }
            }
            catch (Exception ex) { 
            
            }

        }

        private void UpdataEPC(string epc, string tid, string rssi, string count, string ant)
        {
            try
            {
                int index = 0;
                //--------------------------------------------------------
                bool isFlag = false;
                for (int k = 0; k < arrayEPC.Length; k++)
                {
                    if (arrayEPC[k] == epc)
                    {
                        index = k;
                        arrayTime[index] = System.Environment.TickCount;
                        isFlag = true;
                        break;
                    }
                }
                //
                if (!isFlag)
                    return;
                //--------------------------------------------------------
                bool isFlag2 = false;
                for (int k = 0; k < alreadyEpc.Count; k++)
                {
                    if (alreadyEpc[k] == epc)
                    {
                        isFlag2 = true;
                        break;
                    }
                }
                if (!isFlag2)
                {
                    alreadyEpc.Add(epc);
                }
                //--------------------------------------------------------


                lock (locker1)
                {
                    for (int i = 0; i < lvEPC.Items.Count; i++)
                    {
                        if (this.lvEPC.Items[i].SubItems[1].Text == epc)
                        {
                            lvEPC.Items[i].SubItems[3].Text = (int.Parse(lvEPC.Items[i].SubItems[3].Text) + 1).ToString();
                            return;
                        }
                    }


                    ListViewItem lv = new ListViewItem();
                    lv.Text = (lvEPC.Items.Count + 1).ToString();
                    lv.SubItems.Add(epc);
                    lv.SubItems.Add(arrayName[index]);
                    lv.SubItems.Add("1");
                    lvEPC.Items.Add(lv);
                    label3.Text = lvEPC.Items.Count.ToString();
                }

            }
            catch (Exception ex) { 
            
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lock (locker1) {
                lvEPC.Items.Clear();
                listView1.Items.Clear();
                xjEpc2.Clear();
                label3.Text = "0";
                label4.Text = "0";
                if (arrayTime != null)
                {
                    for (int k = 0; k < arrayTime.Length; k++) {
                        arrayTime[k] = 0;
                    }
                }
            }
        }
    }
}
