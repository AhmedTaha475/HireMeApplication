﻿using Microsoft.EntityFrameworkCore;
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
            try
            {
                context.projects.Add(project);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
                
           
           
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

            var list=context.projects.ToList();
            if(list.Count == 0) return null;
            return list;
        }
        public List<Project>? GetAllByPortfolioId(int Portfolio_Id)
        {
            var list=context.projects.Where(p=>p.PortfolioId == Portfolio_Id).ToList();
            if (list.Count > 0)
                return list;
            return null;
        }
        //GetallByPortfolioId

        public Project? GetById(int id)
        {

            var project=context.projects.FirstOrDefault(p=>p.ProjectID == id);
            if (project == null) return null;
            return project;
        }

        public Project? GetByName(string Name)
        {

            var project=context.projects.FirstOrDefault(p=>p.ProjectTitle == Name);
            return project;
        }

        public Project? GetProjectWithImages(int id)
        {
            return context.projects.Include(p=>p.ProjectImages).FirstOrDefault(p=>p.ProjectID==id);
            
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
            P.ClientId = project.ClientId;
            context.SaveChanges();
            return true;

        }

    }
}
