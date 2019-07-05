using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Interfaces
{
    /// <summary>
    /// IMgtEFRd
    /// </summary>
    /// <typeparam name="TRef"></typeparam>
    /// <typeparam name="TEntry"></typeparam>
    /// <typeparam name="TDetail"></typeparam>
    public interface IMgtEFRd<TRef, TEntry, TDetail> : IMgtEFRe<TRef, TEntry>
    {
    }
}
