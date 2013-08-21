/* 
 * Name: Alexander D. Martinez
 * Date: 09/22/09
 * Purpose: allows user to calculate a present and future value also a monthly payment from 3 variables
*/


using System;
using System.Collections.Generic;
using System.Text;

namespace methods
{
    class FinanceCalculator
    {
        static void Main(string[] args)
        {
            //the three variables
            double ammount;            
            double anualRate;            
            int numberOfYears;
            
            string menuSelection;
            string exitLoop = "n";

            while (exitLoop == "n")
            {
                string userSelection = ""; 

                menuSelection = menuOptions();

                ammount = getAmmount();

                anualRate = getAnualRate();

                numberOfYears = getNumberOfYears();

                
                if (menuSelection == "1") //present value
                {
                    double finalResult;

                    finalResult = getPresentValue(ref ammount, ref anualRate, ref numberOfYears);

                    Console.WriteLine("The present value of {0, 0:c} with a rate of {1} and {2} years is {3, 0:c}", ammount, anualRate, numberOfYears, finalResult);
                }

                if (menuSelection == "2") //future value
                {
                    double finalResult;

                    finalResult = getFutureValue(ref ammount, ref anualRate, ref numberOfYears);

                    Console.WriteLine("The future value of {0, 0:c} invested for {2} years at {1} is {3, 0:c}", ammount, anualRate, numberOfYears, finalResult);
                }

                if (menuSelection == "3") //monthly payment
                {
                    double finalResult;

                    finalResult = getMonthlyPayment(ref ammount, ref anualRate, ref numberOfYears);

                    Console.WriteLine("The montly payment to borrow {0, 0:c} at {1} for {2} months is {3, 0:c}", ammount, anualRate, numberOfYears * 12, finalResult);
                }


                Console.Write("\nDo you want to try another option?\nEnter Y/y for yes; anything else for no:");
                userSelection = Console.ReadLine();

                if (userSelection == null || userSelection != "y" && userSelection != "Y")
                {
                    exitLoop = "y"; //sets to exit program
                }
                
                
            } //end execution loop           
           
        } //end Main

        static string menuOptions()
        {
            string userSelection = "";
            string exitLoop = "n";

            while (exitLoop == "n")
            {
                Console.WriteLine("1 - Calculate present value.\n2 - Calculate future value.\n3 - Calculate monthly payment.\n");

                Console.WriteLine("Enter 1, 2 or 3.\n");
                userSelection = Console.ReadLine();

                if (userSelection == null || userSelection != "1" && userSelection != "2" && userSelection != "3")
                {
                    Console.WriteLine("Please enter 1, 2 or 3.\n");
                }
                else
                {
                    exitLoop = "y";                     
                }
            }

            return userSelection;
            
        } //end menuOptions method


        static double getAmmount()
        {
            double result = 0;
            string input;
            string exitLoop = "n";

            while (exitLoop == "n")
            {

                Console.Write("\nEnter the ammount:");
                input = Console.ReadLine();

                if (double.TryParse(input, out result) && result > 0)
                {
                    exitLoop = "y";
                }
                else 
                {
                    Console.WriteLine("The ammount must be > 0.\n");
                }
            }

            return result;

        } //end getAmmount method


        static double getAnualRate()
        {
            double result = 0;
            string input;
            string exitLoop = "n";

            while (exitLoop == "n")
            {

                Console.Write("\nEnter the anual rate:");
                input = Console.ReadLine();


                if (double.TryParse(input, out result) && result > 0)
                {
                    exitLoop = "y";
                }
                else
                {
                    Console.WriteLine("The anual rate must be > 0.\n");
                }
            }

            return result;

        } //end getAnualRate method


        static int getNumberOfYears()
        {
            int result = 0;
            string input;
            string exitLoop = "n";


            while (exitLoop == "n")
            {
                Console.Write("\nEnter the number of years:");
                input = Console.ReadLine();
            
                if (int.TryParse(input, out result) && result > 0)
                {
                    exitLoop = "y";
                }
                else
                {
                    Console.WriteLine("The number of years must be > 0.\n");
                }
            }

            return result;

        } //end getNumberOfYears method


        //present value method
        static double getPresentValue(ref double amm, ref double ar, ref int yrs)
        {
            double pv = 0;
            
            pv = amm * (Math.Pow(1 + ar, -yrs));

            return pv;
        }//end getPresentValue


        //future value method
        static double getFutureValue(ref double amm, ref double ar, ref int yrs)
        {
            double fv = 0;

            fv = amm * (Math.Pow(1 + ar, yrs));

            return fv;
        }//end getFutureValue

        //monthly payment method
        static double getMonthlyPayment(ref double amm, ref double ar, ref int yrs)
        {
            double mp = 0;
            double mInterestRate;
            double monthsToRepay;
            double divisor;

            mInterestRate = ar / 12;
            monthsToRepay = yrs * 12;
            divisor = Math.Pow(1 + mInterestRate, monthsToRepay) - 1;

            mp = (mInterestRate + (mInterestRate / divisor)) * amm;

            return mp;
        }//end getMonthlyPayment

    }//end Class
}//end namespace
