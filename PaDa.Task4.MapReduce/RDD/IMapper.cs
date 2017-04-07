using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaDa.Task4.MapReduce.RDD
{
    public interface IMapper<in TInput, out TOutput> : IMapper
    {
        TOutput Map(TInput input);
    }

    public interface IMapper
    {
        
    }
}
