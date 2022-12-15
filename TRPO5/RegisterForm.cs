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
            InstituteComboBox_SelectedIndexChanged(this, null);
            CourseComboBox_SelectedIndexChanged(this, null);

           
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

            try
            {
                if (LoginTextBox.Text == "")
                {
                    MessageBox.Show("Укажите корректный логин!");
                    return;
                }

                if (PasswordTextBox.Text == "")
                {
                    MessageBox.Show("Введите пароль!");
                    return;
                }

                if (InstituteComboBox.Text == "Выберите институт")
                {
                    MessageBox.Show("Выберите институт!");
                    return;
                }

                if (CourseComboBox.Text == "Выберите курс")
                {
                    MessageBox.Show("Укажите курс!");
                    return;
                }

                if (GroupComboBox.Text == "Выберите группу")
                {
                    MessageBox.Show("Укажите группу!");
                    return;
                }

                if (checkUser())
                {

                    MessageBox.Show("Данный пользователь уже зарегистрирован!");
                    return;
                }

            }
            catch
            {
                string s = null;
                throw new ArgumentNullException(paramName: nameof(s), message: "Ошибка данных при регистрации (неизвестная ошибка )!");
            }
            DataBase dataBase = new DataBase();
            // вставка "формирование sql запроса "
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`id`, `login`, `password`, `Institute`," +
                " `courseStudent`, `groupStudent`) VALUES (NULL, @login, @password, @Institute, @Course, @Group);" , dataBase.GetConnection());

            command.Parameters.Add("@login" , MySqlDbType.VarChar).Value = LoginTextBox.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = PasswordTextBox.Text;
            command.Parameters.Add("@Institute", MySqlDbType.VarChar).Value = InstituteComboBox.Text;
            command.Parameters.Add("@Course", MySqlDbType.Int32).Value = CourseComboBox.Text;
            command.Parameters.Add("@Group", MySqlDbType.VarChar).Value = GroupComboBox.Text;

            dataBase.openConnection();

            if (command.ExecuteNonQuery() == 1 )
            {
                MessageBox.Show("Ваш аккаунт зарегистрирован !");
            }
            else MessageBox.Show("Аккаунт не был создан !");

            dataBase.closeConnection();
        }

        public Boolean checkUser ()
        {

            DataBase dataBase = new DataBase();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE " +

                "`login` = @admin",

           
                dataBase.GetConnection());





            command.Parameters.Add("@admin", MySqlDbType.VarChar).Value = LoginTextBox.Text; // переназначение заглушек 

            

            adapter.SelectCommand = command;



            adapter.Fill(table); // данные поместили в таблицу 




            if (table.Rows.Count > 0)
            {
               
                return true;
            }
            else return false;
        }

        private void InstituteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (numberInst)
            {
                InstituteComboBox.Items.Add("Институт компьютерных систем и информационной безопасности");
              
                InstituteComboBox.Items.Add("Институт нефти , газа и энергетики");
                InstituteComboBox.Items.Add("Институт пищевой и перерабатывающей промышленности");
                InstituteComboBox.Items.Add("Институт экономики , управления и бизнеса");
                InstituteComboBox.Items.Add("Институт строительства и транспортной инфраструктуры");
                InstituteComboBox.Items.Add("Институт механики , робототехники , инженерии транспортных и технических систем");
            }
            numberInst = false;



        }

        private void CourseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (numberCourse)
            {
                CourseComboBox.Items.Add("1");
                CourseComboBox.Items.Add("2");
                CourseComboBox.Items.Add("3");
                CourseComboBox.Items.Add("4");
            }
            GroupComboBox.Items.Clear();

            if (InstituteComboBox.Text == "Институт компьютерных систем и информационной безопасности") AddComboInstKB();
            if (InstituteComboBox.Text == "Институт нефти , газа и энергетики" ) AddComboInstNeft();

            if (InstituteComboBox.Text == "Институт пищевой и перерабатывающей промышленности") AddComboInstPisha();
            if (InstituteComboBox.Text == "Институт экономики , управления и бизнеса") AddComboInstBiznes();

            if (InstituteComboBox.Text == "Институт механики , робототехники , инженерии транспортных и технических систем") AddComboInstRobot();


            numberCourse = false;
        }

        private void AddComboInstKB()
        {
            if ( CourseComboBox.Text == "1")
            {

                GroupComboBox.Items.Add("22-КБ-ПР1");
                GroupComboBox.Items.Add("22-КБ-ПР2");
                GroupComboBox.Items.Add("22-КБ-ПР3");
                GroupComboBox.Items.Add("22-КБ-ПР4");
                GroupComboBox.Items.Add("22-КБ-ИБ1");
                GroupComboBox.Items.Add("22-КБ-ИБ2");
                GroupComboBox.Items.Add("22-КБ-ИБ3");
                GroupComboBox.Items.Add("22-КБ-ПИ1");
                GroupComboBox.Items.Add("22-КБ-ПИ2");
                GroupComboBox.Items.Add("22-КБ-ПИ3");
                GroupComboBox.Items.Add("22-КБ-УС1");
                GroupComboBox.Items.Add("22-КБ-УС2");
                GroupComboBox.Items.Add("22-КБ-УС3");
                GroupComboBox.Items.Add("22-КМ-ПИ1");
                GroupComboBox.Items.Add("22-КМ-ИВ2");
                GroupComboBox.Items.Add("22-КМ-ПР1");


            }
            if ( CourseComboBox.Text == "2")
            {
                GroupComboBox.Items.Add("21-КБ-ПР1");
                GroupComboBox.Items.Add("21-КБ-ПР2");
                GroupComboBox.Items.Add("21-КБ-ПР3");
                GroupComboBox.Items.Add("21-КБ-ИБ1");
                GroupComboBox.Items.Add("21-КБ-ИБ2");
                GroupComboBox.Items.Add("21-КБ-ИБ3");
                GroupComboBox.Items.Add("21-КБ-ПИ1");
                GroupComboBox.Items.Add("21-КБ-ПИ2");
                GroupComboBox.Items.Add("21-КБ-ПИ3");
                GroupComboBox.Items.Add("21-КБ-УС1");
                GroupComboBox.Items.Add("21-КМ-ПИ1");
                GroupComboBox.Items.Add("21-КМ-ИВ2");
                GroupComboBox.Items.Add("21-КМ-ПР1");


            }

            if (CourseComboBox.Text == "3")
            {
                GroupComboBox.Items.Add("20-КБ-ПР1");
                GroupComboBox.Items.Add("20-КБ-ПР2");

                GroupComboBox.Items.Add("20-КБ-ИБ1");

                GroupComboBox.Items.Add("20-КБ-ПИ1");

                GroupComboBox.Items.Add("20-КБ-УС1");

                GroupComboBox.Items.Add("20-КМ-ПИ1");
                GroupComboBox.Items.Add("20-КМ-ИВ2");
                GroupComboBox.Items.Add("20-КМ-ПР1");


            }
            if (CourseComboBox.Text == "4")
            {
                GroupComboBox.Items.Add("19-КБ-ПР1");

                GroupComboBox.Items.Add("19-КБ-ИБ1");

                GroupComboBox.Items.Add("19-КБ-ПИ1");

                GroupComboBox.Items.Add("19-КБ-УС1");

                GroupComboBox.Items.Add("19-КМ-ПР1");


            }
        }
        private void AddComboInstNeft()
        {
            if ( CourseComboBox.Text == "1")
            {

                GroupComboBox.Items.Add("22-АО-Г1");
                GroupComboBox.Items.Add("22-АО-Г2");
                GroupComboBox.Items.Add("22-АО-Г3");
                GroupComboBox.Items.Add("22-АО-Г4");
                GroupComboBox.Items.Add("22-АО-МС1");
                GroupComboBox.Items.Add("22-АО-МС2");
                GroupComboBox.Items.Add("22-АО-МС3");
                GroupComboBox.Items.Add("22-АО-ЭТД1");
                GroupComboBox.Items.Add("22-АО-ЭТД2");
                GroupComboBox.Items.Add("22-АО-ЭТД3");
                GroupComboBox.Items.Add("22-НБ-НД1");
                GroupComboBox.Items.Add("22-НБ-НД2");
                GroupComboBox.Items.Add("22-НБ-ТМ1");
                GroupComboBox.Items.Add("22-НБ-ТМ2");
                GroupComboBox.Items.Add("22-НБ-ТМ3");
                GroupComboBox.Items.Add("22-НБ-ХТ1");
                GroupComboBox.Items.Add("22-НБ-ХТ2");
                GroupComboBox.Items.Add("22-НБ-ХТ3");
                GroupComboBox.Items.Add("22-НБ-ХТ4");



            }
            if (CourseComboBox.Text == "2")
            {

                GroupComboBox.Items.Add("21-АО-Г1");
                GroupComboBox.Items.Add("21-АО-Г2");
                GroupComboBox.Items.Add("21-АО-Г3");
             
                GroupComboBox.Items.Add("21-АО-МС1");
                GroupComboBox.Items.Add("21-АО-МС2");
            
                GroupComboBox.Items.Add("21-АО-ЭТД1");
                GroupComboBox.Items.Add("21-АО-ЭТД2");
              
                GroupComboBox.Items.Add("21-НБ-НД1");
             
                GroupComboBox.Items.Add("21-НБ-ТМ1");
                GroupComboBox.Items.Add("21-НБ-ТМ2");
         
                GroupComboBox.Items.Add("21-НБ-ХТ1");
                GroupComboBox.Items.Add("21-НБ-ХТ2");
                GroupComboBox.Items.Add("21-НБ-ХТ3");
            


            }

            if (CourseComboBox.Text == "3")
            {
                GroupComboBox.Items.Add("20-АО-Г1");
                GroupComboBox.Items.Add("20-АО-Г2");
            

                GroupComboBox.Items.Add("20-АО-МС1");
              

                GroupComboBox.Items.Add("20-АО-ЭТД1");
                GroupComboBox.Items.Add("20-АО-ЭТД2");

                GroupComboBox.Items.Add("20-НБ-НД1");

                GroupComboBox.Items.Add("20-НБ-ТМ1");
            

                GroupComboBox.Items.Add("20-НБ-ХТ1");
                GroupComboBox.Items.Add("20-НБ-ХТ2");
                GroupComboBox.Items.Add("20-НБ-ХТ3");

            }
            if (CourseComboBox.Text == "4")
            {
                GroupComboBox.Items.Add("19-АО-Г1");
              


                GroupComboBox.Items.Add("19-АО-МС1");


                GroupComboBox.Items.Add("19-АО-ЭТД1");
            
                GroupComboBox.Items.Add("19-НБ-НД1");

                GroupComboBox.Items.Add("19-НБ-ТМ1");


                GroupComboBox.Items.Add("19-НБ-ХТ1");
             

            }
        }

        private void AddComboInstPisha()
        {
            if (CourseComboBox.Text == "1")
            {

                GroupComboBox.Items.Add("22-АО-НОЗ1");
                GroupComboBox.Items.Add("22-АО-НОЗ2");
                GroupComboBox.Items.Add("22-АО-НОЗ3");
                GroupComboBox.Items.Add("22-АО-ПЭ1");
                GroupComboBox.Items.Add("22-АО-ПЭ2");
                GroupComboBox.Items.Add("22-АО-ПЭ3");
                GroupComboBox.Items.Add("22-АО-ПЭ4");
                GroupComboBox.Items.Add("22-АО-ПЭ5");
                GroupComboBox.Items.Add("22-ПБ-ГД1");
                GroupComboBox.Items.Add("22-ПБ-ГД2"); 
                GroupComboBox.Items.Add("22-ПБ-ГД3");
                GroupComboBox.Items.Add("22-ПБ-ПЖ1");
                GroupComboBox.Items.Add("22-ПБ-ПЖ2");
                GroupComboBox.Items.Add("22-ПБ-ПЖ3");
                GroupComboBox.Items.Add("22-ПБ-ПР1");
                GroupComboBox.Items.Add("22-ПБ-ПР2");
                GroupComboBox.Items.Add("22-ПБ-ПР3");
                GroupComboBox.Items.Add("22-ПБ-ПР4");
                GroupComboBox.Items.Add("22-ПБ-СМ1");
                GroupComboBox.Items.Add("22-ПБ-СМ2");
                GroupComboBox.Items.Add("22-ПБ-СМ3");




            }
            if (CourseComboBox.Text == "2")
            {

                GroupComboBox.Items.Add("21-АО-НОЗ1");
                GroupComboBox.Items.Add("21-АО-НОЗ2");
                GroupComboBox.Items.Add("21-АО-ПЭ1");
                GroupComboBox.Items.Add("21-АО-ПЭ2");
                GroupComboBox.Items.Add("21-АО-ПЭ3");
                GroupComboBox.Items.Add("21-ПБ-ГД1");
                GroupComboBox.Items.Add("21-ПБ-ГД2");
                GroupComboBox.Items.Add("21-ПБ-ПЖ1");
                GroupComboBox.Items.Add("21-ПБ-ПЖ2");
                GroupComboBox.Items.Add("21-ПБ-ПР1");
                GroupComboBox.Items.Add("21-ПБ-ПР2");
                GroupComboBox.Items.Add("21-ПБ-СМ1");
                GroupComboBox.Items.Add("21-ПБ-СМ2");
              


            }

            if (CourseComboBox.Text == "3")
            {

                GroupComboBox.Items.Add("20-АО-НОЗ1");
                GroupComboBox.Items.Add("20-АО-ПЭ1");
                GroupComboBox.Items.Add("20-АО-ПЭ2");
                GroupComboBox.Items.Add("20-ПБ-ГД1");
                GroupComboBox.Items.Add("20-ПБ-ГД2");
                GroupComboBox.Items.Add("20-ПБ-ПЖ1");
                GroupComboBox.Items.Add("20-ПБ-ПР1");
                GroupComboBox.Items.Add("20-ПБ-ПР2");
                GroupComboBox.Items.Add("20-ПБ-СМ1");


            }
            if (CourseComboBox.Text == "4")
            {
                GroupComboBox.Items.Add("19-АО-НОЗ1");
                GroupComboBox.Items.Add("19-АО-ПЭ1");
                GroupComboBox.Items.Add("19-АО-ПЭ2");
                GroupComboBox.Items.Add("19-ПБ-ГД1");
                GroupComboBox.Items.Add("19-ПБ-ГД2");
                GroupComboBox.Items.Add("19-ПБ-ПЖ1");
                GroupComboBox.Items.Add("19-ПБ-ПР1");
                GroupComboBox.Items.Add("19-ПБ-ПР2");
              


            }
        }
        private void AddComboInstBiznes()
        {
            if (CourseComboBox.Text == "1")
            {

                GroupComboBox.Items.Add("22-АО-Г1");
                GroupComboBox.Items.Add("22-АО-Г2");
                GroupComboBox.Items.Add("22-АО-Г3");
                GroupComboBox.Items.Add("22-АО-Г4");
                GroupComboBox.Items.Add("22-ЭБ-ГУ1");
                GroupComboBox.Items.Add("22-ЭБ-ГУ2");
                GroupComboBox.Items.Add("22-ЭБ-ГУ3");
                GroupComboBox.Items.Add("22-ЭБ-ГУ4");
                GroupComboBox.Items.Add("22-ЭБ-МН1");
                GroupComboBox.Items.Add("22-ЭБ-МН2");
                GroupComboBox.Items.Add("22-ЭБ-МН3");
                GroupComboBox.Items.Add("22-ЭБ-МН4");
                GroupComboBox.Items.Add("22-ЭМ-ЭК1");
                GroupComboBox.Items.Add("22-ЭМ-ЭК2");
                GroupComboBox.Items.Add("22-ЭМ-ЭК3");
                GroupComboBox.Items.Add("22-ЭМ-ЭК4");




            }
            if (CourseComboBox.Text == "2")
            {


                GroupComboBox.Items.Add("21-АО-Г1");
                GroupComboBox.Items.Add("21-АО-Г2");
                GroupComboBox.Items.Add("21-АО-Г3");
                GroupComboBox.Items.Add("21-ЭБ-ГУ1");
                GroupComboBox.Items.Add("21-ЭБ-ГУ2");
                GroupComboBox.Items.Add("21-ЭБ-ГУ3");
                GroupComboBox.Items.Add("21-ЭБ-МН1");
                GroupComboBox.Items.Add("21-ЭБ-МН2");
                GroupComboBox.Items.Add("21-ЭБ-МН3");
                GroupComboBox.Items.Add("21-ЭБ-МН4");
                GroupComboBox.Items.Add("21-ЭМ-ЭК1");
                GroupComboBox.Items.Add("21-ЭМ-ЭК2");
              



            }

            if (CourseComboBox.Text == "3")
            {

                GroupComboBox.Items.Add("20-АО-Г1");
                GroupComboBox.Items.Add("20-АО-Г2");
                GroupComboBox.Items.Add("20-ЭБ-ГУ1");
                GroupComboBox.Items.Add("20-ЭБ-ГУ2");
                GroupComboBox.Items.Add("20-ЭБ-МН1");
                GroupComboBox.Items.Add("20-ЭБ-МН2");
                GroupComboBox.Items.Add("20-ЭБ-МН4");
                GroupComboBox.Items.Add("20-ЭМ-ЭК1");


            }
            if (CourseComboBox.Text == "4")
            {
                GroupComboBox.Items.Add("19-АО-Г1");
                GroupComboBox.Items.Add("19-АО-Г2");
                GroupComboBox.Items.Add("19-ЭБ-ГУ1");
                GroupComboBox.Items.Add("19-ЭБ-ГУ2");
                GroupComboBox.Items.Add("19-ЭБ-МН1");
                GroupComboBox.Items.Add("19-ЭБ-МН2");
                GroupComboBox.Items.Add("19-ЭБ-МН4");
                GroupComboBox.Items.Add("19-ЭМ-ЭК1");


            }
        }
        private void AddComboInstRobot()
        {
            if (CourseComboBox.Text == "1")
            {

                GroupComboBox.Items.Add("22-АО-Г1");
                GroupComboBox.Items.Add("22-АО-Г2");
                GroupComboBox.Items.Add("22-АО-Г3");
                GroupComboBox.Items.Add("22-АО-Г4");
                GroupComboBox.Items.Add("22-АО-МС1");
                GroupComboBox.Items.Add("22-АО-МС2");
                GroupComboBox.Items.Add("22-АО-МС3");
                GroupComboBox.Items.Add("22-ММ-ЭТД1");
                GroupComboBox.Items.Add("22-ММ-ЭТД2");
                GroupComboBox.Items.Add("22-ММ-ЭТД3");
                GroupComboBox.Items.Add("22-НБ-НД1");
                GroupComboBox.Items.Add("22-НБ-НД2");
                GroupComboBox.Items.Add("22-М-ТМ1");
                GroupComboBox.Items.Add("22-М-ТМ2");
                GroupComboBox.Items.Add("22-М-ТМ3");
                GroupComboBox.Items.Add("22-М-ХТ1");
                GroupComboBox.Items.Add("22-М-ХТ2");
                GroupComboBox.Items.Add("22-М-ХТ3");
                GroupComboBox.Items.Add("22-М-ХТ4");



            }
            if (CourseComboBox.Text == "2")
            {

                GroupComboBox.Items.Add("21-АО-Г1");
                GroupComboBox.Items.Add("21-АО-Г2");
                GroupComboBox.Items.Add("21-АО-Г3");
                GroupComboBox.Items.Add("21-АО-МС1");
                GroupComboBox.Items.Add("21-АО-МС2");
                GroupComboBox.Items.Add("21-ММ-ЭТД1");
                GroupComboBox.Items.Add("21-ММ-ЭТД2");
                GroupComboBox.Items.Add("21-НБ-НД1");
                GroupComboBox.Items.Add("21-НБ-НД2");
                GroupComboBox.Items.Add("21-М-ТМ1");
                GroupComboBox.Items.Add("21-М-ТМ2");
                GroupComboBox.Items.Add("21-М-ХТ1");
                GroupComboBox.Items.Add("21-М-ХТ2");
 



            }

            if (CourseComboBox.Text == "3")
            {

                GroupComboBox.Items.Add("20-АО-Г1");
                GroupComboBox.Items.Add("20-АО-Г2");
                GroupComboBox.Items.Add("20-АО-Г3");
                GroupComboBox.Items.Add("20-ММ-ЭТД1");
                GroupComboBox.Items.Add("20-ММ-ЭТД2");
                GroupComboBox.Items.Add("20-НБ-НД1");
                GroupComboBox.Items.Add("20-М-ТМ1");
                GroupComboBox.Items.Add("20-М-ТМ2");



            }
            if (CourseComboBox.Text == "4")
            {
                GroupComboBox.Items.Add("19-АО-Г1");
                GroupComboBox.Items.Add("19-АО-Г2");
                GroupComboBox.Items.Add("19-ММ-ЭТД1");
                GroupComboBox.Items.Add("19-НБ-НД1");
                GroupComboBox.Items.Add("19-М-ТМ1");
                GroupComboBox.Items.Add("19-М-ТМ2");


            }
        }
        private void GroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           


        }
    }
}
