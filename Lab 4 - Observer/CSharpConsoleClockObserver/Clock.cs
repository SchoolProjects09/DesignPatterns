using System;
using System.Collections.Generic;
using System.Text;

namespace GammaConsoleClockObserver
{
    public class Clock : IDisposable
    {
        protected int originalRow;
        protected int originalColumn;
        protected Ticker ticker;
        //nullable type--allows color to be an actual value or "null"
        ConsoleColor? color;
        public Clock(int originalColumn, int originalRow, ConsoleColor? color, Ticker ticker)
        {
            this.originalRow = originalRow;
            this.originalColumn = originalColumn;
            this.color = color;
            this.ticker = ticker;
        }
        protected void WriteAt(string s, int x, int y)
        {
            ConsoleColor localcolor = Console.ForegroundColor;

            if (color != null)
            {
                Console.ForegroundColor = (ConsoleColor)color;
            }
            try
            {
                Console.SetCursorPosition(originalColumn + x, originalRow + y);
                Console.Write("{0}", s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
            if (color != null)
            {
                Console.ForegroundColor = localcolor;
            }
        }
        protected void WriteAt(int n, int x, int y, int precision)
        {
            ConsoleColor localcolor = Console.ForegroundColor;

            if (color != null)
            {
                Console.ForegroundColor = (ConsoleColor)color;
            }
            string formatString = string.Format("{{0:D{0}}}", precision);
            try
            {
                Console.SetCursorPosition(originalColumn + x, originalRow + y);
                Console.Write(formatString, n);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }

            if (color != null)
            {
                Console.ForegroundColor = localcolor;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Clock()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
