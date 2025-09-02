using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace AAL.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/users")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var user = UserService.Get(id);
                if (user == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/users/create")]
        public HttpResponseMessage Create(UserDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

                var result = UserService.Create(dto);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.Created, new { Message = "User created" });
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "User could not be created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/users/update/{id}")]
        public HttpResponseMessage Update(int id, UserDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

                dto.UserId = id;
                var result = UserService.Update(dto);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "User updated" });

                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        //[HttpPatch]
        //[Route("api/users/update/{id}")]
        //public HttpResponseMessage update(int id, UserDTO dto)
        //{

        //}


        [HttpDelete]
        [Route("api/users/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = UserService.Delete(id);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "User deleted" });

                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
