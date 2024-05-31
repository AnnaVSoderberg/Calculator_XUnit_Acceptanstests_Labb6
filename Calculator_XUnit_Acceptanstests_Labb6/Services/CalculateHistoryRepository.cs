using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_XUnit_Acceptanstest_Labb6.Services
{
    public class CalculateHistoryRepository : ICalculatorHistoryRepository
    {
        private readonly List<string> _history = new List<string>();
      
        public List<string> GetHistory()
        {
            return new List<string>(_history);
        }

        public void SaveHistory(string entry)
        {
            _history.Add(entry);
        }
    }
}
