using System;

namespace Demo.Locking
{
    public class LoopProvider
    {
        private readonly Worker _worker;
        private readonly int _lowerBound;
        private readonly int _upperBound;

        public LoopProvider(Worker worker, int lowerBound, int upperBound)
        {
            _worker = worker;
            _lowerBound = lowerBound;
            _upperBound = upperBound;
        }

        public void Execute()
        {
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (var i = 0; i < 10; i++)
            {

                var nextKey = random.Next(_lowerBound, _upperBound + 1);
                _worker.DoWork(nextKey.ToString());
            }
        }
    }
}