using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// H_Service:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class H_Service
    {
        public H_Service()
        { }
        #region Model
        private int _id;
        private string _username;
        private string _name;
        private string _telephone;
        private string _TeamViewerID;
        private string _zhifubao;
        private string _bank;
        private string _bankname;
        private string _banknumber;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 工作人员用户名
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 工作人员姓名
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string telephone
        {
            set { _telephone = value; }
            get { return _telephone; }
        }
        /// <summary>
        /// TeamViewerID
        /// </summary>
        public string TeamViewerID
        {
            set { _TeamViewerID = value; }
            get { return _TeamViewerID; }
        }
        /// <summary>
        /// 支付宝
        /// </summary>
        public string zhifubao
        {
            set { _zhifubao = value; }
            get { return _zhifubao; }
        }
        /// <summary>
        /// 开户银行详细营业网点
        /// </summary>
        public string bank
        {
            set { _bank = value; }
            get { return _bank; }
        }
        /// <summary>
        /// 开户名
        /// </summary>
        public string bankname
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string banknumber
        {
            set { _banknumber = value; }
            get { return _banknumber; }
        }
        #endregion Model

    }
}
