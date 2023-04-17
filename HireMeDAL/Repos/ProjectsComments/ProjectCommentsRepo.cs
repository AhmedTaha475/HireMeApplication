using HireMeDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Repos.ProjectsComments
{
    public class ProjectCommentsRepo : IProjectCommentsRepo
    {
        private readonly HireMeContext context;

        public ProjectCommentsRepo(HireMeContext context)
        {
            this.context = context;
        }
        public bool Add(ProjectComment comment)
        {
            try
            {
                context.projectComments.Add(comment);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var toBeDeleted = context.projectComments.Find(id);
            if (toBeDeleted != null)
            {
                context.projectComments.Remove(toBeDeleted);
                context.SaveChanges();
                return true;
            }
            else return false;
        }

        public List<ProjectComment> GetAllByProjectId(int projectId)
        {
            return context.projectComments.Where(c=>c.ProjectId == projectId).ToList();
        }

        public bool Update(ProjectComment comment, int id)
        {
            var P = context.projectComments.Find(id);
            if (P is null)
                return false;
            if (id != P.Id)
                return false;
            P.Comment = comment.Comment;
            context.SaveChanges();
            return true;
        }
    }
}
