using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ScorpiusClientLibrary;
using Xamarin.Forms;

namespace ScorpiusClient.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    private string _topic;
    private bool _notEmptyList;
    private ObservableCollection<string> _items;

    public bool NotEmptyList
    {
        get => _notEmptyList;
        set => SetProperty(ref _notEmptyList, value);
    }

    public string Topic
    {
        get => _topic;
        set => SetProperty(ref _topic, value);
    }

    public Command AddTopic { get; }
    public Command RemoveAllTopics { get; }

    public ObservableCollection<string> Items
    {
        get => _items;
        set => SetProperty(ref _items, value);
    }
    

    public MainPageViewModel()
    {
        Items = new ObservableCollection<string>();
        AddTopic = new Command(AddTopicToItems);
        RemoveAllTopics = new Command(RemoveAllItems);
    }

    private void AddTopicToItems()
    {
        if (_topic == null || string.IsNullOrEmpty(_topic.Trim()))
            return;

        if (Items.Contains(_topic)) return;

        var temp = Items;
        temp.Add(_topic);
        //_firebaseService.SubscribeToSingleTopic(_topic);
        CrossScorpiusClient.Current.SubscribeToSingleTopic(_topic);

        Items = temp;
        Topic = "";
        ValidateListSize();
    }

    private void ValidateListSize()
    {
        NotEmptyList = Items.Count > 0;
    }

    private void RemoveAllItems()
    {
        if (Items == null || Items.Count == 0)
            return;

        CrossScorpiusClient.Current.UnSubscribeFromMultipleTopics(Items);
        var temp = new ObservableCollection<string>();
        Items = temp;
        ValidateListSize();
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