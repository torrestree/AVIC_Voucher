using Client.Models.EF.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Data;

namespace Client.Funcs
{
    public class FuncSumCredit : AggregateFunction<ZWPZFL, double>
    {
        public FuncSumCredit()
        {
            base.AggregationExpression = ((IEnumerable<ZWPZFL> items) => SumCredit(items));
        }

        private double SumCredit(IEnumerable<ZWPZFL> source)
        {
            return (from t in source
                    where t.ZWPZFL_JZFX == "2"
                    select t.ZWPZFL_JE).Sum();
        }
    }
}
