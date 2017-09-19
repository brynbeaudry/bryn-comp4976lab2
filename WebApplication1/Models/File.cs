using System;
using WebApplication1.Model;

namespace WebApplication1.Model
{
    public class File
    {
        public File()
        {
        }

        public string Text { get; set; }
        public string RelativePath { get; set; }
        public string Content { get; set; }
        public string FileName { get; set; }
        public int Number { get; set; }
        public string Url { get; set; }
    }
}