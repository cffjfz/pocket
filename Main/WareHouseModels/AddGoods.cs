using System;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace WareHouseModels
{
    [Serializable]
    public  class AddGoods
    {

        private int _Rid;
        /// <summary>
        /// 
        /// </summary>
        public int Rid
        {
            get
            {
                return _Rid;
            }
            set
            {
                _Rid=value;
            }
        }

        private DateTime _Date;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date=value;
            }
        }

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

        private string _Yid;
        /// <summary>
        /// 
        /// </summary>
        public string Yid
        {
            get
            {
                return _Yid;
            }
            set
            {
                _Yid=value;
            }
        }

    }
}

