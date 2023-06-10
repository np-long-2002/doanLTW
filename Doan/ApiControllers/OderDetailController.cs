using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Doan.Models;

namespace Doan.ApiControllers
{
    public class OderDetailController : ApiController
    {
        public List<OderDetail> Get()
        {
            DoanDbContext db = new DoanDbContext();
            List<OderDetail> oders = db.OderDetails.ToList();
            return oders;
        }
        public OderDetail GetId(int id)
        {
            DoanDbContext db = new DoanDbContext();
            OderDetail oders = db.OderDetails.Where(x => x.Id == id).FirstOrDefault();
            return oders;
        }
    }
}
