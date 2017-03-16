using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NBarcodeApi;
using System.Windows.Forms;

namespace Main.util
{
    class UtilBaecode
    {
        public string be = null;
        public void initBarcode()
        {
            BARCODE_RESULT res;
            barcode = new BarcodeApi();
            res = barcode.Open();
        }
        public void BarcodeAppCallBack()
        {
            string Value = new string(new char[512]);//条形码
            string SymName = new string(new char[512]);
            string SymType = new string(new char[2]);
            barcode.GetBarcodeData(ref Value, ref SymName, ref SymType);
            Value = Value.Substring(0, Value.IndexOf("\0"));
            be = Value;
            Value = null;
        }

        BarcodeApi barcode;
        public void GetBarcode(string ss)
        {
            BARCODE_RESULT res;
            if (ss == "Scan")
            {
                // Barcode scanning is started
                res = barcode.Start();

                //=============================================================
                // if barcode Barcode scanning is successfully started to return to
                // BARCODE_RESULT_SUCCESS.
                if (res == BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                {
                    ss = "Stop";
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
                    ss = "Scan";
                else
                    MessageBox.Show(res.ToString());
            }
        }
    }
}
