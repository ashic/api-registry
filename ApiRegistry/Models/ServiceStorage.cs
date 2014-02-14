using System.Collections.Generic;

namespace ApiRegistry.Models
{
    public interface ServiceStorage
    {
        IEnumerable<ServiceDefinition> GetServiceLinks();
        void AddService(ServiceDefinition service);
    }

    public class InMemoryServiceStorage : ServiceStorage
    {
        readonly List<ServiceDefinition> _services = new List<ServiceDefinition>();

        public IEnumerable<ServiceDefinition> GetServiceLinks()
        {
            return _services;
        }

        public void AddService(ServiceDefinition service)
        {
            _services.Add(service);
        }
    }

    public class ServiceDefinition
    {
        public string Title { get; private set; }
        public Link Link { get; private set; }

        public ServiceDefinition(string title, Link link)
        {
            Title = title;
            Link = link;
        }
    }
}