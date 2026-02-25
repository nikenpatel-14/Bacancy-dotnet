using AssignmeentWebApi.Services.Interface;

namespace AssignmeentWebApi.Services
{
    public class GuidService : ITransientGuidService,ISingletonGuidService,IScoppedGuidService
    {
        private readonly Guid _Id;
        public GuidService()
        {
            _Id = Guid.NewGuid();
        }

        public Guid getId() => _Id;
    }
}
