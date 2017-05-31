using ModbusTCP;

namespace POPC_TRACEABILITY
{
    public class PlcCommand
    {
        public static void GetPlcRawData(Master master, ushort number, ref byte[] data)
        {
            master.ReadHoldingRegister(200, 1, 200, number, ref data);
        }
        public static void ResetSequence(Master master)
        {
            byte[] dummy = { };
            master.WriteSingleRegister(11, 1, 203, ModbusTcpHelper.WordArrayToByteArray(new[] { 1 }, 1), ref dummy);
        }
        public static void SetPoPcState(Master master, PopcStates states)
        {
            byte[] dummy = { };
            master.WriteSingleRegister(11, 1, 200, ModbusTcpHelper.WordArrayToByteArray(new[] {(int) states }, 1), ref dummy);
        }
        public static void SetOutputQty(Master master,int qty)
        {
            byte[] dummy = { };
            master.WriteSingleRegister(11, 1, 204, ModbusTcpHelper.WordArrayToByteArray(new[] { qty }, 1), ref dummy);
        }
        public static void SetNgQty(Master master, int qty)
        {
            byte[] dummy = { };
            master.WriteSingleRegister(11, 1,206, ModbusTcpHelper.WordArrayToByteArray(new[] { qty }, 1), ref dummy);
        }
        public static void SetProcessableQty(Master master, int qty)
        {
            byte[] dummy = { };
            master.WriteSingleRegister(11, 1,208, ModbusTcpHelper.WordArrayToByteArray(new[] { qty }, 1), ref dummy);
        }
        public static void SetNewOrderNumber(Master master)
        {
            byte[] dummy = { };
            master.WriteSingleRegister(11, 1,202, ModbusTcpHelper.WordArrayToByteArray(new[] { 1 }, 1), ref dummy);
        }
        public static void ResetNewOrderNumber(Master master)
        {
            byte[] dummy = { };
            master.WriteSingleRegister(11,1, 202, ModbusTcpHelper.WordArrayToByteArray(new[] { 0 }, 1), ref dummy);
        }

        public static void DebugIndicator(Master master, int value)
        {
            byte[] dummy = { };
            master.WriteSingleRegister(11, 1, 228, ModbusTcpHelper.WordArrayToByteArray(new[] { value }, 1), ref dummy);
        }
        public static void DebugIndicatorGreen(Master master, int value)
        {
            byte[] dummy = { };
            master.WriteSingleRegister(11, 1, 231, ModbusTcpHelper.WordArrayToByteArray(new[] { value }, 1), ref dummy);
        }
        public static void DebugIndicatorRed(Master master, int value)
        {
            byte[] dummy = { };
            master.WriteSingleRegister(11, 1, 232, ModbusTcpHelper.WordArrayToByteArray(new[] { value }, 1), ref dummy);
        }
        public static void DebugMode(Master master, int value)
        {
            byte[] dummy = { };
            master.WriteSingleRegister(11, 1, 201, ModbusTcpHelper.WordArrayToByteArray(new[] { value }, 1), ref dummy);
        }
    }
}
