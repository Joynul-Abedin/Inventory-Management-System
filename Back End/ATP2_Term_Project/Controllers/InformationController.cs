using ATP2_Term_Project.Attribute;
using ATP2_Term_Project.Models;
using ATP2_Term_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ATP2_Term_Project.Controllers
{
    [RoutePrefix("api/informations")]
    public class InformationController : ApiController
    {
        InformationRepository infoRepo = new InformationRepository();

        [Route("")]
        [BasicAuthorization]

        public IHttpActionResult Get()
        {

            return Ok(infoRepo.GetAll());
        }

        [Route("users")]
        [BasicAuthorization]

        public IHttpActionResult GetUsers()
        {

            return Ok(infoRepo.GetUsers());
        }
     
        [Route("{id}", Name = "GetInfoById")]
        [BasicAuthorization]
        public IHttpActionResult Get(int id)
        {
            Information info = infoRepo.GetById(id);
            if (info == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

           
            return Ok(info);
        }

        [Route("{id}")]
        [BasicAuthorization]
        public IHttpActionResult Put([FromBody]Information info, [FromUri]int id)
        {
            info.InformationId = id;
            infoRepo.Edit(info);
            return Ok(info);
        }

        [Route("")]
        public IHttpActionResult Post(Information info)
        {
            infoRepo.Insert(info);
            string url = Url.Link("GetInfoById", new { id = info.InformationId });
            return Created(url, info);
        }
        [BasicAuthorization]
        [Route("salers")]
        public IHttpActionResult GetInformationByTypes()
        {
            return Ok(infoRepo.GetInformationByType("saler"));
        }
    }
}
