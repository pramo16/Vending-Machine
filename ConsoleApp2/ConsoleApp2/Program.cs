using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

class VendingMachine
{
    public double totalcost { get; set; }

    public void CoinValidation(string type)
    {
        switch (type)
        {
            case ("nickels"):
                totalcost += 0.05;
                break;
            case ("dimes"):
                totalcost += 0.10;
                break;
            case ("quarters"):
                totalcost += 0.25;
                break;
            case ("pennies"):
                totalcost += 0.00;
                break;
            default:
                Console.WriteLine("Invalid Coins");
                rejectedcoins();
                break;
        }
    }

    public bool TotalAmount()
    {
        if (totalcost >= 0.50)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Choice()
    {
        Console.WriteLine("Enter choice");
        Console.WriteLine("1.Cola");
        Console.WriteLine("2.Chips");
        Console.WriteLine("3.Candy");
        Console.WriteLine("4.Exit");
        Item(Convert.ToInt32(Console.ReadLine()));
    }
    private void Item(int choice)
    {
        bool fineselection = false;
        while (!fineselection)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Cola");
                    ColaAmount();
                    Console.WriteLine("Your Cola");
                    ColaChange();
                    fineselection = true;
                    break;
                case 2:
                    Console.WriteLine("Chips");
                    fineselection = true;
                    Console.WriteLine("Your Chips");
                    ChipsChange();
                    break;
                case 3:
                    Console.WriteLine("Candy");
                    fineselection = true;
                    CandyAmount();
                    Console.WriteLine("Your Candy");
                    CandyChange();
                    break;
                case 4:
                    Console.WriteLine("Exit from Menu");
                    fineselection = true;
                    ExitChange();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    choice = Convert.ToInt32(Console.ReadLine());
                    fineselection = false;
                    break;
            }
        }
    }

    private void ColaAmount()
    {
        Program PM = new();
        while (totalcost < 1.00)
        {
            Console.WriteLine("Not enough money to buy Cola. Please add more coins");
            PM.CoinCheck();
            CoinValidation(PM.CoinValue());
        }
    }
    private void CandyAmount()
    {
        Program PM = new();
        while (totalcost < 0.65)
        {
            Console.WriteLine("Not enough money to buy Candy. Please add more coins");
            PM.CoinCheck();
            CoinValidation(PM.CoinValue());
        }
    }
    private void ColaChange()
    {
        Console.WriteLine("Change is ${0}", totalcost - 1.00);
    }
    private void ChipsChange()
    {
        Console.WriteLine("Change is ${0}", totalcost - 0.50);
    }
    private void CandyChange()
    {
        Console.WriteLine("Change is ${0}", totalcost - 0.65);
    }
    private void ExitChange()
    {
        Console.WriteLine("Change is ${0}", totalcost);
    }
    public void rejectedcoins()
    {
        Console.WriteLine("Returning cash of coins ${0} ", totalcost);
    }

    public class Program : CoinValidity
    {
        double money;
        static void Main(string[] args)
        {
            var VM = new VendingMachine();
            var CV = new CoinValidity();
            var PM = new Program();
            string option = null;
            double money;
            Console.WriteLine("Please insert coins");
            while (option != "NO")
            {
                CV.CoinCheck();
                VM.CoinValidation(CV.CoinValue());
                money = VM.totalcost;
                Console.WriteLine("Your money is ${0}", money);
                if (VM.totalcost < 0.5)
                {
                    Console.WriteLine("Need more coins to choose Item. Do you want to proceed?");
                    Console.WriteLine("Yes or No");
                    do
                    {
                        option = Console.ReadLine().ToUpper();
                        if (option != "YES" && option != "NO")
                        {
                            Console.WriteLine("Wrong choice. Please choose 'yes' or 'no'");
                        }
                    } while (option != "YES" && option != "NO");
                }
                else
                {
                    Console.WriteLine("Want to add more coins");
                    Console.WriteLine("Yes or No");
                    do
                    {
                        option = Console.ReadLine().ToUpper();
                        if (option != "YES" && option != "NO")
                        {
                            Console.WriteLine("Wrong choice. Please choose 'yes' or 'no'");
                        }
                    } while (option != "YES" && option != "NO");
                }
            }
            VM.Choice();
            Console.ReadLine();
        }
    }
}
