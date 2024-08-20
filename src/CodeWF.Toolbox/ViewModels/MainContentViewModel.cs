﻿using Avalonia.Controls.Notifications;
using CodeWF.Core.Models;
using CodeWF.Toolbox.Events;
using Prism.Events;
using ReactiveUI;

namespace CodeWF.Toolbox.ViewModels;

internal class MainContentViewModel : ViewModelBase
{
    private bool _bordered;

    public bool Bordered
    {
        get => _bordered;
        set => this.RaiseAndSetIfChanged(ref _bordered, value);
    }

    private NotificationType _selectedType;

    public NotificationType SelectedType
    {
        get => _selectedType;
        set => this.RaiseAndSetIfChanged(ref _selectedType, value);
    }

    private ToolMenuItem? _selectedMenuItem;

    public ToolMenuItem? SelectedMenuItem
    {
        get => _selectedMenuItem;
        set => this.RaiseAndSetIfChanged(ref _selectedMenuItem, value);
    }

    public MainContentViewModel(IEventAggregator eventAggregator)
    {
        eventAggregator.GetEvent<ChangeToolMenuEvent>().Subscribe(ChangeToolMenuHandler);
    }

    private void ChangeToolMenuHandler(ToolMenuItem toolMenuItem)
    {
        SelectedMenuItem = toolMenuItem;
        Bordered = toolMenuItem.Status == ToolStatus.Developing;
        SelectedType = toolMenuItem.Status == ToolStatus.Complete ? NotificationType.Success : NotificationType.Warning;
    }
}