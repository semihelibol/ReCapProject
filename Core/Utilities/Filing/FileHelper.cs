using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Filing
{
    public class FileHelper
    {
        public static IResult Add(string filePath,IFormFile file)
        {
            var tempPath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(tempPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Move(tempPath, filePath);
            if (!File.Exists(filePath)) 
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        
        public static IResult Delete(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new ErrorResult("Dosya Bulunamadı.");
            }
            File.Delete(filePath);            
            return new SuccessResult();                        
        }               

        public static string GenerateGUIDFileName(IFormFile file,int length)
        {           
            return Guid.NewGuid().ToString().Substring(0, length) + new FileInfo(file.FileName).Extension;            
        }
        
        public static IResult CheckFileType(IFormFile file, string[] extensions)
        {
            var extension = new FileInfo(file.FileName).Extension;
            foreach (var ext in extensions)
            {
                if (ext == extension)
                {
                    return new SuccessResult();                    
                }
            }
            return new ErrorResult($"Desteklenmeyen Dosya Formatı: {extension}");
        }        
    }
}
