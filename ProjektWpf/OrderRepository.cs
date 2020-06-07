using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektWpf
{
    public class OrderRepository
    {
        private List<Order> orders { get; set; }

        public List<Order> Orders
        {
            get
            {
                return orders;
            }

            set
            {
                orders = value;
            }
        }


        public OrderRepository()
        {
            this.orders = new List<Order>();
        }

        public OrderRepository(List<Order> orders)
        {
            this.orders = orders;
        }
    }
}