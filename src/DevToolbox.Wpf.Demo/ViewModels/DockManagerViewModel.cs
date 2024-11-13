﻿using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevToolbox.Wpf.Controls;

namespace DevToolbox.Wpf.Demo.ViewModels;

public class DockManagerViewModel : ObservableObject
{
    #region Properties

    public ICommand NewDocumentContentCommand { get; }

    public ICommand ShowDockableContentCommand { get; }

    public ObservableCollection<object> DocumentControItems { get; } = [];

    public ObservableCollection<object> DockableControlItems { get; } = [];

    #endregion

    public DockManagerViewModel()
    {
        DockableControlItems.Add(new DockableControlViewModel()
        {
            Dock = Dock.Left,
            Items = 
            {
                new FlowChartStencilsViewModel()
                {
                    Header = "Flow Chart Stencils",
                    Icon = new BitmapImage(new Uri(@"pack://application:,,,/DevToolbox.Wpf.Demo;component/Assets/flow-chart.ico"))
                }
            }
        });

        DockableControlItems.Add(new DockableControlViewModel()
        {
            Dock = Dock.Right,
            Items =
            {
                new ColorPaletteViewModel()
                {
                    Header = "Color Palette",
                    Icon = new BitmapImage(new Uri(@"pack://application:,,,/DevToolbox.Wpf.Demo;component/Assets/color-palette.ico"))
                },
                new ColorPickerViewModel()
                {
                    Header = "Color Picker",
                    Icon = new BitmapImage(new Uri(@"pack://application:,,,/DevToolbox.Wpf.Demo;component/Assets/color-picker.ico"))
                }
              }
        });

        DocumentControItems.Add(new DocuemntControlViewModel()
        {
            Items =
            {
                new DiagramCanvasViewModel() { Header = "Canvas" },
                new DiagramCanvasViewModel() { Header = "Canvas 2" },
                new DiagramCanvasViewModel() { Header = "Canvas 3" },
                new DiagramCanvasViewModel() { Header = "Canvas 4" },
                new DiagramCanvasViewModel() { Header = "Canvas 5" },
                new DiagramCanvasViewModel() { Header = "Canvas 6" },
                new DiagramCanvasViewModel() { Header = "Canvas 7" },
                new DiagramCanvasViewModel() { Header = "Canvas 8" },
                new DiagramCanvasViewModel() { Header = "Canvas 9" },
                new DiagramCanvasViewModel() { Header = "Canvas 10" },
                new DiagramCanvasViewModel() { Header = "Canvas 11" },
                new DiagramCanvasViewModel() { Header = "Canvas 12" },
                new DiagramCanvasViewModel() { Header = "Canvas 13" },
                new DiagramCanvasViewModel() { Header = "Canvas 14" },
                new DiagramCanvasViewModel() { Header = "Canvas 15" },
                new DiagramCanvasViewModel() { Header = "Canvas 16" },
                new DiagramCanvasViewModel() { Header = "Canvas 17" },
                new DiagramCanvasViewModel() { Header = "Canvas 18" },
                new DiagramCanvasViewModel() { Header = "Canvas 19" },
                new DiagramCanvasViewModel() { Header = "Canvas 20" },
                new DiagramCanvasViewModel() { Header = "Canvas 21" },
                new DiagramCanvasViewModel() { Header = "Canvas 22" },
                new DiagramCanvasViewModel() { Header = "Canvas 23" }
            }
        });

        //if (!string.IsNullOrEmpty(Properties.Settings.Default.DockingLayoutState))
        //{
        //    dockManager.RestoreLayoutFromXml(Properties.Settings.Default.DockingLayoutState, new DockingLibrary.GetContentFromTypeString(this.GetContentFromTypeString));
        //}

        NewDocumentContentCommand = new RelayCommand(NewDocumentContentCommandExecute);
        ShowDockableContentCommand = new RelayCommand(ShowDockableContentCommandExecute);
        DockableControlItems.CollectionChanged += DockableControlItems_CollectionChanged;
        DocumentControItems.CollectionChanged += DocumentContentItems_CollectionChanged;
    }

    #region Methods

    private void DocumentContentItems_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Debug.WriteLine("DocumentControItems: " + DocumentControItems.Count);
    }

    private void DockableControlItems_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Debug.WriteLine("DockableControlItems: " + DockableControlItems.Count);
    }

    private void NewDocumentContentCommandExecute()
    {
        //DocumentControItems.Cast<DocuemntControlViewModel>().FirstOrDefault().ChildItems.Add(new ContentItemViewModel() { Header = "Document", Content = "new Document" });
    }

    private void ShowDockableContentCommandExecute()
    {
        //(obj as DockableContentItem)?.Show();
    }

    private void OnClosing(object sender, EventArgs e)
    {
        //Properties.Settings.Default.DockingLayoutState = dockManager.GetLayoutAsXml();
        //Properties.Settings.Default.Save();
    }

    private DockableItem? GetContentFromTypeString(string type)
    {
        //if (type == typeof(PropertyWindow).ToString())
        //    return propertyWindow;
        //else if (type == typeof(ListWindow).ToString())
        //    return listWindow;
        return null;
    }

    #endregion
}