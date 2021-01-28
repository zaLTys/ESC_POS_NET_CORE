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
            Printer printer = new Printer("BIXOLON SRP-E300");

            PrintBarcodes(printer);
        }

        private static void PrintBarcodes(Printer printer)
        {
            printer.SetLineHeight(40);
            printer.Code128("CEINTVDG1SVJY258C", Positions.BelowBarcode);
            printer.Ean13("CEINTVDG1SVJY258C", Positions.BelowBarcode);
            printer.Code39("CEINTVDG1SVJY258C", Positions.BelowBarcode);
            printer.Separator('=');
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
