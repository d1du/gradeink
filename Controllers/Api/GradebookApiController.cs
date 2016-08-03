using Derek.Web.Domain;
using Derek.Web.Models.GradebookEntries;
using Derek.Web.Models.Responses;
using Derek.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Derek.Web.Controllers.Api
{
    [RoutePrefix("api/gradebook")]
    public class GradebookApiController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage AddEntryToGradebook(GradebookEntryAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();

            response.Item = GradebookService.AddGradebookEntry(model);

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage UpdateGradebookEntryById(GradebookEntryUpdateRequest model, int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            model.Id = id;

            SuccessResponse response = new SuccessResponse();

            GradebookService.UpdateGradebookEntryById(model);

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteGradebookEntryById(int id)
        {
            SuccessResponse response = new SuccessResponse();

            GradebookService.DeleteGradebookEntryById(id);

            return Request.CreateResponse(response);
        }

        [Route("getusergrades"), HttpPost]
        public HttpResponseMessage GetUserGrades(ShortenedUserId userId)
        {
            ItemsResponse<BaseGradebookEntry> response = new ItemsResponse<BaseGradebookEntry>();

            response.Items = GradebookService.GetUserGrades(userId);

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetGradebookEntryById(int id)
        {
            ItemResponse<GradebookEntry> response = new ItemResponse<GradebookEntry>();

            response.Item = GradebookService.SelectGradebookEntryById(id);

            return Request.CreateResponse(response);
        }
        //refactor in future
        [Route("HWPercentage/{userId}"), HttpGet]
        public HttpResponseMessage GetHWPercentage(string userId)
        {
            ItemResponse<UserGradePercentage> response = new ItemResponse<UserGradePercentage>();

            response.Item = GradebookService.GetUserPercentage(userId, "dbo.GetUserHWPercentage");

            return Request.CreateResponse(response);
        }

        [Route("QuizPercentage/{userId}"), HttpGet]
        public HttpResponseMessage GetQuizPercentage(string userId)
        {
            ItemResponse<UserGradePercentage> response = new ItemResponse<UserGradePercentage>();

            response.Item = GradebookService.GetUserPercentage(userId, "dbo.GetUserQuizPercentage");

            return Request.CreateResponse(response);
        }

        [Route("TestPercentage/{userId}"), HttpGet]
        public HttpResponseMessage GetTestPercentage(string userId)
        {
            ItemResponse<UserGradePercentage> response = new ItemResponse<UserGradePercentage>();

            response.Item = GradebookService.GetUserPercentage(userId, "dbo.GetUserTestPercentage");

            return Request.CreateResponse(response);
        }

        [Route("OverallPercentage/{userId}"), HttpGet]
        public HttpResponseMessage GetOverallPercentage(string userId)
        {
            ItemResponse<UserGradePercentage> response = new ItemResponse<UserGradePercentage>();

            response.Item = GradebookService.GetUserPercentage(userId, "dbo.GetUserOverallPercentage");

            return Request.CreateResponse(response);
        }


    }
}