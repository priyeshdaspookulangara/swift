using ARCAERP.Application.Interfaces;
using ARCAERP.Domain.Entities;
using ARCAERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARCAERP.Infrastructure.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly ApplicationDbContext _context;

        public ProjectsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects
                .Include(p => p.ProjectCosts)
                .Include(p => p.SubContractProjects)
                .ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            return await _context.Projects
                .Include(p => p.ProjectCosts)
                .Include(p => p.SubContractProjects)
                .FirstOrDefaultAsync(p => p.ProjectId == projectId);
        }

        public async Task CreateProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task AddCostToProjectAsync(int projectId, ProjectCost cost)
        {
            var project = await GetProjectByIdAsync(projectId);
            if (project != null)
            {
                cost.ProjectId = projectId;
                _context.ProjectCosts.Add(cost);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Project not found");
            }
        }
    }
}
