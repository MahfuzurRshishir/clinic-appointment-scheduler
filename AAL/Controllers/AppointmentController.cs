using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace AAL.Controllers
{
    public class AppointmentController : ApiController
    {
        [HttpGet]
        [Route("api/appointments")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = AppointmentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/appointments/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var appointment = AppointmentService.Get(id);
                if (appointment == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Appointment not found" });
                return Request.CreateResponse(HttpStatusCode.OK, appointment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/appointments/by_doctorid/{doctorId}")]
        public HttpResponseMessage GetByDoctorId(int doctorId)
        {
            try
            {
                var appointments = AppointmentService.GetByDoctorId(doctorId);
                if (appointments == null || appointments.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "No Appointments Found!" });
                return Request.CreateResponse(HttpStatusCode.OK, appointments);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/appointments/by_patientid/{patientId}")]
        public HttpResponseMessage GetByPatientId(int patientId)
        {
            try
            {
                var appointments = AppointmentService.GetByPatientId(patientId);
                if (appointments == null || appointments.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "No Appointments Found!" });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, appointments);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/appointments/search")]
        public HttpResponseMessage Search(string status = null)
        {
            try
            {
                var results = AppointmentService.Search(status);
                if (results == null || results.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "No Appointments Found!" });
                return Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/appointments/create")]
        public HttpResponseMessage Create(AppointmentDTO dto)
        {
            try
            {

                var result = AppointmentService.Create(dto);
                if (result) {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Appointment created" });
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Appointment could not be created" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/appointments/update/{id}")]
        public HttpResponseMessage Update(int id, AppointmentDTO dto)
        {
            try
            {
                dto.AppointmentId = id;
                var result = AppointmentService.Update(dto);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Appointment updated" });
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Appointment not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/appointments/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = AppointmentService.Delete(id);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Appointment deleted" });
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Appointment not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
