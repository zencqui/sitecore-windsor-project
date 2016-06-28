using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using SC.MVC.Starterkit.Business.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Models
{
    [MatchingType(typeof(CoinCopyright))]
    public interface ICoinCopyright : IGlassBase
    {
        [SitecoreField("CopyrightText", Setting = SitecoreFieldSettings.Default)]
        string CopyrightText { get; set; }
    }
}
