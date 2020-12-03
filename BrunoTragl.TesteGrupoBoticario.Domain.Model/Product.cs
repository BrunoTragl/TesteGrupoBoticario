using System.Collections.Generic;

namespace BrunoTragl.TesteGrupoBoticario.Domain.Model
{
    public class Product
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
    }
}
