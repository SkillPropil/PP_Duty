using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace DutyBot
{
    public partial class Authorization : System.Web.UI.Page
    {
        // Проверяем соединение к базе данных
        protected void Page_Load(object sender, EventArgs e)
        {
            checkConnection();
        }
        // функция проверки соединения к БД
        public static bool checkConnection()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-A2PIL339\LYSYISERVER");
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex) { return false; }
    
        }
         // кнопка "Вход"
        protected void btEnter_Click(object sender, EventArgs e)
        {
            // Открываем соединение и вызываем функцию входа
            DBConnection connection = new DBConnection();
            connection.dbEnter(tbLogin.Text, tbPassword.Text);

            // проверка на данные
            switch (DBConnection.IDuser)
            {
                case (0):
                    tbLogin.BackColor = System.Drawing.Color.Red;
                    tbPassword.BackColor = System.Drawing.Color.Red;

                    lblTitle.Text = "Введён не верный логин или пароль!";
                    tbPassword.Text = "";
                    tbLogin.Text = "";
                    break;
                default:
                    Response.Redirect("MainMenu.aspx");
                    break;
            }
        }

        
    }
}