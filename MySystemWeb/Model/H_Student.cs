using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// H_Student:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class H_Student
    {
        public H_Student()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _username;
        private string _email;
        private string _telphone;
        private string _zhifubao;
        private string _bank;
        private string _bank_name;
        private string _bank_num;
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
        /// 姓名
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// Email
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string telphone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// 支付宝账号
        /// </summary>
        public string zhifubao
        {
            set { _zhifubao = value; }
            get { return _zhifubao; }
        }
        /// <summary>
        /// 开户银行具体网点
        /// </summary>
        public string bank
        {
            set { _bank = value; }
            get { return _bank; }
        }
        /// <summary>
        /// 户名
        /// </summary>
        public string bank_name
        {
            set { _bank_name = value; }
            get { return _bank_name; }
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string bank_num
        {
            set { _bank_num = value; }
            get { return _bank_num; }
        }
        /// <summary>
        /// 地区省
        /// </summary>
        public string region_province
        {
            set { _region_province = value; }
            get { return _region_province; }
        }
        /// <summary>
        /// 地区市
        /// </summary>
        public string region_city
        {
            set { _region_city = value; }
            get { return _region_city; }
        }
        /// <summary>
        /// 地区县
        /// </summary>
        public string region_county
        {
            set { _region_county = value; }
            get { return _region_county; }
        }
        #endregion Model

    }
}
