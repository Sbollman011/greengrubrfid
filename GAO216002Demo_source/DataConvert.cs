using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace UHFAPP
{
    public class DataConvert
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            try
            {
                for (int i = 0; i < s.Length; i += 2)
                    buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            }
            catch (System.Exception ex)
            {
            }
            return buffer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            try
            {
                StringBuilder sb = new StringBuilder(data.Length * 3);
                foreach (byte b in data)
                    sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
                return sb.ToString().ToUpper();
            }
            catch (System.Exception ex)
            {
                return string.Empty;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ByteArrayToHexString(byte[] data,int leng)
        {
            try
            {
                StringBuilder sb = new StringBuilder(data.Length * 3);
                for (int k = 0; k < leng; k++)
                {
                    sb.Append(Convert.ToString(data[k], 16).PadLeft(2, '0').PadRight(3, ' '));
                }
                return sb.ToString().ToUpper();
            }
            catch (System.Exception ex)
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string DecimalToHexString(int data) {
           return Convert.ToString(data, 16);
        }
         
    }
}
 