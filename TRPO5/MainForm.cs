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
        public MainForm( string login )
        {
            InitializeComponent();


            // строка подключения к БД
            string connStr = "server=localhost;port=3306;username=root;password=root;database=учетдисциплин";
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = "SELECT groupStudent FROM users WHERE login = @login";


            // объект для выполнения SQL-запроса
           
            MySqlCommand command = new MySqlCommand(sql, conn);

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login; 


            // выполняем запрос и получаем ответ
            string nameGroup = command.ExecuteScalar().ToString();           // получили имя группы 
            // выводим ответ в консоль

            // закрываем соединение с БД
            conn.Close();

            //////////////////////////////////////////////////////////////////////////////////////////

           
            string connStr2 = "server=localhost;port=3306;username=root;password=root;database=schedulegroup";
          
            MySqlConnection conn2 = new MySqlConnection(connStr2);

           
            conn2.Open();

            string sql2 = "SELECT scheduleMonday , scheduleTuesday , scheduleWednesday , scheduleThursday , scheduleFriday , scheduleSunday FROM shedule WHERE nameGroup = @nameGroup";
            MySqlCommand command2 = new MySqlCommand(sql2, conn2);
           

            command2.Parameters.Add("@nameGroup", MySqlDbType.VarChar).Value = nameGroup;

            MySqlDataReader mySqlDataReader = command2.ExecuteReader();

           
            mySqlDataReader.Read();
           

            textBox1.Text = mySqlDataReader[0].ToString();
            textBox2.Text = mySqlDataReader[1].ToString();
            textBox3.Text = mySqlDataReader[2].ToString();
            textBox4.Text = mySqlDataReader[3].ToString();
            textBox5.Text = mySqlDataReader[4].ToString();
            textBox6.Text = mySqlDataReader[5].ToString();


            mySqlDataReader.Close();

            conn2.Close();




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
    }
}
