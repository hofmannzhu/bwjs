using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BWJSLog.BLL;
using BWJSLog.Model;

namespace MofangInterfacle.BLL.Test
{
    [TestClass]
    public class ExceptionLogBLLUnit
    {
        [TestMethod]
        public void AddExceptionLog()
        {
            //ExceptionLog model = new ExceptionLog();
            //model.ClassName = "ExceptionLogBLLUnit";
            //model.MethodName = "AddExceptionLog";
            //model.ErrorDesc = "test ErrorDesc";

            ExceptionLogBLL.WriteExceptionLogToDB("test ErrorDesc");
 
        }
    }
}
