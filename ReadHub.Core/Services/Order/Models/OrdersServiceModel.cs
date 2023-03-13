using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Order.Models
{
	public class OrdersServiceModel
	{
		public IEnumerable<OrderServiceModel> Orders { get; set; } = new List<OrderServiceModel>();
	}
}
