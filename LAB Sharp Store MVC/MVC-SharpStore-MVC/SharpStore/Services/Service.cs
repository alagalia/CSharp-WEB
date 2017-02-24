using SharpStore.Data;

namespace SharpStore.Services
{
    public abstract class Service
    {
        public SharpStoreContext2 Context;

        protected Service(SharpStoreContext2 context)
        {
            this.Context = context;
        }

    }
}