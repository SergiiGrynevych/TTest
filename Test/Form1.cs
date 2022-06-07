using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Test.Model;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            NameTB.Text = "Lokal:";
            Filter.LoadDataFromDB();
            gridControl1.DataSource = Filter.historyExports.Select(m => new { m.name, m.dateTime, m.time, m.userName, m.cellName} );
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
            if (NameTB.Text == string.Empty || dateTimePicker1.Text == string.Empty || dateTimePicker1.Text == " " || dateTimePicker1.Text == string.Empty && dateTimePicker2.Text == " ")
            {
                MessageBox.Show("All fields must be filled", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Filter.historyExports.Clear();
                Filter.GetDataFromDBByFilter(NameTB.Text, dateTimePicker1.Text, dateTimePicker2.Text);
                gridControl1.DataSource = Filter.historyExports.Select(m => new { m.name, m.dateTime, m.time, m.userName, m.cellName });
            }
        }
        private void DeleteTextFromNameTB(object sender, EventArgs e)
        {
            NameTB.Text = string.Empty;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
        }
    }
}
