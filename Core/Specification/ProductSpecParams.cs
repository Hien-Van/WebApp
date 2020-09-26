namespace Core.Specification
{
    public class ProductSpecParams
    {

        private int _maxPageSize = 50;

        public int PageIndex { get; set; } = 1;

        private int _pageSize;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > _maxPageSize? _maxPageSize: value;
        }
        public string Sort { get; set; }
        private string _search;

        public string Search 
        {
            get => _search;
            set => _search = value.ToLower();
        }
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
    }
}