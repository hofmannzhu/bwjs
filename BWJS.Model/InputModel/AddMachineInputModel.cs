 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model.InputModel
{
    public class AddMachineInputModel :InputModelBase
    {
        public Machine Machine { get; set; }


        public ReturnModel IsVilad()
        {
            ReturnModel model = new ReturnModel();

            if (Machine.UserID != 0) {
                model.IsSuccess = true;
            }
               
            if (!string.IsNullOrEmpty(Machine.SN))
            {
                if (Machine.SN.Length > 100)
                {
                    model.IsSuccess = false;
                    model.ErrMessage = "设备号字符过长！";
                }
                else {
                    model.IsSuccess = true;
                }
                
            }
            if (!string.IsNullOrEmpty(Machine.MAC))
            {
                if (Machine.MAC.Length > 50)
                {
                    model.IsSuccess = false;
                    model.ErrMessage = "mac地址字符过长！";
                }
                else {
                    model.IsSuccess = true;
                }
            }

            if (Machine.Status != 0)
            {
                model.IsSuccess = true;
            }

            return model;
        }



    }
}
