using Annenberg.Services;
using Annenberg.Services.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Annenberg.Web.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LandscapesController : ApiController
    {
        readonly ILandscapesService landscapesService;
        public LandscapesController(ILandscapesService landscapesService)
        {
            this.landscapesService = landscapesService;
        }

        [HttpGet, Route("api/landscapes")]
        public HttpResponseMessage GetAll()
        {
            List<AnnenbergLandscape> landscapes = landscapesService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, landscapes);
        }
       
    }
}