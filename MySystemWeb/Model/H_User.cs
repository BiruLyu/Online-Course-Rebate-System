using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// H_User:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class H_User
    {
        public H_User()
        { }
        #region Model
        private int _id;
        private string _username;
        private string _password;
        private int? _qxid;
        private int? _isoccupy;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
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
        /// 密码
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 权限id
        /// </summary>
        public int? qxid
        {
            set { _qxid = value; }
            get { return _qxid; }
        }
        public int? isoccupy
        {
            set { _isoccupy = value; }
            get { return _isoccupy; }
        }
        #endregion Model

    }
}
