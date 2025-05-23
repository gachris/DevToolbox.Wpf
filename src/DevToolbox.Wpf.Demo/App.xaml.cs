﻿using System.Windows;
using CommonServiceLocator;
using DevToolbox.Core.Contracts;
using DevToolbox.Wpf.Demo.Helpers;

namespace DevToolbox.Wpf.Demo;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application, IApplication
{
    #region Fields/Consts

    private readonly SingletonApplicationManager _singletonApplicationManager;

    /// <summary>
    /// The event mutex name.
    /// </summary>
    private const string UniqueEventName = "88D8660D-ACB3-4570-ADBC-50F8AFA1352C";

    /// <summary>
    /// The unique mutex name.
    /// </summary>
    private const string UniqueMutexName = "DevToolbox.Wpf.Demo";

    #endregion

    public App()
    {
        _singletonApplicationManager = new SingletonApplicationManager(UniqueEventName, UniqueMutexName);
    }

    #region Methods Overrides

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _singletonApplicationManager.Register(this, async () =>
        {
            IocConfiguration.Setup();
            GlobalExceptionHandler.SetupExceptionHandling();

            var appUISettings = ServiceLocator.Current.GetInstance<IAppUISettings>();
            await appUISettings.InitializeAsync();
        }, () => { });
    }

    #endregion
}
