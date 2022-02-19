using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NgtEditor.Models
{
    public class Project
    {
        public IReadOnlyList<LangFile> LangList { get; set; }
        public LocalizationFramework Framework { get; set; }
        [JsonIgnore]
        public string ProjectFilePath { get; set; }
    }
}