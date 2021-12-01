using ManagmentPortal.DataAccessLayer;
using ManagmentPortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ManagmentPortal.Presenter
{
    public class FeeInfoPresenter
    {
        FeeInfoDataAccessLayer dataAccess = new FeeInfoDataAccessLayer();
        public  string SaveFeeDetails(FeeInfoModel model)
        {
            return dataAccess.SaveFeeInfo(model);
        }

        public DataTable GetGridResults(int studentID, string month)
        {
            DataTable ds = new DataTable();
            ds = dataAccess.GetFeeGridResults(studentID,month);

            return ds;
        }

        public FeeInfoModel GetFeeResults(int id)
        {
            //FeeInfoModel infoModel = FeeInfoModel();
            return   dataAccess.GetFeeGridResults(id);
        }
    }
}