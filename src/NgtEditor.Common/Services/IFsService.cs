namespace NgtEditor.Common.Services
{
    public interface IFsService
    {
        string ReadTxtFile(string filePath);
        void WriteTxtFile(string content, string filePath);
    }
}