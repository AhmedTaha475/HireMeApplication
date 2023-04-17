using HireMeBLL;

namespace HireMeBLL.Managers.ProjectComment
{
    public interface IProjectCommentManager
    {
        public bool PostComment(CreateProjectCommentDto commentDto);
        public bool DeleteComment(int id);
        public bool UpdateComment(UpdateCommentDto updateCommentDto);
        public List<ProjectCommentReadDto> GetAllCommentsWithClientByProjectId(int Projectid);
    }
}