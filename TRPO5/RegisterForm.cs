using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRPO5
{
    public partial class RegisterForm : Form
    {
        static bool numberInst = true;
        static bool numberCourse = true;

        public RegisterForm()
        {
            InitializeComponent();

            DataTable table = new DataTable();

            table.Columns.Add("Фамилия", typeof(string));
            table.Columns.Add("Группа", typeof(string));
            table.Columns.Add("Выбранный предмет", typeof(string));
            table.Columns.Add("Средний бал успеваемости", typeof(double));

            //table.Columns.Add("Удаление", typeof(double));

            string connStr2 = "server=localhost;port=3306;username=root;password=root;database=учетдисциплин";

            MySqlConnection conn2 = new MySqlConnection(connStr2);


            conn2.Open();

            string sql2 = "SELECT Surname , groupStudent ,selectDiscipline, averageScore FROM users";
            MySqlCommand command2 = new MySqlCommand(sql2, conn2);


            //MySqlDataReader mySqlDataReader = command2.ExecuteReader();


            int os = 0; //Операционные системы
            int inz = 0; //Иностранный язык
            int it = 0; //Информационные технологии

            int ma = 0; //Математический анализ
            int asd = 0; //Алгоритмы и структуры данных



            using (MySqlDataReader reader = command2.ExecuteReader())
            {
                while (reader.Read())
                {
                    //MessageBox.Show(String.Format("{0}", reader[0]));
                    //MessageBox.Show(String.Format("{0}", reader[1]));

                    //     Student student = new Student(reader[0], reader[1], reader[2], reader[3]);

                    if (String.Format("{0}", reader[2]) == "Операционные системы") os++;
                    if (String.Format("{0}", reader[2]) == "Иностранный язык") inz++;
                    if (String.Format("{0}", reader[2]) == "Информационные технологии") it++;
                    if (String.Format("{0}", reader[2]) == "Математический анализ") ma++;
                    if (String.Format("{0}", reader[2]) == "Алгоритмы и структуры данных") asd++;

                    table.Rows.Add(reader[0], reader[1], reader[2], reader[3]);

                }
                reader.Close();

                //label10.Text = it.ToString(); // ИТ
                //label11.Text = os.ToString(); // ОС
                //label12.Text = inz.ToString(); // ин яз
                //label13.Text = asd.ToString(); // асд
                //label14.Text = ma.ToString(); // матан

            }
            DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
            uninstallButtonColumn.Name = "Удалить";
            //uninstallButtonColumn.Text = "Удалить";
            int columnIndex = 4;
            dataGridView1.DataSource = table;
            dataGridView1.Columns.Add(uninstallButtonColumn);

            dataGridView1.DataSource = table;


            dataGridView1.CellClick += dataGridViewSoftware_CellClick;

            comboBox1.Items.Add("Операционные системы");
            comboBox1.Items.Add("Иностранный язык");
            comboBox1.Items.Add("Информационные технологии");
            comboBox1.Items.Add("Математический анализ");
            comboBox1.Items.Add("Алгоритмы и структуры данных");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void dataGridViewSoftware_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Удалить"].Index)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

            }


        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogins_Click(object sender, EventArgs e)
        {

        }

        
        private void GroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           


        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Form1 form1 = new Form1();
            //form1.Show();

            //RegisterForm registerForm = new RegisterForm();
            //registerForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Form1 form1 = new Form1();
            //form1.Show();

            MainForm main = new MainForm();
            main.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string discipline = comboBox1.Text;

       

            int count = 0;
            //   MessageBox.Show (dataGridView1.RowCount.ToString());

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {


                
               // MessageBox.Show(dataGridView1[2, i].Value.ToString());
                if (dataGridView1[3, i].Value.ToString() != discipline ) dataGridView1.Rows.RemoveAt(i);


            }
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {



                //MessageBox.Show(dataGridView1[2, i].Value.ToString());
                if (dataGridView1[3, i].Value.ToString() != discipline) dataGridView1.Rows.RemoveAt(i);


            }
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {



                //MessageBox.Show(dataGridView1[2, i].Value.ToString());
                if (dataGridView1[3, i].Value.ToString() != discipline) dataGridView1.Rows.RemoveAt(i);


            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
