using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Entities;
using Zero.Core.IServices;
using Zero.Infrastructure.Context;

namespace Zero.Infrastructure.Services
{
    public class UserServer : IUserServer
    {

        private readonly ZeroDBContext _ZeroDBContext;

        public UserServer(ZeroDBContext zeroDBContext) {
            _ZeroDBContext = zeroDBContext ?? throw new ArgumentNullException(nameof(zeroDBContext));
        }

        public async Task<int> Add(User user)
        {
            user.Id = new Guid();

            _ZeroDBContext.Add(user);

            return await _ZeroDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(List<string> Codes)
        {
            if (Codes.Equals(null))
            {
                return await _ZeroDBContext.SaveChangesAsync();
            }

            foreach (var item in Codes)
            {
                var result = _ZeroDBContext.User.Where(x => x.Id.Equals(item)).FirstOrDefault();
                _ZeroDBContext.Remove(result);
            }
            return await _ZeroDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Guid Code, User user)
        {
            if (Code.Equals(null))
            {
                return await _ZeroDBContext.SaveChangesAsync();
            }
            _ZeroDBContext.Entry(user).State = EntityState.Modified;
            return await _ZeroDBContext.SaveChangesAsync();
        }

        public async Task<User> User(string Code)
        {
            if (Code.Equals(""))
            {
                throw new ArgumentNullException(nameof(Code));
            }
            return await _ZeroDBContext.User.Where(x => x.Id.Equals(Code)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> Users(string Code)
        {
            if (Code.Equals(""))
            {
                return await _ZeroDBContext.User.ToListAsync();
            }
            return await _ZeroDBContext.User.Where(x => EF.Functions.Contains(x.Account, Code) || EF.Functions.Contains(x.NickName,Code)).ToListAsync();
        }
    }
}
