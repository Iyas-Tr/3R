using System;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    
    public partial class Add_Members : Form
    {
        private string wanted_path;
        private string pwd = Encryptor.GetRandomPassword(20);

        public Add_Members()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            DialogResult result = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG files (*.jpeg)|*.jpeg|PNG FIles (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            
            if(result == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string img_path;
                File.Copy(openFileDialog1.FileName, wanted_path + "\\ID_Card\\" + pwd + ".jpg");
                img_path = "ID_Card\\" + pwd + ".jpg";

                MemberModel memberModel = new MemberModel(textBox1.Text, img_path, textBox3.Text, textBox4.Text);
                memberModel.push();
                
                MessageBox.Show("Record Inserted Successfully");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                throw;
            }
        }

        private void Add_Members_Load(object sender, EventArgs e)
        {

        }
    }
}
