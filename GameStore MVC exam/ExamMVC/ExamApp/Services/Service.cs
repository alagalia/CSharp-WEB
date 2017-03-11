using ExamApp.Data;

namespace ExamApp.Services
{
    public abstract class Service
    {
        public SoftUniStoreContext Context;
        
        protected Service()
        {
            this.Context = Data.Data.Context;
        }
    }
}