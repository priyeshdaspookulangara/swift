using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARCAERP.Domain.Entities
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        [StringLength(200)]
        public string? ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Budget { get; set; }

        public ICollection<ProjectCost> ProjectCosts { get; set; } = new List<ProjectCost>();
        public ICollection<SubContractProject> SubContractProjects { get; set; } = new List<SubContractProject>();
    }

    public class SubContractProject
    {
        [Key]
        public int SubContractProjectId { get; set; }
        [ForeignKey("Project")]
        public int MainProjectId { get; set; }
        public Project? MainProject { get; set; }
        [Required]
        [StringLength(100)]
        public string? SubContractorName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }

    public class ProjectCost
    {
        [Key]
        public int ProjectCostId { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        [Required]
        [StringLength(100)]
        public string? CostType { get; set; } // e.g., "Labor", "Materials", "SubContract"
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime DateIncurred { get; set; }
    }
}
