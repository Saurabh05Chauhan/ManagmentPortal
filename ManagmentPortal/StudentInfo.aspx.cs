using ManagmentPortal.Models;
using ManagmentPortal.Presenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManagmentPortal
{
    public partial class StudentInfo : Page
    {
        StudentInfoPresenter _presenter = new StudentInfoPresenter();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!this.IsPostBack)
            {
                //this.makeFieldVisible(true);
                var id = Request.QueryString["id"];
                if (id != null)
                {
                    this.makeFieldVisible(true);
                    this.GetData(Convert.ToInt32(id));
                }
                this.GetClassDropDownList();
            }

            

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool validator = true;
            if(validator == true)
            {
                if (txtStudentName.Text == "")
                {
                    validator = false;
                    lblStudentNameRequired.Visible = true;
                }

                if (drpClass.SelectedIndex == 0)
                {
                    validator = false;
                    lblClassRequired.Visible = true;
                }

                if (txtdateOfBirth.Text == "")
                {
                    validator = false;
                    lbldobrequired.Visible = true;
                }

                if (txtAdmissionDate.Text == "")
                {
                    validator = false;
                    lbladRequired.Visible = true;
                }
            }


            if (validator == true)
            {
                this.SaveInfo();
            }
            
        }

        public void  SaveInfo()
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            StudentInfoModel infoModel = new StudentInfoModel();
            if ((lblStudentId.Text) == "")
            {

            infoModel.StudentID = 0;
            }
            else
            {
                infoModel.StudentID = Convert.ToInt32(lblStudentId.Text);
            }
            infoModel.studentName = txtStudentName.Text;
            infoModel.fathersName = txtFatherName.Text;
            infoModel.Class =       drpClass.Text;
            infoModel.admitDate =  DateTime.Parse(txtAdmissionDate.Text);
            infoModel.dateOfBirth= DateTime.Parse(txtdateOfBirth.Text);
            if (txtLeaveDate.Text!="")
            {
                infoModel.leaveDate = DateTime.Parse(txtLeaveDate.Text);
            }
            else
            {
                infoModel.leaveDate = null;
            }
            infoModel.mothersName = txtMotherName.Text;
            infoModel.section =     txtSection.Text;
            infoModel.stream =      drpStream.Text;
            infoModel.address =     txtAddress.Text;

            //return infoModel; 
           string result= this._presenter.SaveInfo(infoModel);
            string[] resultarray = result.Split(',');
            
            if (resultarray[0]=="Success")
            {
                lblError.Text = "Save Success";
                lblStudentId.Text = resultarray[1];
                this.makeFieldVisible(true);
                //Alert("Save Success");
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            }

        }

        public void onSearchOfSID(object sender, EventArgs e)
        { //Constant constant = new Constant();

            this.makeFieldVisible(false);
            string value= (SearchStudentID.Text);
            //GridResults gr = new GridResults();
            //gr.BindGrid(Convert.ToInt32(value));
            Response.Redirect("GridResults.aspx?ID=" + value);
        }

        public void GetData(int studentID)
        {
            StudentInfoModel model = new StudentInfoModel();
            if (studentID != 0)
            {
               model= _presenter.GetStudentInfo(studentID);
                txtStudentName.Text = model.studentName;
                txtFatherName.Text = model.fathersName;
                drpClass.Text = model.Class;
                txtAdmissionDate.Text = model.admitDate.ToShortDateString();
                txtdateOfBirth.Text = model.dateOfBirth.ToShortDateString();

                txtMotherName.Text = model.mothersName;
                txtSection.Text = model.section;
                drpStream.Text = model.stream;
                txtAddress.Text = model.address;

                lblStudentId.Text = studentID.ToString();
                SessionHelper.CurrentStudentId = studentID;
                SessionHelper.CurrentStudentInfoId = model.StudentInfoID;
                leavedatePanel.Enabled = true;
                if (model.isActive == 0)
                {
                    this.isNotActive();
                }
            }

        }

        public void isNotActive()
        {
            StudentForm.Enabled = false;
            lblActiveChanged.Visible = true;
            chkActiveChanged.Visible = true;
        }

        public void GetClassDropDownList()
        {
            
            int category = Constant.Class;
            List<string> drpValues = new List<string>();
            drpValues = _presenter.GetDrpList(category);
            
            drpClass.DataSource = drpValues;
            
            
            drpClass.DataBind();
        }

        protected void drpClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(drpClass.SelectedItem.Text== "XI" || drpClass.SelectedItem.Text== "XII"){

                int category = Constant.stream;
                List<string> drpValues = new List<string>();
                drpValues = _presenter.GetDrpList(category);
                

                drpStream.DataSource = drpValues;

                drpStream.DataBind();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            this.makeFieldVisible(true);
            
            this.clearForm();
           // btngoSearchPanel.Enabled = false;
        }

        public void clearForm()
        {
            txtStudentName.Text = "";
            txtFatherName.Text = "";
            drpClass.SelectedIndex = 0;
            txtAdmissionDate.Text = "";
            txtdateOfBirth.Text = "";

            txtMotherName.Text = "";
            txtSection.Text = "";
            drpStream.SelectedIndex = 0;
            txtAddress.Text = "";

            lblStudentId.Text = "";
            SessionHelper.CurrentStudentId = 0;
            SessionHelper.CurrentStudentInfoId = 0;
        }

        private void makeFieldVisible(bool value)
        {
            this.StudentForm.Visible = value;
            //reqStudentName.Enabled = value;
            //RequiredFieldValidatorAD.Enabled = value;
            //RequiredFieldValidatorClass.Enabled = value;
            //RequiredFieldValidatorDOB.Enabled = value;
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            Response.Redirect("GridResults.aspx");
        }

        public void Active_changed(object sender, EventArgs e)
        {
            if (chkActiveChanged.Checked)
            {
                StudentForm.Enabled = true;
            }
            else
            {
                StudentForm.Enabled = false;
            }
        }
        //protected void closeForm_Click(object sender, EventArgs e)
        //{
        //    this.makeFieldVisible(false);
        //    this.clearForm();
        //    btngoSearchPanel.Enabled = true;

        //}
    }
}