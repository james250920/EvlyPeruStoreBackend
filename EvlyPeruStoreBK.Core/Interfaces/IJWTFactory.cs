using EvlyPeruStoreBK.Infrastructure.core.Data;

namespace EvlyPeruStoreBK.Infrastructure.core.Shared
{
    public interface IJWTFactory
    {
        string GenerateJWToken(Naturalperson user);
    }
}