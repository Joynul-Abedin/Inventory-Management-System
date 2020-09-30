using ATP2_Term_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ATP2_Term_Project.Controllers
{
    [RoutePrefix("api/report")]
    public class ReportController : ApiController
    {
        PurchaseRepository purRepo = new PurchaseRepository();
        SaleseRepository saleRepo = new SaleseRepository();

        [Route("purchase")]
        public IHttpActionResult GetPurchaseWithAllDetails()
        {
            return Ok(purRepo.GetPurchaseWithAllDetails());
        }

        [Route("purchase/from/{date}")]
        public IHttpActionResult GetPurchaseFromDate(DateTime date)
        {
            return Ok(purRepo.GetPurchaseFromDate(date));
        }
        [Route("purchase/to/{date}")]
        public IHttpActionResult GetPurchaseToDate(DateTime date)
        {
            return Ok(purRepo.GetPurchaseToDate(date));
        }
        [Route("purchase/{from}/{to}")]
        public IHttpActionResult GetPurchaseBetweenDate(DateTime from, DateTime to)
        {
            return Ok(purRepo.GetPurchaseBetweenDate(from, to));
        }

        [Route("sales")]
        public IHttpActionResult GetSaleeWithAllDetails()
        {
            return Ok(saleRepo.GetSalesWithAllDetails());
        }

        [Route("sales/from/{date}")]
        public IHttpActionResult GetSaleFromDate(DateTime date)
        {
            return Ok(saleRepo.GetSaleFromDate(date));
        }
        [Route("sales/to/{date}")]
        public IHttpActionResult GetSaleToDate(DateTime date)
        {
            return Ok(saleRepo.GetSaleToDate(date));
        }
        [Route("sales/{from}/{to}")]
        public IHttpActionResult GetSaleBetweenDate(DateTime from, DateTime to)
        {
            return Ok(saleRepo.GetSaleBetweenDate(from, to));
        }

    }
}

