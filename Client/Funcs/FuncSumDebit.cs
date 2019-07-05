using Client.Models.EF.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Data;

namespace Client.Funcs
{
    public class FuncSumDebit : AggregateFunction<ZWPZFL, double>
    {
        public FuncSumDebit()
        {
            base.AggregationExpression = ((IEnumerable<ZWPZFL> items) => SumDebit(items));
        }

        private double SumDebit(IEnumerable<ZWPZFL> source)
        {
            return (from t in source
                    where t.ZWPZFL_JZFX == "1"
                    select t.ZWPZFL_JE).Sum();
        }
    }
}
