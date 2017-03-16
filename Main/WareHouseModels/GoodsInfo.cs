using System;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace WareHouseModels
{
    [Serializable]
    public  class GoodsInfo
    {

        private int _Sid;
        /// <summary>
        /// 
        /// </summary>
        public int Sid
        {
            get
            {
                return _Sid;
            }
            set
            {
                _Sid=value;
            }
        }

        private string _Sname;
        /// <summary>
        /// 
        /// </summary>
        public string Sname
        {
            get
            {
                return _Sname;
            }
            set
            {
                _Sname=value;
            }
        }

        private string _Version;
        /// <summary>
        /// 
        /// </summary>
        public string Version
        {
            get
            {
                return _Version;
            }
            set
            {
                _Version=value;
            }
        }

        private string _RFID;
        /// <summary>
        /// 
        /// </summary>
        public string RFID
        {
            get
            {
                return _RFID;
            }
            set
            {
                _RFID=value;
            }
        }

        private string _Barcode;
        /// <summary>
        /// 
        /// </summary>
        public string Barcode
        {
            get
            {
                return _Barcode;
            }
            set
            {
                _Barcode=value;
            }
        }

        private string _Qrcode;
        /// <summary>
        /// 
        /// </summary>
        public string Qrcode
        {
            get
            {
                return _Qrcode;
            }
            set
            {
                _Qrcode=value;
            }
        }

        private string _Specification;
        /// <summary>
        /// 
        /// </summary>
        public string Specification
        {
            get
            {
                return _Specification;
            }
            set
            {
                _Specification=value;
            }
        }

        private int _CateGoryId;
        /// <summary>
        /// 
        /// </summary>
        public int CateGoryId
        {
            get
            {
                return _CateGoryId;
            }
            set
            {
                _CateGoryId=value;
            }
        }

        private int _Number;
        /// <summary>
        /// 
        /// </summary>
        public int Number
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number=value;
            }
        }

        private string _Company;
        /// <summary>
        /// 
        /// </summary>
        public string Company
        {
            get
            {
                return _Company;
            }
            set
            {
                _Company=value;
            }
        }

        private string _Remark;
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark=value;
            }
        }

    }
}

