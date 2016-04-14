using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Abstract;
using System.Data;
using System.Data.SqlClient;
using PagedList;
using System.IO;
using UsedCar.ViewModels;
using Common.Utils;
using Newtonsoft.Json;

namespace Service.Concrete
{
    /// <summary>
    /// 接口具体实现
    /// </summary>
    public class SysManage : ISysManage
    {
        //EFDbContext db = new EFDbContext();

        #region 用户管理
        public IPagedList<SysUser> getSysUserList(string User_Name, int? RoleLevel, int PageIndex, int PageSize)
        {
            //GET api/user/all/page{pageIndex}
            string url = string.Format("{0}/api/user/all/page{1}", WEBUtility.WebApiHost, PageIndex);
            var models = NetUtility.GetHttpWithToken<IList<SysUser>>(url);
            //return models.ToPagedList(PageIndex, PageSize);

            var pModels = new StaticPagedList<SysUser>(models, PageIndex, PageSize, 0);
            return pModels;
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="User_Name">姓名</param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageCount"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public IList<SysUser> GetUserList(string User_Name, int PageSize, int PageIndex, out int PageCount, out int rowCount)
        {
            PageCount = 1;
            rowCount = 1;
            //GET api/user/all/page{pageIndex}
            string url = string.Format("{0}/api/user/all/page{1}", WEBUtility.WebApiHost, PageIndex);
            return NetUtility.GetHttpWithToken<IList<SysUser>>(url);
        }
        public IDictionary<string, string> getDictionarySysUserType()
        {
            var _Dic = new Dictionary<string, string>();
            _Dic.Add("0", "中心平台系统用户");
            _Dic.Add("1", "个人（车主）用户");
            return _Dic;
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int DeleteUser(string UserId)
        {
            //POST api/user/delete?id={id} 
            string url = string.Format("{0}/api/user/delete?id={1}", WEBUtility.WebApiHost, UserId);
            return NetUtility.PostHttpWithToken(url);
        }
        /// <summary>
        /// 更改用户状态
        /// </summary>
        /// <param name="state">1:启用 0:停用</param>
        /// <returns></returns>
        public int UpdateUserState(string SysUser, int state)
        {
            //POST api/user/UpdateUserState
            string url = string.Format("{0}/api/user/UpdateUserState", WEBUtility.WebApiHost);
            //添加信息
            Dictionary<string, string> dicFormData = new Dictionary<string, string>();
            dicFormData.Add("SysUser", SysUser);
            dicFormData.Add("state", state.ToString());

            return NetUtility.PostHttpWithToken(url, dicFormData);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(SysUser user)
        {
            //POST api/user/add
            string url = string.Format("{0}/api/user/add", WEBUtility.WebApiHost);

            return NetUtility.PostHttpWithToken(url, user);
        }
        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int EditUser(SysUser user)
        {
            //POST api/user/add
            string url = string.Format("{0}/api/user/add", WEBUtility.WebApiHost);

            return NetUtility.PostHttpWithToken(url, user);
        }
        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysUser GetUserDetail(int id)
        {
            //GET api/user/{id}
            string url = string.Format("{0}/api/user/{1}", WEBUtility.WebApiHost, id);

            return NetUtility.GetHttpWithToken<SysUser>(url);
        }

        public SysUser GetUserDetailByLoginName(string LoginName)
        {
            //return db.SysUsers.AsNoTracking().FirstOrDefault(s => s.LoginName == LoginName);
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加用户与角色的关联
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddSysUserRole(SysUserRole model)
        {
            //db.SysUserRoles.Add(model);
            //return db.SaveChanges();
            //POST api/userrole/add
            string url = string.Format("{0}/api/userrole/add", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, model);
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public SysUser GetUserInfoByAccount(string account)
        {
            //var UserModel = db.SysUsers.FirstOrDefault(u => u.LoginName == account);
            //if (UserModel != null)
            //    UserModel.HasActions = GetActionsByUserID(UserModel.GUID);
            //return UserModel;
            throw new NotImplementedException();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int UpdatePwd(string account, string pwd)
        {
            //return db.Database.ExecuteSqlCommand("Update dbo.[SysUser] Set LoginPwd = @p0  where [LoginName] = @p1", pwd, account);
            throw new NotImplementedException();
        }
        public bool checkLoginNameUnique(string LoginName)
        {
            //return db.SysUsers.Where(m => m.LoginName == LoginName).Count() > 0;
            throw new NotImplementedException();
        }
        #endregion

        #region 角色管理
        /// <summary>
        ///  获取角色(全部或小于等于指定级别)
        /// </summary>
        /// <returns></returns>
        public IList<Role> GetRolesList(int? RoleLevel)
        {
            //GET api/role/all
            //var models = new List<Role>();
            string url = string.Format("{0}/api/role/all", WEBUtility.WebApiHost);
            return NetUtility.GetHttpWithToken<IList<Role>>(url);
        }
        public Role GetRole(int RoleId)
        {
            //GET api/role/{id}
            string url = string.Format("{0}/api/role/{1}", WEBUtility.WebApiHost, RoleId);
            return NetUtility.GetHttpWithToken<Role>(url);
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public int AddRole(Role r)
        {
            //POST api/role/add
            string url = string.Format("{0}/api/role/add", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, r);
        }
        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public int EditRole(Role r)
        {
            //POST api/role/edit
            string url = string.Format("{0}/api/role/edit", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, r);
        }


        /// <summary>
        ///  删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteRole(int id)
        {
            //POST api/role/delete?id={id}
            string url = string.Format("{0}/api/role/delete?id={1}", WEBUtility.WebApiHost, id);
            return NetUtility.PostHttpWithToken(url);
        }
        /// <summary>
        /// 获取动作
        /// </summary>
        /// <returns></returns>
        public IList<SysAction> GetActions()
        {
            //GET api/action/all
            //var models = new List<SysAction>();
            string url = string.Format("{0}/api/action/all", WEBUtility.WebApiHost);
            return NetUtility.GetHttpWithToken<IList<SysAction>>(url);
        }
        /// <summary>
        /// 根据用户id获取角色id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<int> GetRolesByUserId(int id)
        {
            //IEnumerable<int> RolesQuery = from r in db.SysUserRoles
            //                              where r.ID == id
            //                              select r.ID;
            //return RolesQuery.ToList<int>();
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据用户id删除用户角色关联
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteUserRoleByUserId(int id)
        {
            //return db.Database.ExecuteSqlCommand("delete dbo.UserRoleLinks where ID=@p0", id);
            throw new NotImplementedException();
            //POST api/role/delete?id={id}
            //string url = string.Format("{0}/api/role/delete?id={1}", WEBUtility.WebApiHost, id);
            //return NetUtility.PostHttpWithToken(url);
        }
        /// <summary>
        /// 添加角色权限
        /// </summary>
        /// <param name="rmal"></param>
        /// <returns></returns>
        public int AddRoleAction(RoleAction ral)
        {
            //POST api/roleaction/add
            string url = string.Format("{0}/api/roleaction/add", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, ral);
            //throw new NotImplementedException();
        }
        /// <summary>
        ///  删除角色权限关联
        /// </summary>
        /// <param name="rid"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        public int DeleteRoleAction(int rid)
        {
            //return db.Database.ExecuteSqlCommand("delete dbo.RoleActionLinks where ID=@p0", rid);
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取动作根据角色id
        /// </summary>
        /// <param name="rid"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        public IList<SysAction> GetActionIds(int rid)
        {
            //var idList = (from r in db.RoleActions
            //              join a in db.SysActions
            //              on r.ID equals a.ID
            //              where r.ID == rid
            //              select new { Action_ID = a.ID, Action_Name = a.Name }).ToList().Select(a => new SysAction { ID = a.Action_ID, Name = a.Action_Name });

            //return idList.OrderBy(a => a.Sort).ToList<SysAction>();
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据用户GUID获取所属角色所拥有的动作
        /// </summary>
        /// <param name="SysUserGuid"></param>
        /// <returns></returns>
        public IList<SysAction> GetActionsByUserID(string SysUserGuid)
        {
            //var lst = (from r in db.RoleActions
            //           join a in db.SysActions on r.ActionID equals a.ID
            //           where (from ur in db.SysUserRoles
            //                  where ur.SysUser == SysUserGuid
            //                  select ur.RoleID).Contains(r.RoleID)
            //           select new
            //           {
            //               Action_ID = a.ID,
            //               Action_Name = a.Name
            //           }).Distinct().ToList()
            //           .Select(a => new SysAction
            //           {
            //               ID = a.Action_ID,
            //               Name = a.Action_Name
            //           }).OrderBy(a => a.Sort).ToList();
            //return lst;
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据角色获取角色不拥有的权限
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public IList<SysAction> GetActionByRoleId(int rid)
        {
            //List<SysAction> List = new List<SysAction>();

            //SqlParameter[] sp = new SqlParameter[]
            //   {
            //   new SqlParameter("@rid",rid),
            //    };
            //DataTable dtDicType = SqlHelper.GetDataSet(CommandType.StoredProcedure, "proc_GetActionByRoleId", sp);

            //foreach (DataRow reader in dtDicType.Rows)
            //{
            //    SysAction dict = new SysAction();
            //    dict.ID = Convert.ToInt32(reader["ID"]);
            //    dict.Name = reader["Name"].ToString();

            //    List.Add(dict);
            //}
            //return List;
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据角色获取角色拥有的权限模块
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public IList<int> GetModelHaveAction(int[] rid)
        {
            //IEnumerable<int> mids = (from r in db.RoleActions
            //                         join a in db.SysActions on r.ID equals a.ID
            //                         where (rid).Contains(r.ID)
            //                         select a.ModuleID).Distinct();

            //return mids.ToList<int>();
            throw new NotImplementedException();
        }
        /// <summary>
        ///  根据角色id获取用户数量
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public int GetUserCountByRoleID(int rid)
        {
            //return db.SysUserRoles.Count(url => url.ID == rid);
            throw new NotImplementedException();
        }

        #endregion

        #region 系统模块管理
        public IList<SysModule> getSysModuleList(int? ParentID)
        {
            //GET api/module/list
            //var models = new List<SysModule>();
            string url = string.Format("{0}/api/module/list", WEBUtility.WebApiHost);
            return NetUtility.GetHttpWithToken<IList<SysModule>>(url);
        }
        public SysModule getSysModuleDetail(int ID)
        {
            //GET api/module/find?id={id}
            string url = string.Format("{0}/api/module/find?id={1}", WEBUtility.WebApiHost, ID);
            return NetUtility.GetHttpWithToken<SysModule>(url);
        }
        public int createSysModule(SysModule model)
        {
            //POST api/module/add
            string url = string.Format("{0}/api/module/add", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, model);
        }

        public int updateSysModule(SysModule model)
        {
            //POST api/module/modify
            string url = string.Format("{0}/api/module/modify", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, model);
        }

        public int deleteSysModule(string IDs)
        {
            //POST api/module/delete?id={id}
            string url = string.Format("{0}/api/role/delete?id={1}", WEBUtility.WebApiHost, IDs);
            return NetUtility.PostHttpWithToken(url);
        }

        #endregion

        #region 系统权限动作管理

        public IList<SysAction> getSysActionList(int? ModuleID)
        {
            //GET api/action/all
            //var models = new List<SysAction>();
            string url = string.Format("{0}/api/action/all", WEBUtility.WebApiHost);
            return NetUtility.GetHttpWithToken<IList<SysAction>>(url);
        }
        public SysAction getSysActionDetail(int ID)
        {
            //GET api/action/{id}
            string url = string.Format("{0}/api/action/{1}", WEBUtility.WebApiHost, ID);
            return NetUtility.GetHttpWithToken<SysAction>(url);
        }
        public int createSysAction(SysAction model)
        {
            //POST api/action/add
            string url = string.Format("{0}/api/action/add", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, model);
        }

        public int updateSysAction(SysAction model)
        {
            //POST api/action/edit
            string url = string.Format("{0}/api/action/edit", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, model);
        }

        public int deleteSysAction(string IDs)
        {
            //POST api/action/delete?id={id}
            string url = string.Format("{0}/api/action/delete?id={1}", WEBUtility.WebApiHost, IDs);
            return NetUtility.PostHttpWithToken(url);
        }

        #endregion

        #region 用户角色
        public IList<SysUserRole> getSysUserRoleList(string SysUserGuid)
        {
            //GET api/userrole/all
            string url = string.Format("{0}/api/userrole/all", WEBUtility.WebApiHost);
            return NetUtility.GetHttpWithToken<IList<SysUserRole>>(url);
        }
        public int? getSysUserTopRoleLevel(string SysUserGuid)
        {
            //return getSysUserRoleList(SysUserGuid).Min(m => m.RoleLevel);
            throw new NotImplementedException();
        }
        public int setSysUserRole(string SysUserGuid, string RoleIDs)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 角色权限
        public IList<RoleAction> getRoleActionList(int? RoleID)
        {
            //GET api/roleaction/all
            string url = string.Format("{0}/api/roleaction/all", WEBUtility.WebApiHost);
            return NetUtility.GetHttpWithToken<IList<RoleAction>>(url);
        }
        public int setRoleAction(int RoleID, string ActionIDs)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 系统初始化
        public bool InitSystem()
        {
            string _Sql = @"
--业务层数据
--车辆\车主
TRUNCATE TABLE dbo.Car
TRUNCATE TABLE dbo.[Owner]
";
            /*
                字典表不可清空
                dbo.DicName
                dbo.DicType
                dbo.SysModule
                dbo.SysAction
                dbo.CarBrand
                dbo.CarSerie
                dbo.CarSerie
                dbo.Province
                dbo.City
             */
            //int iReturn = db.Database.ExecuteSqlCommand(_Sql);
            //return iReturn > 0;
            throw new NotImplementedException();
        }
        public string ClearData(string SysUserGuid)
        {

            throw new NotImplementedException();
        }

        #endregion
    }
}
