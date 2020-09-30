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
    [RoutePrefix("api/products")]
    [BasicAuthorization]
    public class ProductController : ApiController
    {
        ProductRepository proRepo = new ProductRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(proRepo.GetProductsWithCategory());
        }

        [Route("{id}", Name = "GetProductById")]
        public IHttpActionResult Get(int id)
        {
            Product pro = proRepo.GetById(id);
            if (pro == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            pro.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:11917/api/products/" + pro.Id, HttpMethod = "GET", Relation = "Self" });
            pro.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:11917/api/products", HttpMethod = "POST", Relation = "Create a new Category resource" });
            pro.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:11917/api/products", HttpMethod = "POST", Relation = "Create a new Category resource" });
            pro.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:11917/api/products/" + pro.Id, HttpMethod = "PUT", Relation = "Edit a existing Category resource" });
            pro.HyperLinks.Add(new HyperLink() { HRef = "http://localhost:11917/api/products/" + pro.Id, HttpMethod = "DELETE", Relation = "Delete a existing Category resource" });

            return Ok(pro);
        }

        [Route("")]
        public IHttpActionResult Post(Product pro)
        {
            proRepo.Insert(pro);
            string url = Url.Link("GetProductById", new { id = pro.Id });
            return Created(url, pro);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody]Product pro, [FromUri]int id)
        {
            pro.Id = id;
            proRepo.Edit(pro);
            return Ok(pro);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            proRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
