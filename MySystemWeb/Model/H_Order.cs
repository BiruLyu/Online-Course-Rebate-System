using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    /// <summary>
    /// H_Order:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class H_Order
    {
        public H_Order()
        { }
        #region Model
        private int _id;
        private string _order_number;
        private string _username;
        private int? _course_id;
        private DateTime? _create_time;
        private int? _isexam;
        private string _exam_handler;
        private DateTime? _exam_time;
        private int? _ispaystudent;
        private string _pay_stu_handler;
        private DateTime? _pay_stu_time;
        private int? _ispayclerk;
        private string _pay_cle_handler;
        private DateTime? _pay_cle_time;
        private int? _ispayservice;
        private DateTime? _pay_ser_time;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string order_number
        {
            set { _order_number = value; }
            get { return _order_number; }
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
        /// 课程id
        /// </summary>
        public int? course_id
        {
            set { _course_id = value; }
            get { return _course_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? create_time
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// 是否审核
        /// </summary>
        public int? isexam
        {
            set { _isexam = value; }
            get { return _isexam; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string exam_handler
        {
            set { _exam_handler = value; }
            get { return _exam_handler; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? exam_time
        {
            set { _exam_time = value; }
            get { return _exam_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ispaystudent
        {
            set { _ispaystudent = value; }
            get { return _ispaystudent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pay_stu_handler
        {
            set { _pay_stu_handler = value; }
            get { return _pay_stu_handler; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? pay_stu_time
        {
            set { _pay_stu_time = value; }
            get { return _pay_stu_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ispayclerk
        {
            set { _ispayclerk = value; }
            get { return _ispayclerk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pay_cle_handler
        {
            set { _pay_cle_handler = value; }
            get { return _pay_cle_handler; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? pay_cle_time
        {
            set { _pay_cle_time = value; }
            get { return _pay_cle_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ispayservice
        {
            set { _ispayservice = value; }
            get { return _ispayservice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? pay_ser_time
        {
            set { _pay_ser_time = value; }
            get { return _pay_ser_time; }
        }
        #endregion Model
    }
}