namespace mineria.Data
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public MetaData Meta { get; set; }

        public ApiResponse(T data, MetaData meta)
        {
            Data = data;
            Meta = meta;
        }
    }
}
