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
    public partial class StudentFeeGrid : System.Web.UI.UserControl
    {
        StudentInfoPresenter _presenter = new StudentInfoPresenter();
        FeeInfoPresenter feeInfoPresenter = new FeeInfoPresenter();
        FeeInfo feeInfo = new FeeInfo();
        int studentID = 0;
        string month = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                GetMonthDropDownList();
            }
            
        }

        public void BindGrid()
        {
            //int StudentID = Convert.ToInt32(id);
            DataTable dt = new DataTable();
            dt = feeInfoPresenter.GetGridResults(studentID,month);
            searchResults.DataSource = dt;
            searchResults.DataBind();
            if (dt.Rows.Count < 1)
            {
                feeErrorlabel.Visible = true;
            }
        }

        //public void BindGrid(int studentid)
        //{
        //    studentID = studentid;
        //    month = drpMonth.SelectedItem.Text;
        //    this.BindGrid();
        //}

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            searchResults.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void searchResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SearchNow_Click(object sender, EventArgs e)
        {
            studentID = Convert.ToInt32( this.txtStudentID.Text);
            month = drpMonth.Text;
            BindGrid();
        }

        public void GetMonthDropDownList()
        {

            int category = Constant.Month;
            List<string> drpValues = new List<string>();
            drpValues = _presenter.GetDrpList(category);

            drpMonth.DataSource = drpValues;


            drpMonth.DataBind();
        }

        protected void btnAddFee_Click(object sender, EventArgs e)
        {
            //feeInfo.makeFormVisible(studentID);
            feeInfo.FindControl("studentinfo").Visible = true;
        }
    }
}