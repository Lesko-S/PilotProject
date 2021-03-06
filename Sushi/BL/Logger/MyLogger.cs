using Sushi.Property;
using System;
using System.IO;

namespace Sushi.BL.Logger
{
    class MyLogger
    {
       private int counter = 1;
        public void Info(string message, string method)
        {
            StreamWriter sw;
            FileInfo log_file = new FileInfo(Constant.WayToLog + DateTime.Now.ToString("yyyy MM dd") +"_"+ counter + ".txt");
            log_file.Create().Close();
            long fileByteSize = log_file.Length;
            if (fileByteSize >= 30720) 
                File.Move(Constant.WayToLog + DateTime.Now.ToString("yyyy MM dd") + "_" + counter + ".txt",
                    Constant.WayToLog + DateTime.Now.ToString("yyyy MM dd") + "_" + counter++ + ".txt");
            sw = log_file.AppendText();
            sw.WriteLine(DateTime.Now.ToString("HH:mm:ss\t")+ "INFO " + $"[{method}]: " + message);
            sw.Close();
        }
        public void Debag(string message, string method)
        {
            StreamWriter sw;
            FileInfo log_file = new FileInfo(Constant.WayToLog + DateTime.Now.ToString("yyyy MM dd") + "_" + counter + ".txt");
            log_file.Create().Close();
            long fileByteSize = log_file.Length;
            if (fileByteSize >= 30720)
                File.Move(Constant.WayToLog + DateTime.Now.ToString("yyyy MM dd") + "_" + counter + ".txt",
                    Constant.WayToLog + DateTime.Now.ToString("yyyy MM dd") + "_" + counter++ + ".txt");
            sw = log_file.AppendText();
            sw.WriteLine(DateTime.Now.ToString("HH:mm:ss\t") + "DEBAG " + $"[{method}]: " + message);
            sw.Close();
        }
        public void Error(string message, string method)
        {
            StreamWriter sw;
            FileInfo log_file = new FileInfo(Constant.WayToLog + DateTime.Now.ToString("yyyy MM dd") + "_" + counter + ".txt");
            log_file.Create().Close();
            long fileByteSize = log_file.Length;
            if (fileByteSize >= 30720)
                File.Move(Constant.WayToLog + DateTime.Now.ToString("yyyy MM dd") + "_" + counter + ".txt",
                    Constant.WayToLog + DateTime.Now.ToString("yyyy MM dd") + "_" + counter++ + ".txt");
            sw = log_file.AppendText();
            sw.WriteLine(DateTime.Now.ToString("HH:mm:ss\t") + "ERROR " + $"[{method}]: " + message);
            sw.Close();
        }
    }
}
