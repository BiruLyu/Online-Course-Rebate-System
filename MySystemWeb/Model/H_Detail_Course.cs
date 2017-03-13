using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    /// <summary>
    /// H_Detail_Course:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class H_Detail_Course
    {
        public H_Detail_Course()
        { }
        #region Model
        private int _id;
        private int? _subordinate_course_id;
        private string _course_name;
        private double? _course_ori_price;
        private double? _course_sel_price;
        private double? _course_pur_price;
        private double? _student_share;
        private double? _clerk_share;
        private double? _service_share;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public int? subordinate_course_id
        {
            set { _subordinate_course_id = value; }
            get { return _subordinate_course_id; }
        }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string course_name
        {
            set { _course_name = value; }
            get { return _course_name; }
        }
        /// <summary>
        /// 课程原价
        /// </summary>
        public double? course_ori_price
        {
            set { _course_ori_price = value; }
            get { return _course_ori_price; }
        }
        /// <summary>
        /// 课程售价
        /// </summary>
        public double? course_sel_price
        {
            set { _course_sel_price = value; }
            get { return _course_sel_price; }
        }
        /// <summary>
        /// 课程进价
        /// </summary>
        public double? course_pur_price
        {
            set { _course_pur_price = value; }
            get { return _course_pur_price; }
        }
        /// <summary>
        /// 学员分成
        /// </summary>
        public double? student_share
        {
            set { _student_share = value; }
            get { return _student_share; }
        }
        /// <summary>
        /// 职员分成
        /// </summary>
        public double? clerk_share
        {
            set { _clerk_share = value; }
            get { return _clerk_share; }
        }
        /// <summary>
        /// 工作人员分成
        /// </summary>
        public double? service_share
        {
            set { _service_share = value; }
            get { return _service_share; }
        }
        #endregion Model

    }
}
