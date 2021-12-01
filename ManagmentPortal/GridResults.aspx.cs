using ManagmentPortal.Presenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManagmentPortal
{
    public partial class GridResults : Page
    {

        StudentInfoPresenter _presenter = new StudentInfoPresenter();
        private int StudentId;
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["ID"];
            if (!this.IsPostBack)
            {
                if (id != null)
                {
                    this.BindGrid();
                }

                this.GetClassDropDownList();
            }
            

        }

        public void BindGrid()
        {
            int StudentID = Convert.ToInt32(id);
            DataTable dt = new DataTable();
            dt = _presenter.GetGridResults(StudentID,"");
            searchResults.DataSource = dt;
            searchResults.DataBind();
        }

        public void BindGrid(int studentid)
        {
            StudentId = studentid;
            this.BindGrid();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            searchResults.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        public void GetClassDropDownList()
        {

            int category = Constant.Class;
            List<string> drpValues = new List<string>();
            drpValues = _presenter.GetDrpList(category);

            drpClass.DataSource = drpValues;


            drpClass.DataBind();
        }

        protected void SearchNow_Click(object sender, EventArgs e)
        {
            string studentName = txtStudentName.Text;
            string Class = drpClass.Text;
            DataTable dt = new DataTable();
            dt = _presenter.GetSearchFromNameAndClass(studentName,Class);
            searchResults.DataSource = dt;
            searchResults.DataBind();

            if (dt.DataSet == null)
            {

            }

        }

        protected void searchResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void drpClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}