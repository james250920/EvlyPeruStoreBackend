using EvlyPeruStoreBK.Infrastructure.core.Data;

namespace EvlyPeruStoreBK.Infrastructure.core.Repositories
{
    public interface INaturalpersonRepository
    {
        Task<bool> IsEmailRegistered(string email);
        Task<Naturalperson> SignIn(string email, string password);
        Task<bool> SignUp(Naturalperson naturalperson);
        Task<bool> Update(Naturalperson naturalperson);
    }
}