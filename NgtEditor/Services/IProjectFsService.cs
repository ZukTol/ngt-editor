using NgtEditor.Models;

namespace NgtEditor.Services
{
    public interface IProjectFsService
    {
        Project LoadProject(string filePath);
        void SaveProject(Project project);
    }
}