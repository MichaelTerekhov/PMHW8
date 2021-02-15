namespace DesignPatterns.ChainOfResponsibility
{
    public class RemoveNumbersMutator : IStringMutator
    {
        private IStringMutator _nextStringMutator;

        public IStringMutator SetNext(IStringMutator next)
        {
            this._nextStringMutator = next;
            return next;
        }

        public string Mutate(string str)
        {
            string withoutNums = string.Empty;
            for (var i = 0; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]))
                    withoutNums += str[i];
            }
            if (_nextStringMutator != null)
                withoutNums = _nextStringMutator.Mutate(withoutNums);
            return withoutNums;
        }
    }
}