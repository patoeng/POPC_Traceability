using System;
using System.Net;

namespace POPC_TRACEABILITY
{
    public class ModbusTcpHelper
    {
         public static int[] ByteArrayToWordArray (byte[] dataBytes)
        {
            if (dataBytes.Length < 2) return null;
            var word = new int[dataBytes.Length / 2];
            for (int x = 0; x < dataBytes.Length; x = x + 2)
            {
                word[x / 2] = dataBytes[x] * 256 + dataBytes[x + 1];
            }
            return word;
        }

        public static byte[] WordArrayToByteArray(int[] dataWord, int num)
        {

            var data = new Byte[num * 2];
            for (int x = 0; x < num; x++)
            {
                byte[] dat = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short) dataWord[x]));
                data[x * 2] = dat[0];
                data[x * 2 + 1] = dat[1];
            }
            return data;
        }
    }
}
