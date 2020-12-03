using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrunoTragl.TesteGrupoBoticario.Web.WebApi.Models
{
    public class InventoryModel
    {
        [Required(ErrorMessage = "The field warehouses is required")]
        public ICollection<WarehouseModel> Warehouses { get; set; }
        public uint Quantity { get; set; }

        public void CalculateQuantity()
        {
            Quantity = 0;
            
            if (Warehouses?.Count > 0)
            {
                foreach (WarehouseModel warehouse in Warehouses)
                    Quantity += warehouse.Quantity;
            }
        }
    }
}
