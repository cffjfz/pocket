using System;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace WareHouseModels
{
    [Serializable]
    public  class Category
    {

        private int _CategoryId;
        /// <summary>
        /// 
        /// </summary>
        public int CategoryId
        {
            get
            {
                return _CategoryId;
            }
            set
            {
                _CategoryId=value;
            }
        }

        private string _Name;
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name=value;
            }
        }

    }
}

