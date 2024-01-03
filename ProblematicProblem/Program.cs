using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static Random rng = new Random();
        //static Random rnd;
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            string userResponse = Console.ReadLine();
            if (userResponse.ToLower() == "yes")
            {
                Console.WriteLine();
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is your age? ");
                int userAge = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                userResponse = Console.ReadLine();
                bool seeList = (userResponse.ToLower() == "sure") ? seeList = true : seeList = false;
                if (seeList)
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                    userResponse = Console.ReadLine();
                    bool addToList = (userResponse.ToLower() == "yes") ? addToList = true : addToList = false;
                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);
                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? yes/no: ");
                        userResponse = Console.ReadLine();
                        addToList = (userResponse.ToLower() == "yes") ? addToList = true : addToList = false;
                    }
                }

                while (cont)
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    do
                    {
                        int randomNumber = rng.Next(activities.Count);
                        string randomActivity = activities[randomNumber];
                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                        if (userAge < 21 && randomActivity == "Wine Tasting")
                        {
                            Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                            Console.WriteLine("Pick something else!");
                            activities.Remove(randomActivity);
                            cont = false;
                        }
                        else
                        {
                            Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                            Console.WriteLine();
                            userResponse = Console.ReadLine();
                            if (userResponse.ToLower() == "redo")
                            {
                                cont = false;
                            }
                            else
                            {
                                cont = true;
                                break;
                            }
                        }

                    } while (cont == false);
                    Console.WriteLine("Thank You!");
                    break;
                }
            } else if (userResponse.ToLower() == "no")
            {
                Console.WriteLine("Thank You!");
            }
        }
    }
}