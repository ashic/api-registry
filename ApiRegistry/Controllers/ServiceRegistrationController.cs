using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ApiRegistry.Models;

namespace ApiRegistry.Controllers
{
    public class ServiceRegistrationController : ApiController
    {
        private readonly ServiceStorage _storage;

        public ServiceRegistrationController(ServiceStorage storage)
        {
            _storage = storage;
        }


        public ServiceRegistrationViewModel Get()
        {
            var apiControls = new ApiControls()
                .Add("submit", Url.Route("DefaultApi", new{controller = "ServiceRegistration"}), "POST")
                .Add("docs", "/home/service-registration");

            return new ServiceRegistrationViewModel(new ServiceRegistrationForm(), apiControls);
        }

        public HttpResponseMessage Post(ServiceRegistrationForm form)
        {
            var definition = new ServiceDefinition(form.Title,
                new Link(form.Rel, form.Url, form.Method, form.MediaTypeTag));
            
            _storage.AddService(definition);

            var location = new Uri(form.Url);

            var controls = new ApiControls()
                .Add("services", Url.Link("DefaultApi", new {controller = "Service"}))
                .Add("docs", "/home/service-registered");

            var vm = new ServiceRegisteredViewModel(definition, controls);

            var response = Request.CreateResponse(HttpStatusCode.Created, vm);
            response.Headers.Location = location;

            return response;
        }
    }
}
