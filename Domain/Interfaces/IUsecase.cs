using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Interfaces
{
    public interface IUsecase<Type, IArgs>
    {
        Task<Type> Call(IArgs args);
    }

    public interface IArgs { };
}