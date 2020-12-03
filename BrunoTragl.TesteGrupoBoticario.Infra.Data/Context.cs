using BrunoTragl.TesteGrupoBoticario.Domain.Model;
using BrunoTragl.TesteGrupoBoticario.Infra.Data.Interfaces;
using System.Collections.Generic;

namespace BrunoTragl.TesteGrupoBoticario.Infra.Data
{
    public class Context : IContext
    {
        public Context()
        {
            Products = new List<Product>();
        }
        public ICollection<Product> Products { get; set; }
    }
}
