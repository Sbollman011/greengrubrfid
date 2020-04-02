using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace UHFAPP
{
    public class FileManage
    {

        static string path = System.Environment.CurrentDirectory + "\\log.txt";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <param name="appdend"></param>
        public static void WriterFile(string path,string data,bool appdend)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path, appdend);
                sw.Write(data);
                sw.Close();
            }
            catch (System.Exception ex)
            {
            	
            }
        }

        public static string ReadFile(string path)
        {
            string data = "";
            StreamReader sr = new StreamReader(path, Encoding.Default);
            data = sr.ReadToEnd();
            sr.Close();
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static void WriterLog(LogType type,string log)
        {
            WriterFile(path, log,true);
       
        }


        public enum LogType {
           Error
        
        }

     
     
    }
}
