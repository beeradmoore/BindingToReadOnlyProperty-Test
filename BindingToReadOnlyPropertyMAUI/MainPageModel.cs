using System;
using System.ComponentModel;

namespace BindingToReadOnlyPropertyMAUI;

public class MainPageModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    double myValue = 50.0;
    public double MyValue
    {
        get
        {
            return myValue;
        }
    }

	public Command SetValueCommand { get; private set; }

	public MainPageModel()
    {
        SetValueCommand = new Command<Entry>(SetValue);
    }

    void SetValue(Entry myValueEntry)
    {
        if (String.IsNullOrEmpty(myValueEntry.Text) == false && Double.TryParse(myValueEntry.Text, out double myNewValue))
        {
            myValue = myNewValue;
            PropertyChanged?.Invoke(MyValue, new PropertyChangedEventArgs(nameof(MyValue)));
        }
    }
}

