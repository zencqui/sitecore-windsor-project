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
    public class GlassBase : IGlassBase, IEquatable<GlassBase>
    {
        [SitecoreChildren(InferType = true, IsLazy = true)]
        public IEnumerable<IGlassBase> BaseChildren { get; set; }

        [SitecoreId]
        public Guid Id { get; set; }

        [SitecoreInfo(SitecoreInfoType.Url)]
        public string ItemLink { get; set; }

        [SitecoreInfo(SitecoreInfoType.Name)]
        public string ItemName { get; set; }

        [SitecoreInfo(SitecoreInfoType.Language)]
        public Language Language { get; set; }

        [SitecoreInfo(SitecoreInfoType.Path)]
        public string Path { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateId)]
        public Guid TemplateId { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateName)]
        public string TemplateName { get; set; }

        [SitecoreInfo(SitecoreInfoType.Version)]
        public int Version { get; set; }

        [SitecoreParent(InferType = true, IsLazy = true)]
        public IGlassBase Parent { get; set; }

        public bool Equals(GlassBase other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if(ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Id.Equals(other.Id) && object.Equals(this.Language, other.Language);
        }

        public override bool Equals(object obj)
        {
             if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if(ReferenceEquals(this, obj))
            {
                return true;
            }

            var glassBase = obj as GlassBase;

            if(glassBase == null)
            {
                return false;
            }

            return this.Equals(glassBase);
        }
    }
}
