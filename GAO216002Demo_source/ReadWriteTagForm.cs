using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm_Test;

namespace UHFAPP
{
    public partial class ReadWriteTagForm : Form
    {
        public string tag = "";
        public ReadWriteTagForm()
        {
            InitializeComponent();
        }
        public ReadWriteTagForm(bool isOpen,string tag)
        {
            InitializeComponent();
            setTAG(isOpen, tag);              
        }
        public void setTAG(bool isOpen, string tag)
        {
            if (isOpen)
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }
            if (tag != "")
            {
                this.tag = tag;
                txtFilter_EPC.Text = tag;
                txtLen.Text = (tag.Length / 2 * 8 ).ToString();
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
            }
        }
 
        private void ReadWriteTagForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.eventOpen -= MainForm_eventOpen;
            MainForm.eventSwitchUI -= MainForm_eventSwitchUI;
        }

        private void ReadWriteTagForm_Load(object sender, EventArgs e)
        {
            txtFilter_EPC.Text = Common.tag;
            MainForm.eventOpen += MainForm_eventOpen;
            cmbRead_Bank.SelectedIndex = 1;
            cmbBlockWrite__Bank.SelectedIndex = 1;
     
           comboBox1.SelectedIndex= cmbQT1.SelectedIndex = 0;
           comboBox2.SelectedIndex=cmbQT2.SelectedIndex = 0;
            cmbQT_bank.SelectedIndex = 1;

            MainForm.eventSwitchUI += MainForm_eventSwitchUI;
            MainForm_eventSwitchUI();

            txtPtr.LostFocus += new EventHandler(txt_LostFocus); 
            txtLen.LostFocus += new EventHandler(txt_LostFocus); 

            if (txtFilter_EPC.Text.Replace(" ", "").Length > 0)
            {
                txtLen.Text = (txtFilter_EPC.Text.Replace(" ", "").Length / 2 * 8) + "";
            }
        }


        void MainForm_eventSwitchUI()
        {
            //if (Common.isEnglish)
            {
                groupBox4.Text = "filter";
                //btnFilterEPC.Text = "Read EPC";
                groupBox1.Text = "Read-write";
                label1.Text = "Bank:";
                label2.Text = "Prt:";
                label4.Text = "Length:";
                label5.Text = "Access Pwd:";
                label6.Text = "Data:";
  
                label13.Text = "(word)";

                label11.Text = "Bank:";
                label10.Text = "Prt:";
                label9.Text = "Length:";
                label8.Text = "Access Pwd:";
                label7.Text = "Data:";
          
                label20.Text = "(word)";

                label18.Text = "Bank:";
                label17.Text = "Prt:";
                label16.Text = "Length:";
                label15.Text = "Access Pwd:";
                label14.Text = "Data:";
 
                label21.Text = "(word)";

                btnWrite.Text = "Write";
                btWrite.Text = "Write";
                btnErase.Text = "Erase";
                btnQTRead.Text = "Read";
                btnQTWrite.Text = "Write";
                btnRead.Text = "Read";
                btnGetQT.Text = "Get";
                btnSetQT.Text = "Set";

                label27.Text = "Access Pwd:";
                label27.Location = new Point(2, 28);
 
            }            
        }


   
        #region readwrite
        private void btnRead_Click(object sender, EventArgs e)
        {
            if (!DetectionFiltration())
                return;

            string filerData = txtFilter_EPC.Text.Replace(" ", "");
            string accessPwd = txtRead_AccessPwd.Text.Replace(" ", "");


            if (!StringUtils.IsHexNumber(accessPwd) || accessPwd.Length != 8)
            {
                MessageBox.Show("The length of the password must be 8!");
                return;
            }

            //filter----------------------------------
            int filerBank = 1;
            byte[] filerBuff = DataConvert.HexStringToByteArray(filerData);
            int filerPtr = int.Parse(txtPtr.Text);
            int filerLen = int.Parse(txtLen.Text);

            if ((filerLen / 8 + (filerLen % 8 == 0 ? 0 : 1)) * 2 > filerData.Length)
            {
                MessageBox.Show("filter data length error!");  //to do
                return;
            }

            if (rbTID.Checked)
                filerBank = 2;
            if (rbUser.Checked)
                filerBank = 3;
            //-----------------------------------------
            byte[] pwd = DataConvert.HexStringToByteArray(accessPwd);
            int bank = cmbRead_Bank.SelectedIndex;
            int Ptr = int.Parse(txtRead_Ptr.Text);
            int leng = int.Parse(txtRead_Length.Text);
            string msg = "";

            txtRead_Data.Text = "";
            string result = UHFAPI.getInstance().ReadData(pwd, (byte)filerBank, filerPtr, filerLen, filerBuff, (byte)bank, Ptr, leng);

            int time = 500;
            if (result != string.Empty)
            {
                time = 100;
                txtRead_Data.Text = result;
                msg = "Read success!";
            }
            else
            {
                msg = "Read failure!";
            }

            frmWaitingBox f = new frmWaitingBox((obj, args) =>
            {
                System.Threading.Thread.Sleep(time);
            }, msg);
            f.ShowDialog(this);
        }
        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (!DetectionFiltration())
                return;

            string filerData = txtFilter_EPC.Text.Replace(" ", "");
            string accessPwd = txtRead_AccessPwd.Text.Replace(" ", "");


            if (!StringUtils.IsHexNumber(accessPwd) || accessPwd.Length != 8)
            {
                MessageBox.Show("The length of the password must be 8!");
                return;
            }

            //--------
            int filerBank = 1;
            byte[] filerBuff = DataConvert.HexStringToByteArray(filerData);
            int filerPtr = int.Parse(txtPtr.Text);
            int filerLen = int.Parse(txtLen.Text);

            if ((filerLen / 8 + (filerLen % 8 == 0 ? 0 : 1)) * 2 > filerData.Length)
            {
                MessageBox.Show("filter data length error!"); //to do
                return;
            }

            if (rbTID.Checked)
                filerBank = 2;
            if (rbUser.Checked)
                filerBank = 3;
            //----------
            byte[] pwd = DataConvert.HexStringToByteArray(accessPwd);
            int bank = cmbRead_Bank.SelectedIndex;
            int Ptr = int.Parse(txtRead_Ptr.Text);
            int leng = int.Parse(txtRead_Length.Text);
            string msg = "";
            string Databuf = txtRead_Data.Text.Replace(" ", "");
            if (!StringUtils.IsHexNumber(Databuf))
            {
                MessageBox.Show("Please input hexadecimal data!");
                return;
            }
            if (Databuf.Length % 4 != 0)
            {
                MessageBox.Show("Write data of the length of the string must be in multiples of four!");
                return;
            }
            if (leng > (Databuf.Length/4))
            {
                MessageBox.Show("Write data length error! ");
                return;
            }
            int time = 500;
            byte[] uDatabuf = DataConvert.HexStringToByteArray(Databuf);
            bool result = UHFAPI.getInstance().WriteData(pwd, (byte)filerBank, filerPtr, filerLen, filerBuff, (byte)bank, Ptr, (byte)leng, uDatabuf);
            if (result)
            {
                time = 100;
                msg = "Write success!";
            }
            else
            {
                msg = "Write failure!";
            }

            frmWaitingBox f = new frmWaitingBox((obj, args) =>
            {
                System.Threading.Thread.Sleep(time);
            }, msg);
            f.ShowDialog(this);
        }
   
        private void txtRead_AccessPwd_TextChanged(object sender, EventArgs e)
        {
            FormatHex_PWD(txtRead_AccessPwd);
        }
        private void txtRead_Data_TextChanged(object sender, EventArgs e)
        {
            FormatHex(txtRead_Data);
            string data = txtRead_Data.Text.Replace(" ", "");
            if (data.Length > 0)
            {
                lblLeng.Text = ((data.Length / 2) + ((data.Length % 2) == 0 ? 0 : 1)).ToString();  // txtRead_Length.Text = ((data.Length / 4) + ((data.Length % 4) == 0 ? 0 : 1)).ToString();
            }
            else
            {
                lblLeng.Text = "0";
            }
        }
 
        private void cmbRead_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbRead_Bank.SelectedIndex;
            if (index == 1)
            {
                if (int.Parse(txtRead_Ptr.Text) < 2)
                {
                    txtRead_Ptr.Text = "2";
                }
            }
            else
            {
                txtRead_Ptr.Text = "0";
            }

            if (index == 1 || index == 2)
            {
                txtRead_Length.Text = "6";
            }
            else
            {
                txtRead_Length.Text = "4";
            }
 
 
        }
        private void TextChangedPtr(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!StringUtils.IsNumber(txt.Text))
            {
                txt.Text = "0";
            }
            int index = cmbRead_Bank.SelectedIndex;
            if (index == 1)
            {
                if (int.Parse(txt.Text) < 2)
                {
                  //  txt.Text = "2";
                }
            }
        }
        //
        private void TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!StringUtils.IsNumber(txt.Text))
            {
                txt.Text = "0";
            }
            if (int.Parse(txt.Text) < 1)
            {
                txt.Text = "1";
            }
        }
        #endregion


        #region BlockWrite

        private void btnErase_Click(object sender, EventArgs e)
        {
            if (!DetectionFiltration())
                return;


            string pws = txtBlockWrite__AccessPwd.Text.Replace(" ", "");

            if (pws.Length != 8)
            {
                MessageBox.Show("The length of the password must be 8!");
                return;
            }
            int bank = cmbBlockWrite__Bank.SelectedIndex;
            int startIndex = int.Parse(txtBlockWrite__Ptr.Text);
            int leng = int.Parse(txtBlockWrite__Length.Text);
            byte[] uAccessPwd = DataConvert.HexStringToByteArray(pws);

            //------------
            string filerData = txtFilter_EPC.Text.Replace(" ", "");
            int filerBank = 1;
            byte[] filerBuff = DataConvert.HexStringToByteArray(filerData);
            int filerPtr = int.Parse(txtPtr.Text);
            int filerLen = int.Parse(txtLen.Text);

            if ((filerLen / 8 + (filerLen % 8 == 0 ? 0 : 1)) * 2 > filerData.Length)
            {
                MessageBox.Show("filter data length error!"); //to do
                return;
            }
            if (rbTID.Checked)
                filerBank = 2;
            if (rbUser.Checked)
                filerBank = 3;
            //-------------------
            string msg = "";
            int time = 500;
            bool result = UHFAPI.getInstance().BlockEraseData(uAccessPwd, (byte)filerBank, filerPtr, filerLen, filerBuff, (byte)bank, startIndex, (byte)leng);
            if (result)
            {
                time = 100;
                msg = "Erase success!";
            }
            else
            {
                msg = "Erase failure!";
            }

            frmWaitingBox f = new frmWaitingBox((obj, args) =>
            {
                System.Threading.Thread.Sleep(time);
            }, msg);
            f.ShowDialog(this);
        }


        private void btWrite_Click(object sender, EventArgs e)
        {
            if (!DetectionFiltration())
                return;


            string pws = txtBlockWrite__AccessPwd.Text.Replace(" ", "");

            if (pws.Length != 8)
            {
                MessageBox.Show("The length of the password must be 8!");
                return;
            }
            int bank = cmbBlockWrite__Bank.SelectedIndex;
            int startIndex = int.Parse(txtBlockWrite__Ptr.Text);
            int leng = int.Parse(txtBlockWrite__Length.Text);
            byte[] uAccessPwd = DataConvert.HexStringToByteArray(pws);

            //------------
            string filerData = txtFilter_EPC.Text.Replace(" ", "");
            int filerBank = 1;
            byte[] filerBuff = DataConvert.HexStringToByteArray(filerData);
            int filerPtr = int.Parse(txtPtr.Text);
            int filerLen = int.Parse(txtLen.Text);

            if ((filerLen / 8 + (filerLen % 8 == 0 ? 0 : 1)) * 2 > filerData.Length)
            {
                MessageBox.Show("filter data length error!"); //to do
                return;
            }
            if (rbTID.Checked)
                filerBank = 2;
            if (rbUser.Checked)
                filerBank = 3;
            //-------------------
            string msg = "";
            string data = txtBlockWrite__Data.Text.Replace(" ", "");
            if (!StringUtils.IsHexNumber(data))
            {
                MessageBox.Show("Please input hexadecimal data!");
                return;
            }
            if (data.Length % 4 != 0)
            {
                MessageBox.Show("Write data of the length of the string must be in multiples of four!");
                return;
            }
            if (leng > (data.Length / 4))
            {
                MessageBox.Show("Write data length error! ");
                return;
            }
            byte[] byteData = DataConvert.HexStringToByteArray(data);

            int time = 500;
            bool result = UHFAPI.getInstance().BlockWriteData(uAccessPwd, (byte)filerBank, filerPtr, filerLen, filerBuff, (byte)bank, startIndex,  leng, byteData);
            if (result)
            {
                time = 100;
                msg = "Write success!";
            }
            else
            {
                msg = "Write failure!";
            }

            frmWaitingBox f = new frmWaitingBox((obj, args) =>
            {
                System.Threading.Thread.Sleep(time);
            }, msg);
            f.ShowDialog(this);
        }
     
    

        private void txtBlockWrite__Data_TextChanged(object sender, EventArgs e)
        {
            FormatHex(txtBlockWrite__Data);

            string data = txtBlockWrite__Data.Text.Replace(" ", "");
            if (data.Length > 0)
            {
                label25.Text = ((data.Length / 2) + ((data.Length % 2) == 0 ? 0 : 1)).ToString();
            }
            else
            {
                label25.Text = "0";
            }
        }

        private void txtBlockWrite__AccessPwd_TextChanged(object sender, EventArgs e)
        {
            FormatHex_PWD(txtBlockWrite__AccessPwd);
        }

        private void txtBlockWrite__Length_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!StringUtils.IsNumber(txt.Text))
            {
                txt.Text = "0";
            }
            if (int.Parse(txt.Text) < 1)
            {
                txt.Text = "1";
            }
        }
        private void txtBlockWrite__Ptr_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!StringUtils.IsNumber(txt.Text))
            {
                txt.Text = "0";
            }
            int index = cmbBlockWrite__Bank.SelectedIndex;
            if (index == 1)
            {
                if (int.Parse(txt.Text) < 2)
                {
                   // txt.Text = "2";
                }
            }
            
        }
        private void cmbBlockWrite__Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBlockWrite__Bank.SelectedIndex == 1)
            {
                if (int.Parse(txtBlockWrite__Ptr.Text) < 2)
                {
                    txtBlockWrite__Ptr.Text = "2";
                }
            }
            else
            {
                txtBlockWrite__Ptr.Text = "0";
            }
            int index = cmbBlockWrite__Bank.SelectedIndex;

            if (index == 1 || index == 2)
            {
                txtBlockWrite__Length.Text = "6";
            }
            else
            {
                txtBlockWrite__Length.Text = "4";
            }

        }
        #endregion

        #region QT
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            FormatHex_PWD(textBox1);
        }
        private void txtQT_data_TextChanged(object sender, EventArgs e)
        {
            FormatHex(txtQT_data);
            string data = txtQT_data.Text.Replace(" ", "");
            if (data.Length > 0)
            {
                label26.Text = ((data.Length / 2) + ((data.Length % 2) == 0 ? 0 : 1)).ToString();
            }
            else
            {
                label26.Text = "0";
            }
        }
   

        private void txtQT_pwd_TextChanged(object sender, EventArgs e)
        {
            FormatHex_PWD(txtQT_pwd);
        }

        private void QT_Length_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!StringUtils.IsNumber(txt.Text))
            {
                txt.Text = "0";
            }
            if (int.Parse(txt.Text) < 1)
            {
                txt.Text = "1";
            }
        }

        private void txtQT_ptr_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!StringUtils.IsNumber(txt.Text))
            {
                txt.Text = "0";
            }
            int index = cmbQT_bank.SelectedIndex;
            if (index == 0)
            {
                if (int.Parse(txt.Text) < 2)
                {
                   // txt.Text = "2";
                }
            }
        }

        private void cmbQT_bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbQT_bank.SelectedIndex;
            if (index == 1)
            {
                if (int.Parse(txtQT_ptr.Text) < 2)
                {
                    txtQT_ptr.Text = "2";
                }
            }
            else
            {
                txtQT_ptr.Text = "0";
            }


            if (index == 1 || index == 2)
            {
                QT_Length.Text = "6";
            }
            else
            {
                QT_Length.Text = "4";
            }
        }

        private void btnQTWrite_Click(object sender, EventArgs e)
        {
            if (!DetectionFiltration())
                return;

            string pws = txtQT_pwd.Text.Replace(" ", "");
            if (pws.Length != 8)
            {
                MessageBox.Show("The length of the password must be 8!");
                return;
            }

            int bank = cmbQT_bank.SelectedIndex;
            int startIndex = int.Parse(txtQT_ptr.Text);
            int leng = int.Parse(QT_Length.Text);
            byte[] uAccessPwd = DataConvert.HexStringToByteArray(pws);
            //-----------------------------
            string filerData = txtFilter_EPC.Text.Replace(" ", "");
            int filerBank = 1;
            byte[] filerBuff = DataConvert.HexStringToByteArray(filerData);
            int filerPtr = int.Parse(txtPtr.Text);
            int filerLen = int.Parse(txtLen.Text);

            if ((filerLen / 8 + (filerLen % 8 == 0 ? 0 : 1)) * 2 > filerData.Length)
            {
                MessageBox.Show("filter data length error!"); //to do
                return;
            }
            if (rbTID.Checked)
                filerBank = 2;
            if (rbUser.Checked)
                filerBank = 3;
            //--------------------------------------

            int QTData = Convert.ToByte("000000" + cmbQT2.SelectedIndex + cmbQT1.SelectedIndex);
            string msg = "";

            //
            string qtData = txtQT_data.Text.Replace(" ", "");
            if (!StringUtils.IsHexNumber(qtData))
            {
                MessageBox.Show("Please input hexadecimal data!");
                return;
            }
            if (qtData.Length % 4 != 0)
            {
                MessageBox.Show("Write data of the length of the string must be in multiples of four!");
                return;
            }
            if (leng > (qtData.Length / 2))
            {
                MessageBox.Show("Write data length error! ");
                return;
            }
            byte[] uDatabuf = DataConvert.HexStringToByteArray(qtData);
       
            bool result = UHFAPI.getInstance().WriteQT(uAccessPwd, (byte)filerBank, filerPtr, filerLen, filerBuff,
                (byte)QTData, (byte)bank, startIndex, (byte)leng, uDatabuf);
            if (result)
            {
                msg = "Write success";
            }
            else
            {
                msg = "Write failure";
            }
            frmWaitingBox f = new frmWaitingBox((obj, args) =>
            {
                System.Threading.Thread.Sleep(500);
            }, msg);
            f.ShowDialog(this);
        }


        private void btnQTRead_Click(object sender, EventArgs e)
        {
            if (!DetectionFiltration())
                return;

            string pws = txtQT_pwd.Text.Replace(" ", "");
            if (pws.Length != 8)
            {
                MessageBox.Show("The length of the password must be 8!");
                return;
            }

            int bank = cmbQT_bank.SelectedIndex;
            int startIndex = int.Parse(txtQT_ptr.Text);
            int leng = int.Parse(QT_Length.Text);
            byte[] uAccessPwd = DataConvert.HexStringToByteArray(pws);
            //----------------------------
            string filerData = txtFilter_EPC.Text.Replace(" ", "");
            int filerBank = 1;
            byte[] filerBuff = DataConvert.HexStringToByteArray(filerData);
            int filerPtr = int.Parse(txtPtr.Text);
            int filerLen = int.Parse(txtLen.Text);

            if ((filerLen / 8 + (filerLen % 8 == 0 ? 0 : 1)) * 2 > filerData.Length)
            {
                MessageBox.Show("filter data length error!"); //to do
                return;
            }
            if (rbTID.Checked)
                filerBank = 2;
            if (rbUser.Checked)
                filerBank = 3;
            //--------------------------------------

            int QTData = Convert.ToByte("000000" + cmbQT2.SelectedIndex + cmbQT1.SelectedIndex);
            string msg = "";
            txtQT_data.Text = "";
            //
            string data = UHFAPI.getInstance().ReadQT(uAccessPwd, (byte)filerBank, filerPtr, filerLen, filerBuff,
                (byte)QTData, (byte)bank, startIndex, (byte)leng);
            if (data != string.Empty)
            {
                txtQT_data.Text = data;
                msg = "  success";
            }
            else
            {
                msg = "  failure";
            }

            frmWaitingBox f = new frmWaitingBox((obj, args) =>
            {
                System.Threading.Thread.Sleep(500);
            }, msg);
            f.ShowDialog(this);
        }


        private void btnGetQT_Click(object sender, EventArgs e)
        {
            if (!DetectionFiltration())
                return;

            string pws = textBox1.Text.Replace(" ", "");
            if (pws.Length != 8)
            {
                MessageBox.Show("The length of the password must be 8!");
                return;
            }

            byte[] uAccessPwd = DataConvert.HexStringToByteArray(pws);
            //----------------------------
            string filerData = txtFilter_EPC.Text.Replace(" ", "");
            int filerBank = 1;
            byte[] filerBuff = DataConvert.HexStringToByteArray(filerData);
            int filerPtr = int.Parse(txtPtr.Text);
            int filerLen = int.Parse(txtLen.Text);

            if ((filerLen / 8 + (filerLen % 8 == 0 ? 0 : 1)) * 2 > filerData.Length)
            {
                MessageBox.Show("filter data length error!"); //to do
                return;
            }
            if (rbTID.Checked)
                filerBank = 2;
            if (rbUser.Checked)
                filerBank = 3;
            //--------------------------------------
            int time = 500;
            int QTData = Convert.ToByte("000000" + comboBox2.SelectedIndex + comboBox1.SelectedIndex);
            string msg = "";
            //QT
            byte qt_byte = 0;
            if (UHFAPI.getInstance().GetQT(uAccessPwd, (byte)filerBank, filerPtr, filerLen, filerBuff, ref qt_byte))
            {
                time = 100;
                msg = "  success";
                int b0 = ((qt_byte >> 0) & 0x1);
                int b1 = ((qt_byte >> 1) & 0x1);
                comboBox1.SelectedIndex = b0;
                comboBox2.SelectedIndex = b1;
            }
            else
            {
                msg ="  failure";
            }
            frmWaitingBox f = new frmWaitingBox((obj, args) =>
            {
                System.Threading.Thread.Sleep(time);
            }, msg);
            f.ShowDialog(this);
        }

        private void btnSetQT_Click(object sender, EventArgs e)
        {
            if (!DetectionFiltration())
                return;

            string pws = textBox1.Text.Replace(" ", "");
            if (pws.Length != 8)
            {
                MessageBox.Show("The length of the password must be 8!");
                return;
            }
 
            byte[] uAccessPwd = DataConvert.HexStringToByteArray(pws);
            //----------------------------
            string filerData = txtFilter_EPC.Text.Replace(" ", "");
            int filerBank = 1;
            byte[] filerBuff = DataConvert.HexStringToByteArray(filerData);
            int filerPtr = int.Parse(txtPtr.Text);
            int filerLen = int.Parse(txtLen.Text);

            if ((filerLen / 8 + (filerLen % 8 == 0 ? 0 : 1)) * 2 > filerData.Length)
            {
                MessageBox.Show("filter data length error!"); //to do
                return;
            }
            if (rbTID.Checked)
                filerBank = 2;
            if (rbUser.Checked)
                filerBank = 3;
            //--------------------------------------
            int time = 500;
            int QTData = Convert.ToByte("000000" + comboBox2.SelectedIndex + comboBox1.SelectedIndex);
            string msg = "";
             //QT
            if (UHFAPI.getInstance().SetQT(uAccessPwd, (byte)filerBank, filerPtr, filerLen, filerBuff, (byte)QTData))
            {
                time = 100;
                msg = "  success";  
            }
            else
            {
                msg =  "  failure";  
            }

            frmWaitingBox f = new frmWaitingBox((obj, args) =>
            {
                System.Threading.Thread.Sleep(time);
            }, msg);
            f.ShowDialog(this);
        }

        #endregion



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
                    txt.SelectionStart = SelectIndex+2; 
                //txt.Select(txt.Text.Length - 1, 0);
                
            }
        }
        private void FormatHex_PWD(TextBox txt)
        {
            if (isDelete) return;
            string data = txt.Text.Trim().Replace(" ", "");
            if (data != string.Empty)
            {
                if (data.Length > 8) {
                    data = data.Substring(0,8);
                }
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
        #region filter1
        private void btnFilterEPC_Click(object sender, EventArgs e)
        {
            string epc = "";
            string msg = "failure";
            if (UHFAPI.getInstance().InventorySingle(ref epc))
            {
                txtFilter_EPC.Text = epc;
                Common.tag = epc;
                msg = "success";
            }
           
            frmWaitingBox f = new frmWaitingBox((obj, args) =>
            {
                System.Threading.Thread.Sleep(500);
            }, msg);
            f.ShowDialog(this);
        }
        private void txtFilter_EPC_TextChanged(object sender, EventArgs e)
        {
            FormatHex(txtFilter_EPC);
            string data = txtFilter_EPC.Text.Replace(" ", "");
            if (data.Length > 0)
            {
                label29.Text = ((data.Length / 2) + ((data.Length % 2) == 0 ? 0 : 1)).ToString();  // txtRead_Length.Text = ((data.Length / 4) + ((data.Length % 4) == 0 ? 0 : 1)).ToString();
            }
            else
            {
                label29.Text = "0";
            }
        }

        public bool DetectionFiltration()
        {
            if (int.Parse(txtLen.Text) > 0)
            {
                string filerData = txtFilter_EPC.Text.Replace(" ", "");
                if (!StringUtils.IsHexNumber(filerData))
                {
                    MessageBox.Show("Please input the hex filter data!");
                    return false;
                }
            }
            return true;
        }
        private void rbEPC_Click(object sender, EventArgs e)
        {
            txtPtr.Text = "32";
        }

        private void rbTID_Click(object sender, EventArgs e)
        {
            txtPtr.Text = "0";
        }

        private void rbUser_Click(object sender, EventArgs e)
        {
            txtPtr.Text = "0";
        }
        #endregion

        private void txtPtr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPtr.Text == "")
                    return;
                string ptr = txtPtr.Text;
                if (!StringUtils.IsNumber(ptr))
                {
                    txtPtr.Text = "0";
                    return;
                }
 
            }
            catch (Exception ex)
            {
                txtPtr.Text = "0";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtLen.Text == "")
                    return;

                string ptr = txtLen.Text;
                if (!StringUtils.IsNumber(ptr))
                {
                    txtLen.Text = "0";
                    return;
                }

            }
            catch (Exception ex)
            {
                txtLen.Text = "0";
            }
        }

      


        void txt_LostFocus(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;

            if (text.Text == "")
            {
                text.Text = "0";
            }

          
     
        }

        bool isDelete = false;
        private void ReadWriteTagForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                isDelete = true;
            }
            else {
                isDelete = false;
            }

        }

 
     
 
    
      
      

     
      
 
   





















    }
}
