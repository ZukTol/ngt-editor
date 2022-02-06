using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Input;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JetBrains.Annotations;
using ReactiveUI;

namespace NgtEditor.Avalonia.Controls
{
    public class LangFilesSelectorControl : UserControl
    {
        private IEnumerable _items = new AvaloniaList<object>();
        private ICommand _scanFolderCommand = ReactiveCommand.Create(() => { });
        private ICommand _addFileCommand = ReactiveCommand.Create(()=>{});

        public static readonly DirectProperty<LangFilesSelectorControl, IEnumerable> ItemsProperty =
            AvaloniaProperty.RegisterDirect<LangFilesSelectorControl, IEnumerable>(
                nameof(Items),
                o => o.Items,
                (o, v) => o.Items = v);

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

        public IEnumerable Items
        {
            get => _items;
            set => SetAndRaise(ItemsProperty, ref _items, value);
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
    }
}
