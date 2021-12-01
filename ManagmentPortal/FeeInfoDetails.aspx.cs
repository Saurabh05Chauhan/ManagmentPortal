using ManagmentPortal.Models;
using ManagmentPortal.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManagmentPortal
{
    public partial class FeeInfoDetails : System.Web.UI.Page
    {
        FeeInfoPresenter feeInfoPresenter = new FeeInfoPresenter();
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];

            if (id != "" && id !=null)
            {
                GetFeeResultData(Convert.ToInt32(id));
            }
        }

        public void GetFeeResultData(int id)
        {
            FeeInfoModel infoModel = new FeeInfoModel();

            infoModel = feeInfoPresenter.GetFeeResults(id);

            if (infoModel != null)
            {
                txtStudentID.Text = infoModel.studentID.ToString();
                txtStudentName.Text = infoModel.StudentName;
                txtClass.Text = infoModel.Class;
                txtSection.Text = infoModel.Section;
                txtStream.Text = infoModel.Stream;
                txtFeeValue.Text = infoModel.Fees.ToString();
                txtFine.Text = infoModel.Fine.ToString();
                txtSubmitDate.Text = infoModel.FeeSubmissionDate.ToShortDateString();
                txtTotal.Text = infoModel.Total.ToString();
                drpMonthValue.Text = infoModel.forMonth;

                if(txtStream.Text == "--Select One--")
                {
                    StreamPanel.Visible = false;
                }
            }
        }
    }
}