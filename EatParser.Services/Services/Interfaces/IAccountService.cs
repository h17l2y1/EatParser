using EatParser.ViewModels.Account.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface IAccountService
	{
		Task SignUpAsync(SignUpAccountView view);
	}
}
