using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Stark.Fundamentals.Models.Requests;
using Stark.Web.Services;
using System.Web.Http;
using Stark.Web.Models.Responses;

namespace Stark.Fundamentals.Controllers.api
{
    [RoutePrefix("api/features")]
    public class FeaturesApiController : ApiController
    {

        //CREATE        [INSERT/POST]
        [Route(), HttpPost]
        public HttpResponseMessage Add(FeatureCreateRequest model) // "public method named "Add" that returns an HtttpResponseMessage, that takes one parameter named "model" of type FeatureAddRequest"
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            //instantiate a a 'feature' entity service object, then instantiate ItemResponse from SQL db, attach the instantiated ItemResponse to the 'Feature' entity Service, 
			// passing in the model data with a .Create method. We then return a createResponse request method, passing in the HttpStatusCode, w/ a property of ok, and return the item, 'resp'
            FeaturesService feature = new FeaturesService();
            ItemResponse <int> resp = new ItemResponse<int>();
            resp.Item = feature.Create(model);  //uses featuresService
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
        
        //UPDATE        [UPDATE/PUT]
        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(FeatureUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
           
        ////READ ALL      [GET/SELECT]
        //[Route(), HttpGet]                 
        //public HttpResponseMessage ReadAll()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //    ItemsResponse<Features> resp = new ItemsResponse<Features>();
        //    resp.Items = FeaturesService.GetAll();

        //    return Request.CreateResponse(HttpStatusCode.OK, resp);
        //}


        ////READ ONE      [GET/SELECT]
        //[Route("{id:int}"), HttpGet]
        //public HttpResponseMessage ReadOne()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //    ItemsResponse<Features> resp = new ItemsResponse<Features>();
        //    resp.Items = FeaturesService.GetAll();

        //    return Request.CreateResponse(HttpStatusCode.OK, resp);
        //}

        
        ////DELETE        [DELETE/DELETE]
        //[Route("{id:int}"), HttpDelete]
        //public HttpResponseMessage Delete()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //    ItemsResponse<FeaturesService> resp = new ItemsResponse<FeaturesSer>();
        //    resp.Items = FeaturesService.Delete();

        //    return Request.CreateResponse(HttpStatusCode.OK, resp);
        //}
    }
}
