using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersDll
{
    public class VisaOrderDecorator : OrderDecorator
    {
        private const double SHIPPING_COST = 2.00d;
        public VisaOrderDecorator(AbstractOrderBase order) : base(order) { }

        public override double GetTotalCost()
        {
            return base.GetTotalCost() + SHIPPING_COST;
        }

        public override void PrintOrderItems()
        {
            Console.WriteLine("A Processing Fee May Apply");
            base.PrintOrderItems();
            Console.WriteLine("Grand Total with Processing Fee {0:C2}", this.GetTotalCost());
        }
    }
}
