using BlazorEcommerce.Server.Services.ProductServices;

namespace BlazorEcommerce.Shared;

public class ServiceResponse<T> : IResponse<ServiceResponse<T>, T>
{
	public T? Data { get; set; }
	public bool Success { get; set; } = true;
	public string Message { get; set; } = string.Empty;

	public static implicit operator ServiceResponse<T>(T data) => new() { Data = data };
	public static implicit operator T?(ServiceResponse<T> response) => response.Data;
}