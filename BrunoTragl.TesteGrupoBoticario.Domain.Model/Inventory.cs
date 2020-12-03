using System.Collections.Generic;

namespace BrunoTragl.TesteGrupoBoticario.Domain.Model
{
    public class Inventory
    {
        public ICollection<Warehouse> Warehouses { get; set; }
    }
}
