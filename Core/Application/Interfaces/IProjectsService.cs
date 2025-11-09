using ARCAERP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARCAERP.Application.Interfaces
{
    public interface IProjectsService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int projectId);
        Task CreateProjectAsync(Project project);
        Task AddCostToProjectAsync(int projectId, ProjectCost cost);
    }
}
