using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Entities;
using Zero.Core.IServices;

namespace Zero.Server.Repository
{
    public class AdminRepository : IAdminRepository
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
       private readonly ZeroDBContext _zeroDBContext;

        #region 注入服务
        public AdminRepository(ZeroDBContext zeroDBContext)
        {
            _zeroDBContext = zeroDBContext ?? throw new ArgumentNullException(nameof(zeroDBContext));
        }
        #endregion

        #region 获取管理员表数据
        /// <summary>
        /// 获取管理员表数据
        /// </summary>
        /// <param name="Code">检索项</param>
        /// <returns></returns>
        public async Task<IEnumerable<Admin>> GetAdmins(string Code)
        {
            if (!Code.Equals(null))
            {
                return await _zeroDBContext.Admin.Where(x => EF.Functions.Like(x.Account, Code)).OrderBy(x => x.Account).ToListAsync();
            }
            return await _zeroDBContext.Admin.ToListAsync();
        }
        #endregion

        #region 获取单个管理员
        /// <summary>
        /// 获取单个管理员
        /// </summary>
        /// <param name="code">检索项</param>
        /// <returns></returns>
        public async Task<Admin> GetAdmin(string Code)
        {
            if (Code.Equals(null))
            {
                throw new ArgumentNullException(nameof(Code));
            }
            return await _zeroDBContext.Admin.Where(x => x.Account.Equals(Code)).FirstOrDefaultAsync();

        }
        #endregion

        #region 添加管理员/Add Admin
        /// <summary>
        /// 添加管理员 / Add Admin
        /// </summary>
        /// <param name="admin">Admin_Entity</param>
        /// <returns></returns>
        public async Task<bool> Add(Admin admin)
        {
            admin.Id = Guid.NewGuid();
            _zeroDBContext.Add(admin);
            return await _zeroDBContext.SaveChangesAsync() >= 0;
        }
        #endregion

        #region 修改管理员 / Update Admin
        /// <summary>
        /// 修改管理员 / Update Admin
        /// </summary>
        /// <param name="admin">Admin_Entity</param>
        /// <returns></returns>
        public async Task<bool> Update(Admin admin)
        {
            _zeroDBContext.Entry(admin).State = EntityState.Modified;
            return await _zeroDBContext.SaveChangesAsync() >= 0;
        }
        #endregion

        #region 删除管理员 / Delete Admin
        /// <summary>
        ///  删除管理员 / Delete Admin
        /// </summary>
        /// <param name="admin">Admin_Entity</param>
        /// <returns></returns>
        public async Task<bool> Delete(Admin admin)
        {
            _zeroDBContext.Remove(admin);
            return await _zeroDBContext.SaveChangesAsync() >= 0;
        }
        #endregion
    }
}
