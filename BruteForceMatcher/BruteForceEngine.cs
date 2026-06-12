using System;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForceMatcher
{
    public class BruteForceEngine
    {
        private readonly string _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!?@#£$%^&*()-=";
        
        private readonly HashValidator _validator;
        private readonly bool _showLive;
        private readonly Action<string> _onLiveGuess; // 7 validator 
        
        private string _foundPassword = null;
        
        private readonly object _lockObj = new object(); // uztikrina kad tik viena gija iveda vienu metu

        public BruteForceEngine(HashValidator validator, bool showLive, Action<string> onLiveGuess)
        {
            _validator = validator;
            _showLive = showLive;
            _onLiveGuess = onLiveGuess;
        }

        public string RunAttack(bool useMultiThreading, CancellationToken token)
        {
            _foundPassword = null;

            for (int length = 1; length <= 6; length++) // veiks tik iki 6 simboliu (4.c)
            {
                if (token.IsCancellationRequested || _foundPassword != null) break;

                if (useMultiThreading)
                {
                    int maxThreads = Math.Max(1, Environment.ProcessorCount - 1); // 4.e , max cores count
                    var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = maxThreads, CancellationToken = token };

                    try
                    {       // vietoj for() , .foreach padalina musu _chars alfabeta lygiomis dalimis visiem cores 
                        Parallel.ForEach(_chars, parallelOptions, (firstChar, state) =>
                        {
                            RecursiveCrack(firstChar.ToString(), length, token, state);
                        });
                    }
                    catch (OperationCanceledException) { } // jei naudojamas quit, nesusiduriama su klaidomis
                }
                else
                {
                    foreach (char c in _chars) // 8. punktas. Single-Thread 
                    {
                        if (token.IsCancellationRequested || _foundPassword != null) break;
                        RecursiveCrack(c.ToString(), length, token, null);
                    }
                }
            }
            return _foundPassword; // null arba slaptazodis
        }

        private void RecursiveCrack(string current, int targetLength, CancellationToken token, ParallelLoopState state)
        {
            if (token.IsCancellationRequested || _foundPassword != null || (state != null && state.IsStopped)) return; // 6 punktas

            if (current.Length == targetLength)
            {
                if (_showLive) _onLiveGuess?.Invoke(current);

                if (_validator.CheckMatch(current))
                {
                    lock (_lockObj)
                    {
                        if (_foundPassword == null)
                        {
                            _foundPassword = current;
                            state?.Stop(); 
                        }
                    }
                }
                return;
            }

            for (int i = 0; i < _chars.Length; i++)
            {
                if (_foundPassword != null || token.IsCancellationRequested) return;
                RecursiveCrack(current + _chars[i], targetLength, token, state);
            }
        }
    }
}