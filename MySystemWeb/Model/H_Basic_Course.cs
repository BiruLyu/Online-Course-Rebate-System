using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// H_Basic_Course:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class H_Basic_Course
    {
        public H_Basic_Course()
        { }
        #region Model
        private int _id;
        private string _basiccourse;
        private string _province;
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
        public string basiccourse
        {
            set { _basiccourse = value; }
            get { return _basiccourse; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string province
        {
            set { _province = value; }
            get { return _province; }
        }
        #endregion Model

    }
}
