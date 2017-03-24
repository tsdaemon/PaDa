using System;
using System.Collections.Generic;
using System.Text;

namespace PaDa.Lib
{
    public interface IAlgorithm<in TInput, out TOutput>
    {
        TOutput Process(TInput input);
    }
}
