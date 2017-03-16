using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WareHouseModels;
using Main.util;
using NBarcodeApi;
using System.Collections;
using NRfidApi;
using System.Threading;

namespace Main
{
    public partial class FrmAdd : Form
    {

        public FrmAdd()
        {
            BARCODE_RESULT res;
            InitializeComponent();

            this.KeyPreview = true;
            initRfid();
            barcode = new BarcodeApi();
            res = barcode.Open();
        }

        ArrayList Tags;//用来接收读取的RFID
        RfidApi rfid;
        DataBase data = new DataBase();
        private void FrmAdd_Load(object sender, EventArgs e)
        {
            
        }

        BarcodeApi barcode;
       static int itemsCount = 0;//用来计算录入多少件
        int sid = 0;//用来接收sid
        public void BarcodeAppCallBack()
        {
            this.btnBarcode.Text = "Scan";
            string Value = new string(new char[512]);
            string SymName = new string(new char[512]);
            string SymType = new string(new char[2]);
            barcode.GetBarcodeData(ref Value, ref SymName, ref SymType);
            this.txtBarcode.Text += Value;
            Value = Value.Substring(0, Value.IndexOf("\0"));
            string sql = string.Format("select * from goodsInfo where barcode= '{0}' ", Value);
            DataBase data = new DataBase();
            DataTable dt = data.Query(sql);
            GoodsInfo gi = new GoodsInfo();
            //判断输入的rfid码是否有效
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("输入的二维码/条形码无效");
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                gi.Sname = dt.Rows[i][1].ToString();
                gi.Number = Convert.ToInt32(dt.Rows[i][8]);
                gi.Specification = dt.Rows[i][6].ToString();
                gi.Remark = dt.Rows[i][10].ToString();
                gi.RFID = dt.Rows[i][3].ToString();
                //判断是否有rfid
                if (gi.RFID == null || gi.RFID.Equals(""))
                {
                    MessageBox.Show("请匹配一个rfid标签，再提交入库");
                }
                else
                {
                    this.txtRfid.Text = gi.RFID;
                    ListViewItem li = new ListViewItem(gi.Sname);
                    li.SubItems.Add(gi.Number.ToString());
                    li.SubItems.Add(gi.Specification.ToString());
                    li.SubItems.Add(gi.Remark);
                    li.SubItems.Add(gi.RFID);
                    lvInfo.Items.Insert(0, li);//新加的一行排在最前面
                    this.lblCount.Text=(++itemsCount).ToString();
                    
                }
            }
            Value = null;
        }

        #region rfid初始化
        public void initRfid()
        {
            this.KeyPreview = true;
            Tags = new ArrayList();
            rfid = new RfidApi();
            rfid.PowerOn();
            if (rfid.Open() == RFID_RESULT.RFID_RESULT_SUCCESS)
            {
                rfid.PowerLevel = (uint)20;//设置天线功率//这里是降序的
            }
            else
            {
                rfid.PowerOff();
                MessageBox.Show("RFID Open Failed");
            }
        }
        #endregion

        #region rfid回调方法
        // Callback function registered by the application,应用程序注册的回调函数，
        public void CallbackProc(RFIDCALLBACKDATA CallbackData)
        {
            string Msg = new string(new char[512]);
            // Data GetResult function and read the values  告过程的分离。
            rfid.GetResult(Msg, CallbackData.CallbackType, CallbackData.wParam, CallbackData.lParam);
            Msg = Msg.Substring(0, Msg.IndexOf("\0"));
            if (this.txtRfid.Text != null && !this.txtRfid.Text.Equals("")&&Msg.Length>5)
            {
                if (Msg.Substring(0, 4).Equals("3000"))//3000e4110000
                {
                    Msg = Msg.Substring(4);
                }
            }
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
                ////
                //MessageBox.Show(Msg);
                    this.txtRfid.Text = Msg;
                    string sql = string.Format("update  GoodsInfo set RFID='{0}' where barcode='{1}' ", Msg, this.txtBarcode.Text);
                    int num = data.RunSql(sql);
                    if (num > 0)
                    {
                        MessageBox.Show("匹配成功，请重新扫描二维码进行导入");
                    }
                    Tags.Add(Msg);

                }
            }
            // Run from the command module to receive the results of running Callback delegate.
            else if (Type == RFID_CALLBACK_TYPE.RFIDCALLBACKTYPE_REPLY)
            {
                if (Msg.Equals("OK") || Msg.Equals("Multi Read Stop") || Msg.Equals(""))
                {
                    this.btnRfid.Text = "Start";
                }
                else
                {
                    MessageBox.Show(Msg);
                    btnRfid.Text = "Start";
                }
            }
        }
        #endregion

        private void txtRfid_TextChanged(object sender, EventArgs e)
        {
            if (this.txtRfid.Text == null || this.txtRfid.Text.Equals(""))
            {
                this.btnRfid.Enabled = true;
            }
            else
            {
                this.btnRfid.Enabled = false;
                
            }
        }

        private void btnBarcode_Click_1(object sender, EventArgs e)
        {
            BARCODE_RESULT res;
            //先把输入框的值清空
            if (this.txtBarcode.Text != null || this.txtBarcode.Text != "")
            {
                this.txtBarcode.Text = "";
                this.txtRfid.Text = "";
            }
            if (this.btnBarcode.Text == "Scan")
            {
                res = barcode.Start();

                if (res == BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                {
                    this.btnBarcode.Text = "Stop";
                    barcode.SetCallback(new BarcodeApi.BARCODECALLBACK(BarcodeAppCallBack));
                }

                else
                    MessageBox.Show(res.ToString());
            }
            else
            {
                // Barcode scanning is stoppend.
                res = barcode.Stop();             //对象为空报错
                if (res == BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                    this.btnBarcode.Text = "Scan";
                else
                    MessageBox.Show(res.ToString());
            }
        }

        private void btnRfid_Click_1(object sender, EventArgs e)
        {
            // Tag reading on the type of tag(ISO-1800-6B or ISO-18000-6C[GEN2]) can be read by specifying a UID.
            RFID_READ_TYPE ReadType;

            if (this.btnRfid.Text.Equals("Start"))
            {
                rfid.SetCallback(new RfidCallbackProc(CallbackProc));
                btnRfid.Text = "Stop";
                ReadType = RFID_READ_TYPE.EPC_GEN2_MULTI_TAG;
                // RFID tag reads from the EPC data. RFID标签读取EPC数据。
                rfid.ReadEpc(false, ReadType, String.Empty);

            }
            else
            {
                rfid.Stop();
            }
        }
        //提交
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        #region 根据rfid获取sid
        public int GetSidByRfid(string ss)
        {
            List<int> nums = new List<int>();
            string sql =string.Format( " select sid from goodsInfo where rfid='{0}'",ss);
            DataTable dt = data.Query(sql);
            foreach (DataRow dr in dt.Rows)
            {
                nums.Add(Convert.ToInt32(dr["sid"]));
            }
            return nums[0];
        }
        #endregion

        private void lvInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////lvInfo.SelectedIndexCollection c = lvInfo.SelectedIndices;
            if (lvInfo.SelectedIndices.Count > 0)
            {
                string ss = null;
                if (lvInfo.SelectedIndices != null && lvInfo.SelectedIndices.Count > 0)
                {
                    ListView.SelectedIndexCollection c = lvInfo.SelectedIndices;
                    ss = lvInfo.Items[c[0]].Text;
                    string s1 = lvInfo.Items[c[0]].SubItems[1].Text;
                    string s2 = lvInfo.Items[c[0]].SubItems[2].Text;
                    string s3 = lvInfo.Items[c[0]].SubItems[3].Text;
                    //ss = lstwlview.Items[c[0]].SubItems[1].Text;// 表示选中行的第二列
                    MessageBox.Show("名称：" + " " + ss + "\r\n" + "数量：" + " " + s1 + "\r\n" + "型号：" + " " + s2 + "\r\n" + "备注：" + " " + s3 + "\r\n");
                }
            }
           
        }

        private void FrmAdd_KeyDown(object sender, KeyEventArgs e)
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
                rfid.Stop();
                barcode.Stop();
                rfid.PowerOff();
                itemsCount = 0;//计数清0
                FrmFunction ff = new FrmFunction();
                ff.Show();
                this.Close();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.F9))
            {
                btnRfid_Click_1(null, null);
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.F19))
            {
                //if (this.txtBarcode.Text == null || this.txtBarcode.Text != null && this.txtRfid.Text != null)
                //{
                //    btnBarcode_Click_1(null, null);
                //}
                //else if (this.txtBarcode.Text != null && this.txtRfid.Text == null)
                //{
                //    btnRfid_Click_1(null, null);
                //}
                btnBarcode_Click_1(null, null);
            }
        }

        protected virtual void Scan() 
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < lvInfo.Items.Count; i++)
            {
                ListViewItem item = lvInfo.Items[i];

                string rfid = item.SubItems[4].Text.ToString();

                sid = GetSidByRfid(rfid);
                string sql = string.Format("insert into addgoods values ('{0}','{1}','{2}','{3}')", DateTime.Now.ToString(), sid, 1, Form1.userName);
                int result = data.RunSql(sql);
                if (result > 0)
                {
                    count++;
                }
            }
            MessageBox.Show("共提交" + count + "条数据");
            lvInfo.Items.Clear();
            itemsCount = 0;
            this.lblCount.Text = itemsCount.ToString();
            //MessageBox.Show(lvInfo.Items[0].SubItems[4].Text.ToString());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}