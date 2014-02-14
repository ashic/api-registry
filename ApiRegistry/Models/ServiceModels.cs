using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace ApiRegistry.Models
{
    public class ServiceIndexViewModel : ApiViewModel<Unit>
    {
        public ServiceIndexViewModel(IEnumerable<ServiceDefinition> data, ApiControls controls)
            : base(new Unit(), Combine(data, controls))
        {
        }

        public static ApiControls Combine(IEnumerable<ServiceDefinition> links, ApiControls controls)
        {
            var apiControls = new ApiControls();

            foreach (var link in links)
                apiControls.Add(link.Link);

            foreach (var link in controls.Links)
                apiControls.Add(link);
            
            return apiControls;
        }
    }

    public class ServiceRegistrationViewModel : ApiForm<ServiceRegistrationForm>
    {
        public ServiceRegistrationViewModel(ServiceRegistrationForm data, ApiControls controls) : base(data, controls)
        {
        }
    }

    public class ServiceRegisteredViewModel : ApiViewModel<ServiceDefinition>
    {
        public ServiceRegisteredViewModel(ServiceDefinition registeredService, ApiControls controls) 
            : base(registeredService, controls)
        {
        }
    }


    public class ServiceRegistrationForm
    {
        public string Title { get; set; }
        public string Rel { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
        public string MediaTypeTag { get; set; }
    }
}