using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public interface IBase
    {
        T MapToModel<T>() where T : class;
    }
}
