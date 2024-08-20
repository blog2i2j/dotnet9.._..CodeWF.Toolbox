﻿using CodeWF.Core;
using CodeWF.Core.Models;
using CodeWF.Modules.AI.Helpers;
using CodeWF.Modules.AI.I18n;
using CodeWF.Modules.AI.ViewModels;
using CodeWF.Modules.AI.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace CodeWF.Modules.AI;

public class AIModule : IModule
{
    public AIModule(IToolMenuService toolMenuService)
    {
        var groupName = Language.AI;
        toolMenuService.AddSeparator();
        toolMenuService.AddGroup(groupName, Icons.AI);
        toolMenuService.AddItem(Language.AskBot, groupName, Language.AskBotDescription, nameof(AskBotView),
            Icons.AskBot,
            ToolStatus.Developing);
        toolMenuService.AddItem(Language.PolyTranslate, groupName, Language.PolyTranslateDescription,
            nameof(PolyTranslateView),
            Icons.PolyTranslate,
            ToolStatus.Developing);
        toolMenuService.AddItem(Language.Title2Slug, groupName, Language.Title2SlugDescription, nameof(Title2SlugView),
            Icons.Title2Slug,
            ToolStatus.Developing);
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
        IRegionManager? regionManager = containerProvider.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion<AskBotView>(RegionNames.ContentRegion);
        regionManager.RegisterViewWithRegion<PolyTranslateView>(RegionNames.ContentRegion);
        regionManager.RegisterViewWithRegion<Title2SlugView>(RegionNames.ContentRegion);
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterScoped<ApiClient>();
        containerRegistry.RegisterSingleton(typeof(AskBotViewModel));
        containerRegistry.RegisterSingleton(typeof(PolyTranslateViewModel));
        containerRegistry.RegisterSingleton(typeof(Title2SlugViewModel));
    }
}