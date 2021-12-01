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
    public partial class FeeInfo : Page
    {
        StudentInfoPresenter _presenter = new StudentInfoPresenter();
        FeeInfoPresenter feeInfoPresenter = new FeeInfoPresenter();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                GetMonthDropDownList();
            }
           

        }

        public void makeFormVisible(int studentid)
        {
            //studentinfo.Visible = true;
            
        }

        protected void btnAddFee_Click(object sender, EventArgs e)
        {
            this.modalPopUp.Show();
        }

        public void GetMonthDropDownList()
        {
            //int index = 0;
            int category = Constant.Month;
            List<string> drpValues = new List<string>();
            List<string> drpValuesCode = new List<string>();
            drpValues = _presenter.GetDrpList(category);
            

                drpMonth.DataSource = drpValues;
                //drpMonth.DataSourceID = index.ToString();
               
                drpMonth.DataBind();
            


           
            drpMonth.DataBind();
            txtYear.Text = DateTime.Today.Year.ToString();
            txtYear.Enabled = false;
        }

        protected void chckStudentID_CheckedChanged(object sender, EventArgs e)
        {
            var studentID = "0";
            StudentInfoModel model = new StudentInfoModel();
            if (chckStudentID.Checked)
            {
                if (txtStudentID.Text != "")
                {
                    studentID = txtStudentID.Text;
                }
                
                model = _presenter.GetStudentInfo(Convert.ToInt32(studentID));
                txtStudentName.Text = model.studentName;
                txtClass.Text = model.Class;
                txtSection.Text = model.section;
                txtFee.Text = (getFeeAmount(model.Class)).ToString();
            }
            else
            {
                txtStudentName.Text = "";
                txtClass.Text = "";
                txtSection.Text = "";
                txtFee.Text = "";
            }
            
            
            this.modalPopUp.Show();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtStudentName.Text = "";
            txtClass.Text = "";
            txtSection.Text = "";
            txtFee.Text = "";
            txtStudentID.Text = "";
            chckStudentID.Checked = false;
            txtFine.Text = "";
            drpMonth.Text = "--Select One--";
            this.modalPopUp.Show();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                FeeInfoModel model = new FeeInfoModel();
                model.studentID= Convert.ToInt32(txtStudentID.Text );
               model.Fees = Convert.ToInt32(txtFee.Text);
                 model.Fine= Convert.ToInt32(txtFine.Text);
                model.forMonth= drpMonth.Text ;
                model.Total = Convert.ToInt32(txtTotal.Text);
                model.FeeSubmissionDate = DateTime.Now.Date;

               string result= feeInfoPresenter.SaveFeeDetails(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Close_Click(object sender, EventArgs e)
        {
            txtStudentName.Text = "";
            txtClass.Text = "";
            txtSection.Text = "";
            txtFee.Text = "";
            txtStudentID.Text = "";
            chckStudentID.Checked = false;
            txtFine.Text = "";
            drpMonth.Text = "--Select One--";
            this.modalPopUp.Hide();
        }

        public double getFeeAmount(string Class)
        {
            double Fee = 0.00;
            switch (Class)
            {
                case ("Nursery"):
                case ("KG"):
                    Fee = 500.00;
                    break;
                case ("I"):
                case ("II"):
                case ("III"):
                        Fee= 1000.00;
                    break;
                case ("IV"):
                case ("V"):
                case ("VI"):
                case ("VII"):
                case ("VIII"):
                    Fee = 1200.00;
                    break;
                case ("IX"):
                case ("X"):
                case ("XI"):
                case ("XII"):
                    Fee = 1200.00;
                    break;
                default:
                    Fee = 0.00;
                    break;
            }
            return Fee;
        }

        protected void drpMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int monthcode = GetMonthCode();
            int total = 0;
            if (monthcode < DateTime.Today.Month)
            {
                if(DateTime.Today.Month - monthcode > 3)
                {
                    txtFine.Text = "300";
                    total = Convert.ToInt32(txtFine.Text) + Convert.ToInt32(txtFee.Text);
                    txtTotal.Text = total.ToString();
                }
                else
                {
                    txtFine.Text = "100";
                    total = Convert.ToInt32(txtFine.Text) + Convert.ToInt32(txtFee.Text);
                    txtTotal.Text = total.ToString();
                }
            }
            else
            {
                txtFine.Text = "0";
                total = Convert.ToInt32(txtFine.Text) + Convert.ToInt32(txtFee.Text);
                txtTotal.Text = total.ToString();
            }

            modalPopUp.Show();
        }

        public int GetMonthCode()
        {
            int monthCode = 0;

            switch (drpMonth.Text)
            {
                case "January":
                     monthCode = 1;
                    break;
                case "Febuary":
                     monthCode = 2;
                    break;
                case "March":
                     monthCode = 3;
                    break;
                case "April":
                     monthCode = 4;
                    break;
                case "May":
                     monthCode = 5;
                    break;
                case "June":
                     monthCode = 6;
                    break;
                case "July":
                     monthCode = 7;
                    break;
                case "August":
                     monthCode = 8;
                    break;
                case "September":
                     monthCode = 9;
                    break;
                case "October":
                     monthCode = 10;
                    break;
                case "November":
                     monthCode = 11;
                    break;
                case "December":
                     monthCode = 12;
                    break;
                default:
                    monthCode = 0;
                    break;
            }

            return monthCode;
        }
    }
}