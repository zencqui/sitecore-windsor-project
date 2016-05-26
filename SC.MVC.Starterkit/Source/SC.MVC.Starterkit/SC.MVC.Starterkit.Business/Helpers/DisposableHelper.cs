using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Helpers
{
    public class DisposableHelper : IDisposable
    {
        private Action end;
        private bool isDisposed;

        public DisposableHelper(Action end)
        {
            this.end = end;
        }

        protected virtual void Dispose(bool isDisposed)
        {
            if (!isDisposed)
            {
                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            end();
        }
    }
}
