using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class View_Members : Form
    {            
        string wanted_path;
        DialogResult result;
        string pwd = Encryptor.GetRandomPassword(20);

        public View_Members()
        {
            InitializeComponent();
        }

        private void View_Members_Load(object sender, EventArgs e)
        {
            fillGrid();         
        }

        public void fillGrid(string def = "select * from \"Members_Info\"")
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            int i = 0;

            MemberModel memberModel = new MemberModel();
            DataTable dataTable = memberModel.getCmd(def);
            dataGridView1.DataSource = dataTable;

            Bitmap img;
            DataGridViewImageColumn imageCol1 = new DataGridViewImageColumn();
            imageCol1.Width = 500;
            imageCol1.HeaderText = "ID_Card";
            imageCol1.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imageCol1.Width = 100;
            dataGridView1.Columns.Add(imageCol1);


            foreach (DataRow dataRow in dataTable.Rows)
            {
                img = new Bitmap(@"..\..\" + dataRow["ID_Card"].ToString());
                dataGridView1.Rows[i].Cells[5].Value = img;
                dataGridView1.Rows[i].Height = 100;
                i++;
            }
        } 

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            fillGrid("select * from \"Members_Info\" where \"Name\" like('%" + textBox1.Text + "%')");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            MemberModel memberModel = new MemberModel();
            memberModel.pullById(i);

            Name.Text = memberModel.Name;
            Email.Text = memberModel.Email;
            Contact.Text = memberModel.Contact;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            result = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG files (*.jpeg)|*.jpeg|PNG FIles (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            if (result == DialogResult.OK)
            {               
                string img_path;
                File.Copy(openFileDialog1.FileName, wanted_path + "\\ID_Card\\" + pwd + ".jpg");
                img_path = "ID_Card\\" + pwd + ".jpg";

                MemberModel memberModel = new MemberModel(i, Name.Text, Email.Text, Contact.Text);
                memberModel.update(img_path);

                fillGrid();
                MessageBox.Show("Record Updated Successfully");
            }
            else if(result == DialogResult.Cancel)
            {
                MemberModel memberModel = new MemberModel(i, Name.Text, Email.Text, Contact.Text);
                memberModel.update();
                fillGrid();
                MessageBox.Show("Record Updated Successfully");
            }
            else
            {
                MemberModel memberModel = new MemberModel(i, Name.Text, Email.Text, Contact.Text);
                memberModel.update();
                fillGrid();
                MessageBox.Show("Record Updated Successfully");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                MemberModel memberModel = new MemberModel();
                memberModel.deleteById(i);
                fillGrid();
                MessageBox.Show("Record Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                throw;
            }
        }
    }
}
