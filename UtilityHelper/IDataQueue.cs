using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityHelper
{
    public interface IDataQueue: IDisposable
    {

        void EnqueueItemOnList(string listID, string obj);
        void EnqueueItemOnList<T>(string listID, T obj) where T : class, new();

        T DequeueItemFromList<T>(string listID, TimeSpan timeOut) where T : class, new();

        string DequeueItemFromList(string listID);
    }
}
