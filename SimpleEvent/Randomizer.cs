using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleEvent
{
    public class Randomizer
    {

        public event EventHandler RandomizerEventCalculated;

        public List<int> Numbers { get; private set; }

        public async Task ProcessGeneratorAsync()
        {
            while (true)
            {
                var nums = await Task.Run(() => LongTimeRunningFunc());
                Numbers = nums;

                var del = RandomizerEventCalculated;
                del?.Invoke(this, EventArgs.Empty);

            }
        }


        private List<int> LongTimeRunningFunc()
        {
            var num = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                int card = rnd.Next(52);
                num.Add(card);
                Thread.Sleep(20);
            }
            
            Thread.Sleep(40);

            return num;
        }

    }
}
