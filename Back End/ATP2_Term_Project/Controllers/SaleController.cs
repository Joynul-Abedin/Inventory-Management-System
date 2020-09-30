using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ATP2_Term_Project.Repository;
using ATP2_Term_Project.Models;
using ATP2_Term_Project.Attribute;

namespace ATP2_Term_Project.Controllers
{
    [RoutePrefix("api/sales")]
    [BasicAuthorization]
    public class SaleController : ApiController
    {
        CategoryRepository catRepo = new CategoryRepository();
        ProductRepository proRepo = new ProductRepository();
        InformationRepository infoRepo = new InformationRepository();
        SaleseRepository saleRepo = new SaleseRepository();
        SaleRepository saleRepo1 = new SaleRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(catRepo.GetAll());
        }
        [Route("")]
        public IHttpActionResult Post(Sale sales)
        {
            saleRepo.Insert(sales);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult GetInvoiceNumber(string id)
        {
            Sale sale = saleRepo1.checkInvoice(id);
            if (sale == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(sale);
        }

        [Route("sales/{id}")]
        public IHttpActionResult GetProductsWithCategory(int id)
        {
            return Ok(proRepo.GetProducts(id));
        }
        [Route("details")]
        public IHttpActionResult GetSaleDetails(int? id=0)
        {
            //var proDetail = proRepo.GetById(id);
            //var saleDeatils = saleRepo.GetSalesByProduct(id);
            //var data= new Dictionary<string, string>();
            //data.Add("aQuantity", proDetail.Quantity.ToString());
            //if(saleDeatils != null)
               // data.Add("pUnitPrice", saleDeatils.NewUnitPrice.ToString());
            //else
              //  data.Add("pUnitPrice", "0");
            return Ok(saleRepo.GetSalesWithAllDetails());
        }

    }
}
