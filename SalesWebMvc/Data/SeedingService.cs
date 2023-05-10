using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; // Db has been seeded!
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Laptops");
            Department d3 = new Department(3, "Smartphones");
            Department d4 = new Department(4, "Tablets");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1994, 4, 21), 1400.00, d1);
            Seller s2 = new Seller(2, "Ana Green", "ana@gmail.com", new DateTime(1995, 4, 22), 1400.00, d2);
            Seller s3 = new Seller(3, "Alex Gray", "alex@gmail.com", new DateTime(1996, 4, 23), 1400.00, d1);
            Seller s4 = new Seller(4, "Nuno Red", "nuno@gmail.com", new DateTime(1997, 4, 24), 1400.00, d3);
            Seller s5 = new Seller(5, "Donald Pink", "donald@gmail.com", new DateTime(1998, 4, 25), 1400.00, d4);
            Seller s6 = new Seller(6, "Timóteo Black", "timoteo@gmail.com", new DateTime(1999, 4, 26), 1400.00, d4);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2023, 05, 05), 11000.00, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2023, 05, 06), 15000.00, SaleStatus.Billed, s3);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2023, 05, 07), 13000.00, SaleStatus.Billed, s6);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2023, 05, 08), 19000.00, SaleStatus.Billed, s4);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2023, 05, 09), 5000.00, SaleStatus.Billed, s5);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            _context.SalesRecord.AddRange(r1, r2, r3, r3, r5);

            _context.SaveChanges();

        }
    }
}
