using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;


namespace TaxCalculator
{
   public class DefaultTaxCalculator : TaxCalculator
    {

        private bool _story5Toggle = false;

        public DefaultTaxCalculator(bool story5Toggle)
        {
            _story5Toggle = story5Toggle;
        }
        
        public override int CalculateTax(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public override int TaxCal(Vehicle vehicle)
        {
            var dict = new Dictionary<int, int>();
            var price = 0;

            if(_story5Toggle == true)
            {
                if (vehicle.ListPrice > 40000)
                {
                    switch (vehicle.FuelType)
                    {
                        case FuelType.Petrol:
                            return price = 450;

                        case FuelType.Diesel:
                            return price = 450;

                        case FuelType.Electric:
                            return price = 310;

                        case FuelType.AlternativeFuel:
                            return price = 440;
                    }
                }
            }

            if (vehicle.DateOfFirstRegistration.DayOfYear - DateTime.Now.DayOfYear > 1)
            {
                price = vehicle.FuelType == FuelType.Petrol ? 140 : 130;

                return vehicle.FuelType == FuelType.Electric ? 0 : price;
            }


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

                case FuelType.Diesel:
                    dict.Add(0,0);
                    dict.Add(50, 25);
                    dict.Add(75, 110);
                    dict.Add(90, 130);
                    dict.Add(100, 150);
                    dict.Add(110, 170);
                    dict.Add(130, 210);
                    dict.Add(150, 530);
                    dict.Add(170, 855);
                    dict.Add(190, 1280);
                    dict.Add(225, 1815);
                    dict.Add(255, 2135);

                    price = dict.Where(x => vehicle.Co2Emissions <= x.Key).
                        Select(xx => xx.Value).FirstOrDefault();

                    price = vehicle.Co2Emissions > 255 ? 2135 : price;
                    break;

                case FuelType.AlternativeFuel:
                    dict.Add(0, 0);
                    dict.Add(50, 0);
                    dict.Add(75, 15);
                    dict.Add(90, 95);
                    dict.Add(100, 115);
                    dict.Add(110, 135);
                    dict.Add(130, 155);
                    dict.Add(150, 195);
                    dict.Add(170, 505);
                    dict.Add(190, 820);
                    dict.Add(225, 1230);
                    dict.Add(255, 1750);

                    price = dict.Where(x => vehicle.Co2Emissions <= x.Key)
                   .Select(xx => xx.Value).FirstOrDefault();

                    price = vehicle.Co2Emissions > 255 ? 2060 : price;
                    break;

                case FuelType.Electric:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return price;
        }
    }

}
