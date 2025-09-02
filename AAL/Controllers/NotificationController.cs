using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace AAL.Controllers
{
    public class NotificationController : ApiController
    {
        [HttpGet]
        [Route("api/notifications")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = NotificationService.Get();
                if(data == null || data.Count ==0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "No Notification is Found!" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/notifications/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var notification = NotificationService.Get(id);
                if (notification == null )
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Notification not found" });
                return Request.CreateResponse(HttpStatusCode.OK, notification);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/notifications/by_userid/{userId}")]
        public HttpResponseMessage GetAllByUserId(int userId)
        {
            try
            {
                var notifications = NotificationService.GetAllByUserId(userId);
                if (notifications == null || notifications.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "No Notifications Found!" });
                return Request.CreateResponse(HttpStatusCode.OK, notifications);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/notifications/unread/by_userid/{userId}")]
        public HttpResponseMessage GetUnreadByUserId(int userId)
        {
            try
            {
                var notifications = NotificationService.GetUnreadByUserId(userId);
                if (notifications == null || notifications.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "No Unread Notifications!" });
                return Request.CreateResponse(HttpStatusCode.OK, notifications);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/notifications/create")]
        public HttpResponseMessage Create(NotificationDTO dto)
        {
            try
            {
                var result = NotificationService.Create(dto);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Notification created" });
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Notification could not be created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/notifications/update/{id}")]
        public HttpResponseMessage Update(int id, NotificationDTO dto)
        {
            try
            {
                dto.NotificationId = id;
                var result = NotificationService.Update(dto);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Notification updated" });

                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Notification not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/notifications/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = NotificationService.Delete(id);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Notification deleted" });

                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Notification not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/notifications/mark_all_as_read/{userId}")]
        public HttpResponseMessage MarkAllAsRead(int userId)
        {
            try
            {
                NotificationService.MarkAllAsRead(userId);
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "All notifications marked as read" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
