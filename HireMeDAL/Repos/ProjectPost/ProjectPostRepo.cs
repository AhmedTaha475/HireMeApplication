﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class ProjectPostRepo : IProjectPostRepo
    {
        private readonly HireMeContext _hireMeContext;

        public ProjectPostRepo(HireMeContext hireMeContext)
        {
            this._hireMeContext = hireMeContext;
        }
        public bool CreateProjectPost(ProjectPost projectPost)
        {
            try
            {
                _hireMeContext.projectPosts.Add(projectPost);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {

               return false;
            }
            
        }

        public bool DeleteProjectPost(int id)
        {
            var projectPost = _hireMeContext.projectPosts.Find(id);
            if (projectPost != null)
            {
                _hireMeContext.projectPosts.Remove(projectPost);
                SaveChanges();
                return true;
            }return false;
        }

        public List<ProjectPost> GetALl()
        {
            return _hireMeContext.projectPosts.ToList();
        }

        public ProjectPost GetProjectPostById(int id)
        {
            return _hireMeContext.projectPosts.Find(id) ?? null;
        }

        public ProjectPost GetProjectPostWithApplicantsById(int id)
        {
            return _hireMeContext.projectPosts.Include(p=> p.ProjectPostApplicants).FirstOrDefault(p=>p.Pp_Id == id);
        }

        public int SaveChanges()
        {
            return _hireMeContext.SaveChanges();
        }

        public bool UpdateProjectPost(int id, ProjectPost projectPost)
        {
            var currentProjectPost = GetProjectPostById(id);
            if (currentProjectPost != null)
            {
                currentProjectPost.Description = projectPost.Description;
                currentProjectPost.AveragePrice = projectPost.AveragePrice;
                currentProjectPost.ProjectPostApplicants = projectPost.ProjectPostApplicants;
                currentProjectPost.PostTitle = projectPost.PostTitle;
                currentProjectPost.ClientId = projectPost.ClientId;
                currentProjectPost.CategoryId = projectPost.CategoryId;
                currentProjectPost.ProjectPostDate= projectPost.ProjectPostDate;
                currentProjectPost.Milestones = projectPost.Milestones;
                currentProjectPost.Done= projectPost.Done;
                currentProjectPost.location = projectPost.location;
                currentProjectPost.approved = projectPost.approved;
                SaveChanges();
                return true;
            }return false;
        }
    }
}
