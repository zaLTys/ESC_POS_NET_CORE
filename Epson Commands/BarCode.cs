using System;
using System.Linq;
using System.Text;
using ESC_POS_NET_CORE.Enums;
using ESC_POS_NET_CORE.Extensions;
using ESC_POS_NET_CORE.Interfaces.Command;

namespace ESC_POS_NET_CORE.Epson_Commands
{
    public class BarCode : IBarCode
    {
        public byte[] Code128(string code,Positions printString=Positions.NotPrint)
        {
            return new byte[] { 29, 119, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 102, 1 }) // font hri character
                .AddBytes(new byte[] { 29, 72, printString.ToByte() }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 73 }) // printCode
                .AddBytes(new[] { (byte)(code.Length + 2) })
                .AddBytes(new[] { '{'.ToByte(), 'C'.ToByte() })
                .AddBytes(code)
                .AddLF();
        }

        public byte[] Code39(string code, Positions printString = Positions.NotPrint)
        {
            var result = new byte[] { 29, 119, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 96 }) // Height
                .AddBytes(new byte[] { 29, 102, 2 }) // font hri character
                .AddBytes(new byte[] { 29, 72, printString.ToByte() }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 4 })
                .AddBytes(code)
                .AddBytes(new byte[] { 0 })
                .AddLF();


            var hexas = ByteArrayToString(new byte[] { 29, 119, 2 });
            var hexas2 = ByteArrayToString(new byte[] { 29, 104, 50 });
            var hexas3 = ByteArrayToString(new byte[] { 29, 102, 0 });
            var hexas4 = ByteArrayToString(new byte[] { 29, 119, 2 });
            var hexas5 = ByteArrayToString(new byte[] { 29, 107, 4 });
            var hexascode = code;
            var hexas7 = ByteArrayToString(new byte[] { 0 });

            var bytesas = StringToByteArray("1d48021d66011d68601d77021b61001d6b04393939393939000a");
            var bytesas2 = StringToByteArray("1D4802");
            var bytesas3 = StringToByteArray("1D6601");
            var bytesas4 = StringToByteArray("1D6860");
            var bytesas5 = StringToByteArray("1D7702");
            var bytesastranz = StringToByteArray("1D6B04");
            var bytesas11 = StringToByteArray("1D7701");
            var bytesas13 = StringToByteArray("1D7704");
            
            return result;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }

        public byte[] Code39Expanded(string code, Positions printString = Positions.NotPrint)
        {
            return
                Expanded(PrinterModeState.On)
                .AddBytes(new byte[] { 29, 119, 2 }) // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 102, 0 }) // font hri character
                .AddBytes(new byte[] { 29, 72, printString.ToByte() }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 4 })
                .AddBytes(code)
                .AddBytes(new byte[] { 0 })
                .AddBytes(Expanded(PrinterModeState.Off))
                .AddLF();
        }

        public byte[] Expanded(PrinterModeState state)
        {
            return state == PrinterModeState.On
                ? new byte[] { 29, '!'.ToByte(), 16 }
                : new byte[] { 29, '!'.ToByte(), 0 };
        }

        public byte[] Expanded(string value)
        {
            return Expanded(PrinterModeState.On)
                .AddBytes(value)
                .AddBytes(Expanded(PrinterModeState.Off))
                .AddLF();
        }

        public byte[] Ean13(string code, Positions printString = Positions.NotPrint)
        {
            if (code.Trim().Length != 13)
                return new byte[0];

            return new byte[] { 29, 119, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 72, printString.ToByte() }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 67, 12 })
                .AddBytes(code.Substring(0, 12))
                .AddLF();
        }
    }
}

