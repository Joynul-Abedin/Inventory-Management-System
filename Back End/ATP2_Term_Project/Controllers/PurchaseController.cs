using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ATP2_Term_Project.Repository;
using ATP2_Term_Project.Models;

namespace ATP2_Term_Project.Controllers
{
    [RoutePrefix("api/purchases")]
    public class PurchaseController : ApiController
    {
        CategoryRepository catRepo = new CategoryRepository();
        ProductRepository proRepo = new ProductRepository();
        InformationRepository infoRepo = new InformationRepository();
        PurchaseRepository purRepo = new PurchaseRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(catRepo.GetAll());
        }
        [Route("")]
        public IHttpActionResult Post(Purchase purchase)
        {
            purRepo.Insert(purchase);
            Product pro = proRepo.GetById(purchase.ProductId);
            pro.Quantity += purchase.Quantity;
            proRepo.Edit(pro);
            return Ok();
        }
        [Route("checkInvoice")]
        public IHttpActionResult GetInvoiceUnique(string invoice)
        {
            return Ok(purRepo.GetInvoiceUnique(invoice));
        }
        [Route("suppliers")]
        public IHttpActionResult GetInformationByType()
        {
            return Ok(infoRepo.GetInformationByType("supplier"));
        }
        [Route("products/{id}")]
        public IHttpActionResult GetProductsWithCategory(int id)
        {
            return Ok(proRepo.GetProducts(id));
        }
        [Route("products/{id}/details")]
        public IHttpActionResult GetPurchaseDetails(int id)
        {
            var proDetail = proRepo.GetById(id);
            var purDeatils = purRepo.GetPurchaseByProduct(id);
            var data = new Dictionary<string, string>();
            data.Add("aQuantity", proDetail.Quantity.ToString());
            if (purDeatils != null)
                data.Add("pUnitPrice", purDeatils.NewUnitPrice.ToString());
            else
                data.Add("pUnitPrice", "0");
            return Ok(data);
        }

        [Route("addSupplier")]
        public IHttpActionResult PostAddSupplier(Information info)
        {
            purRepo.PostAddSupplier(info);
            return Ok();
        }

    }
}
