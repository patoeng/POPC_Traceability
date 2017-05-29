using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPC_TRACEABILITY
{
    public enum EquipmentState
    {
        NotReady,
        WaitingForOrderNumber,
        WaitingForProcessableQty,
        WaitingForPoPcOkOrNgBtn,
        WaitingForOkOrNgBtn
    }
}
