using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace UsedCar.Domain
{
    public class SysActionRepository
    {
        private EFDbContext m_db = new EFDbContext();

        /// <summary>
        /// 添加系统模块动作
        /// </summary>
        /// <param name="action">SysAction</param>
        /// <returns></returns>
        public bool AddSysAction(SysAction action)
        {
            int? maxSort = (from q in m_db.SysActions
                            where q.ModuleId == action.ModuleId
                            select (int?)q.Sort).Max();
            if (maxSort.HasValue)
            {
                action.Sort = (int)maxSort + 1;
            }
            else
            {
                action.Sort = 1;
            }
            m_db.SysActions.Add(action);
            int rows = m_db.SaveChanges();
            if (rows > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改系统模块动作
        /// </summary>
        /// <param name="action">SysAction</param>
        /// <returns></returns>
        public bool ModifySysAction(SysAction action)
        {
            var sysAction = this.GetSysActionForId(action.Id);
            if (sysAction.ModuleId != action.ModuleId)
            {
                int? maxSort = (from q in m_db.SysActions
                                where q.ModuleId == action.ModuleId
                                select (int?)q.Sort).Max();
                if (maxSort.HasValue)
                {
                    action.Sort = (int)maxSort + 1;
                }
                else
                {
                    action.Sort = 1;
                }
            }
            var sql = @"UPDATE dbo.SystemAction 
                        SET Name=@name, ModuleId=@moduleId, Sort=@sort 
                        WHERE Id=@id";
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@name", action.Name),
                new SqlParameter("@moduleId", action.ModuleId),
                new SqlParameter("@sort", action.Sort),
                new SqlParameter("@id", action.Id)
            };
            int rows = m_db.Database.ExecuteSqlCommand(sql, parms);
            if (rows > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 查询系统模块动作，条件：Id
        /// </summary>
        /// <param name="id">SysAction.Id</param>
        /// <returns></returns>
        public SysAction GetSysActionForId(int id)
        {
            var query = (from t_action in m_db.SysActions
                         join t_module in m_db.SysModules on t_action.ModuleId equals t_module.Id
                         where t_action.Id == id
                         select new
                         {
                             Id = t_action.Id,
                             Name = t_action.Name,
                             ModuleId = t_action.ModuleId,
                             Code = t_action.Code,
                             Sort = t_action.Sort,
                             ModuleName = t_module.Name
                         }).SingleOrDefault();
            if (null == query)
            {
                return null;
            }
            return new SysAction
            {
                Id = query.Id,
                Name = query.Name,
                ModuleId = query.ModuleId,
                Code = query.Code,
                Sort = query.Sort,
                ModuleName = query.Name
            };
        }

        /// <summary>
        /// 查询系统动作模块，条件：Name
        /// </summary>
        /// <param name="name">SysAction.Name</param>
        /// <returns></returns>
        public SysAction GetSysActionForName(string name)
        {
            var query = (from t_action in m_db.SysActions
                         join t_module in m_db.SysModules on t_action.ModuleId equals t_module.Id
                         where t_action.Name == name
                         select new
                         {
                             Id = t_action.Id,
                             Name = t_action.Name,
                             ModuleId = t_action.ModuleId,
                             Code = t_action.Code,
                             Sort = t_action.Sort,
                             ModuleName = t_module.Name
                         }).FirstOrDefault();
            if (null == query)
            {
                return null;
            }
            return new SysAction
            {
                Id = query.Id,
                Name = query.Name,
                ModuleId = query.ModuleId,
                Code = query.Code,
                Sort = query.Sort,
                ModuleName = query.Name
            };
        }

        /// <summary>
        /// 查询系统模块动作，条件：SysModule.Id
        /// </summary>
        /// <param name="moduleId">SysModule.Id</param>
        /// <returns></returns>
        public IQueryable<SysAction> GetSysActionsForModuleId(int moduleId)
        {
            var query = (from t_action in m_db.SysActions
                         join t_module in m_db.SysModules on t_action.ModuleId equals t_module.Id
                         where t_module.Id == moduleId
                         orderby t_module.ParentId, t_module.Sort, t_action.Sort
                         select new
                         {
                             t_action,
                             t_module
                         }).ToList();
            return query.Select(x => new SysAction
            {
                Id = x.t_action.Id,
                Name = x.t_action.Name,
                ModuleId = x.t_action.ModuleId,
                Code = x.t_action.Code,
                Sort = x.t_action.Sort,
                ModuleName = x.t_module.Name
            }).AsQueryable();
        }

        /// <summary>
        /// 查询系统模块动作
        /// </summary>
        /// <returns></returns>
        public IQueryable<SysAction> GetAllSysActions()
        {
            var query = (from t_action in m_db.SysActions
                         join t_module in m_db.SysModules on t_action.ModuleId equals t_module.Id
                         orderby t_module.ParentId, t_module.Sort, t_action.Sort
                         select new
                         {
                             t_action,
                             t_module
                         }).ToList();
            return query.Select(x => new SysAction
            {
                Id = x.t_action.Id,
                Name = x.t_action.Name,
                ModuleId = x.t_action.ModuleId,
                Code = x.t_action.Code,
                Sort = x.t_action.Sort,
                ModuleName = x.t_module.Name
            }).AsQueryable();
        }
    }
}

