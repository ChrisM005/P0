using System;
using System.Collections.Generic;
using Models;

namespace UI
{
    public class MainMenu : IMenu
    {
        /*private IRevBL _revbl;
        public MainMenu(IRevBL bl)
        {
            _Revbl = bl;
        }*/

        public void Start()
        {
            List<Restaurant> res = new List<Restaurant>();
            string rname;
            bool repeat = true;
            do
            {
                Console.WriteLine("Welcome to Resteraunt Reviewer!");
                Console.WriteLine("0) Exit Resterant Reviewer");
                Console.WriteLine("1) New User");
                Console.WriteLine("2) Display List of Restaurants");
                Console.WriteLine("3) Search for a Restaurant");
               // Console.WriteLine("4) Search for a Resteraunt");
                //Console.WriteLine("5) Search for a Resteraunt");

                switch(Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("Exiting ...");
                        repeat = false;
                    break;
                    case "1":
                        CreateUser();
                    break;
                    case "2":
                        DispResteraunt(res);                        
                    break;
                    case "3":
                        SearchResteraunt(rname);
                    break;
                    default:
                        Console.WriteLine("Invalid input, try again.");
                    break;
                }
            } while(repeat);
        }
        //Create User
        public void CreateUser()
        {
            string username;
            string password;
            User userdata;
            do
            {
                Console.WriteLine("Enter Username: ");
                username = Console.ReadLine();
            }while(String.IsNullOrWhiteSpace(username));
            do    
            {    Console.WriteLine("Enter Password: ");
                password = Console.ReadLine();
            }while(String.IsNullOrWhiteSpace(password));
            userdata = new User();
            userdata.uname = username;
            userdata.pass = password;
            Console.WriteLine($"{userdata.uname} was successfully added!");
        }

        //Display Restaurant
        public void DispResteraunt(List<Restaurant> r)
        {
            Console.WriteLine("--------------------------------");
            foreach(int element in r)
            {
                Console.WriteLine(r.Name);
                Console.WriteLine($"{r.Rating} out of 5");
                Console.WriteLine(r.Location);
                Console.WriteLine(r.ZipCode);
                Console.WriteLine("--------------------------------");
            }
        }

        //Search for the Restaurant
        public void SearchResteraunt(string input)
        {
            List<Restaurant> r = new List<Restaurant>();
            List<User> u = new List<User>();
            string yn;
            string usr;
            string pw;
            int count = 0;
            Console.WriteLine("Search the Resterant name: ");
            input = Console.ReadLine();
            foreach(int element in r)
            {
                if(input == r.Name)
                {
                    Console.WriteLine("Found Restaurant!");
                    Console.WriteLine("Do you want to Review this Restaurant? (y/n)");
                    yn = Console.ReadLine();
                    if(yn != "y" || yn != "n")
                    {
                        do
                        {
                            Console.WriteLine("Invalid Input. Do you want to Review this Restaurant? (y/n)");
                            yn = Console.ReadLine();
                        }while(yn != "y" || yn != "n");
                    }
                    if(yn == "y")
                    {
                        Console.WriteLine("Enter your username: ");
                        usr = Console.ReadLine();
                        Console.WriteLine("Enter your password: ");
                        pw = Console.ReadLine();
                        
                        CheckUser(usr,pw);
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }
        
        //Check if the user exists
        public User CheckUser(string username, string password)
        {
            List<User> u = new List<User>();
            foreach(int element in u)
            {
                if(username == u.uname && password == u.pass)
                {
                    
                    return u;
                }
            }
            return null;

        }
        
        public void MakeReview()
        {
            
        }
    }
}