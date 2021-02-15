namespace DesignPatterns.ChainOfResponsibility
{
    public class InvertMutator : IStringMutator
    {
        private IStringMutator _nextStringMutator;
        public IStringMutator SetNext(IStringMutator next)
        {
            this._nextStringMutator = next;
            return next;
        }

        public string Mutate(string str)
        {
            string inversed = string.Empty;
            for (var i = str.Length - 1; i >= 0; i--)
                inversed += str[i];

          
            if (_nextStringMutator != null)
                inversed = _nextStringMutator.Mutate(inversed);
            return inversed;
        }
    }
}