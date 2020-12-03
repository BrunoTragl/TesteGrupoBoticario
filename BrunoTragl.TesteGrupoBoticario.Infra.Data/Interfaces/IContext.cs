using BrunoTragl.TesteGrupoBoticario.Domain.Model;
using System.Collections.Generic;

namespace BrunoTragl.TesteGrupoBoticario.Infra.Data.Interfaces
{
    public interface IContext
    {
        ICollection<Product> Products { get; set; }
    }
}
