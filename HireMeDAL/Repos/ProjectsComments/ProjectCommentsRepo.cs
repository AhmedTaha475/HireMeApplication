using HireMeDAL.Data.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<ProjectComment> GetCommentsByProjectId(int ProjectId)
        {
           return context.projectComments.Include(c=>c.Client).Where(c=>c.ProjectId == ProjectId).ToList();
        }
        public bool Update(ProjectComment comment, int id)
        {
            var C = context.projectComments.Find(id);
            if (C is null)
                return false;
            if (id != C.Id)
                return false;
            C.Comment = comment.Comment;
            context.SaveChanges();
            return true;
        }
    }
}
