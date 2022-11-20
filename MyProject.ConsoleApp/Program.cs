using MyProject.Mock;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Repositories;
using System;

namespace MyProject.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var mock = new MockContext();
            var db = new MockContext();
            mock.Roles.ForEach(r =>
            {
                Console.WriteLine(r.ToString());
            });

            var roleRepository = new RoleRepository(db);
            roleRepository.GetAll();

            Console.ReadLine();
        }
    }
}
