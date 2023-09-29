using System;
using System.Collections.Generic;
using System.Text;

namespace GammaConsoleClockObserver
{
    
    //Note: Shouldn't really have multiple classes in the same .cs file but I think
    //it drives home the point that interfaces cause you to implement all methods when
    //you can see all the classes together.
    
    public class SecondClock : Clock
    {
        public SecondClock(int originalColumn, int originalRow, ConsoleColor? color, Ticker ticker)
            : base(originalColumn, originalRow, color, ticker)
        {
            ticker.OnSecondsTick += Second;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            ticker.OnSecondsTick -= Second;
        }
        private void Second()
        {
            DateTime dt = DateTime.Now;

            WriteAt(dt.Hour, 0, 0, 2);
            WriteAt(":", 2, 0);
            WriteAt(dt.Minute, 3, 0, 2);
            WriteAt(":", 5, 0);
            WriteAt(dt.Second, 6, 0, 2);
        }       
    }
    public class HundredthSecondClock : Clock
    {
        public HundredthSecondClock(int originalColumn, int originalRow, ConsoleColor? color, Ticker ticker)
            : base(originalColumn, originalRow, color, ticker)
        {
            ticker.OnHundredthsTick += HundredthSecond;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            ticker.OnHundredthsTick -= HundredthSecond;
        }
        private void HundredthSecond()
        {
            DateTime dt = DateTime.Now;

            WriteAt(dt.Hour, 0, 0, 2);
            WriteAt(":", 2, 0);
            WriteAt(dt.Minute, 3, 0, 2);
            WriteAt(":", 5, 0);
            WriteAt(dt.Second, 6, 0, 2);
            WriteAt(".", 8, 0);
            WriteAt(dt.Millisecond / 10, 9, 0, 2);
        }
    }
    public class TenthSecondClock : Clock
    {
        public TenthSecondClock(int originalColumn, int originalRow, ConsoleColor? color, Ticker ticker)
            : base(originalColumn, originalRow, color, ticker)
        {
            ticker.OnTenthsTick += TenthSecond;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            ticker.OnTenthsTick -= TenthSecond;
        }
        private void TenthSecond()
        {
            DateTime dt = DateTime.Now;

            WriteAt(dt.Hour, 0, 0, 2);
            WriteAt(":", 2, 0);
            WriteAt(dt.Minute, 3, 0, 2);
            WriteAt(":", 5, 0);
            WriteAt(dt.Second, 6, 0, 2);
            WriteAt(".", 8, 0);
            WriteAt(dt.Millisecond / 100, 9, 0, 1);
        }
    }
}
