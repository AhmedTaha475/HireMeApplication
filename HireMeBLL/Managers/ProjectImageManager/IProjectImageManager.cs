using HireMeBLL.Dtos.ProectImage;
using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface IProjectImageManager
    {
        public List<ProjectImageDto> GetAllByProjectId(int PId);
        public ProjectImageDto GetById(int id);
        public bool Add(CreateProjectImageDto image);
        public bool Delete(int id);
        public bool Update(UpdateProjectImageDto image);
    }
}
