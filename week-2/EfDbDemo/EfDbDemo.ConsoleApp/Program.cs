using EfDbDemo.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace EfDbDemo.ConsoleApp {
    class Program {

        static DbContextOptions<Project0Context> s_dbContextOptions;

        static void Main(string[] args) {

            using var logStream = new StreamWriter("ef-logs.txt");

            var ob = new DbContextOptionsBuilder<Project0Context>();
            ob.UseSqlServer(GetConnectionString());
            ob.LogTo(logStream.WriteLine, LogLevel.Information);
            s_dbContextOptions = ob.Options;

            Console.WriteLine("Enter the user's ID and new name (separated by whitespace)");
            DisplayAllCustomers();
            Console.WriteLine();
            string input;
            string expected = "[0-9]+\\s\\w+\\s\\w+";
            string[] param;
            while (true) {
                input = Console.ReadLine();
                if (!Regex.IsMatch(input, expected)) {
                    Console.WriteLine("Valid Syntax: <UserId> <FirstName> <LastName>");
                    continue;
                }
                param = input.Split(null);
                break;
            }

            int customer_id = int.Parse(param[0]);
            string customer_firstname = param[1];
            string customer_lastname = param[2];

            try {
                UpdateCustomerName(customer_id, customer_firstname, customer_lastname);
            } catch (InvalidOperationException) {
                Console.WriteLine($"No customers with Id: {customer_id}");
            }
            Console.WriteLine();

            DisplayAllCustomers();
            Console.WriteLine();

            AddCustomer("Joe", "Biden", "joe.biden@gmail.com");

            DisplayAllCustomers();
            Console.WriteLine();

            RemoveCustomer("joe.biden@gmail.com");

            DisplayAllCustomers();
            Console.WriteLine();
        }

        static string GetConnectionString() {
            string path = "../../../../../../../Project0-connection-string.json";
            string json;
            try {
                json = File.ReadAllText(path);
            } catch (IOException) {
                Console.WriteLine("Bad path.");
                throw;
            }
            string connectionString = JsonSerializer.Deserialize<string>(json);
            return connectionString;
        }

        static void DisplayAllCustomers() {
            using var context = new Project0Context(s_dbContextOptions);
            var customers = context.Customers.OrderBy(c => c.Id);
            
            foreach (var customer in customers) {
                Console.WriteLine($"[{customer.Id}] {customer.LastName}, {customer.FirstName}");
            }
        }

        static void UpdateCustomerName(int id, string first, string last) {
            using var context = new Project0Context(s_dbContextOptions);
            var customer = GetCustomerById(id);
            customer.FirstName = first;
            customer.LastName = last;
            context.Customers.Update(customer);
            context.SaveChanges();
        }

        static Customer GetCustomerById(int id) {
            using var context = new Project0Context(s_dbContextOptions);
            return context.Customers.First(x => x.Id == id);
        }

        static Customer GetCustomerByEmail(string s) {
            using var context = new Project0Context(s_dbContextOptions);
            return context.Customers.First(x => x.Email == s);
        }

        static void AddCustomer(string firstName, string lastName, string email) {
            using var context = new Project0Context(s_dbContextOptions);
            var customer = new Customer() { FirstName = firstName, LastName = lastName, Email = email };
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        static void RemoveCustomer(string email) {
            using var context = new Project0Context(s_dbContextOptions);
            var customer = GetCustomerByEmail(email);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

    }
}
