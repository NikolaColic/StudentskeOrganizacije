using System;
using System.Collections.Generic;
using System.Text;

namespace FonData.Helpers
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public string Role { get; set; }

    }
}
