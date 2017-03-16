using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NBarcodeApi;
using System.Runtime.InteropServices;
using util;
using SalesPoint.Device.Scan;
using System.Threading;
namespace demo
{
    public partial class Form1 : Form
    {
        private Thread scanThread;
        //private delegate void invokeSetScanedData(string data);
        //private delegate void invokeSetScanedData2(barCodeInfoBean bean);
        public Form1()
        {
            BARCODE_RESULT res;
            InitializeComponent();
            this.KeyPreview = true;//很重要,启用控件内容
            barcode = new BarcodeApi();
            res=barcode.Open();
            //if (res != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            //{
            //    MessageBox.Show(res.ToString());
            //    btnScan.Enabled = false;
            //    button2.Enabled = false;
            //    return;
            //}
           
        }
        //List<string> ls = new List<string>();
        void BarcodeAppCallBack()
        {
            this.btnScan.Text = "Scan";
            string Value = new string(new char[512]);
            string SymName = new string(new char[512]);
            string SymType = new string(new char[2]);
            barcode.GetBarcodeData(ref Value, ref SymName, ref SymType);
            this.textBox1.Text += Value;
            Value = Value.Substring(0, Value.IndexOf("\0"));
            string sql = string.Format("insert into barcode values('{0}') ",Value);
            DataBase data = new DataBase();
            data.RunSql(sql);
            Value = null;   
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if (e.KeyValue == 256)
            {
                button1_Click(null,null);
            }
            
            if ((e.KeyCode == System.Windows.Forms.Keys.F9))
            {
                BARCODE_RESULT res;

                if (this.btnScan.Text == "Scan")
                {
                    // Barcode scanning is started
                    res = barcode.Start();

                    //=============================================================
                    // if barcode Barcode scanning is successfully started to return to
                    // BARCODE_RESULT_SUCCESS.
                    if (res == BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                    {
                        this.btnScan.Text = "Stop";
                        barcode.SetCallback(new BarcodeApi.BARCODECALLBACK(BarcodeAppCallBack));
                    }

                    else
                        MessageBox.Show(res.ToString());
                }
                else
                {
                    // Barcode scanning is stoppend.
                    res = barcode.Stop();             //对象为空报错

                    //=============================================================
                    // Barcode scanning operation should return to normal
                    // BARCODE_RESULT_SUCCESS is interrupted.

                    if (res == BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                        this.btnScan.Text = "Scan";
                    else
                        MessageBox.Show(res.ToString());
                }
           
            }

        }

        BarcodeApi barcode;
        private void button1_Click(object sender, EventArgs e)
        {
            BARCODE_RESULT res;
            
            if (this.btnScan.Text == "Scan")
            {
                // Barcode scanning is started
                res = barcode.Start();

                //=============================================================
                // if barcode Barcode scanning is successfully started to return to
                // BARCODE_RESULT_SUCCESS.
                if (res == BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                {
                    this.btnScan.Text = "Stop";
                    barcode.SetCallback(new BarcodeApi.BARCODECALLBACK(BarcodeAppCallBack));
                }
                    
                else
                    MessageBox.Show(res.ToString());
            }
            else
            {
                // Barcode scanning is stoppend.
                res = barcode.Stop();             //对象为空报错

                //=============================================================
                // Barcode scanning operation should return to normal
                // BARCODE_RESULT_SUCCESS is interrupted.

                if (res == BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                    this.btnScan.Text = "Scan";
                else
                    MessageBox.Show(res.ToString());
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text="";
        }

        protected virtual void Scan()
        {
            
            
            BARCODE_RESULT res;

            if (this.btnScan.Text == "Scan")
            {
                // Barcode scanning is started
                res = barcode.Start();

                //=============================================================
                // if barcode Barcode scanning is successfully started to return to
                // BARCODE_RESULT_SUCCESS.
                if (res == BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                {
                    this.btnScan.Text = "Stop";
                    barcode.SetCallback(new BarcodeApi.BARCODECALLBACK(BarcodeAppCallBack));
                }

                else
                    MessageBox.Show(res.ToString());
            }
            else
            {
                // Barcode scanning is stoppend.
                res = barcode.Stop();             //对象为空报错

                //=============================================================
                // Barcode scanning operation should return to normal
                // BARCODE_RESULT_SUCCESS is interrupted.

                if (res == BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                    this.btnScan.Text = "Scan";
                else
                    MessageBox.Show(res.ToString());
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyValue)
            {
                case KeyValue.Key_F2:   //F2按键
                    
                    break;
                case KeyValue.Key_F3:   //F3按键
                    //KeyDownF3();
                    break;
                case KeyValue.Key_F4:   //F4按键
                    //KeyDownF4();
                    break;
                case KeyValue.Key_Home:   //Home按键
                    //KeyDownHome();
                    break;
                case KeyValue.Key_OK:   //F5按键
                    //KeyDownOK();
                    break;
                case KeyValue.Key_Gun1:   //Scan按键
                    
                    MessageBox.Show( Scanner.StartScan());
                    button1_Click(null,null);
                    break;
                case KeyValue.Key_Gun2:   //Scan按键

                    MessageBox.Show(Scanner.StartScan());
                    button1_Click(null, null);
                    break;
                case KeyValue.Key_R:
                    //CloseWindown();
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            MessageBox.Show(Scanner.StartScan());
        }

        private void ClInTaskDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 256)
            {
                MessageBox.Show("进来了");
                //开始线程 连续扫描条码
                if (scanThread == null)
                {
                    
                    scanThread.IsBackground = true;
                    scanThread.Start();
                }
            }
        }

    }
}