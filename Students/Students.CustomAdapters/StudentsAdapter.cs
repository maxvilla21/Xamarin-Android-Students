using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Views;
using Android.Widget;
using Students.Entities;

namespace Students.CustomAdapters
{
    public class StudentsAdapter : BaseAdapter<Student>
    {
        List<Student> Items;
        Activity Context; 
        int ItemLayoutTemplate;

        int StudentNameId;
        int StudentLocationId;



        public StudentsAdapter(Activity context, List<Student> students, int itemLayoutTemplate, int studentNameId, int studentLocationId)
        {
            this.Context = context;
            this.Items = students;
            this.ItemLayoutTemplate = itemLayoutTemplate;

            this.StudentNameId = studentNameId;
            this.StudentLocationId = studentLocationId;
        }

        public override long GetItemId(int position)
        {
            return Items[position].ID;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // Obtenemos el elemento del cual se requiere la Vista
            var Item = Items[position];
            View ItemView; // Vista que vamos a devolver
            if (convertView == null)
            {
                ItemView = Context.LayoutInflater.Inflate(ItemLayoutTemplate, null /* No hay View padre*/);
            }
            else
            {
                ItemView = convertView;
            }

            // Establecemos los datos del elemento dentro del View
            ItemView.FindViewById<TextView>(StudentNameId).Text = Item.Name;
            ItemView.FindViewById<TextView>(StudentLocationId).Text = Item.Location;
            return ItemView;
        }

        public override int Count
        {
            get
            {
                return Items.Count;
            }
        }

        public override Student this[int position]
        {
            get
            {
                return Items[position];
            }
        }
    }
}
