﻿namespace DevToolbox.Wpf.Data;

internal class HexColor : NotifyPropertyChanged
{
    #region Fields/Consts

    private string? _value;

    #endregion

    #region Properties

    public string? Value
    {
        get => _value;
        set => SetProperty(ref _value, value);
    }

    #endregion
}
