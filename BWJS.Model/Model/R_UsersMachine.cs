using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model.Model
{
    public class R_UsersMachine
    {
        /// <summary>
        /// RUMID
        /// </summary>		
        private int _rumid;
        public int RUMID
        {
            get { return _rumid; }
            set { _rumid = value; }
        }
        /// <summary>
        /// UserID
        /// </summary>		
        private int _userid;
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// MachineID
        /// </summary>		
        private int _machineid;
        public int MachineID
        {
            get { return _machineid; }
            set { _machineid = value; }
        }
        /// <summary>
        /// RecordIsDelete
        /// </summary>		
        private bool _recordisdelete;
        public bool RecordIsDelete
        {
            get { return _recordisdelete; }
            set { _recordisdelete = value; }
        }
        /// <summary>
        /// RecordCreateTime
        /// </summary>		
        private DateTime _recordcreatetime;
        public DateTime RecordCreateTime
        {
            get { return _recordcreatetime; }
            set { _recordcreatetime = value; }
        }
        /// <summary>
        /// RecordUpdateTime
        /// </summary>		
        private DateTime _recordupdatetime;
        public DateTime RecordUpdateTime
        {
            get { return _recordupdatetime; }
            set { _recordupdatetime = value; }
        }
    }
}
