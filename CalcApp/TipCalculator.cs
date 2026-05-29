using System;

namespace CalcApp
{
    public static class TipCalculator
    {
        public static double CalculateTotal(double bill, int guests, int tipPercent)
        {
            if (bill <= 0)
            {
                throw new ArgumentException("Сумма счета должна быть больше 0");
            }

            if (guests <= 0)
            {
                throw new ArgumentException("Количество гостей должно быть больше 0");
            }

            double total = bill + (bill * tipPercent / 100.0);

            return total;
        }

        public static double CalculatePerPerson(double total, int guests)
        {
            if (guests <= 0)
            {
                throw new ArgumentException("Количество гостей должно быть больше 0");
            }

            return total / guests;
        }
    }
}

