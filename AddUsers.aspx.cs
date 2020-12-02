using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
namespace DutyBot
{
    public partial class AddUsers : System.Web.UI.Page
    {
        
        private string QR = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // выбор таблицы Specialist
            QR = DBConnection.qrSpecialist;
            if (!IsPostBack)
            {
                gvFill(QR);

                FillDropLists1();
            }
        }
        // Нажатие кнопки "Выбрать"
        protected void gvAddUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAddUser.SelectedRow;
            tbSpecialist.Text = row.Cells[2].Text.ToString();
            tbPhone.Text = row.Cells[3].Text.ToString();
            tbSurname.Text = row.Cells[4].Text.ToString();
            tbName.Text = row.Cells[5].Text.ToString();
            tbMiddleName.Text = row.Cells[6].Text.ToString();


            lstDepartment.SelectedValue = row.Cells[7].Text;
            DBConnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }
        // Скрытие столбцов
        protected void gvAddUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[7].Visible = false;
            //e.Row.Cells[8].Visible = false;
        }
        // Сортировка
        protected void gvAddUser_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Должность"):
                    e.SortExpression = "[RankSpecialist]";
                    break;
                case ("Фамилия"):
                    e.SortExpression = "[Surname]";
                    break;
                case ("Телефон"):
                    e.SortExpression = "[Phone]";
                    break;

            }
            sortGridView(gvAddUser, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill(QR + " order by " + e.SortExpression + " " + strDirection);
        }

        private void sortGridView(GridView gridView,
         GridViewSortEventArgs e,
         out SortDirection sortDirection,
         out string strSortField)
        {
            strSortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null &&
                gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (strSortField ==
                    gridView.Attributes["CurrentSortField"])
                {
                    if (gridView.Attributes["CurrentSortDirection"]
                        == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }
            }
            gridView.Attributes["CurrentSortField"] = strSortField;
            gridView.Attributes["CurrentSortDirection"] =
                (sortDirection == SortDirection.Ascending ? "ASC"
                : "DESC");
        }
        // заполнение таблицы
        private void gvFill(string qr)
        {
            sdsSpecialist.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsSpecialist.SelectCommand = qr;
            sdsSpecialist.DataSourceMode = SqlDataSourceMode.DataReader;
            gvAddUser.DataSource = sdsSpecialist;
            gvAddUser.DataBind();

        }
        // заполнение выпадающего списка
        public void FillDropLists1()
        {
            sdsDepartment.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsDepartment.DataSourceMode = SqlDataSourceMode.DataReader;

        }
        // добавление данных
        protected void btInsert_Click(object sender, EventArgs e)
        {
            bool err = false;

            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tbSpecialist);
            textBoxes.Add(tbPhone);
            textBoxes.Add(tbName);
            textBoxes.Add(tbSurname);
            textBoxes.Add(tbMiddleName);

            if (!err)
            {
                SqlCommand command = new SqlCommand("", DBConnection.connection);


                int Department_ID = int.Parse(lstDepartment.SelectedValue);

                command.CommandText = "INSERT INTO [dbo].[Specialist] ([RankSpecialist],[Phone],[Surname],[Name],[MiddleName],[Department_ID]) values ('" + tbSpecialist.Text + "','" + tbPhone.Text + "','" + tbSurname.Text + "','" + tbName.Text + "','" + tbMiddleName.Text + "','" + lstDepartment.SelectedValue + "')";



                DBConnection.connection.Open();
                command.ExecuteNonQuery();
                DBConnection.connection.Close();
                Response.Redirect(Request.RawUrl);
                gvFill(QR);

            }
        }
        // Изменение данных
        protected void btUpdate_Click(object sender, EventArgs e)
        {
            switch (tbSpecialist.Text == "")
            {
                case (true):
                    tbSpecialist.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbSpecialist.BackColor = System.Drawing.Color.White;
                    switch (tbName.Text == "")
                    {
                        case (true):
                            tbName.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbName.BackColor = System.Drawing.Color.White;


                            SqlCommand command = new SqlCommand("", DBConnection.connection);
                            command.CommandText = "update [dbo].[Specialist] set " +
                                "[RankSpecialist] ='" + tbSpecialist.Text + "', " +
                                "[Phone] ='" + tbPhone.Text + "', " +
                                "[Surname] ='" + tbSurname.Text + "', " +
                                "[Name] ='" + tbName.Text + "', " +
                                "[MiddleName] ='" + tbMiddleName.Text + "', " +
                                "[Department_ID] ='" + lstDepartment.SelectedValue + "' " +
                                " where ID_Specialist = " + DBConnection.IDrecord + "";

                            DBConnection.connection.Open();
                            command.ExecuteNonQuery();
                            DBConnection.connection.Close();
                            gvFill(QR);
                            Response.Redirect(Request.RawUrl);
                            break;
                    }
                    break;
            }
        }
        // удаление данных из таблицы
        protected void btDelete_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", DBConnection.connection);
            command.CommandText = "delete from [dbo].[Specialist] " +
                "where ID_Specialist = " + DBConnection.IDrecord + "";
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
            gvFill(QR);
            Response.Redirect(Request.RawUrl);
        }
        // Поиск
        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvAddUser.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[3].Text.Equals(tbSearch.Text)
                    || row.Cells[4].Text.Equals(tbSearch.Text)
                    || row.Cells[5].Text.Equals(tbSearch.Text))
                    //|| row.Cells[10].Text.Equals(tbSearch.Text)
                    //|| row.Cells[13].Text.Equals(tbSearch.Text)
                    //|| row.Cells[16].Text.Equals(tbSearch.Text)
                    //|| row.Cells[19].Text.Equals(tbSearch.Text)
                    //|| row.Cells[13].Text.Equals(tbSearch.Text))
                    ////|| row.Cells[18].Text.Equals(tbSearch.Text))

                    row.BackColor = System.Drawing.Color.Green;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }
        // фильтрация данных
        protected void btFilter_Click(object sender, EventArgs e)
        {
            
            
                string newQr = QR + " where [RankSpecialist] like '%" + tbSearch.Text + "%' or " + "[Phone] like '%" + tbSearch.Text + "%' or " + "[NameDepartment] like '%" + tbSearch.Text + "%' or " + "[Surname] like '%" + tbSearch.Text + "%'";


                gvFill(newQr);
            
        }
        // отмена поиска/фильтрации
        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);



            gvAddUser.DataBind();
        }
        // Выход из вкладки в главное меню
        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }
    }    
}
