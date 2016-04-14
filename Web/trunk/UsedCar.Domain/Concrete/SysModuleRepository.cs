using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace UsedCar.Domain
{
    public class SysModuleRepository
    {
        private EFDbContext m_db = new EFDbContext();

        /// <summary>
        /// 添加功能模块名称
        /// </summary>
        /// <param name="module">SysModule</param>
        /// <returns></returns>
        public bool AddSysModule(SysModule module)
        {
            int? max = (from q in m_db.SysModules
                        where q.ParentId == module.ParentId
                        select (int?)q.Sort).Max();
            int sort = 1;
            if (max.HasValue)
            {
                sort = (int)max + 1;
            }
            module.Sort = sort;
            m_db.SysModules.Add(module);
            int rows = m_db.SaveChanges();
            if (rows > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除功能模块
        /// </summary>
        /// <param name="id">SysModule.Id</param>
        /// <returns></returns>
        public bool DeleteSysModuleForId(int id)
        {
            using (var trans = m_db.Database.BeginTransaction())
            {
                try
                {
                    SqlParameter parm = new SqlParameter("@id", id);
                    string sql = @"DELETE FROM dbo.SystemModule FROM dbo.SystemModule AS a 
                                    LEFT JOIN dbo.SystemAction AS b ON a.id = b.moduleId 
                                    LEFT JOIN dbo.RoleAction AS c ON b.id = c.actionId 
                                    WHERE a.id = @id";
                    int rows = m_db.Database.ExecuteSqlCommand(sql, parm);
                    trans.Commit();
                    if (rows > 0)
                        return true;
                    else
                        return false;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// 修改功能模块
        /// </summary>
        /// <param name="module">SysModule</param>
        /// <returns></returns>
        public bool ModifySysModule(SysModule module)
        {
            var sysModule = this.GetSysModuleForId(module.Id);
            if (sysModule.ParentId != module.ParentId)
            {
                int? max = (from q in m_db.SysModules
                            where q.ParentId == module.ParentId
                            select (int?)q.Sort).Max();
                if (max.HasValue)
                {
                    module.Sort = (int)max + 1;
                }
                else
                {
                    module.Sort = 1;
                }
            }
            var sql = @"UPDATE dbo.SystemModule 
                        SET name = @name, sort = @sort, parentid = @parentid 
                        WHERE id = @id";
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@name", module.Name),
                new SqlParameter("@sort", module.Sort),
                new SqlParameter("@parentid", module.ParentId),
                new SqlParameter("@id", module.Id)
            };
            int rows = m_db.Database.ExecuteSqlCommand(sql, parms);
            if (rows > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 查询功能模块，条件：SysModule.ParentId
        /// </summary>
        /// <param name="parentId">SysModule</param>
        /// <returns></returns>
        public IQueryable<SysModule> GetSysModulesForParentId(int parentId)
        {
            var query = (from q in m_db.SysModules
                         where q.ParentId == parentId
                         select q).OrderBy(x => x.Sort).AsQueryable();
            return query;
        }

        /// <summary>
        /// 查询功能模块，条件：SysMoudle.Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysModule GetSysModuleForId(int id)
        {
            var query = m_db.SysModules.Where(x => x.Id == id).FirstOrDefault();
            return query;
        }

        /// <summary>
        /// 查询功能模块，条件：SysModule.Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SysModule GetSysModuleForName(string name)
        {
            var query = m_db.SysModules.Where(x => x.Name == name).FirstOrDefault();
            return query;
        }

        /// <summary>
        /// 查询所有功能模块
        /// </summary>
        /// <returns></returns>
        public IQueryable<SysModule> GetAllSysModules()
        {
            return m_db.SysModules.OrderBy(x => x.ParentId).ThenBy(x => x.Sort);
        }        
    }
}

