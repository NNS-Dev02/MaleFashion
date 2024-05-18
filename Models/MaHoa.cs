using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MaleFashion.Models
{
    public class MaHoa
    {
        //--- Hàm mã hóa mật khẩu ---//
        public static string encryptSHA256(string PlainText)
        {
            string result = "";
            //--- Create a SHA256 object ---//
            using (SHA256 bb = SHA256.Create())
            {
                //--- Convert plain text to a bytes array ---//
                byte[] sourceData = Encoding.UTF8.GetBytes(PlainText);
                //--- Compute Hash and return a byte array ---//
                byte[] hashResult = bb.ComputeHash(sourceData);
                result = BitConverter.ToString(hashResult);
            }
            return result;
        }
    }
}