using Scripts.Data;
using Scripts.Infrastructure.Services;

namespace Scripts.Services.PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress progress { get; set; }
    }
}