namespace ERP_System.Helpers
{
    public class Pagination<T> where T :class
    {
   

        public Pagination(int PageIndex,int PageSize,int Count,IReadOnlyList<T> data)
        {
            
            _PageIndex = PageIndex;
            _PageSize = PageSize;
            _Count = Count;
            _data = data;
        }

        public int _PageIndex { get; }
        public int _PageSize { get; }
        public int _Count { get; }
        public IReadOnlyList<T> _data { get; }
    }
}
