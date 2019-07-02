using Microsoft.Extensions.Localization;
using System;

namespace Jasarsoft.AmadeusDev.Web
{
    public class Resource
    {
        private readonly IStringLocalizer<Resource> localizer;

        public Resource(IStringLocalizer<Resource> localizer)
        {
            this.localizer = localizer;
        }

        
        public string Bosnian => localizer["Bosnian"];
        public string English => localizer["English"];
        public string ImgLangIcon => localizer["ImgLangIcon"];
        public string SelectLanguage => localizer["SelectLanguage"];

        public string Departure => localizer["Departure"];
    }
}
