using Derek.Web.Domain;
using Derek.Web.Models.Assignments;
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
    [RoutePrefix("api/assignments")]
    public class AssignmentsApiController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage AddAssignment(AssignmentAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();

            response.Item = AssignmentService.AddAssignment(model);

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage UpdateAssignment(AssignmentUpdateRequest model, int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            model.Id = id;

            SuccessResponse response = new SuccessResponse();

            AssignmentService.UpdateAssignment(model);

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetAssignmentById(int id)
        {
            ItemResponse<Assignment> response = new ItemResponse<Assignment>();

            response.Item = AssignmentService.SelectAssignmentById(id);

            return Request.CreateResponse(response);
        }

        [Route("period/{id:int}"), HttpGet]
        public HttpResponseMessage GetAssignmentsByPeriod(int period)
        {
            ItemsResponse<Assignment> response = new ItemsResponse<Assignment>();

            response.Items = AssignmentService.GetAssignmentsByPeriod(period);

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteAssignmentById(int id)
        {
            SuccessResponse response = new SuccessResponse();

            AssignmentService.DeleteAssignmentById(id);

            return Request.CreateResponse(response);
        }

        [Route, HttpGet]
        public HttpResponseMessage GetAllAssignments()
        {
            ItemsResponse<Assignment> response = new ItemsResponse<Assignment>();

            response.Items = AssignmentService.GetAllAssignments();

            return Request.CreateResponse(response);
        }

    }
}