using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// H_Clerk:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class H_Clerk
    {
        public H_Clerk()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _username;
        private string _TeamViewerID;
        private string _phone;
        private string _telphone;
        private string _zhifubao;
        private string _bank_region;
        private string _bank_name;
        private string _bank_number;
        private string _region_province;
        private string _region_city;
        private string _region_county;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TeamViewerID
        {
            set { _TeamViewerID = value; }
            get { return _TeamViewerID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string telphone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zhifubao
        {
            set { _zhifubao = value; }
            get { return _zhifubao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bank_region
        {
            set { _bank_region = value; }
            get { return _bank_region; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bank_name
        {
            set { _bank_name = value; }
            get { return _bank_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bank_number
        {
            set { _bank_number = value; }
            get { return _bank_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string region_province
        {
            set { _region_province = value; }
            get { return _region_province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string region_city
        {
            set { _region_city = value; }
            get { return _region_city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string region_county
        {
            set { _region_county = value; }
            get { return _region_county; }
        }
        #endregion Model

    }
}
