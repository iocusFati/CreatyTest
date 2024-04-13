using Infrastructure.AssetProviderService;

namespace Infrastructure.Services.Pool
{
    public class PoolService : IPoolService
    {
        private readonly IAssets _assets;

        public PoolService(IAssets assets)
        {
            _assets = assets;
            
            Initialize();
        }
        
        public void Initialize()
        {
        }
    }
}