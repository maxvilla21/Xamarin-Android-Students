using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Students.Entities
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
