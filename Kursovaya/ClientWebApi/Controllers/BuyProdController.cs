using Data;
using System;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Xml;

namespace ClientWebApi.Controllers
{
    public class BuyProdController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
                System.Net.WebResponse resp = req.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string xmlString = sr.ReadToEnd();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xmlString);
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xml.NameTable);
                nsmgr.AddNamespace("ecb", "http://www.ecb.int/vocabulary/2002-08-01/eurofxref");
                nsmgr.AddNamespace("gesmes", "http://www.gesmes.org/xml/2002-08-01");
                XmlNode currencyNode = xml.SelectSingleNode("descendant::ecb:Cube[@currency='RUB']", nsmgr);
                string rate = currencyNode.Attributes.GetNamedItem("rate").Value.Trim().Replace(".", ",");
                var drate = Convert.ToInt32(Math.Round(float.Parse(rate)));
                sr.Close();
                return Ok(drate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IHttpActionResult Get([FromUri]int id)
        {
            if (id == 1)
            {
                using (BaseContext db = new BaseContext())
                {
                    var arr = db.Products
                        .Where(e => e.NameGroup == Namegroup.IronBeton).Select(e => new { IdProd = e.IdProduct, Name = e.Name, Price = e.Price }).ToList();
                    return Ok(arr);
                };
            }

            if (id == 2)
            {
                using (BaseContext db = new BaseContext())
                {
                    var arr = db.Products
                         .Where(e => e.NameGroup == Namegroup.AsphaltBeton).Select(e => new { IdProd = e.IdProduct, Name = e.Name, Price = e.Price }).ToList();
                    return Ok(arr);

                };
            }

            if (id == 3)
            {
                using (BaseContext db = new BaseContext())
                {
                    var arr = db.Products
                         .Where(e => e.NameGroup == Namegroup.KeramzBeton).Select(e => new { IdProd = e.IdProduct, Name = e.Name, Price = e.Price }).ToList();
                    return Ok(arr);
                };
            }
            return BadRequest("Товар не найден");
        }

        // POST: api/BuyProd
        public IHttpActionResult Post([FromBody]Purchase pur)
        {
            using (BaseContext db = new BaseContext())
            {
                try
                {
                    pur.Date = DateTime.Now;
                    db.Purchases.Add(pur);
                    var temp = db.Products.Find(pur.IdProduct);
                    if (temp.Count - pur.Counttovar > 0)
                    {
                        temp.Count = temp.Count - pur.Counttovar;
                        db.SaveChanges();
                        return Ok("Заказ успешно совершён!");
                    }
                    else {
                        return BadRequest("Выбранного товара недостаточно на складе. Масимальное количество товара: " + temp.Count);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

    }
}