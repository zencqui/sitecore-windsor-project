using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class MatchingTypeAttribute : Attribute
    {
        private readonly Type type;

        public Type MatchType
        {
            get 
            {
                return this.type;
            }
        }

        public MatchingTypeAttribute(Type type)
        {
            this.type = type;
        }
    }
}
