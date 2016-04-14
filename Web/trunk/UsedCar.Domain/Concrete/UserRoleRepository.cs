using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Transactions;

namespace UsedCar.Domain
{
    public class UserRoleRepository
    {
        private EFDbContext m_db = new EFDbContext();

        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool AddUserRole(UserRole role)
        {
            m_db.UserRoles.Add(role);
            int rows = m_db.SaveChanges();
            if (rows > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <returns><c>true</c>, if user role was added, <c>false</c> otherwise.</returns>
        /// <param name="userId">User identifier.</param>
        /// <param name="roleIDs">Role I ds.</param>
        public bool AddUserRole(int userId, string roleIDs)
        {
            bool result = false;
            // 暂不清楚回滚是否有效！需测试结果
            using (TransactionScope trans = new TransactionScope())
            {
                SqlParameter parm = new SqlParameter("@userId", userId);
                string sql = @"DELETE FROM dbo.UserRole WHERE userId = @userId";
                m_db.Database.ExecuteSqlCommand(sql, parm);

                foreach (var id in roleIDs.TrimStart(','))
                {
                    m_db.UserRoles.Add(new UserRole
                        {
                            UserId = userId,
                            RoleId = id,
                            State = 1,
                            AddTime = DateTime.Now
                        });
                }
                m_db.SaveChanges();
                trans.Complete();
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 查询用户角色
        /// </summary>
        /// <returns>The user roles.</returns>
        public IQueryable<UserRole> GetUserRoles()
        {
            return m_db.UserRoles.OrderBy(x => x.AddTime);
        }

        /// <summary>
        /// 查询用户角色，条件：SysUser.Id
        /// </summary>
        /// <returns>The user roles for user identifier.</returns>
        /// <param name="userId">SysUser.Id</param>
        public IQueryable<UserRole> GetUserRolesForUserId(int userId)
        {
            var query = (from t_userRole in m_db.UserRoles
                         join t_sysRole in m_db.SysRoles on t_userRole.RoleId equals t_sysRole.Id
                         where t_userRole.UserId == userId
                         orderby t_userRole.AddTime
                         select new { t_userRole, t_sysRole }).ToList();
            return query.Select(x => new UserRole
                {
                    Id = x.t_userRole.Id,
                    UserId = x.t_userRole.UserId,
                    RoleId = x.t_userRole.RoleId,
                    State = x.t_userRole.State,
                    AddTime = x.t_userRole.AddTime,
                    RoleName = x.t_sysRole.Name
                }).AsQueryable();
        }

        /// <summary>
        /// 查询用户角色，条件：SysRole.Id
        /// </summary>
        /// <returns>The user role for role identifier.</returns>
        /// <param name="roleId">Role identifier.</param>
        public IQueryable<UserRole> GetUserRoleForRoleId(int roleId)
        {
            var query = (from t_userRole in m_db.UserRoles
                                  join t_sysRole in m_db.SysRoles on t_userRole.RoleId equals t_sysRole.Id
                                  where t_sysRole.Id == roleId
                                  orderby t_userRole.AddTime
                                  select new { t_userRole, t_sysRole}).ToList();
            return query.Select(x => new UserRole
                {
                    Id = x.t_userRole.Id,
                    UserId = x.t_userRole.UserId,
                    RoleId = x.t_userRole.RoleId,
                    State = x.t_userRole.State,
                    AddTime = x.t_userRole.AddTime,
                    RoleName = x.t_sysRole.Name
                }).AsQueryable();
        }

        /// <summary>
        /// 修改用户角色
        /// </summary>
        /// <returns><c>true</c>, if user role was modifyed, <c>false</c> otherwise.</returns>
        /// <param name="role">Role.</param>
        public bool ModifyUserRole(UserRole role)
        {
            m_db.Entry<UserRole>(role).State = EntityState.Modified;
            int rows = m_db.SaveChanges();
            if (rows >= 0)
                return true;
            else
                return false;
        }
    }
}

