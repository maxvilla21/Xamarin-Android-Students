using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Students.Entities
{
    [XmlRoot("Students")]
    public  class Students
    {
        [XmlElement("Student", typeof(Student))]
        public List<Student> StudentList { get; set; }
    }
}