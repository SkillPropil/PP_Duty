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
    public partial class WorkPlan : System.Web.UI.Page
    {
        private string QR = "";
        // при загрузке страницы заполняется таблица и выпадающий список
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrDuty;
            if (!IsPostBack)
            {
                gvFill(QR);

                FillDropLists1();
           

            }
        }
        // функция заполнения таблицы
        private void gvFill(string qr)
        {
            sdsWork.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsWork.SelectCommand = qr;
            sdsWork.DataSourceMode = SqlDataSourceMode.DataReader;
            gvWork.DataSource = sdsWork;
            gvWork.DataBind();
        }
        // функция выбора данных из таблицы
        protected void gvWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvWork.SelectedRow;
            tbStart.Text = row.Cells[2].Text.ToString();
            tbStop.Text = row.Cells[3].Text.ToString();
            

           

            lstSpecialist.SelectedValue = row.Cells[5].Text;
            DBConnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }
        // функция заполнения выпадающего списка
        public void FillDropLists1()
        {
            sdsSpecialist.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsSpecialist.DataSourceMode = SqlDataSourceMode.DataReader;

        }

      
        // скрываем строки
        protected void gvWork_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[5].Visible = false;
            //
        }
        // функция сортировки
        protected void gvWork_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Начало смены"):
                    e.SortExpression = "[StartWork]";
                    break;
                case ("Конец смены"):
                    e.SortExpression = "[StopWork]";
                    break;

            }
            sortGridView(gvWork, e, out sortDirection, out strField);
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
        // При нажатии на дату календаря дата выводится в текстовое поле
        protected void calendar1_SelectionChanged(object sender, EventArgs e)
        {
            tbStart.Text = calendar1.SelectedDate.ToShortDateString();
            calendar1.Visible = false;
        }
        // При нажатии на дату календаря дата выводится в текстовое поле
        protected void calendar2_SelectionChanged(object sender, EventArgs e)
        {
         
            tbStop.Text = calendar2.SelectedDate.ToShortDateString();
            calendar2.Visible = false;
        }
        // Функция добавления данных
        protected void btInsert_Click(object sender, EventArgs e)
        {
            bool err = false;

            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tbStart);
            textBoxes.Add(tbStop);

            if (!err)
            {
                SqlCommand command = new SqlCommand("", DBConnection.connection);


                int Specialist_ID = int.Parse(lstSpecialist.SelectedValue);

                command.CommandText = "INSERT INTO [dbo].[Duty] ([StartWork],[StopWork],[Specialist_ID]) values ('" + tbStart.Text + "','" + tbStop.Text + "','" + lstSpecialist.SelectedValue + "')";



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
            switch (tbStart.Text == "")
            {
                case (true):
                    tbStart.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbStart.BackColor = System.Drawing.Color.White;
                    switch (tbStop.Text == "")
                    {
                        case (true):
                            tbStop.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbStop.BackColor = System.Drawing.Color.White;


                            SqlCommand command = new SqlCommand("", DBConnection.connection);
                            command.CommandText = "update [dbo].[Duty] set " +
                                "[StartWork] ='" + tbStart.Text + "', " +
                                "[StopWork] ='" + tbStop.Text + "', " +
                                "[Specialist_ID] ='" + lstSpecialist.SelectedValue + "' " +
                                " where ID_Duty = " + DBConnection.IDrecord + "";

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
        // функция удаления
        protected void btDelete_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", DBConnection.connection);
            command.CommandText = "delete from [dbo].[Duty] " +
                "where ID_Duty = " + DBConnection.IDrecord + "";
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
            gvFill(QR);
            Response.Redirect(Request.RawUrl);
        }
        // функция поиска
        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvWork.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[3].Text.Equals(tbSearch.Text))
                    //|| row.Cells[4].Text.Equals(tbSearch.Text)
                    //|| row.Cells[5].Text.Equals(tbSearch.Text))

                    row.BackColor = System.Drawing.Color.Green;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }
        // функция фильтра
        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [StartWork] like '%" + tbSearch.Text + "%' or " + "[StopWork] like '%" + tbSearch.Text + "%' or "  + "[Surname] like '%" + tbSearch.Text + "%'";


            gvFill(newQr);
        }
        // функция отмены
        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);



            gvWork.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }
    }    
}
