using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Services
{
    public class SettingsWrapper : ISettingsWrapper
    {
        public string GetSetting(string settingName)
        {
            return "This is a string comming from settings";
        }
    }
}
