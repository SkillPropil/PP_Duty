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
    public partial class Registration : System.Web.UI.Page
    {
        private string QR = "";
        // при загрузке страницы заполняется таблицы и выпадающий список
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrAuthorization;
            if (!IsPostBack)
            {
                gvFill(QR);

                FillDropLists1();
            }

        }
        // по нажатию кнопки "выбор" просходит заполнение выбранных данных в текстовые поля и выпадающие списки
        protected void gvAddUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAddUser.SelectedRow;
            tbLogin.Text = row.Cells[2].Text.ToString();
            tbPassword.Text = row.Cells[3].Text.ToString();
       

            lstRole.SelectedValue = row.Cells[4].Text;
            DBConnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }
        // скрытие строк
        protected void gvAddUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            //e.Row.Cells[5].Visible = false;
        }
        // сортировка
        protected void gvAddUser_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Роль"):
                    e.SortExpression = "[RoleName]";
                    break;
                case ("Логин"):
                    e.SortExpression = "[Login]";
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
        // функция заполнения таблицы
        private void gvFill(string qr)
        {
            sdsAuthorization.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsAuthorization.SelectCommand = qr;
            sdsAuthorization.DataSourceMode = SqlDataSourceMode.DataReader;
            gvAddUser.DataSource = sdsAuthorization;
            gvAddUser.DataBind();

        }
        // функция заполнения выпадающего листа
        public void FillDropLists1()
        {
            sdsRole.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsRole.DataSourceMode = SqlDataSourceMode.DataReader;

        }
        // функция добавления данных
        protected void btInsert_Click(object sender, EventArgs e)
        {
            bool err = false;

            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tbLogin);
            textBoxes.Add(tbLogin);
            

            if (!err)
            {
                SqlCommand command = new SqlCommand("", DBConnection.connection);


                int Role_ID = int.Parse(lstRole.SelectedValue);

                command.CommandText = "INSERT INTO [dbo].[Authorization] ([Login],[Password],[Role_ID]) values ('" + tbLogin.Text + "','"  + tbPassword.Text + "','" + lstRole.SelectedValue + "')";



                DBConnection.connection.Open();
                command.ExecuteNonQuery();
                DBConnection.connection.Close();
                Response.Redirect(Request.RawUrl);
                gvFill(QR);

            }
        }
        // функция изменения данных
        protected void btUpdate_Click(object sender, EventArgs e)
        {
            switch (tbLogin.Text == "")
            {
                case (true):
                    tbLogin.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbLogin.BackColor = System.Drawing.Color.White;
                    switch (tbPassword.Text == "")
                    {
                        case (true):
                            tbPassword.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbPassword.BackColor = System.Drawing.Color.White;


                            SqlCommand command = new SqlCommand("", DBConnection.connection);
                            command.CommandText = "update [dbo].[Authorization] set " +
                                "[Login] ='" + tbLogin.Text + "', " +
                                "[Password] ='" + tbPassword.Text + "', " +
                                "[Role_ID] ='" + lstRole.SelectedValue + "' " +
                                " where ID_Authorization = " + DBConnection.IDrecord + "";

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
        // функция удаления данных
        protected void btDelete_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", DBConnection.connection);
            command.CommandText = "delete from [dbo].[Authorization] " +
                "where ID_Authorization = " + DBConnection.IDrecord + "";
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
            gvFill(QR);
            Response.Redirect(Request.RawUrl);
        }
        // функция поиска
        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvAddUser.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[3].Text.Equals(tbSearch.Text)
                    || row.Cells[4].Text.Equals(tbSearch.Text))
                    //|| row.Cells[5].Text.Equals(tbSearch.Text))
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
        // функция фильтрации
        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Login] like '%" + tbSearch.Text + "%' or " + "[RoleName] like '%" + tbSearch.Text + "%'";


            gvFill(newQr);
        }
        // функция отмены
        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);



            gvAddUser.DataBind();
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }
    }
}