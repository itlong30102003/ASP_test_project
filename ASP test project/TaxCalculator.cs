using System;

namespace taxCalculator
{
    public class TaxCalculator
    {
        public static float Calculate(float salary, float income, float dependent)
        {
            float taxable_income = salary - (income * 0.105F) - (dependent * 4400000F);
            if (taxable_income <= 11000000) 
            { 
                return 0F; 
            }
            else
            {
                taxable_income = taxable_income - 11000000F;
            }
            Console.WriteLine("Taxable_income: " + taxable_income.ToString());
            float taxRate = 0F;
            float tax;
            switch (taxable_income)
            {
                case float n when (n <= 5000000F):
                    taxRate = 0.05F;
                    break;
                case float n when (n <= 10000000F):
                    taxRate = 0.1F;
                    break;
                case float n when (n <= 18000000F):
                    taxRate = 0.15F;
                    break;
                case float n when (n <= 32000000F):
                    taxRate = 0.20F;
                    break;
                case float n when (n <= 52000000F):
                    taxRate = 0.25F;
                    break;
                case float n when (n <= 80000000F):
                    taxRate = 0.30F;
                    break;
                default:
                    taxRate = 0.35F;
                    break;
            }
            if (taxRate == 0.05F)
                tax = taxable_income * taxRate;
            else if (taxRate == 0.10F)
                tax = taxable_income * taxRate - 250000F;
            else if (taxRate == 0.15F)
                tax = taxable_income * taxRate - 750000F;
            else if (taxRate == 0.20F)
                tax = taxable_income * taxRate - 1650000F;
            else if (taxRate == 0.25F)
                tax = taxable_income * taxRate - 3250000F;
            else if (taxRate == 0.30F)
                tax = taxable_income * taxRate - 5850000F;
            else if (taxRate == 0.35F)
                tax = taxable_income * taxRate - 9850000F;
            else
                tax = 0F;

            return tax;
        }
    }
}