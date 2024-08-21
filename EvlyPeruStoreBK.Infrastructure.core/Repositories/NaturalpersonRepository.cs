using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvlyPeruStoreBK.Infrastructure;
using EvlyPeruStoreBK.Infrastructure.core.Data;

namespace EvlyPeruStoreBK.Infrastructure.core.Repositories
{
    public class NaturalpersonRepository : INaturalpersonRepository
    {
        private readonly EvlyperuStoredbContext _context;

        public NaturalpersonRepository(EvlyperuStoredbContext context)
        {
            _context = context;
        }
        //SignIn
        public async Task<Naturalperson> SignIn(string email, string password)
        {
            var result = await _context.Naturalperson.Where(x => x.Email == email && x.Password == password)
                .FirstOrDefaultAsync();
            return result;
        }
        //SignUp
        public async Task<bool> SignUp(Naturalperson naturalperson)
        {
            await _context.Naturalperson.AddAsync(naturalperson);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        //Update
        public async Task<bool> Update(Naturalperson naturalperson)
        {
            _context.Naturalperson.Update(naturalperson);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        //EmailRegistered
        public async Task<bool> IsEmailRegistered(string email)
        {
            var result = await _context.Naturalperson.Where(x => x.Email == email).FirstOrDefaultAsync();
            return result != null;
        }


    }
}
