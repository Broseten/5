﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CookBook.Maui.BL.ViewModels;

public class ViewModelBase : IViewModel, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public virtual Task OnAppearingAsync()
    {
        return Task.CompletedTask;
    }
}
