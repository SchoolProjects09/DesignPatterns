using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdersDll;

namespace DecoratorLabStarterCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();

            order.AddItem("SeahawksHats", 2, 1.5, 0.2);
            order.AddItem("SeahawksGloves", 1, 3.0, 0.5);
            order.AddItem("SeahawksSocks", 6, 1.9, 0.1);
            order.AddItem("SeahawksBanners", 3, 8.0, 1.5);
            order.AddItem("SeahawksFootBalls", 4, 5.6, 0.6);
            order.AddItem("SeahawksJerseys", 2, 2.3, 0.4);

            order.PrintOrderItems();

            Console.WriteLine("Express ------------------------");

            AbstractOrderBase expressOrder = new ExpressDeliveryOrderDecorator(order);
            expressOrder.PrintOrderItems();

            Console.WriteLine("");
            Console.WriteLine("VISA ------------------------");

            AbstractOrderBase visaOrder = new VisaOrderDecorator(order);
            visaOrder.PrintOrderItems();

            Console.WriteLine("");
            Console.WriteLine("AMEX ------------------------");

            AbstractOrderBase amexOrder = new AmexOrderDecorator(order);
            amexOrder.PrintOrderItems();

            Console.WriteLine("");
            Console.WriteLine("Express and Visa ------------------------");

            AbstractOrderBase expressAndvisa = new VisaOrderDecorator(expressOrder);
            expressAndvisa.PrintOrderItems();

            Console.ReadLine();
        }
    }
}
