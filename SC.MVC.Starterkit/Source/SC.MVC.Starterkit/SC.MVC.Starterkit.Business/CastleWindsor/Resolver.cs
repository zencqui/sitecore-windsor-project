using Castle.Windsor;
using SC.MVC.Starterkit.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.CastleWindsor
{
    public static class Resolver
    {
        private static IWindsorContainer container;
        private static readonly object locker = new object();

        public static IWindsorContainer Container
        {
            get
            {
                return container;
            }

            set
            {
                lock (locker)
                {
                    if (container != null)
                    {
                        throw new InvalidOperationException("Container has been set laready.");
                    }

                    container = value;
                }
            }
        }

        public static IDisposable Resolve<T>(out T item)
        {
            item = container.Resolve<T>();
            var localItem = item;
            return new DisposableHelper(() => container.Release(localItem));
        }
    }
}
