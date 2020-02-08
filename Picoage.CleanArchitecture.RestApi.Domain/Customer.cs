using System;
using System.Collections.Generic;
using System.Text;

namespace Picoage.CleanArchitecture.RestApi.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}
