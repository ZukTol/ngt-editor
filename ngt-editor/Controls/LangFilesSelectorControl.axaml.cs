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
        private ICommand _addFilesCommand = ReactiveCommand.Create(() => { });

        public static readonly DirectProperty<LangFilesSelectorControl, IEnumerable> ItemsProperty =
            AvaloniaProperty.RegisterDirect<LangFilesSelectorControl, IEnumerable>(
                nameof(Items),
                o => o.Items,
                (o, v) => o.Items = v);

        public static readonly DirectProperty<LangFilesSelectorControl, ICommand> AddFilesCommandProperty =
            AvaloniaProperty.RegisterDirect<LangFilesSelectorControl, ICommand>(
                nameof(AddFilesCommand),
                o => o.AddFilesCommand,
                (o, v) => o.AddFilesCommand = v);
        
        
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
            get { return _items; }
            set { SetAndRaise(ItemsProperty, ref _items, value); }
        }

        [CanBeNull]
        public ICommand AddFilesCommand
        {
            get => _addFilesCommand;
            set => SetAndRaise(AddFilesCommandProperty, ref _addFilesCommand, value);
        }
    }
}
