using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConvertToHTML
{
    public static class ToHTML
    {
        public static void ConvertToHTML<T>(this T argument)
        {
            string output = "";

            foreach (PropertyInfo item in argument.GetType().GetProperties())
            {
                output += $"<li>{item.Name} - {GetPropValue(argument, item.Name)}";
            }

            string layout = string.Format($"<!DOCTYPE html>" +
                $"<html>" +
                    $"<head>" +
                        $"<title>" +
                            $"Convert to HTML" +
                        $"</title>" +
                    $"</head>" +
                    $"<body>" +
                        $"<h3>Responce</h3>" +
                        $"<ul>" +
                            $"{output}" +
                        $"</ul>" +
                    $"</body>" +
                $"</html>");

            using (FileStream fstream = new FileStream(@"D:\ITA\index.html", FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Unicode.GetBytes(layout);
                fstream.Write(array, 0, array.Length);
            }

            Process.Start(@"C:\Program Files\Mozilla Firefox\firefox.exe", @"D:\ITA\index.html");
        }
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
