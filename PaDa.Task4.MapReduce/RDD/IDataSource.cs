using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaDa.Task4.MapReduce.RDD
{
    public interface IDataSource
    {
        IEnumerable<object> GetData();
    }
}
