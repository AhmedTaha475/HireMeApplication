using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Repos.Projects
{
    public class ProjectsRepo:IProjectsRepo
    {

        private readonly HireMeContext context;

        public ProjectsRepo(HireMeContext context)
        {
            this.context = context;
        }
        public bool Add(Project project)
        {
            
                context.projects.Add(project);
                context.SaveChanges();
                return true;
           
           
        }

        public bool Delete(int id)
        {
            var toBeDeleted = context.projects.Find(id);
            if (toBeDeleted != null)
            {
                context.projects.Remove(toBeDeleted);
                context.SaveChanges();
                return true;
            }
            else return false;
        }

        public List<Project>? GetAll()
        {
            return context.projects
                .Include(p => p.ProjectComments).ThenInclude(C => C.Client)
                .Include(p=>p.ProjectImages)
                .Include(p=>p.ProjectReview)
                .Include(p => p.Client)
                .ToList();
        }
        //GetallByPortfolioId
        
        public Project? GetById(int id)
        {
            Project? project = context.projects
                .Include(p => p.ProjectComments).ThenInclude(C => C.Client)
                .Include(p => p.ProjectImages)
                .Include(p => p.ProjectReview).
                Include(p => p.Client)
                .FirstOrDefault(p => p.ProjectID == id);
            return project;
        }

        public Project? GetByName(string Name)
        {
            Project? project = context.projects
                 .Include(p => p.ProjectComments).ThenInclude(C => C.Client)
                .Include(p => p.ProjectImages)
                .Include(p => p.ProjectReview).
                Include(p => p.Client)
                .FirstOrDefault(p => p.ProjectTitle == Name);
            return project;
        }

        public bool Update(Project project, int id)
        {
            var P = context.projects.Find(id);
            if (P is null)
                return false;
            if (id != P.ProjectID)
                return false;
             P.ProjectTitle = project.ProjectTitle;
             P.Description = project.Description;
            P.ProjectDate = project.ProjectDate;
            P.SystemProject = project.SystemProject;
            P.MoneyEarned = project.MoneyEarned;
            P.ProjectImages = project.ProjectImages;
            P.ProjectReview = project.ProjectReview;
            P.ProjectComments = project.ProjectComments;
            P.Client = project.Client;
            context.SaveChanges();
            return true;

        }

    }
}
