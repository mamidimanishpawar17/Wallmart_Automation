using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Wallmart_Automation
{
    public class Program
    {
        static void Main(string[] args)
        {
            ImportData importData = new ImportData();
            Email email = new Email();

            //    string stEmail = importData.DisplayData("0");
            //    string stFiveWeekData = importData.DisplayData("1");
            //    string emailData = stEmail.ToString() + "<br/></table>" + stFiveWeekDat.ToSting() + "<br/><br/><br/> ThankYou! <br/> Lucky";
            //    Console.WriteLine("Sending Email");
            //    Email.sendEmail(emailData);
        }

    }
}
