using System;
using System.Collections.Generic;
using System.Drawing;
using ESC_POS_NET_CORE;
using ESC_POS_NET_CORE.Enums;

namespace ESC_POS_NET_CORE_Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Barkodai = 1, Image =2");
            var selection = Console.ReadLine();

            Printer printer = new Printer("BIXOLON SRP-E300");

            if(selection == "1")
                PrintBarcodes(printer);
            if (selection == "2")
                PrintImage(printer);
        }

        private static void PrintBarcodes(Printer printer)
        {
            printer.Append("Code 128");
            printer.Code128("123456789");
            printer.Separator();
            printer.Append("Code39");
            printer.Code39("123456789", Positions.BelowBarcode);
            printer.Separator('=');
            printer.Append("Ean13");
            printer.Ean13("1234567891231", Positions.AbovBarcode);
            printer.FullPaperCut();
            printer.PrintDocument();
        } 
        
        private static void PrintImage(Printer printer)
        {
            Bitmap image = new Bitmap(Image.FromFile("Icon.bmp"));
            printer.Image(image);
            printer.FullPaperCut();
            printer.PrintDocument();
        }


    }
}
