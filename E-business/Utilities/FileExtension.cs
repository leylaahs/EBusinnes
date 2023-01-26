using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace E_business.Utilities
{
    public static class FileExtension
    {
        public static bool CheckType(this IFormFile file, string type)
        => file.ContentType.Contains(type);

        public static bool CheckSize(this IFormFile file, int kb)
            => kb * 1024 < file.Length;

        public static string SaveFile(this IFormFile file, string path)
        {
            string fileName = ChangeFileName(file.FileName);
            using (FileStream fs = new FileStream(Path.Combine(path, fileName), (FileMode.Create)))
            {
                file.CopyTo(fs);
             }
            return fileName;    
        }
        static string ChangeFileName(string oldname)
        {
            string extension = oldname.Substring(oldname.LastIndexOf("."));
            if (oldname.Length < 32)
            {
                oldname = oldname.Substring(0, oldname.LastIndexOf("."));
            }
            else
            {
                oldname = oldname.Substring(0, 31);
            }
            string newName = Guid.NewGuid() + oldname + extension;
            return Guid.NewGuid() + oldname + extension;
        }

    }

}

