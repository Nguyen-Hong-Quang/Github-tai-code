using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ass_nhap
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            // Enter user information
            string userName = GetUserName();
            Console.WriteLine("User is: " + userName);

            // Enter the water meter readings
            float previousWaterComsuption = GetWaterMeterComsuption("previous");
            float currentWaterComsuption = GetWaterMeterComsuption("current");

            // Check water consumption and prompt for re-entry if it's negative
            while (currentWaterComsuption < previousWaterComsuption)
            {
                Console.WriteLine("Error: Current water meter reading must be greater than or equal to the previous reading. Please enter again.");
                Console.WriteLine("Current water meter reading:");
                currentWaterComsuption = float.Parse(Console.ReadLine());
            }

            // Calculate the water usage for this month
            float waterUsed = currentWaterComsuption - previousWaterComsuption;
           
            // Display the result water comsumed
            Console.WriteLine("Water Comsumed: " + waterUsed +"m^3");

            // Process billing based on user choice
            ProcessBilling(waterUsed);
        }

        //Enter user name
        static string GetUserName()
        {
            Console.WriteLine("Enter username:");
            return Console.ReadLine();
        }

        //Enter the water meter usage index
        static float GetWaterMeterComsuption(string meterwaterType)
        {
            float meterwater = 0;
            while (meterwater <= 0)
            {
                Console.Write($"Enter the water meter reading for the {meterwaterType} month: ");
                string input_meterwater = Console.ReadLine();
                if (float.TryParse(input_meterwater, out meterwater) && meterwater > 0)
                {
                    Console.WriteLine($"Water meter reading for the {meterwaterType} month: " + meterwater);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter again.");
                }
            }
            return meterwater;
        }

        // Process billing based on user choice
        static void ProcessBilling(float waterUsed)
        {
            string userInput;
            do
            {
                // Display customer types
                Console.WriteLine("List of options:\r\n" +
                    "1. Household\r\n" +
                    "2. Administrative Agencies and Public Service \r\n" +
                    "3. Production Units\r\n" +
                    "4. Business Service");
                Console.Write("Types of customer: ");
                userInput = Console.ReadLine();

                // Calculate water charges based on customer type
                switch (userInput)
                {
                    case "1":
                        HouseholdBilling(waterUsed);
                        break;
                    case "2":
                        AgencyBilling(waterUsed, 9.955);
                        break;
                    case "3":
                        ProductionBilling(waterUsed, 11.615);
                        break;
                    case "4":
                        BusinessServiceBilling(waterUsed, 22.608);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4");
            Console.ReadKey();
        }

        // Calculate water bill for household 
        static void HouseholdBilling(float waterUsed)
        {
            Console.WriteLine("Enter the number of people in your household:");
            if (int.TryParse(Console.ReadLine(), out int numberOfPeople) && numberOfPeople > 0)
            {
                double waterbill;
                if (waterUsed < 10 && waterUsed > 0)
                {
                    waterbill = waterUsed * 5.973;
                }
                else if (waterUsed < 20 && waterUsed >= 10)
                {
                    waterbill = (10 * 5973) + ((waterUsed - 10) * 7.052) ;
                }
                else if (waterUsed >= 20 && waterUsed < 30)
                {
                    waterbill = (10 * 5973) + (10 * 7052) + ((waterUsed - 20) * 8.699);
                }
                else
                {
                    waterbill = (10 * 5.973) + (10 * 7.052) + ( 10 * 8.699) + (waterUsed - 30) * 15.929;
                }
                Console.WriteLine("Water bill: " + waterbill + "VND");

                // Calcultate fees and total bill  for household 
                double priceEnviromentFee = (waterbill / 100) * 10;
                Console.WriteLine("Enviroment Fee : " + priceEnviromentFee + "VND");

                double priceVAT = (waterbill / 100) * 10;
                Console.WriteLine("VAT : " + priceVAT + "VND");

                double finalTotalAmount = waterbill + priceEnviromentFee + priceVAT;
                Console.WriteLine("Total Bill: " + finalTotalAmount + "VND");
            }
            else
            {
                Console.WriteLine("Invalid number of people.");
            }
        }

        // Calculate water bill for Administrative Agencies and Public Service
        static void AgencyBilling(float waterUsed, double price)
        {
            double waterbill = waterUsed * price;
            Console.WriteLine("Water bill: " + waterbill + "VND");

            // Calcultate fees and total bill  for Administrative Agencies and Public Service
            double priceEnviromentFee = (waterbill / 100) * 10;
            Console.WriteLine("Enviroment Fee : " + priceEnviromentFee + "VND");

            double priceVAT = (waterbill / 100) * 10;
            Console.WriteLine("VAT : " + priceVAT + "VND");

            double finalTotalAmount = waterbill + priceEnviromentFee + priceVAT;
            Console.WriteLine("Total Bill: " + finalTotalAmount + "VND");
        }

        // Calculate water bill for Production Units
        static void ProductionBilling(float waterUsed, double price)
        {
            double waterbill = waterUsed * price;
            Console.WriteLine("Water bill: " + waterbill + "VND");

            // Calcultate fees and total bill for Production Units
            double priceEnviromentFee = (waterbill / 100) * 10;
            Console.WriteLine("Enviroment Fee : " + priceEnviromentFee + "VND");

            double priceVAT = (waterbill / 100) * 10;
            Console.WriteLine("VAT : " + priceVAT + "VND");


            double finalTotalAmount = waterbill + priceEnviromentFee + priceVAT;
            Console.WriteLine("Total Bill: " + finalTotalAmount + "VND");
        }

        // Calculate water bill for Business Service
        static void BusinessServiceBilling(float waterUsed, double price)
        {
            double waterbill = waterUsed * price;
            Console.WriteLine("Water bill: " + waterbill + "VND");

            // Calcultate fees and total bill for Business Service
            double priceEnviromentFee = (waterbill / 100) * 10;
            Console.WriteLine("Enviroment Fee : " + priceEnviromentFee + "VND");

            double priceVAT = (waterbill / 100) * 10;
            Console.WriteLine("VAT : " + priceVAT + "VND");

            double finalTotalAmount = waterbill + priceEnviromentFee + priceVAT;
            Console.WriteLine("Total Bill: " + finalTotalAmount + "VND");
        }

       
    }
}
