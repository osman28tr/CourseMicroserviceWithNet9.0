using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMicroservice.Shared.Services
{
	public class IdentityService : IIdentityService
	{
		public Guid UserId => Guid.Parse("850b3e0a-e436-4f0b-981b-5b7412f23a93");
		public string UserName => "Osman28";
	}
}
