using Bai1.EmployeeModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1
{
    public partial class Form1 : Form
    {

        HoTenDBEntities db = new HoTenDBEntities();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void lbDiaChi_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        public void loadDataGridView()
        {
            dataGridView1.DataSource = getData();
        }

        private List<Employee> getData()
        {
            return db.Employees.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void loadCombobox()
        {
            var empTypeList = db.EmpTypes.ToList();
            comboBox1.DataSource = empTypeList;
            comboBox1.DisplayMember = "TypeName";
            comboBox1.ValueMember = "TypeId";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadCombobox();
            loadDataGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbName.Text = dataGridView1.Rows[e.RowIndex].Cells["Cl1"].Value.ToString();
            tbDC.Text = dataGridView1.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            tbPB.Text = dataGridView1.Rows[e.RowIndex].Cells["Department"].Value.ToString();
            string gender = dataGridView1.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
            if(gender== "True")
            {
                radioMale.Checked =true;
            }else
            {
                radioFemale.Checked = true;
            }
         
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["EmployeeType"].Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }
    }
}
