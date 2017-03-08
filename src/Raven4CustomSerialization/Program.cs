using NodaMoney;
using System;

namespace Raven4CustomSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			using (var session = RavenFactory.Store.OpenSession())
			{
				Transaction tran = new Transaction();
				tran.Amount = Money.Parse("101", Currency.FromCode("EUR"));
				session.Store(tran);
				session.SaveChanges();
			}
		}
    }
}