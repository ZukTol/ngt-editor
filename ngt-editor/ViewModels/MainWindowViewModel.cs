using System;
using System.Collections.Generic;
using System.Text;

namespace ngt_editor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";

        public void OnOpen()
        {
        }
    }
}