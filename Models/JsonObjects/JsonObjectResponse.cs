namespace NasaApolo.Models.JsonObjects
{
    public class JsonObjectResponse
    {
        public Collection collection { get; set; }

        public class Collection
        {
            public string? version { get; set; }
            public string? href { get; set; }

            public List<Item>? items { get; set; }
        }

        public class Item
        {
            public string href { get; set; }
            public List<Data> data { get; set; }
            public List<Link> links { get; set; }
        }

        public class Data
        {
            public string center { get; set; }
            public string title { get; set; }
            public List<string> keywords { get; set; }
            public string nasa_id { get; set; }
            public string date_created { get; set; }
            public string media_type { get; set; }
            public string description { get; set; }

        }

        public class Link
        {
            public string href { get; set; }

            public string rel { get; set; }

            public string render { get; set; }

        }

    }

   

}
