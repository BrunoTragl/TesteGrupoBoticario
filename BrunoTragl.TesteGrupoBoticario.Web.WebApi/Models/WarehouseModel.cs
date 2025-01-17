﻿using System.ComponentModel.DataAnnotations;

namespace BrunoTragl.TesteGrupoBoticario.Web.WebApi.Models
{
    public class WarehouseModel
    {
        [Required(ErrorMessage = "The field locality is required")]
        public string Locality { get; set; }
        [Required(ErrorMessage = "The field quantity is required")]
        public uint Quantity { get; set; }
        [Required(ErrorMessage = "The field type is required")]
        public string Type { get; set; }
    }
}
