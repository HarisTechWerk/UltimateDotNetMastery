
namespace DIP_DependencyInversionDemo.GoodExample
{
    // Low level module (Payment Method) implements abstraction
    public interface IPaymentMethod
    {
        void Pay(decimal amount);
    }

    public class PayPalPayment : IPaymentMethod
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paying {amount}€ using PayPal");
        }
    }
    // High level module (Business Logic) depends on abstraction, not concrete class
    public class ShoppingMall
    {
        private readonly IPaymentMethod _paymentMethod;

        public ShoppingMall(IPaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }

        public void ProcessPurchase(decimal amount)
        {
            _paymentMethod.Pay(amount);
        }
    }

    public class CreditCardPayment : IPaymentMethod
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paying {amount}€ using Credit Card");
        }
    }

}