using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Entities;

namespace Zero.Core.IServices
{
    /// <summary>
    /// 管理员
    /// </summary>
   public interface IAdminRepository
    {

        #region 获取管理员表数据
        /// <summary>
        /// 获取管理员表数据
        /// </summary>
        /// <param name="Code">检索项</param>
        /// <returns></returns>
        Task<IEnumerable<Admin>> GetAdmins(string Code);
        #endregion

        #region 获取单个管理员
        /// <summary>
        /// 获取单个管理员
        /// </summary>
        /// <param name="code">检索项</param>
        /// <returns></returns>
        Task<Admin> GetAdmin(string code);
        #endregion

        #region 添加管理员/Add Admin
        /// <summary>
        /// 添加管理员 / Add Admin
        /// </summary>
        /// <param name="admin">Admin_Entity</param>
        /// <returns></returns>
        Task<bool> Add(Admin admin);
        #endregion

        #region 修改管理员 / Update Admin
        /// <summary>
        /// 修改管理员 / Update Admin
        /// </summary>
        /// <param name="admin">Admin_Entity</param>
        /// <returns></returns>
        Task<bool> Update(Admin admin);
        #endregion

        #region 删除管理员 / Delete Admin
        /// <summary>
        ///  删除管理员 / Delete Admin
        /// </summary>
        /// <param name="admin">Admin_Entity</param>
        /// <returns></returns>
        Task<bool> Delete(Admin admin);
        #endregion

    }
}
