using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Android.App;
using Android.Content.Res;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Students.CustomAdapters;
using Students.Entities;
using Formatting = Newtonsoft.Json.Formatting;

namespace Students.App
{
    [Activity(Label = "Students.App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ListView listViewStudents;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

           listViewStudents = FindViewById<ListView>(Resource.Id.listViewStudents);

            GetStudenFromXml();
        }

        public  void GetStudenFromXml()
        {
            /* Opcion 1
           var  xml = XDocument.Load(Assets.Open("ListStudents.xml"));
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml.ToString());
            string jsonString = JsonConvert.SerializeXmlNode(doc);
            JObject response = JsonConvert.DeserializeObject<dynamic>(jsonString);
            var studentsString = response.Value<JObject>("Students");
            var array = (JArray)studentsString["Student"];
            var listStudents = JsonConvert.DeserializeObject<List<Student>>(array.ToString());
            */

            /*Opcion 2*/
            XmlSerializer serializer = new XmlSerializer(typeof(Entities.Students));
            var Studentlst = (Entities.Students)serializer.Deserialize(Assets.Open("ListStudents.xml"));


            listViewStudents.Adapter = new StudentsAdapter(this, Studentlst.StudentList, Resource.Layout.ListItem, Resource.Id.tvName,Resource.Id.tvLocation);

        }

    }
}

