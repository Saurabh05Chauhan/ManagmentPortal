using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManagmentPortal
{
    public partial class _Default : Page
    {
        public void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void btnInfoPortal_Click(object sender, EventArgs e)
        {

            Response.Redirect("StudentInfo.aspx");
            
        }

        protected void btnFeePortal_Click(object sender, EventArgs e)
        {
            Response.Redirect("FeeInfo.aspx");

            
        }
    }
}