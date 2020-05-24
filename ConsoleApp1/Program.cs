using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IDataService<User> userService = new GenericDataService<User>(new SimpleTraderDbContextFactory());
            var newUser = await userService.Create(new User() { Username = "Kumar" });

            Console.WriteLine("GetALL");
            var users = await userService.GetAll();
            Console.WriteLine("Id       Name");
            foreach (User user in users)
            {
                Console.WriteLine(user.Id + "\t" + user.Username);
            }

            Console.WriteLine("\nGet by Id");
            var myuser = await userService.Get(newUser.Id);
            Console.WriteLine(myuser.Id + "\t" + myuser.Username);

            Console.WriteLine("\nUpdate");
            var UpdatedUser = await userService.Update(newUser.Id, new User { Username = "Bala" });
            Console.WriteLine(UpdatedUser.Id + "\t" + UpdatedUser.Username);

            Console.WriteLine("\nDelete");
            bool IsDeleted = await userService.Delete(UpdatedUser.Id);
            Console.WriteLine(UpdatedUser.Username + " is Deleted : " + IsDeleted);
        }
    }
}
