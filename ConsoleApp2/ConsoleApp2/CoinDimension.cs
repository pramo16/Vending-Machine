using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CoinValidity : VendingMachine
{
    double? radius;
    double? height;
    double? weight;
    public void CoinCheck()
    {
        Console.Write("Radius = ");
        radius = Convert.ToDouble(Console.ReadLine());
        Console.Write("Height = ");
        height = Convert.ToDouble(Console.ReadLine());
        Console.Write("Weight = ");
        weight = Convert.ToDouble(Console.ReadLine());
    }

    public string CoinValue()
    {
        if (radius == 1 && height == 0.68 && weight == 5)
        {
            return "nickels";
        }
        else if (radius == 1.1 && height == 0.72 && weight == 6)
        {
            return "dimes";
        }
        else if (radius == 1.2 && height == 0.76 && weight == 7)
        {
            return "quarters";
        }
        else if (radius == 0.9 && height == 0.6 && weight == 4)
        {
            return "pennies";
        }
        else
        {
            Console.WriteLine("Please insert valid coins");
            return "";
        }
    }
}

