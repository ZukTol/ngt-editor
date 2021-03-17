using System.Collections.Generic;
using System.IO;
using System.Linq;
using NgtEditor.Models;

namespace NgtEditor.Services.Impl
{
    internal class LangFileSearchService : ILangFileSearchService
    {
        public IReadOnlyList<LangFile> GetLangListInDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException(directoryPath);
            }

            var dirInfo = new DirectoryInfo(directoryPath);
            var jsonFileList = dirInfo.GetFiles($"{Common.Constants.Ctrl.Asterisk}{Constants.FileExt.Json}");
            var result = jsonFileList.Select(x => new LangFile {Lang = Path.GetFileNameWithoutExtension(x.Name), Path = x.FullName}).ToArray();
            return result;
        }
    }
}