using AutoMapper;
using Employee_API.Model;
using Employee_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Employee_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        protected ApiResponse _APIRes;
        private readonly IRepo<EmployeeModel> _Repository;
        private Employee_API.Model.ApiResponseHelper _ApiResponseHelper;
        private readonly IMapper _mapper;
        public EmployeeController(IRepo<EmployeeModel> Repository, IMapper mapper)
        {
            _APIRes = new ApiResponse();
            _Repository = Repository;
            _ApiResponseHelper = new ApiResponseHelper();
            _mapper = mapper;
        }

        //Get All Base details.
        [HttpGet]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Route("GetAllEmployeeModels")]

        public async Task<ApiResponse> GetAllEmployeeModels()
        {
            try
            {
                var allEmployeeModels = await _Repository.GetAllAsync();

                if (allEmployeeModels == null || !allEmployeeModels.Any())
                {
                    var Response = _ApiResponseHelper.NotFoundResponse("No data found");
                    return Response;
                }

                return _ApiResponseHelper.OkResponse(allEmployeeModels);
            }
            catch (Exception ex)
            {
                return _ApiResponseHelper.HandleException(ex);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[Route("PostEmployeeModel")]

        public async Task<ApiResponse> PostEmployeeModel([FromBody] PostEmployeeModel_DTO postEmployeeModel_DTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ApiResponseHelper.BadRequest(ModelState);
                }

                EmployeeModel EmployeeModels = _mapper.Map<EmployeeModel>(postEmployeeModel_DTO);

                await _Repository.CreateAsync(EmployeeModels);
                await _Repository.SaveAsync();
                _APIRes.result = _mapper.Map<PostEmployeeModel_DTO>(EmployeeModels);
                _APIRes.HttpStatusCode = HttpStatusCode.Created;
                return _APIRes;


            }
            catch (Exception ex)
            {
                return _ApiResponseHelper.HandleException(ex);
            }

        }
        // We will not implement in front end 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ApiResponse> DeleteEmployeeModelById(int id)
        {
            try
            {
                var EmployeeModelById = await _Repository.GetAllAsyncById(id);
                if (EmployeeModelById == null)
                {
                    var response = _ApiResponseHelper.NotFoundResponse("No Model with given id:" + id + " was found");
                    return response;
                }
                else
                {
                    await _Repository.DeleteAsync(id);
                    await _Repository.SaveAsync();

                    // Return OK response after successful deletion
                    return _ApiResponseHelper.OkResponse("The model was successfully deleted");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                return _ApiResponseHelper.HandleException(ex);
            }
        }
    }
}
