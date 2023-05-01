namespace Wallmart_Automation
{
    public class Elogging
    {
        public static void SendErrorToText(Exception ex)
        {
            var line =Environment.NewLine;
            try
            {
                string filepath = @"C:\Logs\";
                if(!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                if(!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    string error = "Error Line No :" + " " + ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7) + line +
                                    "Error Message:" + " " + ex.GetType().Name.ToString() + line +
                                    "Exception Type:" + " " + ex.GetType().ToString() + line +
                                    "Call Stack:" + " " + ex.StackTrace.ToString() + line;
                    sw.WriteLine("----------Exception Details on " + " " + DateTime.Now.ToString() + "----------");
                    sw.WriteLine("------------------------------------------------------------------------------");
                    sw.WriteLine(error);
                    sw.WriteLine("-----------------------------------*END*--------------------------------------");
                    sw.Flush(); 
                    sw.Close();
                }
            }
            catch (Exception e)
            {

                e.ToString(); 
            }
        }
    }
}
