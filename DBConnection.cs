using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows;
using System.Net;

namespace DutyBot
{
    public class DBConnection
    {

        public static string connectionString = @"Data Source=LAPTOP-A2PIL339\LYSYISERVER; Initial Catalog=DutyBot;Integrated Security=True;" +
            @"Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            @"ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection connection = new SqlConnection(connectionString);
        public DataTable dtAuthorization = new DataTable("Authorization");
        public DataTable dtRole = new DataTable("Role");
        public DataTable dtDuty = new DataTable("Duty");
        public DataTable dtIncident = new DataTable("Incident");
        public DataTable dtDepartment = new DataTable("Department");
        public DataTable dtSpecialist = new DataTable("Specialist");

        public static string qrDepartment = "SELECT " +
         "[ID_Department], " +
         "[NameDepartment], " +
         "[Senior] " +
         "FROM [dbo].[Department]  ",

        qrSpecialist = "SELECT " +
          "[ID_Specialist], " +
          "[RankSpecialist] as \"Должность\", " +
          "[Phone] as \"Номер телефона\", " +
          "[Surname] as \"Фамилия\", " +
          "[Name] as \"Имя\", " +
          "[MiddleName] as \"Отчество\", " +
          "[Department_ID] " +
          "FROM [dbo].[Specialist] " +
          "INNER JOIN [dbo].[Department] ON [ID_Department] = [Department_ID] ",

        qrDuty = "SELECT " +
         "[ID_Duty], " +
         "[StartWork], " +
         "[StopWork], " +
         "[Surname], " +
         "[Specialist_ID] " +
         "FROM [dbo].[Duty]  " +
         "INNER JOIN [dbo].[Specialist] ON [ID_Specialist] = [Specialist_ID] " ,

        qrRole = "SELECT " +
         "[ID_Role], " +
         "[AddWork], " +
         "[EditWork] " +
         "[Duty_ID] " +
         "FROM [dbo].[Role]  " +
         "INNER JOIN [dbo].[Duty] ON [ID_Duty] = [Duty_ID] ",

        qrAuthorization = "SELECT " +
          "[ID_Authorization], " +
          "[Login], " +
          "[Password], " +
          "[Role_ID] " +
          "FROM [dbo].[Authorization]  " +
          "INNER JOIN [dbo].[Role] ON [ID_Role] = [Role_ID] ",

        qrWork = "SELECT" +
         "[ID_Duty], " +
         "[Surname] as \"Фамилия\", [Name] as \"Имя\", [MiddleName] as \"Отчество\", " +
         "[Phone] as \"Номер телефона\", " +
         "[StartWork] as \"Начало смены\", " +
         "[StopWork] as \"Конец смены\", " +
         "[Specialist_ID] " +
         "FROM [dbo].[Duty]" +
         "INNER JOIN [dbo].[Specialist] ON [ID_Specialist] = [Specialist_ID] ";


        private SqlCommand command = new SqlCommand("", connection);
        public static Int32 IDrecord, IDuser;

        public void dbEnter(string login, string password)
        {
            command.CommandText = "SELECT count(*) FROM [dbo].[Authorization]" +
                "where [Login] = '" + login + "' and [Password] = '" +
                password + "'";
            connection.Open();
            IDuser = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
        }



        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }

        public Int32 Authorization(string User_Login, string User_Password)
        {
            Int32 ID_record = 0;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select [dbo].[Authorization]('"
                + User_Login + "','" + User_Password + "')";
            DBConnection.connection.Open();
            ID_record = Convert.ToInt32(command.ExecuteScalar().ToString());
            DBConnection.connection.Close();
            return (ID_record);
        }


    }
}