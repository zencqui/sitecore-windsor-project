using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Services
{
    public interface ISettingsWrapper
    {
        string GetSetting(string settingName);
    }
}
