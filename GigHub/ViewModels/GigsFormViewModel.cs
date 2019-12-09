using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.ViewModels
{
    public class GigsFormViewModel
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string Venue { get; set; }
        public int Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}