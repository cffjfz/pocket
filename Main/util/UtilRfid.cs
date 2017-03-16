using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using NRfidApi;
using System.Windows.Forms;

namespace Main.util
{
    class UtilRfid
    {
      public  List<string> Tags;
        RfidApi rfid;
        public void initRfid()
        {
            Tags = new List<string>();
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
        string _RFID = "";//rfid值
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
                    _RFID = Msg;
                    Tags.Add(Msg);

                }
            }
            //// Run from the command module to receive the results of running Callback delegate.
            //else if (Type == RFID_CALLBACK_TYPE.RFIDCALLBACKTYPE_REPLY)
            //{
            //    if (Msg.Equals("OK") || Msg.Equals("Multi Read Stop") || Msg.Equals(""))
            //    {
            //        btnText = "Start";
            //    }
            //    else
            //    {
            //        MessageBox.Show(Msg);
            //        btnText = "Start";
            //    }
            //}
        }

        public void getRfid(string ss)
        {
            RFID_READ_TYPE ReadType;

            if (ss.Equals("Start"))
            {
                rfid.SetCallback(new RfidCallbackProc(CallbackProc));
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
