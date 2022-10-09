using System;
using System.Collections.Generic;

namespace my_books.Data.ViewModel
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        //You can make a property optional by adding a question mark as written in the above

        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }

        public int PublisherId { get; set; }
        public List<int> AuthorIds { get; set; }
    }

    public class BookWithAuthorsVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        //You can make a property optional by adding a question mark as written in the above

        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }

        public string PublisherName { get; set; }
        public List<string> AuthorNames { get; set; }

    }
}
