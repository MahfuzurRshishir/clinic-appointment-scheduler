using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace AAL.Controllers
{
    public class PatientController : ApiController
    {
        [HttpGet]
        [Route("api/patients")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = PatientService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/patients/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var patient = PatientService.Get(id);
                if (patient == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Patient not found" });
                return Request.CreateResponse(HttpStatusCode.OK, patient);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/patients/by_userid/{userId}")]
        public HttpResponseMessage GetByUserId(int userId)
        {
            try
            {
                var patient = PatientService.GetByUserId(userId);
                if (patient == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Patient not found" });
                return Request.CreateResponse(HttpStatusCode.OK, patient);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/patients/search")]
        public HttpResponseMessage Search( string term)
        {
            try
            {
                var results = PatientService.Search(term);
                if(results == null || results.Count ==0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "No Patient Found!");

                }
                return Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/patients/createNew")]
        public HttpResponseMessage Create(PatientDTO dto)
        {
            try
            {
                var result = PatientService.Create(dto);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Patient created" });
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Patient could not be created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/patients/update/{id}")]
        public HttpResponseMessage Update(int id, PatientDTO dto)
        {
            try
            {
                dto.PatientId = id;
                var result = PatientService.Update(dto);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Patient updated" });

                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Patient not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/patients/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = PatientService.Delete(id);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Patient deleted" });

                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Patient not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
