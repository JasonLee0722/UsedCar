using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using UsedCar.ViewModels;

namespace Service.Abstract
{
    /// <summary>
    /// 接口
    /// </summary>
    public interface ISysManage
    {

        #region 用户管理
        /// <summary>
        /// 获取系统用户列表（小于等于当前用户级别的所有用户）
        /// </summary>
        /// <param name="User_Name">姓名</param>
        /// <param name="RoleLevel">当前用户角色级别</param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        IPagedList<SysUser> getSysUserList(string User_Name, int? RoleLevel, int PageIndex, int PageSize);
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="User_Name">姓名</param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageCount"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        IList<SysUser> GetUserList(string User_Name, int PageSize, int PageIndex, out int PageCount, out int rowCount);
        /// <summary>
        /// 获取系统用户类型
        /// </summary>
        /// <returns></returns>
        IDictionary<string, string> getDictionarySysUserType();
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        int DeleteUser(string UserId);
        /// <summary>
        /// 更改用户状态
        /// </summary>
        /// <param name="SysUser"></param>
        /// <returns></returns>
        int UpdateUserState(string SysUser, int state);
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int AddUser(SysUser user);
        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int EditUser(SysUser user);
        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SysUser GetUserDetail(int id);
        /// <summary>
        /// 登录帐号查询用户
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        SysUser GetUserDetailByLoginName(string LoginName);
        /// <summary>
        /// 添加用户与角色的关联
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddSysUserRole(SysUserRole model);
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        SysUser GetUserInfoByAccount(string account);
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        int UpdatePwd(string account, string pwd);
        /// <summary>
        /// 检查账号是否唯一
        /// </summary>
        /// <param name="LoginName">账号</param>
        /// <returns></returns>
        bool checkLoginNameUnique(string LoginName);

        #endregion

        #region 角色管理

        /// <summary>
        ///  获取角色(全部或小于等于指定级别)
        /// </summary>
        /// <returns></returns>
        IList<Role> GetRolesList(int? RoleLevel);
        /// <summary>
        /// 获取角色根据ID
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        Role GetRole(int RoleId);
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        int AddRole(Role r);
        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        int EditRole(Role r);
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteRole(int id);
        /// <summary>
        /// 获取动作
        /// </summary>
        /// <returns></returns>
        IList<SysAction> GetActions();
        /// <summary>
        /// 根据用户id获取角色id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<int> GetRolesByUserId(int id);
        /// <summary>
        /// 根据用户GUID获取所属角色所拥有的动作
        /// </summary>
        /// <param name="SysUserGuid"></param>
        /// <returns></returns>
        IList<SysAction> GetActionsByUserID(string SysUserGuid);
        /// <summary>
        /// 根据用户id删除用户角色关联
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteUserRoleByUserId(int id);
        /// <summary>
        /// 添加角色权限关联
        /// </summary>
        /// <param name="rmal"></param>
        /// <returns></returns>
        int AddRoleAction(RoleAction ral);
        /// <summary>
        ///  删除角色权限关联
        /// </summary>
        /// <param name="rid"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        int DeleteRoleAction(int rid);
        /// <summary>
        /// 获取动作根据角色id
        /// </summary>
        /// <param name="rid"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        IList<SysAction> GetActionIds(int rid);
        /// <summary>
        /// 根据角色获取角色不拥有的权限
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        IList<SysAction> GetActionByRoleId(int rid);
        /// <summary>
        /// 根据角色获取角色拥有的权限模块
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        IList<int> GetModelHaveAction(int[] rid);
        /// <summary>
        /// 根据角色id获取用户数量
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        int GetUserCountByRoleID(int rid);
        #endregion

        #region 系统模块管理
        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        IList<SysModule> getSysModuleList(int? ParentID);
        SysModule getSysModuleDetail(int ID);
        int createSysModule(SysModule model);
        int updateSysModule(SysModule model);
        int deleteSysModule(string IDs);

        #endregion

        #region 系统权限动作管理
        /// <summary>
        /// 获取权限动作列表
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        IList<SysAction> getSysActionList(int? ModuleID);
        SysAction getSysActionDetail(int ID);
        int createSysAction(SysAction model);
        int updateSysAction(SysAction model);
        int deleteSysAction(string IDs);

        #endregion

        #region 用户角色
        IList<SysUserRole> getSysUserRoleList(string SysUserGuid);
        /// <summary>
        /// 获取用户所属用户最高角色级别
        /// </summary>
        /// <param name="SysUserGuid"></param>
        /// <returns></returns>
        int? getSysUserTopRoleLevel(string SysUserGuid);
        int setSysUserRole(string SysUserGuid, string RoleIDs);
        #endregion

        #region 角色权限
        IList<RoleAction> getRoleActionList(int? RoleID);
        int setRoleAction(int RoleID, string ActionIDs);
        #endregion

        #region 系统初始化
        bool InitSystem();
        /// <summary>
        /// 清空企业业务数据
        /// </summary>
        /// <param name="SysUserGuid">企业登录账号GUID</param>
        /// <returns></returns>
        string ClearData(string SysUserGuid);
        #endregion
    }
}
