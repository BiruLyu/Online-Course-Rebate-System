using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// H_Attendance:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class H_Attendance
    {
        public H_Attendance()
        { }
        #region Model
        private int _id;
        private string _username;
        private DateTime? _attendance_time;
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
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? attendance_time
        {
            set { _attendance_time = value; }
            get { return _attendance_time; }
        }
        #endregion Model

    }
}
