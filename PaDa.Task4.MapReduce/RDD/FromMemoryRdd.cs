using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaDa.Task4.MapReduce.RDD
{
    public class FromMemoryRdd<T>: RDD<T>, IDataSource
    {
        private IEnumerable<T> _input;

        public FromMemoryRdd(IEnumerable<T> input)
        {
            _input = input;
        }

        internal override RDD GetPrevious()
        {
            return null;
        }

        public IEnumerable<object> GetData()
        {
            return (IEnumerable<object>)_input.Cast<object>();
        }
    }
}
