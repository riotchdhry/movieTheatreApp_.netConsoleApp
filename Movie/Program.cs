using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Movie
{


    class Program
    {

        ArrayList arrMovieName = new ArrayList();
        ArrayList arrRating = new ArrayList();

        int nowplaying;
        int movieselector = 0;
        string rating;
        string weak;
        string msg;

        public void admin() //For password
        {
            string pwd = "university";
            int ctr = 0;


            do
            {
                Console.Write("Please Enter Admin Password:");

                pwd = Console.ReadLine();
                if (pwd == "B" || pwd == "b")
                {
                    //If user enter B then whole application will be Restarted.
                    display();
                }
                else if (pwd != "university")
                {
                    ctr++;
                    Console.WriteLine("You Entered an Invalid Password");
                    Console.WriteLine("You have" + " " + +(5 - ctr) + " more attempts to enter the correct password OR Press B to go back the previous screen.\n");

                }
                else
                {
                    ctr = 1;
                }
            }

            while ((pwd != "university") && (ctr != 5));
            if (ctr == 5)
            {
                //User Entered wrong password so from here our application is Restarted. 
                display();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\t\t**********************************" +
                            "\n\t\t***Welcome to MoviePlex Theatre***" +
                            "\n\t\t**********************************\n");
                Console.WriteLine("Welcome MoviePlex Administrator");

                //Here we call the playing function for Storing movie name and Rating
                playing();




            }


        }



        public void playing() //For Further Operation in Admin
        {
            Console.Write("How many Movies playing Today:?");
            try
            {
                nowplaying = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("Please enter value between 1 to 10 to start adding movies.");
            }
            if (nowplaying < 1)
            {
                Console.WriteLine("Please enter the valid number.");
                playing();

            }
            else if (nowplaying > 10)
            {
                Console.WriteLine("Please Enter Number From 1 to 10:");
                playing();
            }
            else if (nowplaying >= 1)
            {

                //Console.WriteLine("Success");

                for (int i = 0; i < nowplaying; i++)
                {

                    Console.Write("Please Enter " + (i + 1) + "  Movie Name:");
                    arrMovieName.Add(Console.ReadLine());

                    Console.Write("Please Enter the Age Limit or Rating For the First Movie:");
                    string input = Console.ReadLine();

                    Console.WriteLine("\n");

                    if (input.All(char.IsDigit))
                    {
                        int ag = Convert.ToInt32(input);
                        arrRating.Add(ag);
                    }
                    else if (input.Equals("G") || input.Equals("g") || input.Equals("PG") || input.Equals("pg") || input.Equals("PG-13") || input.Equals("pg-13") || input.Equals("R") || input.Equals("r") || input.Equals("NC-17") || input == "nc-17")
                    {
                        arrRating.Add(input.ToUpper());

                    }
                    else
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Please Enter valid Age Limit OR Rating for Movie, from : G,PG,PG-13,R,NC-17 ");
                        Console.WriteLine("\n");
                        arrMovieName.Clear();
                        arrRating.Clear();

                        playing();
                    }

                    //Console.WriteLine("\n");                  
                }

                Console.Clear();
                Console.WriteLine("\t\t**********************************" +
                            "\n\t\t***Welcome to MoviePlex Theatre***" +
                            "\n\t\t**********************************\n");
                for (int j = 0; j < arrMovieName.Count; j++)
                {
                    Console.WriteLine(j + 1 + ": " + arrMovieName[j].ToString() + "[" + arrRating[j].ToString() + "]");
                }

                //Form here Program flow continue
                //Asking Question to Admin about movie satisfaction

                selection();

            }

        }

        public void selection() //For satisfaction surver to Admin.
        {
            Console.WriteLine("\n");
            Console.Write("Your Movies Playing today Are Listed Above.   Are You Satisfied? {Y/N} ?");
            weak = Console.ReadLine();


            if (weak == "y" || weak == "Y")
            {
                display();
            }
            else if (weak == "n" || weak == "N")
            {
                arrMovieName.Clear();
                arrRating.Clear();
                playing();
            }
            else
            {
                Console.WriteLine("Incorrect value, please select appropriate choice from {Y/N}:");
                selection();
            }

        }

        private Boolean ageVerification(int index)
        {
            Boolean condition = false;
            Console.WriteLine("Please Enter your Age for Verification:");
            int age = 0;
            try
            {
                age = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException e) 
            { 
                Console.WriteLine("Please enter valid age again. ");
            }

            String strRating = arrRating[index].ToString();
            String enjoyMessage = "Enjoy the movie!";

            if (age > 0)
            {

                if (strRating.All(char.IsDigit))
                {
                    int a = Convert.ToInt32(strRating);
                    if ((age > 0 && age < 120) && age >= a)
                    {
                        Console.WriteLine(enjoyMessage);
                        condition = true;
                    }
                    else
                    {
                        condition = false;
                    }
                }
                else if (strRating == "G" && (age<100))
                {
                    Console.WriteLine(enjoyMessage);
                    condition = true;
                }
                else if (strRating == "PG" && (age >= 10 && age < 100))
                {
                    Console.WriteLine(enjoyMessage);
                    condition = true;
                }
                else if (strRating == "PG-13" && (age >= 13 && age < 100))
                {
                    Console.WriteLine(enjoyMessage);
                    condition = true;
                }
                else if (strRating == "R" && (age >= 15 && age < 100))
                {
                    Console.WriteLine(enjoyMessage);
                    condition = true;
                }
                else if (strRating == "NC-17" && (age >= 17 && age < 100))
                {
                    Console.WriteLine(enjoyMessage);

                    condition = true;
                }
            }
            else
            {
                condition = false;
            }

            return condition;

        }

        public void showmessage()
        {
            Console.WriteLine("Press M to go back to the Guest Main Menu\n" +
                               "Press S to go back to the Start Page.");
            msg = Console.ReadLine();

            if (msg == "M" || msg == "m")
            {
                //If user enter M then whole application jump to Guest Main Menu.
                guest();
            }
            else if (msg == "S" || msg == "s")
            {
                //If user enter S then whole application jump to Start Page.
                display();
            }

        }


        public void guest()
        {
            if (arrMovieName.Count <= 0)
            {
                string s;
                Console.Clear();
                Console.WriteLine("\t\t**********************************" +
                            "\n\t\t***Welcome to MoviePlex Theatre***" +
                            "\n\t\t**********************************\n");

                Console.WriteLine("There are no Movies playing today,please check after some time.");
                Console.WriteLine("Please press S to go to start page");
                s = Console.ReadLine();
                if (s == "S" || s == "s")
                {
                    display();
                }
                else
                {
                    guest();
                }

            }

            else
            {
                Console.Clear();
                Console.WriteLine("\t\t**********************************" +
                            "\n\t\t***Welcome to MoviePlex Theatre***" +
                            "\n\t\t**********************************\n");

                Console.WriteLine("There are  movies playing today. Please choose from the following movies:\n");

                for (int j = 0; j < arrMovieName.Count; j++) //For Showing the Movies to Guest
                {
                    Console.WriteLine(j + 1 + ": " + arrMovieName[j].ToString() + "[" + arrRating[j].ToString() + "]");
                }

                Console.WriteLine("\n");
                Console.WriteLine("Which Movie would you like to watch:");
                try
                {
                    movieselector = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Please Enter Valid Number.");
                    Console.ReadLine();
                    guest();
                }





                int index = 0;

                if (movieselector <= arrMovieName.Count && movieselector > 0)
                {
                    //do
                    //{
                    index = movieselector - 1;
                    Console.WriteLine("Movie name selected to watch: " + arrMovieName[index].ToString());
                    //}
                    //while (index > 0);
                }
                else
                {
                    Console.WriteLine("Enter a valid number");
                    Console.WriteLine("Please select valid movie option");
                    Console.ReadLine();
                    guest();
                }
                while (ageVerification(index) == false)
                {
                    Boolean b = ageVerification(index);
                    if (b == true)
                    {
                        break;
                    }
                }
                showmessage(); //For show the choice to user.

            }
        }



        public void display() //For Main menu
        {
            Console.Clear();
            string choice;

            Console.WriteLine("\t\t**********************************" +
                            "\n\t\t***Welcome to MoviePlex Theatre***" +
                            "\n\t\t**********************************\n");

            Console.WriteLine("Please Select From the Following Options:");
            Console.WriteLine("1:Administrator\n2:Guest");

            Console.Write("\nYour Choice:");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("\nSelection:Administrator");
                admin();

            }
            else if (choice == "2")
            {
                Console.WriteLine("\nSelection:Guests");
                guest();

            }
            else
            {
                Console.WriteLine("Incorrect Value,please select appropriate choice");
                Console.ReadLine();
            }
            display();


        }


        static void Main(string[] args)
        {
            Program d = new Program();
            d.display();
            Console.ReadLine();
        }
    }
}
