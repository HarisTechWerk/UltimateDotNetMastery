using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenges.SOLID_Principles.SRP
{
    public class InvoiceGenerator
    {
        public void GenerateInvoice()
        {
            Console.WriteLine("Invoice Generated.");
        }
    }

    public class InvoicePrinter
    {
        public void PrintInvoice()
        {
            Console.WriteLine("Printing Invoice...");
        }

        public class InvoiceEmailSender
        {
            public void SendInvoiceEmail()
            {
                Console.WriteLine("Invoice Invoice via Email.");
            }
        }
    }