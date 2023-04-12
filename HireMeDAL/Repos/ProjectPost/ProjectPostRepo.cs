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
        public void CreateProjectPost(ProjectPost projectPost)
        {
            _hireMeContext.projectPosts.Add(projectPost);
            SaveChanges();
        }

        public void DeleteProjectPost(int id)
        {
            var projectPost = _hireMeContext.projectPosts.Find(id);
            if (projectPost != null)
            {
                _hireMeContext.projectPosts.Remove(projectPost);
                SaveChanges();
            }
        }

        public List<ProjectPost> GetALl()
        {
            return _hireMeContext.projectPosts.ToList();
        }

        public ProjectPost GetProjectPostById(int id)
        {
            return _hireMeContext.projectPosts.Find(id) ?? null;
        }

        public int SaveChanges()
        {
            return _hireMeContext.SaveChanges();
        }

        public void UpdateProjectPost(int id, ProjectPost projectPost)
        {
            var currentProjectPost = GetProjectPostById(id);
            if (currentProjectPost != null)
            {
                currentProjectPost.Description = projectPost.Description;
                currentProjectPost.AveragePrice = projectPost.AveragePrice;
                currentProjectPost.ProjectPostApplicants = projectPost.ProjectPostApplicants;
                currentProjectPost.PostTitle = projectPost.PostTitle;
                currentProjectPost.ClientId = projectPost.ClientId;
                currentProjectPost.Client =projectPost.Client;
                currentProjectPost.LookupValue = projectPost.LookupValue;
                currentProjectPost.CategoryId = projectPost.CategoryId;
                currentProjectPost.Pp_Id = projectPost.Pp_Id;
                currentProjectPost.Milestones = projectPost.Milestones;
                currentProjectPost.ProjectPostApplicants = projectPost.ProjectPostApplicants;
                SaveChanges();
            }
        }
    }
}
