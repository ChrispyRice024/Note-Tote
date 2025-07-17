using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Tote.Classes
{
    public class ErrorHandling
    {
        public static string CatchException(Exception ex)
        {
            return "Catch Error: " +
                ex.Message + "\n" +
                "Method That triggered exception: " +
                ex.TargetSite;
        }
    }
}
