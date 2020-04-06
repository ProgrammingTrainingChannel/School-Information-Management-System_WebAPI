using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models
{
    public interface IBase
    {
        T MapToEntity<T>() where T : class;
    }
}
