using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.User
{
	public interface IUserService
	{
		Task<string> GetFistName(string userId);
	}
}
