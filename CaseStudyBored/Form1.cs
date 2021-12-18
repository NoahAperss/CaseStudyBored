using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace CaseStudyBored
{
    public partial class Form1 : Form
    {
      public static Activity activity = new Activity();
     
        
       
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
           
            //Ophalen en omzetten data van de api
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://www.boredapi.com/api/activity/"));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            var model = JsonConvert.DeserializeObject<Activity>(jsonString);
                        



        //Maken dategridview
        dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Activity";
            dataGridView1.Columns[1].Name = "Type";
            dataGridView1.Columns[2].Name = "Participants";
            dataGridView1.Columns[3].Name = "Price";
            
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            //Toevoegen rows
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = model.activity;
            row.Cells[1].Value = model.type;
            row.Cells[2].Value = model.participants + " participants";
           
            if(model.price == 0)
            {
                row.Cells[3].Value = "Free";
            }

            if (model.price > 0 && model.price < 0.5) 
            {
                row.Cells[3].Value = "cheap";
            }

            if (model.price > 0.5 && model.price < 1)
            {
                row.Cells[3].Value = "mediumly cheap";
            }

            if (model.price > 1)
            {
                row.Cells[3].Value = "Expensive";
            }






            dataGridView1.Rows.Add(row);
            this.dataGridView1.DefaultCellStyle.Font = new Font("Comic Sans MS", 10);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
          



            Form1.activity.activity = model.activity;
            Form1.activity.type = model.type;
            Form1.activity.participants = model.participants;
            Form1.activity.price = model.price;














        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            FavouriteActivity favourite = new FavouriteActivity(Form1.activity.activity, Form1.activity.type, Form1.activity.participants, Form1.activity.price);

            
            Form1.activity.favouriteList.Add(activity.activity);
            
            Debug.WriteLine(Form1.activity.favouriteList.Count);
            






        }

        private void button3_Click(object sender, EventArgs e)
        {

            var m = new Form2();
            
            m.Show();
        }

        
    }
}
