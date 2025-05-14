namespace FrontEnd.Models
{
    public class PageResult<T>
    {
        public List<T> items { get; set; }=new List<T>();
        public int CurrentPage { get; set; }
        public int Pagesize { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

    }
}
