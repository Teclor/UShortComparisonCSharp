using System;
using System.Collections.Generic;
using System.Text;

namespace application.lib.compareresults
{
    public interface ICompareResult
    {
        public bool GetState();
        public void SetTrueState();
        public void SetFalseState();
    }
}
