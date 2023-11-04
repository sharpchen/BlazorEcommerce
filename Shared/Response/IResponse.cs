namespace BlazorEcommerce.Server.Services.ProductServices;

internal interface IResponse<TResponse, TData>
    where TResponse : IResponse<TResponse, TData>, new()
{
    TData? Data { get; set; }
    string Message { get; set; }
    bool Success { get; set; }
    abstract static implicit operator TResponse(TData data);
    abstract static implicit operator TData?(TResponse response);
}