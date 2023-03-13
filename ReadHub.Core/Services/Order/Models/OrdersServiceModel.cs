namespace ReadHub.Core.Services.Order.Models
{
	public class OrdersServiceModel
	{
		public IEnumerable<OrderServiceModel> Orders { get; set; } = new List<OrderServiceModel>();
	}
}
