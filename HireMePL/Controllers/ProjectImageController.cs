using HireMeBLL;
using HireMeBLL.Dtos.ProectImage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectImageController : ControllerBase
    {
        private readonly IProjectImageManager _projectImageManager;

        public ProjectImageController(IProjectImageManager projectImageManager)
        {
            this._projectImageManager = projectImageManager;
        }



        [HttpGet]
        [Route("GetAllImagesByProjectId/{id}")]

        public ActionResult<List<ProjectImageDto>> GetProjectImages(int id) 
        {
              
            var result=_projectImageManager.GetAllByProjectId(id);
            if (result == null)
                return NotFound(new { Message = "No data was found" });
            return Ok(new {Message="Here are all the images",result=result});
        }

        [HttpGet]
        [Route("GetById/{id}")]

        public ActionResult<ProjectImageDto> GetImageById(int id)
        {

            var result = _projectImageManager.GetById(id);
            if (result == null)
                return NotFound(new { Message = "No data was found" });
            return Ok(new { Message = "Here is your image", result = result });
        }



        [HttpPost]
        [Route("AddImage")]
        public ActionResult CreateImage([FromForm]  CreateProjectImageDto image) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
            var result=_projectImageManager.Add(image);
            if(result)
                return Ok(result);
            return BadRequest(new {Message="Something went wrong"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPut]
        [Route("UpdateImage")]

        public ActionResult updateImage(UpdateProjectImageDto updatedimage)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
            var result=_projectImageManager.Update(updatedimage);
            if(result)
                return Ok(result);
            return BadRequest(new {Message = "Somethign Went wrong"});
            }catch (Exception ex)
            {
                return BadRequest(new {Message = ex.Message});
            }


        }


        [HttpDelete]
        [Route("DeleteImage")]

        public ActionResult DeleteImage(int id)
        {
            try
            {

                var result=_projectImageManager.Delete(id);
                if(result)
                   return Ok(new {Message="Image has been deleted" });
                return BadRequest(new { Message = "Something went wrong..." });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
