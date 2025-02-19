using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenges.SOLID_Principles.SRP
{
    public class Invoice
    {
        public void GenerateInvoice()
        {
            Console.WriteLine("Invoice generated successfully!");
        }

        public void PrintInvoice()
        {
            Console.WriteLine("Invoice printed successfully!");
        }

        public void SendInvoiceEmail()
        {
            Console.WriteLine("Invoice sent successfully!");
        }
    }
}