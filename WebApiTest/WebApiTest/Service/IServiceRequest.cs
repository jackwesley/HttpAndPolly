using System.Threading.Tasks;

namespace WebApiTest.Service
{
    public interface IServiceRequest
    {
        Task<object> GetDeckOfCards(int cards);
        Task<object> PostDeckOfCards(int cards);
    }
}
