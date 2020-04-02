using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm_Test;
using System.Threading;

namespace UHFAPP
{
    public partial class ConfigForm : Form
    {

        bool isFlag = false;
        public ConfigForm()
        {
            InitializeComponent();
        }
        public ConfigForm(bool isOpen)
        {
            InitializeComponent();
            if (isOpen)
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }
            cmbAntWorkTime.SelectedIndex = 0;
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
            }
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            MainForm.eventOpen += MainForm_eventOpen;
            cmbLinkFrequency.SelectedIndex = 3;

            MainForm.eventSwitchUI += MainForm_eventSwitchUI;
            MainForm_eventSwitchUI();
            comboBox1.SelectedIndex = 0;
            cmbOutStatus.SelectedIndex = 0;
 
             
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.eventOpen -= MainForm_eventOpen;
            MainForm.eventSwitchUI -= MainForm_eventSwitchUI;
        }
        #region power
        private void btnPowerGet_Click(object sender, EventArgs e)
        {
            string msg = "Get the power failure!";
            byte power = 0;
            if (UHFAPI.getInstance().GetPower(ref power))
            {
                cmbPower.SelectedIndex = power - 5;
                msg = "Get the power success";
            }


            showMessage(msg);
        }

        private void btnPowerSet_Click(object sender, EventArgs e)
        {
            string msg = "Set the power failure!";
            if (cmbPower.SelectedIndex >= 0)
            {
                byte power = (byte)(cmbPower.SelectedIndex + 5);
                byte save = (byte)(cbSave.Checked?1:0);
                if (UHFAPI.getInstance().SetPower(save, power))
                {
                    msg="Set the power success!";
                }
                
            }

            showMessage(msg);
        }
        #endregion

        #region frequency
        private void btnWorkModeSet_Click(object sender, EventArgs e)
        {
             string msg ="failure!";
             try
             {
                 if (comboBox1.Text != "")
                 {
                     string frequency = comboBox1.Text.Replace(".", "");
                     if (frequency.Length == 3) {
                         frequency = frequency + "000";
                     }
                     else if (frequency.Length == 4) {
                         frequency = frequency + "00";
                     }
                     else if (frequency.Length == 5)
                     {
                         frequency = frequency + "0";
                     }
                     if (StringUtils.IsNumber(frequency))
                     {
                         int[] ifrequency = new int[] { int.Parse(frequency) };
                         if (UHFAPI.getInstance().SetJumpFrequency(1, ifrequency))
                         {
                             msg = "success!";
                         }
                     }
                 }
             }
             catch (Exception ex) { 
             
             }

             showMessage(msg);
        }
        private void btnWorkModeGet_Click(object sender, EventArgs e)
        {
            string msg ="failure!";
            int[] ifrequency = new int[1];
            if (UHFAPI.getInstance().GetJumpFrequency(ref ifrequency))
            {
                comboBox1.Text = ifrequency[0].ToString().Insert(3, ".");
                msg = "success!";
            }

            showMessage(msg);
        }
        #endregion

        #region Gen2
        private void btnGen2Get_Click(object sender, EventArgs e)
        {
            byte Target = 0;
            byte Action = 0;
            byte T = 0;
            byte Q = 0;
            byte StartQ = 0;
            byte MinQ = 0;
            byte MaxQ = 0;
            byte D = 0;
            byte Coding = 0;
            byte P = 0;
            byte Sel = 0;
            byte Session = 0;
            byte G = 0;
            byte LF = 0;
            string msg = "failure";
            if (UHFAPI.getInstance().GetGen2(ref  Target, ref   Action, ref   T, ref   Q,
                     ref   StartQ, ref   MinQ,
                     ref   MaxQ, ref   D, ref   Coding, ref   P,
                     ref   Sel, ref   Session, ref   G, ref   LF))
            {
                cmbTarget.SelectedIndex = Target;
                cmbAction.SelectedIndex = Action;
                cmbT.SelectedIndex = T;
                cmbQ.SelectedIndex = Q;
                cmbCoding.SelectedIndex = Coding;
                cmbP.SelectedIndex = P;
                cmbSel.SelectedIndex = Sel;
                cmbStartQ.SelectedIndex = StartQ;
                cmbMinQ.SelectedIndex = MinQ;
                cmbMaxQ.SelectedIndex = MaxQ;
                cmbDr.SelectedIndex = D;
                cmbSession.SelectedIndex = Session;
                cmbG.SelectedIndex = G;
                cmbLinkFrequency.SelectedIndex = LF;
                msg = "success";
                btnGen2Set.Enabled = true;
            }


            showMessage(msg);
        }
        private void btnGen2Set_Click(object sender, EventArgs e)
        {
            string msg ="Set the Gen2 failure!";
            try
            {
                byte Target =(byte) cmbTarget.SelectedIndex;
                byte Action = (byte)cmbAction.SelectedIndex;
                byte T = (byte)cmbT.SelectedIndex;
                byte Q = (byte)cmbQ.SelectedIndex;
                byte StartQ = (byte)cmbStartQ.SelectedIndex;
                byte MinQ = (byte)cmbMinQ.SelectedIndex;
                byte MaxQ = (byte)cmbMaxQ.SelectedIndex;
                byte D = (byte)cmbDr.SelectedIndex;
                byte Coding = (byte)cmbCoding.SelectedIndex;
                byte P = (byte)cmbP.SelectedIndex;
                byte Sel = (byte)cmbSel.SelectedIndex;
                byte Session = (byte)cmbSession.SelectedIndex;
                byte G = (byte)cmbG.SelectedIndex;
                byte LF = (byte)cmbLinkFrequency.SelectedIndex;
                if (UHFAPI.getInstance().SetGen2(Target, Action, T, Q, StartQ, MinQ, MaxQ, D, Coding, P, Sel, Session, G, LF))
                {
                    msg = "Set the Gen2 success!";
                }
                
            }
            catch (Exception ex)
            {
               
            }
            showMessage(msg);
        }
        #endregion

        #region CW
        private void btnGetCW_Click(object sender, EventArgs e)
        {
            string msg = "failure!";
            if (UHFAPI.getInstance().SetCW(1))
            {
                msg = "success!";
            }
            showMessage(msg);
        }
        private void btnSetCW_Click(object sender, EventArgs e)
        {
            string msg = "failure!";
            if (UHFAPI.getInstance().SetCW(0))
            {
                msg = "success!";
            }
            showMessage(msg);
        }
        #endregion

        #region antenna
        private void btnGetANT_Click(object sender, EventArgs e)
        {
             cmbAnt8.Checked = false;
             cmbAnt7.Checked = false;
             cmbAnt6.Checked = false;
             cmbAnt5.Checked = false;
             cmbAnt4.Checked = false;
             cmbAnt3.Checked = false;
             cmbAnt2.Checked = false;
             cmbAnt1.Checked = false;
             cmbAnt16.Checked = false;
             cmbAnt15.Checked = false;
             cmbAnt14.Checked = false;
             cmbAnt13.Checked = false;
             cmbAnt12.Checked = false;
             cmbAnt11.Checked = false;
             cmbAnt10.Checked = false;
             cmbAnt9.Checked = false;

            string msg = "failure!";
            byte[] ant = new byte[2];
            if (UHFAPI.getInstance().GetANT(ant))
            {
                foreach (Control control in this.groupBox10.Controls)
                {
                    if (control is CheckBox) {
                        CheckBox checkBox = (CheckBox)control;
                        checkBox.Checked = false;
                    }
                }
               // ant[0] = 00;
               // ant[1] = 03;

             //   MessageBox.Show("ant[0]=" + DataConvert.ByteArrayToHexString(new byte[] { ant[0] }) + "ant[1]="+DataConvert.ByteArrayToHexString(new byte[] { ant[1] }));

                string t1 = System.Convert.ToString(ant[0], 2);
                string t2  = System.Convert.ToString(ant[1], 2);

                string temp1 = "00000000".Substring(0, 8 - t1.Length) + t1;
                string temp2 = "00000000".Substring(0, 8 - t2.Length) + t2;

                if (temp2.Substring(0, 1) == "1") cmbAnt8.Checked = true;
                if (temp2.Substring(1, 1) == "1") cmbAnt7.Checked = true;
                if (temp2.Substring(2, 1) == "1") cmbAnt6.Checked = true;
                if (temp2.Substring(3, 1) == "1") cmbAnt5.Checked = true;
                if (temp2.Substring(4, 1) == "1") cmbAnt4.Checked = true;
                if (temp2.Substring(5, 1) == "1") cmbAnt3.Checked = true;
                if (temp2.Substring(6, 1) == "1") cmbAnt2.Checked = true;
                if (temp2.Substring(7, 1) == "1") cmbAnt1.Checked = true;

                if (temp1.Substring(0, 1) == "1") cmbAnt16.Checked = true;
                if (temp1.Substring(1, 1) == "1") cmbAnt15.Checked = true;
                if (temp1.Substring(2, 1) == "1") cmbAnt14.Checked = true;
                if (temp1.Substring(3, 1) == "1") cmbAnt13.Checked = true;
                if (temp1.Substring(4, 1) == "1") cmbAnt12.Checked = true;
                if (temp1.Substring(5, 1) == "1") cmbAnt11.Checked = true;
                if (temp1.Substring(6, 1) == "1") cmbAnt10.Checked = true;
                if (temp1.Substring(7, 1) == "1") cmbAnt9.Checked = true;

                msg = "success";
              //  msg = Common.isEnglish?"success":"获取天线成功!("+ DataConvert.ByteArrayToHexString(ant)+")";
            }

            showMessage(msg);
        }
        private void btnSetAnt_Click(object sender, EventArgs e)
        {
            string msg = "failure";
            StringBuilder sb1 = new StringBuilder();
            if (cmbAnt8.Checked) sb1.Append("1"); else sb1.Append("0");
            if (cmbAnt7.Checked) sb1.Append("1"); else sb1.Append("0");
            if (cmbAnt6.Checked) sb1.Append("1"); else sb1.Append("0");
            if (cmbAnt5.Checked) sb1.Append("1"); else sb1.Append("0");
            if (cmbAnt4.Checked) sb1.Append("1"); else sb1.Append("0");
            if (cmbAnt3.Checked) sb1.Append("1"); else sb1.Append("0");
            if (cmbAnt2.Checked) sb1.Append("1"); else sb1.Append("0");
            if (cmbAnt1.Checked) sb1.Append("1"); else sb1.Append("0");

            StringBuilder sb2 = new StringBuilder();
            if (cmbAnt16.Checked) sb2.Append("1"); else sb2.Append("0");
            if (cmbAnt15.Checked) sb2.Append("1"); else sb2.Append("0");
            if (cmbAnt14.Checked) sb2.Append("1"); else sb2.Append("0");
            if (cmbAnt13.Checked) sb2.Append("1"); else sb2.Append("0");
            if (cmbAnt12.Checked) sb2.Append("1"); else sb2.Append("0");
            if (cmbAnt11.Checked) sb2.Append("1"); else sb2.Append("0");
            if (cmbAnt10.Checked) sb2.Append("1"); else sb2.Append("0");
            if (cmbAnt9.Checked) sb2.Append("1"); else sb2.Append("0");

            byte[] ant = new[]{
                   Convert.ToByte(sb2.ToString(),2),
                   Convert.ToByte(sb1.ToString(),2)
            };
            
            byte flag = cbAntSet.Checked ? (byte)1 : (byte)0;
            if (UHFAPI.getInstance().SetANT(flag, ant))
            {
                msg = "success";
               
            }
            showMessage(msg);

        }


        private void btnGetANTWorkTime_Click(object sender, EventArgs e)
        {
            string msg = "failure";
            int ant = cmbAntWorkTime.SelectedIndex + 1;
            int time = 0;
            if (UHFAPI.getInstance().GetANTWorkTime((byte)ant, ref time))
            {
                txtAntWorkTime.Text = time.ToString();
                msg = "success";
            }

            showMessage(msg);
        }

        private void btnSetANTWorkTime_Click(object sender, EventArgs e)
        {
            string msg = "failure";
            int ant = cmbAntWorkTime.SelectedIndex+1;
            int time = int.Parse(txtAntWorkTime.Text);
            int flag = cbAntWorkTime.Checked ? 1 : 0;
            if (UHFAPI.getInstance().SetANTWorkTime((byte)ant, (byte)flag, time))
            {
                msg = "success";
            }
            showMessage(msg);
        }
        private void txtWorkTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtAntWorkTime.Text = txtAntWorkTime.Text.Trim();
                string workTime = txtAntWorkTime.Text;
                if (!StringUtils.IsNumber(workTime))
                {
                    txtAntWorkTime.Text = "";
                    return;
                }
                int time = int.Parse(workTime);
                if (time > 65535) {
                    txtAntWorkTime.Text = "65535";
                }
            }
            catch (Exception ex)
            {
                txtAntWorkTime.Text = "";
            }
        }
        private void txtWorkTime_LostFocus(object sender, EventArgs e)
        {
            try
            {
                txtAntWorkTime.Text = txtAntWorkTime.Text.Trim();
                string workTime = txtAntWorkTime.Text;
                if (!StringUtils.IsNumber(workTime))
                {
                    txtAntWorkTime.Text = "";
                    return;
                }
                int time = int.Parse(workTime);
                if (time <10)
                {
                    txtAntWorkTime.Text = "10";
                }
            }
            catch (Exception ex)
            {
                txtAntWorkTime.Text = "";
            }
        }
        
        
        #endregion

        #region region
        private void btnRegionGet_Click(object sender, EventArgs e)
        {
            //0x01(China1),0x02(China2),0x04(Europe),0x08(USA),0x16(Korea),0x32(Japan)
            string msg = "Get the region failure!";
            byte region=0;
            if (UHFAPI.getInstance().GetRegion(ref region))
            {
                switch (region) { 
                    case 0x01:
                        cmbRegion.SelectedIndex = 0;
                        break;
                    case 0x02:
                        cmbRegion.SelectedIndex = 1;
                        break;
                    case 0x04:
                        cmbRegion.SelectedIndex = 2;
                        break;
                    case 0x08:
                        cmbRegion.SelectedIndex = 3;
                        break;
                    case 0x16:
                        cmbRegion.SelectedIndex = 4;
                        break;
                    case 0x32:
                        cmbRegion.SelectedIndex = 5;
                        break;
                    case 0x34:
                        cmbRegion.SelectedIndex = 6;
                        break;
                }
                msg="Get the region success";
            }

            showMessage(msg);
        }

        private void btnRegionSet_Click(object sender, EventArgs e)
        {
            //0x01(China1),0x02(China2),0x04(Europe),0x08(USA),0x16(Korea),0x32(Japan)
            int flag = cbRegionSave.Checked ? 1 : 0;
            int region = -1;
            switch (cmbRegion.SelectedIndex)
            {
                case 0:
                    region = 0x01;
                    break;
                case 1:
                    region = 0x02;
                    break;
                case 2:
                    region = 0x04;
                    break;
                case 3:
                    region = 0x08;
                    break;
                case 4:
                    region = 0x16;
                    break;
                case 5:
                    region = 0x32;
                    break;
                case 6:
                    region = 0x34;
                    break;
            }
            string msg = "Set the region failure!";
            if (region >= 0)
            {
                if (UHFAPI.getInstance().SetRegion((byte)flag, (byte)region))
                {
                    msg="Set the region success";
                }
                 
            }
            showMessage(msg);
        }
        #endregion
        #region Temperature protection
        private void GetTemperatureProtect_Click(object sender, EventArgs e)
        {
            byte flag = 0;
            string msg = "failure!";
            if (UHFAPI.getInstance().GetTemperatureProtect(ref flag))
            {
                if (flag == 1)
                {
                    rbEnable.Checked = true;
                    rbDisable.Checked = false;
                      msg = "success!";
                }
                else if (flag ==0)
                {
                    rbEnable.Checked = false;
                    rbDisable.Checked = true;
                      msg = "success!";
                }

            }
            showMessage(msg);
        }
        private void btnSetTemperatureProtect_Click(object sender, EventArgs e)
        {
            string msg ="failure!";
            int flag = 0;
            if (rbDisable.Checked)
            {
                flag = 0;
            }
            else if (rbEnable.Checked)
            {
                flag = 1;
            }
            if (UHFAPI.getInstance().SetTemperatureProtect((byte)flag))
            {
                msg = "success!";
            }
            showMessage(msg);
        }
        #endregion

        #region Linkcombination
        private void btnRFLinkGet_Click(object sender, EventArgs e)
        {
            string msg = "failure";
            byte mode = 0;
            if (UHFAPI.getInstance().GetRFLink(ref mode))
            {
                cmbRFLink.SelectedIndex = mode;
                msg = "success";
            }

            showMessage(msg);
        }
        private void btnRFLinkSet_Click(object sender, EventArgs e)
        {
            string msg = "failure";
            int flag = cbRFLink.Checked ? 1 : 0;
            if (cmbRFLink.SelectedIndex >= 0)
            {
                if (UHFAPI.getInstance().SetRFLink((byte)flag, (byte)cmbRFLink.SelectedIndex)) {
                    msg = "success";
                }
            }

            showMessage(msg);
        }

        #endregion

        #region FastID
        private void btnFastIDGet_Click(object sender, EventArgs e)
        {
            byte flag = 0;
            string msg = "failure";
            if (UHFAPI.getInstance().GetFastID(ref flag))
            {
                if (flag == 0)
                {
                    rbFastIDEnable.Checked = false;
                    rbFastIDDisable.Checked = true;
                    msg = "success";
                }
                else if (flag == 1)
                {
                    rbFastIDEnable.Checked = true;
                    rbFastIDDisable.Checked = false;
                    msg = "success";
                }
            }
            showMessage(msg);
        }
        private void btnFastIDSet_Click(object sender, EventArgs e)
        {
            int flag = -1;
            string msg = "failure";
            if (rbFastIDEnable.Checked)
            {
                flag = 1;
            }
            else if (rbFastIDDisable.Checked)
            {
                flag = 0;
            }

            if (flag >= 0)
            {
                if (UHFAPI.getInstance().SetFastID((byte)flag))
                {
                    msg = "success";

                    if (flag == 1) {
                        if (UHFAPI.getInstance().SetTagfocus(0))
                        {
                            rbTagfocusDisable.Checked = true;
                        }
                        if (UHFAPI.getInstance().SetEPCTIDMode(0, 0))
                        {
                            rbEPCDisable.Checked = true;
                        }
                    }

                }
               
            }

            showMessage(msg);
        }
        #endregion

        #region Tagfocus
        private void btnrbTagfocusGet_Click(object sender, EventArgs e)
        {
            string msg = "failure";
            byte flag = 0;
            if (UHFAPI.getInstance().GetTagfocus(ref flag))
            {
                if (flag == 0)
                {
                    rbTagfocusEnable.Checked = false;
                    rbTagfocusDisable.Checked = true;
                    msg = "success";
                }
                else if (flag == 1)
                {
                    rbTagfocusEnable.Checked = true;
                    rbTagfocusDisable.Checked = false;
                    msg = "success";
                }
            }

            showMessage(msg);
        }
        private void btnrbTagfocusSet_Click(object sender, EventArgs e)
        {
            int flag = -1;
            string msg = "failure";
            if (rbTagfocusEnable.Checked)
            {
                flag = 1;
            }
            else if (rbTagfocusDisable.Checked)
            {
                flag = 0;
            }

            if (flag >= 0)
            {
                if (UHFAPI.getInstance().SetTagfocus((byte)flag))
                {
                    msg = "success";
                    if (flag == 1)
                    {

                        if (UHFAPI.getInstance().SetFastID(0))
                        {
                            rbFastIDDisable.Checked = true;
                        }
                 
                        if (UHFAPI.getInstance().SetEPCTIDMode(0, 0))
                        {
                            rbEPCDisable.Checked = true;
                        }
                    }
                }
                
            }
            showMessage(msg);
        }
        #endregion
        #region Setsoftreset
        private void btnReset_Click(object sender, EventArgs e)
        {
            string msg = "failure";
            if (UHFAPI.getInstance().SetSoftReset())
            {
                msg = "success";
            }

            showMessage(msg);
        }
        #endregion
        #region DualSingel
        private void btnDualSingelGet_Click(object sender, EventArgs e)
        {
            byte flag = 0;
            string msg = "failure";
            if (UHFAPI.getInstance().GetDualSingelMode(ref flag))
            {
                if (flag == 0)
                {
                    rbDual.Checked = true;
                    rbSingel.Checked = false;
                    msg = "success";
                }
                else if (flag == 1)
                {
                    rbDual.Checked = false;
                    rbSingel.Checked = true ;
                    msg = "success";
                }
            }
            showMessage(msg);
        }
        private void btnDualSingelSet_Click(object sender, EventArgs e)
        {
            int flag = -1;

            if (rbDual.Checked)
            {
                flag = 0;
            }
            else if (rbSingel.Checked)
            {
                flag =1 ;
            }
            string msg = "failure";
            if (flag >= 0)
            {
                int save = cbDualSingelSave.Checked ? 1 : 0;
                if (UHFAPI.getInstance().SetDualSingelMode((byte)save, (byte)flag))
                {
                    msg = "success";
                }
            }
            showMessage(msg);
        }
        #endregion

        #region EPC And Tid
        private void EPCGet_Click(object sender, EventArgs e)
        {
            string msg = "failure";
            byte mode=0;
            if (UHFAPI.getInstance().GetEPCTIDMode(ref mode))
            {
                if (mode == 0)
                {
                    rbEPCDisable.Checked = true;
                    rbEPCEnable.Checked = false;
                    msg = "success";
                }
                else if (mode == 1)
                {
                    rbEPCDisable.Checked = false;
                    rbEPCEnable.Checked = true;
                    msg = "success";
                }
            }
            showMessage(msg);
        }

        private void EPCSet_Click(object sender, EventArgs e)
        {
            string msg = "failure";
            int mode = -1;
            if (rbEPCDisable.Checked)
            {
                mode = 0;
            }
            else if (rbEPCEnable.Checked)
            {
                mode = 1;
            }
            if (mode >= 0)
            {
                int flag = cbEPCAndTID.Checked ? 1 : 0;
                if (UHFAPI.getInstance().SetEPCTIDMode((byte)flag,(byte)mode))
                {
                    msg ="success";
                    if (mode == 1)
                    {
                        if (UHFAPI.getInstance().SetFastID(0))
                        {
                            rbFastIDDisable.Checked = true;
                        }
                        if (UHFAPI.getInstance().SetTagfocus(0))
                        {
                            rbTagfocusDisable.Checked = true;
                        }
                     
                    }
                }
            }
            showMessage(msg);
        }
        #endregion

        #region protocol
        private void button2_Click_1(object sender, EventArgs e)
        { 
            string msg = "failure";
            int type = UHFAPI.getInstance().GetProtocol();
            if (type>-1)
            {
                msg = "success";
                cmbProtocol.SelectedIndex = type;
            }
            showMessage(msg);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string msg = "failure";
            int type = cmbProtocol.SelectedIndex;
            if (type >= 0)
            {
                if (UHFAPI.getInstance().SetProtocol((byte)type))
                {
                    msg = "success";
                }
            }
            showMessage(msg);
        }


        #endregion  

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string data = textBox1.Text.Trim().Replace(" ", "");
            if (data.Length > 0) {

                
                int index=textBox1.SelectionStart-1;
                if (index >= 0)
                {
                    string charData = data.Substring(index, 1);
                    if (charData != "0" && charData != "1" && charData != "2" 
                        && charData != "3" && charData != "4" && charData != "5" && charData != "6" && charData != "7"
                        && charData != "8" && charData != "9" && charData != ".")
                    {
                        textBox1.Text = textBox1.Text.Remove(index, 1);
                        textBox1.SelectionStart = textBox1.Text.Length;
                    }
                }
            }
   
        }



        public void MainForm_eventSwitchUI()
        {
            //if (Common.isEnglish)
            {
                groupBox19.Text = "Protocol";
                label35.Text = "Protocol:";

                label2.Text = "";
                groupBox6.Text = "Power";
                label24.Text = "Output Power:";
                cbSave.Text = "Save";
             

                groupBox11.Text = "Region";
                label1.Text = "Region:";           
                cbRegionSave.Text = "Save";

                label5.Text = "RFLink:";
                groupBox3.Text = "RFLink";
                cbRFLink.Text = "cbSave";

                groupBox7.Text = "Rrequency";
                label28.Text = "Rrequency:";

                btnReset.Text = "Reset";

                groupBox10.Text = "ANT";
                groupBox8.Text = "TemperatureProtect";
                groupBox20.Text = "TemperatureProtect Set";
                // label24.Location = new Point(8, 34);
                // label1.Location = new Point(51, 39);
                //  label5.Location = new Point(51, 33);
                //  label28.Location = new Point(27, 42);

                rbFastIDEnable.Text = rbTagfocusEnable.Text = rbEnable.Text = rbEPCEnable.Text = "Enable";
                rbFastIDDisable.Text = rbTagfocusDisable.Text = rbDisable.Text = rbEPCDisable.Text = "Disable";

                groupBox4.Text = "Local IP";
                groupBox17.Text = "Destination IP";
                label9.Text = label31.Text = "IP:";
                label25.Text = label30.Text = "Port:";
                groupBox9.Text = "Buzzer=";

                int index = workMode.SelectedIndex == -1 ? 0 : workMode.SelectedIndex;
                workMode.Items.Clear();
                workMode.Items.Add("command mode");
                workMode.Items.Add("auto mode");

                groupBox1.Text = "cw";
                
                workMode.SelectedIndex = index;

      
                label39.Text = "input1:";
                label40.Text = "input2:";
                label38.Text = "Relay:";
            }
            

        }

        private void showMessage(string msg,int time) {
            if (msg.ToLower().Contains("fail"))
            {
                frmWaitingBox f = new frmWaitingBox((obj, args) =>
                {
                    System.Threading.Thread.Sleep(time);
                }, msg);
                f.ShowDialog(this);
            }
        }
        private void showMessage(string msg)
        {
            if (msg.ToLower().Contains("fail"))
            {
                frmWaitingBox f = new frmWaitingBox((obj, args) =>
                {
                    System.Threading.Thread.Sleep(500);
                }, msg);
                f.ShowDialog(this);
            }
        }

        
        //local IP
        private void btnSetIPLocal_Click(object sender, EventArgs e)
        {
            string port = txtLocalPort.Text.Trim();
            string[] tempIp=ipControlLocal.IpData;
            StringBuilder sb = new StringBuilder();
            sb.Append(tempIp[0]);
            sb.Append(".");
            sb.Append(tempIp[1]);
            sb.Append(".");
            sb.Append(tempIp[2]);
            sb.Append(".");
            sb.Append(tempIp[3]);
            string ip = sb.ToString();

             if (!StringUtils.isIP(ip))
             {
                 string msg = "failure!";
                 showMessage(msg);
                 return;
             }
             if (!StringUtils.IsNumber(port))
             {
                 string msg = "failure!";
                 showMessage(msg);
                 return;
             }

             if (!UHFAPI.getInstance().SetLocalIP(ip, int.Parse(port)))
             {
                 string msg = "failure!";
                 showMessage(msg);
                 return;
             }
        }
        //Local IP
        private void btnGetIPLocal_Click(object sender, EventArgs e)
        {

            
              int startTime = Environment.TickCount;
 

            StringBuilder sIP=new StringBuilder(20);
            StringBuilder sPort = new StringBuilder(20);
            if (UHFAPI.getInstance().GetLocalIP(sIP, sPort))
            {
                ipControlLocal.IpData = sIP.ToString().Split('.');// txtLocalIP.Text = sIP.ToString();
                txtLocalPort.Text = sPort.ToString();
            }
            else
            {
                string msg = "failure!";
                showMessage(msg);
                return;
            }

           
           
        }
 
        //destination IP
        private void btnGetIpDest_Click(object sender, EventArgs e)
        {
            StringBuilder sIP = new StringBuilder();
            StringBuilder sPort = new StringBuilder();
            if (UHFAPI.getInstance().GetDestIP(sIP, sPort))
            {
               // txtIPDest.Text = sIP.ToString();
                ipControlDest.IpData = sIP.ToString().Split('.');
                txtPortDest.Text = sPort.ToString();
            }
            else
            {
                string msg = "failure!";
                showMessage(msg);
                return;
            }
        }

        //IP
        private void btnSetIpDest_Click(object sender, EventArgs e)
        {
            string port = txtPortDest.Text.Trim();

            string[] tempIp = ipControlDest.IpData;
            StringBuilder sb = new StringBuilder();
            sb.Append(tempIp[0]);
            sb.Append(".");
            sb.Append(tempIp[1]);
            sb.Append(".");
            sb.Append(tempIp[2]);
            sb.Append(".");
            sb.Append(tempIp[3]);
            string ip = sb.ToString();
  
            if (!StringUtils.isIP(ip))
            {
                string msg = "failure!";
                showMessage(msg);
                return;
            }
            if (!StringUtils.IsNumber(port))
            {
                string msg = "failure!";
                showMessage(msg);
                return;
            }

            if (!UHFAPI.getInstance().SetDestIP(ip, int.Parse(port)))
            {
                string msg = "failure!";
                showMessage(msg);
                return;
            }
        }

        
        private void btnGetBuzzer_Click(object sender, EventArgs e)
        {
            byte[] mode=new byte[10];
            if (!UHFAPI.getInstance().UHFGetBuzzer(mode))
            {
                string msg = "failure!";
                showMessage(msg);
                return;
            }
            else
            {
                if (mode[0] == 0)
                {

                    rbEnableBuzzer.Checked = false;
                    rbDisableBuzzer.Checked = true;
                }
                else if (mode[0] == 1)
                {
                    rbDisableBuzzer.Checked = false;
                    rbEnableBuzzer.Checked = true;
                }

            }
        }
        
        private void btnSetBuzzer_Click(object sender, EventArgs e)
        {
            //0x00: turn off buzzer；0x01: turn on buzzer
            byte mode =0;
            if (rbEnableBuzzer.Checked)
            {
                mode = 1;
            }
            else if (rbDisableBuzzer.Checked)
            {
                mode = 0;
            }
            else {

                string msg = "failure!";
                showMessage(msg);
                return;
            }

            if (!UHFAPI.getInstance().UHFSetBuzzer(mode))
            {
                string msg = "failure!";
                showMessage(msg);
                return;
            }
        }

        #region workmode
        private void button2_Click(object sender, EventArgs e)
        {
            //get
            byte[] mode=new byte[2];
            if (UHFAPI.getInstance().GetWorkMode(mode))
            {
                if (mode[0] == 0)
                {
                    workMode.SelectedIndex = 0;
                }
                else if (mode[0] == 1)
                {
                    workMode.SelectedIndex = 1;
                }
            }
            else
            {
                string msg = "failure!";
                showMessage(msg);
                return;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte mode=(byte) workMode.SelectedIndex;
            if (!UHFAPI.getInstance().SetWorkMode(mode))
            {
                string msg = "failure!";
                showMessage(msg);
                return;
             
            }
        }
        #endregion

        private void label18_Click(object sender, EventArgs e)
        {

        }

     

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //string msg = Common.isEnglish ? "connecting..." : "连接中...";
            //frmWaitingBox f = new frmWaitingBox((obj, args) =>
            //{
            //    this.Invoke(new EventHandler(delegate {

                  
            //    }));

            //}, msg);
            //f.ShowDialog(this);

            Cursor.Current = Cursors.WaitCursor;

            groupBox6.Visible = true;
            groupBox14.Visible = true;

            groupBox5.Visible = true;
            groupBox11.Visible = true;
            groupBox3.Visible = true;
            groupBox15.Visible = true;
         //   groupBox16.Visible = true;

            btnReset.Visible = true;

            groupBox1.Visible = true;
            groupBox10.Visible = true;
            groupBox8.Visible = true;

            groupBox2.Visible = true;
            groupBox7.Visible = true;

            groupBox4.Visible = true;
            groupBox17.Visible = true;
            groupBox9.Visible = true;
 
            groupBox18.Visible = true;
            groupBox19.Visible = true;


            groupBox20.Visible = true;
            groupBox21.Visible = true;
            Cursor.Current = Cursors.Default;
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            int temp = UHFAPI.getInstance().GetTemperatureVal();
            textBox3.Text = temp+"";
            if (temp == -1) {
                string msg = "failure!";
                showMessage(msg);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string temp = textBox3.Text;
                if (temp == null || temp.Length == 0)
                {
                    string msg = "failure!";
                    showMessage(msg);
                    return;
                }
                int t = int.Parse(temp);

                if (t < 50 || t > 75)
                {
                    string msg = "failure!";
                    showMessage(msg);
                    return;
                }


                if (!UHFAPI.getInstance().SetTemperatureVal((byte)t))
                {
                    string msg = "failure!";
                    showMessage(msg);
                    return;
                }
            }
            catch (Exception ex)
            {
                string msg = "failure!";
                showMessage(msg);
                return;
            }
        }

        #region GPIO
        private void button6_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[2];
            if (!UHFAPI.getInstance().getIOControl(data))
            {
                string msg = "failure!";
                showMessage(msg);
                return;
            }
            else {
                comboBox2.SelectedIndex = data[0];
                comboBox3.SelectedIndex = data[1];
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int status = cmbOutStatus.SelectedIndex;
            int ouput2 = 1;// cmbOutPut2.SelectedIndex;
            int ouput1 = 1;// cmbOutPut1.SelectedIndex;



            if (!UHFAPI.getInstance().setIOControl((byte)ouput1, (byte)ouput2, (byte)status))
            {
                string msg = "failure!";
                showMessage(msg);
                return;
            }
        }
        #endregion















    }
}
