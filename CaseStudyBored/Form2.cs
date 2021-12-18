using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CaseStudyBored
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {

            
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
           
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Favourite activity";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
            for (int i = 0; i < Form1.activity.favouriteList.Count; i++)  // output:
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = Form1.activity.favouriteList[i];
                





                dataGridView1.Rows.Add(row);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Comic Sans MS", 10);
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
