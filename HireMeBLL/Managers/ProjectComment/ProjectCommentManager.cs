using HireMeBLL;
using HireMeBLL.Managers.ProjectComment;
using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class ProjectCommentManager : IProjectCommentManager
    {
        private readonly IProjectCommentsRepo projectCommentsRepo;

        public ProjectCommentManager(IProjectCommentsRepo projectCommentsRepo)
        {
            this.projectCommentsRepo = projectCommentsRepo;
        }

        public bool DeleteComment(int id)
        {
            return projectCommentsRepo.Delete(id);
        }

        public List<ProjectCommentReadDto> GetAllCommentsWithClientByProjectId(int Projectid)
        {
            List<ProjectComment> projectComments = projectCommentsRepo.GetAllByProjectId(Projectid);
            return projectComments.Select(c => new ProjectCommentReadDto( Comment : c.Comment,
           new UserChildReadDto() { FName = c.Client.FirstName , LName = c.Client.LastName,img = c.Client.Image,Id=c.Client.Id}
                )).ToList();
        }

        public bool PostComment(CreateProjectCommentDto commentDto)
        {
            if (projectCommentsRepo.Add(new ProjectComment()
            {
                Comment = commentDto.Comment,
                ProjectId = commentDto.ProjectId,
                ClientId = commentDto.ClientId,
           }))
                return true;
            else return false;
        }

        public bool UpdateComment(UpdateCommentDto updateCommentDto)
        {
           return projectCommentsRepo.Update(new ProjectComment()
            {
                Comment = updateCommentDto.Comment,
            }, updateCommentDto.CommentId);
        }
    }
}
