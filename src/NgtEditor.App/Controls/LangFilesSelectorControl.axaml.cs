using System.Collections;
using System.Windows.Input;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using JetBrains.Annotations;
using ReactiveUI;

namespace NgtEditor.Avalonia.Controls
{
    public class LangFilesSelectorControl : UserControl
    {
        private IList _items = new AvaloniaList<object>();
        private object _selectedItem;
        private ICommand _scanFolderCommand = ReactiveCommand.Create(() => { });
        private ICommand _addFileCommand = ReactiveCommand.Create(() => { });

        public static readonly DirectProperty<LangFilesSelectorControl, IList> ItemsProperty =
            AvaloniaProperty.RegisterDirect<LangFilesSelectorControl, IList>(
                nameof(Items),
                o => o.Items,
                (o, v) => o.Items = v);

        public static readonly DirectProperty<DataGrid, object> SelectedItemProperty =
            AvaloniaProperty.RegisterDirect<DataGrid, object>(
                nameof(SelectedItem),
                o => o.SelectedItem,
                (o, v) => o.SelectedItem = v,
                defaultBindingMode: BindingMode.TwoWay);
        
        public static readonly DirectProperty<LangFilesSelectorControl, ICommand> ScanFolderCommandProperty =
            AvaloniaProperty.RegisterDirect<LangFilesSelectorControl, ICommand>(
                nameof(ScanFolderCommand),
                o => o.ScanFolderCommand,
                (o, v) => o.ScanFolderCommand = v);
        
        public static readonly DirectProperty<LangFilesSelectorControl, ICommand> AddFileCommandProperty =
            AvaloniaProperty.RegisterDirect<LangFilesSelectorControl, ICommand>(
                nameof(AddFileCommand),
                o => o.AddFileCommand,
                (o, v) => o.AddFileCommand = v);
        
        
        public LangFilesSelectorControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public IList Items
        {
            get => _items;
            set => SetAndRaise(ItemsProperty, ref _items, value);
        }
        
        public object SelectedItem
        {
            get { return _selectedItem; }
            set { SetAndRaise(SelectedItemProperty, ref _selectedItem, value); }
        }
        
        [CanBeNull]
        public ICommand ScanFolderCommand
        {
            get => _scanFolderCommand;
            set => SetAndRaise(ScanFolderCommandProperty, ref _scanFolderCommand, value);
        }
        
        [CanBeNull]
        public ICommand AddFileCommand
        {
            get => _addFileCommand;
            set => SetAndRaise(AddFileCommandProperty, ref _addFileCommand, value);
        }

        private void RemoveSelected(object sender, RoutedEventArgs e)
        {
            if (SelectedItem != null)
            {
                Items.Remove(SelectedItem);
            }
        }
    }
}
