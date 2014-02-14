namespace ApiRegistry.Models
{
    public class Link
    {
        public string Rel { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
        public string MediaTypeTag { get; set; }

        public Link(string rel, string url, string method = "GET", string mediaTypeTag = "")
        {
            Rel = rel;
            Url = url;
            Method = method;
            MediaTypeTag = mediaTypeTag;
        }
    }
}