using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_XUnit_Acceptanstest_Labb6.Services
{
    public interface ICalculatorHistoryRepository
    {
        void SaveHistory(string entry);
        List<string> GetHistory();
    }
}
