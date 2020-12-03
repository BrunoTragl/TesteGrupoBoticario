using System;

namespace BrunoTragl.TesteGrupoBoticario.Web.WebApi.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Requested { 
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
