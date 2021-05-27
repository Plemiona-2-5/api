using Infrastructure.Data;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationDbContext Context;

        protected BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        
        protected async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                return false;
            }
        }
    }
}
