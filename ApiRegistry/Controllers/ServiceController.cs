using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using System.Web.Mvc;
using ApiRegistry.Models;

namespace ApiRegistry.Controllers
{
    public class ServiceController : ApiController
    {
        private readonly ServiceStorage _serviceStorage;

        public ServiceController(ServiceStorage serviceStorage)
        {
            _serviceStorage = serviceStorage;
        }

        // GET api/<controller>
        public ServiceIndexViewModel Get()
        {
            var services = _serviceStorage.GetServiceLinks();
            var controls = new ApiControls();
            controls.Add("register-service", Url.Link("DefaultApi", new{controller="ServiceRegistration"}));
            controls.Add("docs", "/home/index");

            var vm = new ServiceIndexViewModel(services, controls);
            return vm;
        }
    }
}