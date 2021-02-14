using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ngt_editor.ViewModels;
using ngt_editor.Views.Base;

namespace ngt_editor.Views
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