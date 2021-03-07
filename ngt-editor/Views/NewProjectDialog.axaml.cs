using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NgtEditor.ViewModels;
using NgtEditor.Views.Base;

namespace NgtEditor.Views
{
    public class NewProjectDialog : DialogWindowBase<NewProjectDialogResult>
    {
        public NewProjectDialog()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}