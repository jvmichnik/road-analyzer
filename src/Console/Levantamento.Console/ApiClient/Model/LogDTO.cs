using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Levantamento.Consoles.ApiClient.Model
{
    public class LogDTO
    {
        public LogDTO(int speed = 30, Decimal @long = -47.882667m, Decimal lat = -15.793766m)
        {

            Long = @long + 0.0001m;
            Lat = lat + 0.0001m;

            Rate = RandomNumber() * RandomInt(1, 30);
            Speed = CalculoSpeed(speed);

            DateOccurred = DateTime.Now;
        }

        public Decimal Long { get; private set; }
        public Decimal Lat { get; private set; }
        public Decimal Rate { get; private set; }
        public int Speed { get; private set; }
        public DateTime DateOccurred { get; private set; }

        private int CalculoSpeed(int speed)
        {
            var val = RandomInt(0, 12);
            if (val < 3)
                return speed - 1;
            if (val >= 3 && val < 6)
                return speed + 1;

            return speed;
        }

        private int RandomInt(int min, int max)
        {
            Random random = new Random(DateTime.Now.Millisecond+ DateTime.Now.Second);
            return random.Next(min, max);
        }
        private decimal RandomNumber()
        {
            Random random = new Random(DateTime.Now.Millisecond + DateTime.Now.Second);
            return Convert.ToDecimal(random.NextDouble());
        }
    }
}
