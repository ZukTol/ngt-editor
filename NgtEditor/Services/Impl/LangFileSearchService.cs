using System.Collections.Generic;
using System.IO;
using System.Linq;
using NgtEditor.Common.Utils;
using NgtEditor.Models;

namespace NgtEditor.Services.Impl
{
    internal class LangFileSearchService : ILangFileSearchService
    {
        public IReadOnlyList<LangFile> GetLangListInDirectory(string directoryPath)
        {
            CheckHelper.CheckNull(directoryPath, nameof(directoryPath));
            
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException(directoryPath);
            }

            var dirInfo = new DirectoryInfo(directoryPath);
            var jsonFileList = dirInfo.GetFiles($"{Common.Constants.Ctrl.Asterisk}{Constants.FileExt.Json}");
            var result = jsonFileList.Select(x => CreateLang(x)).ToArray();
            return result;
        }

        public LangFile GetLangFromPath(string filePath)
        {
            CheckHelper.CheckNull(filePath, nameof(filePath));
            
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Empty, filePath);
            }

            var fileInfo = new FileInfo(filePath);
            return CreateLang(fileInfo);
        }
        
        private static LangFile CreateLang(FileInfo fileInfo)
        {
            return new LangFile {Lang = Path.GetFileNameWithoutExtension(fileInfo.Name), Path = fileInfo.FullName};
        }

        
    }
}