using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Models
{
    public interface IGlassBase
    {
        [SitecoreChildren(InferType = true, IsLazy = true)]
        IEnumerable<IGlassBase> BaseChildren { get; set; }

        [SitecoreId]
        Guid Id { get; set; }

        [SitecoreInfo(SitecoreInfoType.Url)]
        string ItemLink { get; set; }

        [SitecoreInfo(SitecoreInfoType.Name)]
        string ItemName { get; set; }

        [SitecoreInfo(SitecoreInfoType.Language)]
        Language Language { get; set; }

        [SitecoreInfo(SitecoreInfoType.Path)]
        string Path { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateId)]
        Guid TemplateId { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateName)]
        string TemplateName { get; set; }

        [SitecoreInfo(SitecoreInfoType.Version)]
        int Version { get; set; }

        [SitecoreParent(InferType = true, IsLazy = true)]
        IGlassBase Parent { get; set; }
    }
}
