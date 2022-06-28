using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;


namespace ScorpiusClient.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    private string _topic;

    public string Topic
    {
        get => _topic;
        set => SetProperty(ref _topic, value);
    }

    public Command AddTopic { get; }

    public ObservableCollection<string> Items { get; set; }


    public MainPageViewModel()
    {
        Items = new ObservableCollection<string>();
        AddTopic = new Command(AddTopicToItems);
    }

    private void AddTopicToItems()
    {
        if (_topic == null || string.IsNullOrEmpty(_topic.Trim()))
            return;

        if (Items.Contains(_topic)) return;

        var temp = Items;
        temp.Add(_topic);
        Items = temp;
        Topic = "";
    }


    #region INotifyPropertyChanged

    private void SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "",
        Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value)) return;

        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        var changed = PropertyChanged;

        changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}