using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace UsedCar.Domain
{
    public class SysRoleRepository
    {
        private EFDbContext m_db = new EFDbContext();

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role">SysRole</param>
        /// <returns></returns>
        public bool AddSysRole(SysRole role)
        {
            m_db.SysRoles.Add(role);
            int rows = m_db.SaveChanges();
            if (rows > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteSysRoleForId(int id)
        {
            SqlParameter parm = new SqlParameter("@id", id);
            string sql = @"DELETE FROM dbo.SystemRole WHERE ID = @id";
            int rows = m_db.Database.ExecuteSqlCommand(sql, parm);
            if (rows > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="role">SysRole</param>
        /// <returns></returns>
        public bool ModifySysRole(SysRole role)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id", role.Id),
                new SqlParameter("@name", role.Name),
                new SqlParameter("@desc", role.Desc)
            };
            string sql = @"UPDATE dbo.SystemRole SET Name=@name, describe=@desc WHERE id = @id";
            int rows = m_db.Database.ExecuteSqlCommand(sql, parms);
            if (rows > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 查询角色
        /// </summary>
        /// <returns>The sys role.</returns>
        public IQueryable<SysRole> GetAllSysRoles()
        {
            return m_db.SysRoles.OrderBy(x => x.AddTime);
        }

        /// <summary>
        /// 查询角色，条件：Id
        /// </summary>
        /// <param name="id">SysRole.Id</param>
        /// <returns></returns>
        public SysRole GetSysRoleForId(int id)
        {
            return m_db.SysRoles.Find(id);
        }

        /// <summary>
        /// 查询角色，条件：Name
        /// </summary>
        /// <param name="name">SysRole.Name</param>
        /// <returns></returns>
        public SysRole GetSysRoleForName(string name)
        {
            var query = (from q in m_db.SysRoles
                         where q.Name == name
                         select q).FirstOrDefault();
            return query;
        }
        
    }
}

