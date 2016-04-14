using Common.Utils;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsedCar.ViewModels;
//using Webdiyer.WebControls.Mvc;

namespace UsedCar.WebBack.Controllers
{
    [ValidateUserLogin]
    public class SysManageController : BaseController
    {
        [Ninject.Inject]
        private ISysManage m_ISysManage { get; set; }
        [Ninject.Inject]
        private IProvinceService m_IProveince { get; set; }

        #region 账号

        //
        // GET: /SysManage/SysUserIndex
        /// <summary>
        /// 返回系统用户列表分页
        /// </summary>
        /// <param name="id">用户姓名</param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public ActionResult SysUserIndex(string id, int PageIndex = 1)
        {
            getSysUserTypeDisplayList();
            ViewBag.NumberStart = (PageIndex - 1) * WEBUtility.GetPageSize + 1;
            var list = m_ISysManage.getSysUserList(id, GetCurrentUser().TopRoleLevel, PageIndex, WEBUtility.GetPageSize);
            return View(list);
        }

        //
        // GET: /SysManage/SysUserEdit/5
        public ActionResult SysUserEdit(int? id)
        {
            var model = new SysUser() { State = 1 };
            if (id != null)
            {
                model = m_ISysManage.GetUserDetail(id.Value);
            }
            getSysUserTypeSelectList();
            return View(model);
        }

        //
        // POST: /SysManage/SysUserEdit/5
        [HttpPost]
        public ActionResult SysUserEdit(int? id, SysUser model, FormCollection collection)
        {
            try
            {
                if (id == null)
                {
                    model.LoginName = model.LoginName.Trim();
                    if (m_ISysManage.checkLoginNameUnique(model.LoginName))
                    {
                        return Json(new { success = false, message = "此账号已被占用！" });
                    }
                    
                    if (m_ISysManage.AddUser(model) > 0)
                    {
                        //绑定演示车辆
                        string msg = "";
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "添加成功！" + msg });
                    }
                    else
                    {
                        throw new Exception("未添加任何值！");
                    }
                }
                else
                {

                    if (m_ISysManage.EditUser(model) > 0)
                    {
                        //绑定演示车辆
                        string msg = "";//m_ISysManage.DataBindToEnterprise(model);
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "修改成功！" + msg });
                    }
                    else
                    {
                        throw new Exception("未修改任何值！");
                    }
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "<br />");
                return Json(new { success = false, message = string.Format("保存失败！<br />详情：<br />{0}", msg) });
            }
        }
        //
        // GET: /SysManage/SysUserDelete/5
        public ActionResult SysUserDelete(string id)
        {
            try
            {
                if (m_ISysManage.DeleteUser(id) > 0)
                {
                    return Json(new { success = true, message = "删除成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未删除任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("删除失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // GET: /SysManage/UpdateUserState/[sysuser]
        public ActionResult UpdateUserState(string id, int State)
        {
            try
            {
                if (m_ISysManage.UpdateUserState(id, State) > 0)
                {
                    return Json(new { success = true, message = "已成功改变用户状态！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未能将用户状态改变！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("改变用户状态失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // GET: /SysManage/
        public ActionResult ResetPWD(string id)
        {

            try
            {
                if (m_ISysManage.UpdatePwd(id, WEBUtility.CreateMd5("111111")) > 0)
                {
                    return Json(new { success = true, message = "已成功将密码重置为“111111”！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未能将密码重置！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("密码重置失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SysUserPassWordUpdate()
        {
            var model = m_ISysManage.GetUserInfoByAccount(GetCurrentUser().LoginName);
            return View(model);
        }
        [HttpPost]
        public int SysUserPassWordUpdate(string LogName, string LogPwd)
        {

            int i = 0;
            try { i = m_ISysManage.UpdatePwd(LogName, WEBUtility.CreateMd5(LogPwd)); }
            catch { }

            return i;
        }
        [HttpPost]
        public string GetPwdMd5(string Pwd)
        {
            string pwd = "";
            try { pwd = WEBUtility.CreateMd5(Pwd); }
            catch { }

            return pwd;
        }
        public ActionResult validUnique(string LoginName)
        {
            if (m_ISysManage.checkLoginNameUnique(LoginName.Trim()))
            {
                //return Json(new { success = false, message = "此账号已被占用！" }, JsonRequestBehavior.AllowGet);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 角色

        //
        // GET: /SysManage/
        public ActionResult RoleIndex()
        {
            var list = m_ISysManage.GetRolesList(GetCurrentUser().TopRoleLevel);
            return View(list);
        }

        //
        // GET: /SysManage/RoleEdit/5
        public ActionResult RoleEdit(int? id)
        {
            var model = new Role();
            if (id != null)
            {
                model = m_ISysManage.GetRole(id.Value);
            }
            //getMaintenanceTypeSelectList();
            return View(model);
        }

        //
        // POST: /SysManage/RoleEdit/5
        [HttpPost]
        public ActionResult RoleEdit(int? id, Role model, FormCollection collection)
        {
            try
            {
                if (id == null)
                {
                    model.AddTime = DateTime.Now;
                    if (m_ISysManage.AddRole(model) > 0)
                    {
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "添加成功！" });
                    }
                    else
                    {
                        throw new Exception("未添加任何值！");
                    }
                }
                else
                {
                    if (m_ISysManage.EditRole(model) > 0)
                    {
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "修改成功！" });
                    }
                    else
                    {
                        throw new Exception("未修改任何值！");
                    }
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("保存失败！\r\n详情：\r\n{0}", msg) });
            }
        }
        //
        // GET: /SysManage/RoleDelete/5
        public ActionResult RoleDelete(int id)
        {
            try
            {
                if (m_ISysManage.DeleteRole(id) > 0)
                {
                    return Json(new { success = true, message = "删除成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未删除任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("删除失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 用户角色
        public ActionResult SysUserRole(string id)
        {
            var lst = m_ISysManage.getSysUserRoleList(id);
            //获取用户所属最高等级
            ViewBag.Roles = m_ISysManage.GetRolesList(GetCurrentUser().TopRoleLevel);
            return View(lst);
        }
        //
        // POST: /SysManage/SysUserRoleEdit/5
        /// <summary>
        /// 保存已分配项
        /// </summary>
        /// <param name="id">用户GUID</param>
        /// <param name="RoleIDs">逗号分隔的角色ID</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SysUserRoleEdit(string id, string RoleIDs)
        {
            try
            {
                if (m_ISysManage.setSysUserRole(id, RoleIDs) > 0)
                {
                    // TODO: Add update logic here
                    return Json(new { success = true, message = "修改成功！" });
                }
                else
                {
                    throw new Exception("未修改任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "<br />");
                return Json(new { success = false, message = string.Format("保存失败！<br />详情：<br />{0}", msg) });
            }
        }
        #endregion

        #region 角色权限
        public ActionResult RoleAction(int id)
        {
            var lst = m_ISysManage.getRoleActionList(id);
            ViewBag.SysActions = m_ISysManage.getSysActionList(null);
            return View(lst);
        }
        //
        // POST: /SysManage/RoleActionEdit/5
        /// <summary>
        /// 保存已分配项
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="ActionIDs">逗号分隔的动作ID</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RoleActionEdit(int id, string ActionIDs)
        {
            try
            {
                if (m_ISysManage.setRoleAction(id, ActionIDs) > 0)
                {
                    // TODO: Add update logic here
                    return Json(new { success = true, message = "修改成功！" });
                }
                else
                {
                    throw new Exception("未修改任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "<br />");
                return Json(new { success = false, message = string.Format("保存失败！<br />详情：<br />{0}", msg) });
            }
        }
        #endregion

        #region 模块

        //
        // GET: /SysManage/SysModuleIndex
        public ActionResult SysModuleIndex(int? id)
        {
            getSysModuleDisplayList();
            var list = m_ISysManage.getSysModuleList(id);
            return View(list);
        }

        //
        // GET: /SysManage/SysModuleEdit/5
        public ActionResult SysModuleEdit(int? id, int? PID)
        {
            var model = new SysModule() { ParentID = PID ?? 0 };

            if (id != null)
            {
                model = m_ISysManage.getSysModuleDetail(id.Value);
            }
            getParentSysModuleSelectList();
            return View(model);
        }

        //
        // POST: /SysManage/SysModuleEdit/5
        [HttpPost]
        public ActionResult SysModuleEdit(int? id, SysModule model, FormCollection collection)
        {
            try
            {
                if (id == null)
                {
                    if (m_ISysManage.createSysModule(model) > 0)
                    {
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "添加成功！" });
                    }
                    else
                    {
                        throw new Exception("未添加任何值！");
                    }
                }
                else
                {
                    if (m_ISysManage.updateSysModule(model) > 0)
                    {
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "修改成功！" });
                    }
                    else
                    {
                        throw new Exception("未修改任何值！");
                    }
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "<br />");
                return Json(new { success = false, message = string.Format("保存失败！<br />详情：<br />{0}", msg) });
            }
        }
        //
        // GET: /SysManage/SysModuleDelete/5
        public ActionResult SysModuleDelete(int id)
        {
            try
            {
                if (m_ISysManage.deleteSysModule(id.ToString()) > 0)
                {
                    return Json(new { success = true, message = "删除成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未删除任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("删除失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 权限动作

        //
        // GET: /SysManage/SysActionIndex
        public ActionResult SysActionIndex(int? id)
        {
            getSysModuleDisplayList();
            var list = m_ISysManage.getSysActionList(id);
            return View(list);
        }

        //
        // GET: /SysManage/SysActionEdit/5
        public ActionResult SysActionEdit(int? id, int? MID)
        {
            var model = new SysAction() { ModuleID = MID ?? 0 };
            if (id != null)
            {
                model = m_ISysManage.getSysActionDetail(id.Value);
            }
            getParentSysModuleSelectList();
            return View(model);
        }

        //
        // POST: /SysManage/SysActionEdit/5
        [HttpPost]
        public ActionResult SysActionEdit(int? id, SysAction model, FormCollection collection)
        {
            try
            {
                model.Name = model.Name.Trim().Replace(" ", "");
                if (id == null)
                {
                    model.AddTime = DateTime.Now;
                    if (m_ISysManage.createSysAction(model) > 0)
                    {
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "添加成功！" });
                    }
                    else
                    {
                        throw new Exception("未添加任何值！");
                    }
                }
                else
                {
                    if (m_ISysManage.updateSysAction(model) > 0)
                    {
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "修改成功！" });
                    }
                    else
                    {
                        throw new Exception("未修改任何值！");
                    }
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "<br />");
                return Json(new { success = false, message = string.Format("保存失败！<br />详情：<br />{0}", msg) });
            }
        }
        //
        // GET: /SysManage/SysActionDelete/5
        public ActionResult SysActionDelete(int id)
        {
            try
            {
                if (m_ISysManage.deleteSysAction(id.ToString()) > 0)
                {
                    return Json(new { success = true, message = "删除成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未删除任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("删除失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 数据清空

        //清空企业业务数据
        //SysManage/ClearData/
        public ActionResult ClearData(string id)
        {
            try
            {
                string msg = m_ISysManage.ClearData(id);
                if (string.IsNullOrWhiteSpace(msg))
                {
                    return Json(new { success = true, message = "企业业务数据清空成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //throw new Exception("未清空任何资料！");
                    return Json(new { success = false, message = msg }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("执行清空数据操作失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 函数

        #region 显示关联字典
        /// <summary>
        /// 获取系统模块显示关联字典
        /// </summary>
        private void getSysModuleDisplayList()
        {
            var lst = m_ISysManage.getSysModuleList(null);
            var dicItem = new Dictionary<string, string>();
            foreach (var item in lst)
            {
                dicItem.Add(item.ID.ToString(), item.Name);
            }
            ViewBag.SysModuleDisplayList = dicItem;
        }
        /// <summary>
        /// 获取系统用户类型字典
        /// </summary>
        private void getSysUserTypeDisplayList()
        {
            ViewBag.SysUserTypeDisplayList = m_ISysManage.getDictionarySysUserType();
        }
        #endregion

        #region 设置SelectListItem视图包
        /// <summary>
        /// 获取系统用户类型SelectListItem
        /// </summary>
        private void getSysUserTypeSelectList()
        {
            List<SelectListItem> SLItems = new List<SelectListItem>();
            foreach (var item in m_ISysManage.getDictionarySysUserType())
            {
                SLItems.Add(new SelectListItem { Text = item.Value, Value = item.Key });
            }
            ViewBag.SysUserTypeSelectList = SLItems;
        }

        private void getParentSysModuleSelectList()
        {
            List<SelectListItem> SLItems = new List<SelectListItem>();
            foreach (var item in m_ISysManage.getSysModuleList(null))
            {
                SLItems.Add(new SelectListItem { Text = item.Name, Value = item.ID.ToString() });
            }
            ViewBag.ParentSysModuleSelectList = SLItems;
        }
        #endregion

        #endregion
    }
}
