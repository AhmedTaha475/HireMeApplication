using HireMeDAL.Data.Models;
using HireMeBLL.Dtos.ProjectComment;
using HireMeDAL.Repos.ProjectsComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Managers.ProjectComment
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
            List<HireMeDAL.Data.Models.ProjectComment> projectComments = projectCommentsRepo.GetAllByProjectId(Projectid);
            return projectComments.Select(c => new ProjectCommentReadDto( Comment : c.Comment,
           new ClientChildReadDto() { FName = c.Client.FirstName , LName = c.Client.LastName,img = c.Client.Image,Id=c.Client.Id}
                )).ToList();
        }

        public bool PostComment(CreateProjectCommentDto commentDto)
        {
            if (projectCommentsRepo.Add(new HireMeDAL.Data.Models.ProjectComment()
            {
                Comment = commentDto.Comment,
                ClientId = commentDto.ClientId,
           }))
                return true;
            else return false;
        }

        public bool UpdateComment(UpdateCommentDto updateCommentDto)
        {
           return projectCommentsRepo.Update(new HireMeDAL.Data.Models.ProjectComment()
            {
                Comment = updateCommentDto.Comment,
            }, updateCommentDto.CommentId);
        }
    }
}
