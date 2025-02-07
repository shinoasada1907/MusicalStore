using Microsoft.AspNetCore.Hosting;
using System.Globalization;
using System.Text;

namespace MusicalStore.Function
{
    public class FunctionApplication
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FunctionApplication(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public static string GenerateId(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder result = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                // Lấy ký tự ngẫu nhiên từ danh sách và thêm vào kết quả
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return "File is empty";
            }

            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var fileExtension = Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, file.FileName);
            int counter = 1;

            // Kiểm tra và tạo tên tệp mới nếu tệp đã tồn tại
            while (System.IO.File.Exists(filePath))
            {
                filePath = Path.Combine(uploadsFolder, $"{fileName}_{counter}{fileExtension}");
                counter++;
            }

            // Lưu tệp tin
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            string filename = Path.GetFileName(filePath);
            return filename;
        }

        public static string ConvertToUnsign(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

            // Normalize the string to decompose accents into base characters
            string normalizedString = input.Normalize(NormalizationForm.FormD);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            // Normalize back to the composed form and return
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
