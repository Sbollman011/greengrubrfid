using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace UHFAPP
{
    public partial class WaitForm : Form
    {

        private static WaitForm loadingForm = null;
        public WaitForm() {
            InitializeComponent();
          
        }
     
        /// <summary>

        /// </summary>
        public static void ShowLoading()
        {
            try
            {
                Thread loadingTh = new Thread(new ThreadStart(delegate
                {
                    loadingForm = new WaitForm();
                    loadingForm.StartPosition = FormStartPosition.CenterParent;
                    Application.Run(loadingForm);
                    loadingForm.Dispose();
                    loadingForm = null;
                    loadingTh = null;
                }));
                loadingTh.IsBackground = true;
                loadingTh.Priority = ThreadPriority.Highest;
                loadingTh.Start();                 
            }
            catch
            { }
        }
        /// <summary>

        /// </summary>
        public static void HideLoading()
        {
            try
            {
                if (loadingForm != null)
                {
                    loadingForm.Invoke(new EventHandler(delegate
                    {
                        loadingForm.Close();
                    }));
                }
            }
            catch
            { }
        }
    }


}
