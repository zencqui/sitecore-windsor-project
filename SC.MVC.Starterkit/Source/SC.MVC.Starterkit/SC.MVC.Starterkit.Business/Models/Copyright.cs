using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Models
{
    public partial class Copyright : GlassBase, ICoinCopyright
    {
        [SitecoreField("CopyrightText", Setting = SitecoreFieldSettings.Default)]
        public virtual string CopyrightText { get; set; }
    }
}
