using System;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace WareHouseModels
{
    [Serializable]
    public  class User
    {

        private int _id;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id=value;
            }
        }

        private string _UserName;
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName=value;
            }
        }

        private string _PassWord;
        /// <summary>
        /// 
        /// </summary>
        public string PassWord
        {
            get
            {
                return _PassWord;
            }
            set
            {
                _PassWord=value;
            }
        }

    }
}

