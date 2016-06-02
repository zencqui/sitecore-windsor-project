using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Utilities
{
    public static class AssemblyUtility
    {
        private const string AssemblyFilter = "SC.MVC";

        public static IEnumerable<string> RelatedAssemblies
        {
            get 
            {
                return AppDomain.CurrentDomain.GetAssemblies()
                    .Where(assembly => assembly.FullName.StartsWith(AssemblyFilter, StringComparison.OrdinalIgnoreCase))
                    .Select(assembly => assembly.Location).ToArray();
            }
        }
    }
}
