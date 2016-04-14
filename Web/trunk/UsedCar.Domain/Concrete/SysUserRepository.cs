using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCar.Domain
{
    public class SysUserRepository
    {
        private EFDbContext m_db = new EFDbContext();

        public bool AddSysUser(SysUser user)
        {
            return false;
        }

        /// <summary>
        /// 查询用户信息，条件：用户名与密码
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="loginPwd">密码</param>
        /// <returns></returns>
        public SysUser GetSysUserOfLogin(string loginName, string loginPwd)
        {
            if (loginName == string.Empty || loginPwd == string.Empty)
            {
                return null;
            }
            var query = (from user in m_db.SysUsers
                         where user.LoginPwd == loginPwd && user.LoginName == loginName
                         select user).FirstOrDefault();
            return query;
        }

        public Task<SysUser> GetSysUserByIdAsync(int id)
        {
            // Task异步编程
            return Task.Run(() =>
            {
                var query = (from user in m_db.SysUsers
                             where user.Id == id
                             select user).FirstOrDefault();
                return query;
            });
        }

        public IQueryable<SysUser> GetSysUsers()
        {
            return m_db.SysUsers;
        }

        /// <summary>
        /// 分页查询用户信息
        /// </summary>
        /// <returns>The sys users of page.</returns>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        public IQueryable<SysUser> GetSysUsersOfPage(int pageIndex, int pageSize)
        {
            var query = (from q in m_db.SysUsers
                         select q)
                .OrderByDescending(x => x.AddTime)
                .Take(pageSize * pageIndex)
                .Skip(pageSize * (pageIndex - 1))
                .AsQueryable();
            return query;
        }
    }
}
