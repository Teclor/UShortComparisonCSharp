namespace application.lib.compareresults
{
    public interface ICompareResult
    {
        public bool GetState();
        public void SetTrueState();
        public void SetFalseState();
    }
}
