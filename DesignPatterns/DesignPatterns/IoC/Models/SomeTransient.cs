namespace DesignPatterns.IoC.Models
{
    public class SomeTransient
    {
        private int _counter = 0;

        public SomeTransient()
        {
            _counter++;
        }

        public int Counter => _counter;
    }
}