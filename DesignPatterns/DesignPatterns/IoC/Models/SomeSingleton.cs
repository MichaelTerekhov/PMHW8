namespace DesignPatterns.IoC.Models
{
    public class SomeSingleton
    {
        private int _counter = 0;
        private SomeSingleton _someSingleton;

        public SomeSingleton()
        {
                _counter++;
        }

        public int Counter => _counter;
    }
}
