﻿using Abp.Application.Navigation;
using Abp.Localization;
using ControlBooks.Authorization;

namespace ControlBooks.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class ControlBooksNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", ControlBooksConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Tenants",
                        L("Tenants"),
                        url: "#tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Users",
                        L("Users"),
                        url: "#users",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Users
                        )
                ).AddItem(
                        new MenuItemDefinition(
                        "Authors",
                        L("Authors"),
                        url: "#authors",
                        icon: "fa fa-pencil",
                        requiredPermissionName: PermissionNames.Pages_Users
                        )
               ).AddItem(
                        new MenuItemDefinition(
                        "Publishers",
                        L("Publishers"),
                        url: "#publishers",
                        icon: "fa fa-pencil",
                        requiredPermissionName: PermissionNames.Pages_Users
                        )
               ).AddItem(
                        new MenuItemDefinition(
                        "Books",
                        L("Books"),
                        url: "#books",
                        icon: "fa fa-pencil",
                        requiredPermissionName: PermissionNames.Pages_Users
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", ControlBooksConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                        )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ControlBooksConsts.LocalizationSourceName);
        }
    }
}
