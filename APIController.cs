using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Fundamentals.Models.Requests;
using Fundamentals.Services;
using System.Web.Http;
using Web.Models.Responses;

namespace Fundamentals.Controllers.api
{
    [RoutePrefix("api/features")]
    public class FeaturesApiController : ApiController
    {


        //CREATE        [INSERT/POST]
        [Route(), HttpPost]
        public HttpResponseMessage Add(FeatureAddRequest model) // "public method named "Add" that returns an HtttpResponseMessage, that takes one parameter named "model" of type FeatureAddRequest"
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }


            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
                


        //UPDATE        [UPDATE/PUT]
        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(FeatureUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        

            
        //READ ALL      [GET/SELECT]
        [Route(), HttpGet]                 
        public HttpResponseMessage ReadAll()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemsResponse<MeetUpEvent> resp = new ItemsResponse<MeetUpEvent>();
            resp.Items = FeaturesService.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }



        //READ ONE      [GET/SELECT]
        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage ReadAll()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemsResponse<MeetUpEvent> resp = new ItemsResponse<MeetUpEvent>();
            resp.Items = FeaturesService.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }

        
        
        //DELETE        [DELETE/DELETE]
        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemsResponse<MeetUpEvent> resp = new ItemsResponse<MeetUpEvent>();
            resp.Items = FeaturesService.Delete();

            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }


    }
}
