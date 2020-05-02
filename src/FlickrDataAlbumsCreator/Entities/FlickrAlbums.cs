namespace FlickrDataAlbumsCreator.Entities
{
    public class FlickrAlbums
    {
        public Album[] albums { get; set; }

        public class Album
        {
            public string photo_count { get; set; }
            public string id { get; set; }
            public string url { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string view_count { get; set; }
            public string created { get; set; }
            public string last_updated { get; set; }
            public string cover_photo { get; set; }
            public string[] photos { get; set; }
        }
    }
}