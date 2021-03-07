using NgtEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgtEditor.Services.Impl
{
    internal class LangFileSearchService : ILangFileSearchService
    {
        public IReadOnlyList<LangFile> GetLangListInDirectory(string directoryPath)
        {
            return new List<LangFile>();
        }
    }
}