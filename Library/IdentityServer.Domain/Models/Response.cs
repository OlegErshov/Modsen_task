using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Domain.Models
{
    public class Response
    {
        public Response(bool success, string message, string? token)
        {
            Success = success;
            Message = message ?? throw new ArgumentNullException(nameof(message));
            Token = token;
        }

        public Response(string message) :
            this(false, message, null)
        {
        }

        public bool Success { get; set; }

        public string Message { get; set; }
        public string? Token { get; set; }
    }
}

