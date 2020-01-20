using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxCalculator
{
   public class DefaultTaxCalculator : TaxCalculator
    {
        public override int AltFuelCalc(Vehicle vehicle)
        {
            var dict = new Dictionary<int, int>();
            var price = 0;

            switch (vehicle.FuelType)
            {
                case FuelType.Petrol:
                    dict.Add(0, 0);
                    dict.Add(50, 10);
                    dict.Add(75, 25);
                    dict.Add(90, 105);
                    dict.Add(100, 125);
                    dict.Add(110, 145);
                    dict.Add(130, 165);
                    dict.Add(150, 205);
                    dict.Add(170, 515);
                    dict.Add(190, 830);
                    dict.Add(225, 1240);
                    dict.Add(255, 1760);

                    price = dict.Where(x => vehicle.Co2Emissions <= x.Key)
                   .Select(xx => xx.Value).FirstOrDefault();

                    price = vehicle.Co2Emissions > 255 ? 2070 : price;
                    break;
            }
            return price;
        }

        public override int CalculateTax(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public override int TaxCal(Vehicle vehicle)
        {
            var dict = new Dictionary<int, int>();
            var price = 0;

            switch (vehicle.FuelType)
            {
                case FuelType.Petrol:
                    dict.Add(0,0);
                    dict.Add(50, 10);
                    dict.Add(75, 25);
                    dict.Add(90, 105);
                    dict.Add(100, 125);
                    dict.Add(110, 145);
                    dict.Add(130, 165);
                    dict.Add(150, 205);
                    dict.Add(170, 515);
                    dict.Add(190, 830);
                    dict.Add(225, 1240);
                    dict.Add(255, 1760);

                         price = dict.Where(x => vehicle.Co2Emissions <= x.Key)
                        .Select(xx => xx.Value).FirstOrDefault();

                    price =  vehicle.Co2Emissions > 255 ? 2070 : price;
                    break;
            }
            return price;
        }
    }

    
}
