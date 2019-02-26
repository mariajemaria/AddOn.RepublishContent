using System.Collections.Generic;
using EPiServer;
using EPiServer.Framework.Localization;
using EPiServer.Security;
using EPiServer.Shell.Navigation;

namespace AddOn.RepublishContent.Core
{
    [MenuProvider]
    public class RepublishContentMenuProvider : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var menuItems = new List<UrlMenuItem>
            {
                new UrlMenuItem(LocalizationService.Current.GetString("/addon.republishcontent/name"),
                MenuPaths.Global + "/cms" + "/cmsMenuItem",
                UriSupport.ResolveUrlFromUIAsRelativeOrAbsolute("/RepublishContent/"))
                {
                    SortIndex = SortIndex.First + 25,
                    IsAvailable = (request) => PrincipalInfo.HasAdminAccess
                }
            };

            return menuItems;
        }
    }
}
