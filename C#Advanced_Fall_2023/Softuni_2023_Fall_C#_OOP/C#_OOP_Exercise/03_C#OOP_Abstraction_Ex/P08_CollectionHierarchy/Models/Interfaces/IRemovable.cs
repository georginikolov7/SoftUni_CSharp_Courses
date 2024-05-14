using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08_CollectionHierarchy.Models.Interfaces
{
    internal interface IRemovable:IAdeable
    {
        string Remove();
    }
}
