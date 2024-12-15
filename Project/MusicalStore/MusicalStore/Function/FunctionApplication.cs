using System.Text;

namespace MusicalStore.Function
{
    public class FunctionApplication
    {
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
    }
}
