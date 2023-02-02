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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
          

        }

   

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            String login = LoginTextBox.Text;



            String password = PasswordTextBox.Text;



            DataBase dataBase = new DataBase();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE " +

                "`login` = @admin AND `password` = @12345" ,

                //"`numberDisciplines` = @12 AND" +
                //"`Institute` = @Институт компьютерных систем и информационной безопасности AND " +
                //"`courseStudent` = @2 AND " +
                //"`groupStudent` = @21-КБ-ПР3",

                dataBase.GetConnection());





            command.Parameters.Add("@admin", MySqlDbType.VarChar).Value = login; // переназначение заглушек 

            command.Parameters.Add("@12345", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;



            adapter.Fill(table); // данные поместили в таблицу 




            if (table.Rows.Count > 0)
            {
              

                this.Hide();

                //MainForm mainForm = new MainForm(login);
                //mainForm.Show();



            }
            else MessageBox.Show("Пользователь не найден !");
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
    }
}
