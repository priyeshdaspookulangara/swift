using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARCAERP.Domain.Entities
{
    public class BillOfMaterials
    {
        [Key]
        public int BillOfMaterialsId { get; set; }

        [ForeignKey("Item")]
        public int FinishedProductId { get; set; } // The final product this BOM is for
        public Item? FinishedProduct { get; set; }

        public ICollection<BillOfMaterialsItem> RequiredItems { get; set; } = new List<BillOfMaterialsItem>();
    }

    public class BillOfMaterialsItem
    {
        [Key]
        public int BillOfMaterialsItemId { get; set; }

        [ForeignKey("BillOfMaterials")]
        public int BillOfMaterialsId { get; set; }
        public BillOfMaterials? BillOfMaterials { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; } // Raw material/component
        public Item? Item { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Quantity { get; set; }
    }

    public class WorkOrder
    {
        [Key]
        public int WorkOrderId { get; set; }

        [ForeignKey("BillOfMaterials")]
        public int BillOfMaterialsId { get; set; }
        public BillOfMaterials? BillOfMaterials { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal QuantityToProduce { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }

        public string? Status { get; set; } // e.g., "Pending", "In Progress", "Completed"
    }
}
