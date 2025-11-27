using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNest.Models.ViewModels
{
    public class ShoppingCartVM
    {
       public IEnumerable<ShoppingCart> shoppingCartsList { get; set; }
       
       public OrderHeader orderHeader { get; set; }
    }
}
