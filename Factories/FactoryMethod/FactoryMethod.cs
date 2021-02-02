using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.FactoryMethod
{
    //Define an interface for creating an object, but let the subclasses decide which class to instantiate. The Factory method lets a class defer instantiation it uses to subclasses

    public enum CardTypes
    {
        TitaniumEdge,
        MoneyBack,
        Platinum
    }

    public class Platinum : CreditCard
    {
        public CardTypes CardType()
        {
            return CardTypes.Platinum;
        }
        public int CreditLimit()
        {
            return 35000;
        }
        public int AnnualCharge()
        {
            return 2000;
        }
    }

    public class Titanium : CreditCard
    {
        public CardTypes CardType()
        {
            return CardTypes.TitaniumEdge;
        }
        public int CreditLimit()
        {
            return 25000;
        }
        public int AnnualCharge()
        {
            return 1500;
        }
    }

    class MoneyBack : CreditCard
    {
        public CardTypes CardType()
        {
            return CardTypes.MoneyBack;
        }
        public int CreditLimit()
        {
            return 15000;
        }
        public int AnnualCharge()
        {
            return 500;
        }
    }
    public interface CreditCard
    {
        CardTypes CardType();
        int CreditLimit();
        int AnnualCharge();
    }

    public abstract class CreditCardFactory
    {
        protected abstract CreditCard MakeProduct();
        public CreditCard CreateProduct()
        {
            return MakeProduct();
        }
    }

    public class MoneyBackFactory : CreditCardFactory
    {
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new MoneyBack();
            return product;
        }
    }
    public class PlatinumFactory : CreditCardFactory
    {
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new Platinum();
            return product;
        }
    }
    public class TitaniumFactory : CreditCardFactory
    {
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new Titanium();
            return product;
        }
    }

    class FactoryMethod
    {
        static void Main(string[] args)
        {
            CreditCard creditCard = new PlatinumFactory().CreateProduct();

            if (creditCard != null)
            {
                Console.WriteLine("Card Type : " + creditCard.CardType());
                Console.WriteLine("Credit Limit : " + creditCard.CreditLimit());
                Console.WriteLine("Annual Charge :" + creditCard.AnnualCharge());
            }

            else
                Console.Write("Invalid Card Type");

            Console.WriteLine("--------------");

            creditCard = new MoneyBackFactory().CreateProduct();

            if (creditCard != null)
            {
                Console.WriteLine("Card Type : " + creditCard.CardType());
                Console.WriteLine("Credit Limit : " + creditCard.CreditLimit());
                Console.WriteLine("Annual Charge :" + creditCard.AnnualCharge());
            }

            else
                Console.Write("Invalid Card Type");

            Console.ReadLine();
        }
    }
}