using System.Threading.Tasks;
using Sample.Lambda.Models.Request;

namespace Sample.Lambda.Interfaces
{
    public interface IHandler
    {
        Task Handle(Request request);
    }
}