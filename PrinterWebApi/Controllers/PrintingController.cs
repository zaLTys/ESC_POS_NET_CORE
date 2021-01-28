using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESC_POS_NET_CORE;
using ESC_POS_NET_CORE.Enums;

namespace PrinterWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrintingController : ControllerBase
    {
        private readonly ILogger<PrintingController> _logger;

        public PrintingController(ILogger<PrintingController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public bool Print()
        {
            Printer printer = new Printer();
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
            return true;
        }
    }
}
