using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace AAL.Controllers
{
    public class DoctorController : ApiController
    {
        [HttpGet]
        [Route("api/doctors")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = DoctorService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/doctors/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var doctor = DoctorService.Get(id);
                if (doctor == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Doctor not found" });
                return Request.CreateResponse(HttpStatusCode.OK, doctor);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/doctors/by_userid/{userId}")]
        public HttpResponseMessage GetByUserId(int userId)
        {
            try
            {
                var doctor = DoctorService.GetByUserId(userId);
                if (doctor == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Doctor not found" });
                return Request.CreateResponse(HttpStatusCode.OK, doctor);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/doctors/search")]
        public HttpResponseMessage Search(string term)
        {
            try
            {
                var results = DoctorService.Search(term);
                if (results == null || results.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "No Doctor Found!" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/doctors/create")]
        public HttpResponseMessage Create(DoctorDTO dto)
        {
            try
            {
                var result = DoctorService.Create(dto);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Doctor created" });
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Doctor could not be created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/doctors/update/{id}")]
        public HttpResponseMessage Update(int id, DoctorDTO dto)
        {
            try
            {
                dto.DoctorId = id;
                var result = DoctorService.Update(dto);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Doctor updated" });

                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Doctor not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/doctors/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = DoctorService.Delete(id);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Doctor deleted" });

                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Doctor not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
