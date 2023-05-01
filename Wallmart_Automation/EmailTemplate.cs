using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallmart_Automation
{
    public class EmailTemplate
    {
        public static void EmailTextinHTML(string HtmlContent, string input)
        {
            string filepath = @"C:\Logs\";
            if(!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            filepath = filepath + "Email-" + (input == "0" ? "Daily" : "Weekly") + DateTime.Today.ToString("MM-dd-yy") + ".html";
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Dispose();
            }
            File.WriteAllText(filepath, string.Empty);
            using (StreamWriter sw = File.AppendText(filepath))
            {
                sw.WriteLine(HtmlContent);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
