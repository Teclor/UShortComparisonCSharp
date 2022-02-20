namespace application.lib.compareresults
{
    public class BaseCompareResult : ICompareResult
    {
        private bool isTrue;
        public BaseCompareResult(bool isTrue = false)
        {
            this.isTrue = isTrue;
        }
        public bool GetState()
        {
            return isTrue;
        }

        public void SetTrueState()
        {
            this.isTrue = true;
        }

        public void SetFalseState()
        {
            this.isTrue = false;
        }
    }
}
