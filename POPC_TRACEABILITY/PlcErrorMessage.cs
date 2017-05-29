using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPC_TRACEABILITY
{
    public class PlcErrorMessage
    {
        public static string GetMessage(int error)
        {
            string message="";
            switch (error)
            {
                case 0:
                    message = "No Error";
                    break;
                default:
                    message = "Undifined Error";
                    break;
            }
            return message;
        }
    }
}
