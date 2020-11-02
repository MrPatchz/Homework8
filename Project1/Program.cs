
/// Homework No.   Homework 8
/// File Name:     Project1.cs
/// @author:       Jacques Zwielich
/// Date:          Nov 1st. 2020
///
/// Problem Statement: Duel to the death, with each contestant trying to kill the best other duelist. Record them dueling 10000 times
///    
/// Overall Plan (step-by-step, how you want the code to make it happen):
/// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
///             Duelist Class
/// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/// 1. Create Intance variables for Duelist
/// 2. Create a construstor that requires all instance variables
/// 3. Create setters and getters for all variables
/// 4. Create a shootAtTarget method that takes two other duelist variables
/// 5. generate a random number and see if its within' this dueslist skill
/// 6. if the random number is within' their skill and the this duelist is kill the next, alive and highest skill dueslist
/// 7. return a 1 if they kill someone otherwise return a 0
/// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
///             Main
/// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/// 1. Keep track of the number of wins for each person
/// 2. Create a variable incsae Aaron decides to mix up his strategy
/// 3. in a do while loop (looping 10000 times)
/// 4. Create 3 duelist and establish how many are alive
/// 5. create another do while loop while there is more than one person alive
/// 6. Have Aaron shoot first (unless we decide to skip his first turn)
/// 7. then have bob shoot next
/// 8. then have charlie shoot
/// 9. Keep looping till only one person is left
/// 10. Record who won and loop again
/// 11. Print how many times each duelist won

using System;

namespace Project1
{
    class Program
    {
        static void Main(String[] args)
        {
            int aWin = 0;
            int bWin = 0;
            int cWin = 0;
            int number = 0;
            //This variable allows us to skip aarons first shot
            bool skip = true;
            do
            {
                Duelist aaron = new Duelist("Aaron", true, 3333);
                Duelist bob = new Duelist("Bob", true, 5000);
                Duelist charlie = new Duelist("Charlie", true, 9950);
                int alive = 3;
                do
                {
                    if (!(skip))
                    {
                        alive -= aaron.shootAtTarget(bob, charlie);
                    }
                    else
                    {
                        skip = false;
                    }
                    alive -= bob.shootAtTarget(aaron, charlie);
                    alive -= charlie.shootAtTarget(aaron, bob);

                } while (alive != 1);

                if (aaron.IsAlive)
                {
                    aWin += 1;
                }
                if (bob.IsAlive)
                {
                    bWin += 1;
                }
                if (charlie.IsAlive)
                {
                    cWin += 1;
                }
                number += 1;
            } while (number != 100000);
            Console.WriteLine("Aaron won " + aWin + "/100000 times");
            Console.WriteLine("Bob won " + bWin + "/100000 times");
            Console.WriteLine("Charlie won " + cWin + "/100000 times");
        }
    }
    class Duelist
    {
        private string name;
        private bool isAlive;
        private int skill;

        public Duelist(string name,  bool isAlive, int skill){
            this.name = name;
            this.isAlive = isAlive;
            this.skill = skill;
        }

       public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public int Skill
        {
            get { return skill; }
            set { skill = value; }
        }

        public int shootAtTarget (Duelist otherGuy1, Duelist otherGuy2)
        {
            Random rnd = new Random();
            int number = rnd.Next(10000);
            int kill = 0;
            if (number <= skill && isAlive)
            {
                kill = 1;
                if (otherGuy1.Skill >= otherGuy2.Skill && otherGuy1.isAlive)
                {
                    otherGuy1.IsAlive = false;
                }
                else if (otherGuy2.isAlive)
                {
                    otherGuy2.IsAlive = false;
                }
                else
                {
                    otherGuy1.IsAlive = false;
                }
            }
            return kill;

        }
    }

}
