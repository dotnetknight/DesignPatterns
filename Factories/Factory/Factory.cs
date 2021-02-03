using System;

namespace Factories.Factory
{
    //“A factory is an object which is used for creating other objects”. In technical terms, we can say that a factory is a class with a method. That method will create and return different types of objects based on the input parameter, it received.

    public enum CardTypes
    {
        TitaniumEdge,
        MoneyBack,
        Platinum
    }

    public class Platinum : ICreditCard
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

    public class Titanium : ICreditCard
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

    class MoneyBack : ICreditCard
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
    public interface ICreditCard
    {
        CardTypes CardType();
        int CreditLimit();
        int AnnualCharge();
    }

    public class CreditCardFactory
    {
        public static ICreditCard CreditCard(CardTypes cardType)
        {
            ICreditCard cardDetails = null;

            if (cardType == CardTypes.MoneyBack)
                cardDetails = new MoneyBack();

            if (cardType == CardTypes.TitaniumEdge)
                cardDetails = new Titanium();

            if (cardType == CardTypes.Platinum)
                cardDetails = new Platinum();

            return cardDetails;
        }
    }

    class Factory
    {
        //static void Main(string[] args)
        //{
        //    ICreditCard cardDetails = CreditCardFactory.CreditCard(CardTypes.Platinum);

        //    if (cardDetails != null)
        //    {
        //        Console.WriteLine("CardType : " + cardDetails.CardType());
        //        Console.WriteLine("CreditLimit : " + cardDetails.CreditLimit());
        //        Console.WriteLine("AnnualCharge :" + cardDetails.AnnualCharge());
        //    }

        //    else
        //        Console.Write("Invalid Card Type");

        //    Console.ReadLine();
        //}
    }
}
