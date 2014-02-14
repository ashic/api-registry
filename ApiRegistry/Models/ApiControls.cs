using System.Collections.Generic;

namespace ApiRegistry.Models
{
    public class ApiControls
    {
        private readonly List<Link> _links = new List<Link>(); 
        public ICollection<Link> Links { get { return _links; } }

        public ApiControls Add(Link link)
        {
            _links.Add(link);
            return this;
        }

        public ApiControls Add(string rel, string url, string method = "GET", string mediaTypeTag = "")
        {
            return Add(new Link(rel, url, method, mediaTypeTag));
        }

    }
}