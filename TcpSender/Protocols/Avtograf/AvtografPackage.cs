using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpSender.Protocols.Avtograf
{
    public class AvtografPackage
    {
        private static byte _Count = 0;

        private byte _Tittle;
        private byte[] _Length;
        private byte[] _Number;
        private byte _Type;
        private byte _SerialNumber;
        private byte[] _Password;
        // data
        private byte[] _Time;
        private byte[] _Lat;
        private byte[] _Lon;
        private byte[] _Pins;
        // checksum
        private byte _CheckSum;

        public AvtografPackage()
        {
            _Tittle = 0x24;
            _Type = 00;
            _Number = new byte[] { 92, 224, 13, 00 };
            _SerialNumber = _Count++;
            _Password = new byte[] { 32, 35, 36, 37, 33, 33, 35 };

            _Time = new byte[] { 188, 236, 62, 18 };
            _Lat = new byte[] { 56, 06, 30, 243 };
            _Lon = new byte[] { 172, 173, 64, 22 };
            _Pins = new byte[] { };
        }
    }
}
