using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TRPO5
{
    public partial class MainForm : Form
    {
     
        public MainForm(  )
        {
            InitializeComponent();


            //// строка подключения к БД
            //string connStr = "server=localhost;port=3306;username=root;password=root;database=учетдисциплин";
            //// создаём объект для подключения к БД
            //MySqlConnection conn = new MySqlConnection(connStr);
            //// устанавливаем соединение с БД
            //conn.Open();
            //// запрос
            //string sql = "SELECT groupStudent FROM users WHERE login = @login";


            //// объект для выполнения SQL-запроса

            //MySqlCommand command = new MySqlCommand(sql, conn);

            //command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login; 


            //// выполняем запрос и получаем ответ
            //string nameGroup = command.ExecuteScalar().ToString();           // получили имя группы 
            //// выводим ответ в консоль

            //// закрываем соединение с БД
            //conn.Close();

            ////////////////////////////////////////////////////////////////////////////////////////////

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

                    table.Rows.Add(reader[0], reader[1], reader[2], reader[3] );

                }
                reader.Close();

                label10.Text = it.ToString(); // ИТ
                label11.Text = os.ToString(); // ОС
                label12.Text = inz.ToString(); // ин яз
                label13.Text = asd.ToString(); // асд
                label14.Text = ma.ToString(); // матан

            }

            comboBox1.Items.Add("Операционные системы");
            comboBox1.Items.Add("Иностранный язык");
            comboBox1.Items.Add("Информационные технологии");
            comboBox1.Items.Add("Математический анализ");
            comboBox1.Items.Add("Алгоритмы и структуры данных");

            DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
            uninstallButtonColumn.Name = "Удалить";
            //uninstallButtonColumn.Text = "Удалить";
            int columnIndex = 4;
            dataGridView1.DataSource = table;
            dataGridView1.Columns.Add(uninstallButtonColumn);

            dataGridView1.DataSource = table;


            dataGridView1.CellClick += dataGridViewSoftware_CellClick;

            conn2.Close();

          




        }
        private void dataGridViewSoftware_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Удалить"].Index)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                
            }
          

        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // понедельник 

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //  вторник  
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // среда
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // четверг
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // пятница 
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // суббота 
        }

       

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            string discipline = comboBox1.Text;

            double sredniBal = Convert.ToDouble (textBox2.Text);

            int count = 0;
         //   MessageBox.Show (dataGridView1.RowCount.ToString());

           for ( int i = 0; i < dataGridView1.RowCount - 1; i++ )
           {



                //MessageBox.Show("зашел");
                if (dataGridView1[3 , i].Value.ToString() == discipline && 
                    Convert.ToDouble(dataGridView1[4, i].Value.ToString()) > sredniBal) count++;
                //MessageBox.Show(dataGridView1[4, i].Value.ToString() + " " + sredniBal + " count " + count.ToString() );
               

            }


            label16.Text = count.ToString();



        }

        private void button2_Click(object sender, EventArgs e)
        {


            double sredniBal = Convert.ToDouble ( textBox1.Text);



            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {


                //MessageBox.Show(dataGridView1[2, i].Value.ToString() + " " + dataGridView1[3, i].Value.ToString());

                if (  Convert.ToDouble(dataGridView1[4, i].Value.ToString()) < sredniBal) dataGridView1.Rows.RemoveAt(i);

               
            }

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {


                //MessageBox.Show(dataGridView1[2, i].Value.ToString() + " " + dataGridView1[3, i].Value.ToString());

                if (Convert.ToDouble(dataGridView1[4, i].Value.ToString()) < sredniBal) dataGridView1.Rows.RemoveAt(i);


            }

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {


                //MessageBox.Show(dataGridView1[2, i].Value.ToString() + " " + dataGridView1[3, i].Value.ToString());

                if (Convert.ToDouble(dataGridView1[4, i].Value.ToString()) < sredniBal) dataGridView1.Rows.RemoveAt(i);


            }


        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Form1 form1 = new Form1();
            //form1.Show();

            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
    }
}
