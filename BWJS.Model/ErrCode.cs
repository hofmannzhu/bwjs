using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model
{
    public class ErrCode
    {
        public const string ExceptionErrCode = "500";
        public const string InputErrCode = "800";
        public const string InputErrCodeMessage = "参数验证失败";

        public const string DBInsertErrCode = "801";
        public const string DBInsertErrCodeMessage = "数据库插入失败";

        public const string DBselectErrCode = "802";
        public const string DBselectErrCodeMessage = "数据库查询失败";
    }
}
