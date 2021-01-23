using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Entities;

namespace Zero.Core.IServices
{
    public interface IUserServer
    {
        #region 获取所有用户信息
        Task<IEnumerable<User>> Users(string Code);
        #endregion

        #region 获取单个用户信息
        Task<User> User(string Code);
        #endregion

        #region 新增用户信息
        Task<int> Add(User user);
        #endregion

        #region 修改用户信息
        Task<int> Update(Guid Code,User user);
        #endregion

        #region 删除用户信息
        Task<int> Delete(List<string> Codes);
        #endregion

        #region Login
        Task<int> Login(string Account,string Password);
        #endregion
    }
}
