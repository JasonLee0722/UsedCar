using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCar.Domain
{
    public class RoleActionRepository
    {
        private EFDbContext m_db = new EFDbContext();

        /// <summary>
        /// 添加角色模块动作
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="actionIDs"></param>
        /// <returns></returns>
        public bool ModifyRoleActionsWithRoleIdAndActionIDs(int roleId, string actionIDs)
        {
            using (var trans = m_db.Database.BeginTransaction())
            {
                try
                {
                    var sql = @"DELETE FROM dbo.RoleAction WHERE RoleId=@roleId";
                    SqlParameter parm = new SqlParameter("@roleId", roleId);
                    m_db.Database.ExecuteSqlCommand(sql, parm);

                    foreach (var actionId in actionIDs.Trim(',').Split(','))
                    {
                        m_db.RoleActions.Add(new RoleAction
                        {
                            RoleId = roleId,
                            ActionId = Convert.ToInt32(actionId)
                        });
                    }
                    m_db.SaveChanges();

                    trans.Commit();

                    return true;
                }
                catch(SqlException sqlEx)
                {
                    trans.Rollback();
                    throw sqlEx;
                }
            }
        }

        /// <summary>
        /// 查询角色模块动作
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IQueryable<RoleAction> GetRoleActionsForRoleId(int roleId)
        {
            var query = (from t_roleAction in m_db.RoleActions
                         join t_action in m_db.SysActions on t_roleAction.ActionId equals t_action.Id
                         where t_roleAction.RoleId == roleId
                         orderby t_action.Sort
                         select new { t_roleAction, t_action }).ToList();
            return query.Select(x => new RoleAction
            {
                Id = x.t_roleAction.Id,
                RoleId = x.t_roleAction.RoleId,
                ActionId = x.t_roleAction.ActionId,
                ActionName = x.t_action.Name,
            }).AsQueryable();
        }
    }
}
