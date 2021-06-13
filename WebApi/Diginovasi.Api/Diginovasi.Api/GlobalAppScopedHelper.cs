using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Diginovasi.Api
{
    public class GlobalAppScopedHelper
    {
        public static string UploadFile(IFormFile file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));
            if (!Directory.Exists(GlobalConstants.UploadFolderLocation))
            {
                Directory.CreateDirectory(GlobalConstants.UploadFolderLocation);
            }
            string filename = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string fullName = Path.Combine(GlobalConstants.UploadFolderLocation, filename);
            using(FileStream fs = new FileStream(fullName, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fs);
            }
            return fullName;
        }
        public static string GetUploadedFile(string localUrl)
        {
            return $"{localUrl.Replace("\\\\", "/")}";
        }
    }
}
