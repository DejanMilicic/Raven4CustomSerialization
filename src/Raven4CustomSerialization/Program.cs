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
				tran.Money = new Money { Amount = 10 };
				session.Store(tran);
				session.SaveChanges();
			}
		}
    }
}