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
    public partial class Girafik : System.Web.UI.Page
    {
        
        private string QR = "";
        // при загрузке страницы заполняется таблица
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrWork;
            if (!IsPostBack)
            {
                gvFill(QR);

               
            }
        }
        // функция заполнения таблицы
        private void gvFill(string qr)
        {
            sdsWork.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsWork.SelectCommand = qr;
            sdsWork.DataSourceMode = SqlDataSourceMode.DataReader;
            gvGirafik.DataSource = sdsWork;
            gvGirafik.DataBind();
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }
        // экспорт данных
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            // выбираем таблицу и источник данных
            GridView gv = new GridView();
            GridView gridView = gvGirafik;
            DBConnection.connection.Open();
            gv.DataSource = sdsWork;
            DBConnection.connection.Close();
            gvFill(QR);





            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            gvGirafik.AllowPaging = false;
            Response.AddHeader("content-disposition", "attachment; filename=" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
          
            //Response.Clear();
            //Response.Buffer = true;
            //Response.Charset = "";
            //Response.AddHeader("content-disposition", "attachment;filename= Warehouse.xls");
            //Response.ContentType = "application/ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);

            //gvWarehouse.AllowPaging = false;
            //gvWarehouse.DataBind();

            //Response.Output.Write(sw.ToString());
            //Response.Flush();
            //Response.End();
        }
        // скрытие строк
        protected void gvGirafik_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[8].Visible = false;
        }
        // сортировка
        protected void gvGirafik_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Начало смены"):
                    e.SortExpression = "[StartWork]";
                    break;

                case ("Фамилия"):
                    e.SortExpression = "[Surname]";
                    break;

                case ("Имя"):
                    e.SortExpression = "[Name]";
                    break;

                case ("Отчество"):
                    e.SortExpression = "[MiddleName]";
                    break;

                case ("Конец смены"):
                    e.SortExpression = "[StopWork]";
                    break;

            }
            sortGridView(gvGirafik, e, out sortDirection, out strField);
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
        // поиск
        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvGirafik.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[3].Text.Equals(tbSearch.Text)
                    || row.Cells[4].Text.Equals(tbSearch.Text)
                    || row.Cells[5].Text.Equals(tbSearch.Text)
                    || row.Cells[6].Text.Equals(tbSearch.Text)
                    || row.Cells[7].Text.Equals(tbSearch.Text))

                    row.BackColor = System.Drawing.Color.Green;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }
        // фильтр
        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Surname] like '%" + tbSearch.Text + "%' or " + "[Name] like '%" + tbSearch.Text + "%' or " + "[MiddleName] like '%" + tbSearch.Text + "%' or " + "[Phone] like '%" + tbSearch.Text + "%' or " + "[StartWork] like '%" + tbSearch.Text + "%' or " + "[StopWork] like '%" + tbSearch.Text + "%'";
            gvFill(newQr);
        }
        // очистка данных 
        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);


            // почти RealTime
            gvGirafik.DataBind();
        }
    }
}