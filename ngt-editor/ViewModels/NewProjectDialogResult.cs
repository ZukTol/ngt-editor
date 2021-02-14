using ngt_editor.Models;
using ngt_editor.ViewModels.Base;

namespace ngt_editor.ViewModels
{
    public class NewProjectDialogResult : DialogResultBase
    {
        public Project? Project { get; set; }
    }
}