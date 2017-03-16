using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NRfidApi;
using System.Collections;

namespace demo2
{
    public partial class Form1 : Form
    {
        ArrayList Tags;
        RfidApi rfid;
        public Form1()
        {
            InitializeComponent();
            initRfid();
            
        }
        public void initRfid()
        {
            this.KeyPreview = true;
            Tags = new ArrayList();
            rfid = new RfidApi();
            // RFID reader module to apply power to. 
            rfid.PowerOn();

            // RFID reader module for communication with the port is open.
            if (rfid.Open() == RFID_RESULT.RFID_RESULT_SUCCESS)
            {
                //===============================================================================
                //  RFID reader tag data read by the application at the end to register 
                // callback fuction is called.
                rfid.PowerLevel = (uint)10;//设置天线功率

            }
            else
            {
                //  RFID reader module to an authorized power is removed.
                rfid.PowerOff();
                MessageBox.Show("RFID Open Failed");

                this.Close();
            }
        }
        // Callback function registered by the application,应用程序注册的回调函数，
        public void CallbackProc(RFIDCALLBACKDATA CallbackData)
        {
            string Msg = new string(new char[512]);

            // Data GetResult function and read the values  告过程的分离。
            rfid.GetResult(Msg, CallbackData.CallbackType, CallbackData.wParam, CallbackData.lParam);
            Msg = Msg.Substring(0, Msg.IndexOf("\0"));
            InventoryProc(Msg, CallbackData.CallbackType);
                    
               
        }
        public void InventoryProc(string Msg, RFID_CALLBACK_TYPE Type)
        {
            // Memory modules of the Data from the tags and read through it runs so Callback delegate.
            //从标签的数据的内存模块，并通过它读取运行，所以回调委托。
            if (Type == RFID_CALLBACK_TYPE.RFIDCALLBACKTYPE_DATA)
            {
                if (Tags.Contains(Msg))//如果是相同数据
                {
                    
                }
                else
                {
                    this.textBox1.Text = Msg;
                    Tags.Add(Msg);
                  
                }
            }
            // Run from the command module to receive the results of running Callback delegate.
            else if (Type == RFID_CALLBACK_TYPE.RFIDCALLBACKTYPE_REPLY)
            {
                if (Msg.Equals("OK") || Msg.Equals("Multi Read Stop") || Msg.Equals(""))
                {
                    button1.Text = "Start";
                }
                else
                {
                    MessageBox.Show(Msg);
                    button1.Text = "Start";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tag reading on the type of tag(ISO-1800-6B or ISO-18000-6C[GEN2]) can be read by specifying a UID.
            RFID_READ_TYPE ReadType;

            if (button1.Text.Equals("Start"))
            {
                rfid.SetCallback(new RfidCallbackProc(CallbackProc));
                button1.Text = "Stop";
                ReadType = RFID_READ_TYPE.EPC_GEN2_MULTI_TAG;
                // RFID tag reads from the EPC data. RFID标签读取EPC数据。
                rfid.ReadEpc(false, ReadType, String.Empty);
            }
            else
            {
                rfid.Stop();
            }
        }
    }
}