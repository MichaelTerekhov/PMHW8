namespace DesignPatterns.ChainOfResponsibility
{
    public class TrimMutator : IStringMutator
    {
        private IStringMutator _nextStringMutator;
        public IStringMutator SetNext(IStringMutator next)
        {
            this._nextStringMutator = next;
            return next;
        }

        public string Mutate(string str)
        {
            str = str.Trim();
            if (_nextStringMutator != null)
                str = _nextStringMutator.Mutate(str);
            return str; 
        }
    }
}