using NgtEditor.Models;
using System.Collections.Generic;

namespace NgtEditor.Services
{
    public interface ILangFileSearchService
    {
        IReadOnlyList<LangFile> GetLangListInDirectory(string directoryPath);
        LangFile GetLangFromPath(string filePath);
    }
}