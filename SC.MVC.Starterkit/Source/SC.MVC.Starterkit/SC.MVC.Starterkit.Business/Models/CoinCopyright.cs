using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Models
{
    [SitecoreType(TemplateId="9B1B8A7F-4218-48AA-AB51-C9D53B3391E9")]
    public partial class CoinCopyright : GlassBase, ICoinCopyright
    {
        [SitecoreField("CopyrightText", Setting = SitecoreFieldSettings.Default)]
        public virtual string CopyrightText { get; set; }
    }
}
