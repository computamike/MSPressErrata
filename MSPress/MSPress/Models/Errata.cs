using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSPress.Models
{

    public enum Status
    {
        Pending,
        Confirmed,
        Fixed
    }

    /// <summary>
    /// Basic Class detailing Errors in a book.
    /// </summary>
    public class Erratum
    {
        public int ID{ get; set; }
        public virtual ApplicationUser Reporter { get; set; }
        public Status Status { get; set; }
        public int PageNumber { get; set; }
        public string DescriptionOfError { get; set; }
        public virtual Book Book { get; set; }
    }

    /// <summary>
    /// Basic class detailing a publication.
    /// </summary>
    public class Book
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public string Image { get; set; }
        public virtual List<Erratum> BookErrata { get; set; }
    }

}