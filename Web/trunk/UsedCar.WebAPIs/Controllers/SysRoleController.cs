using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Configuration;

using UsedCar.Domain;
using UsedCar.WebAPIs.Models;

namespace UsedCar.WebAPIs.Controllers
{
    /// <summary>
    ///  角色_APIs（身份验证）
    /// </summary>
    [Authorize]
  	[RoutePrefix("api/role")]
    public class SysRoleController : ApiController
    {
        private SysRoleRepository m_sysRoleRepo = new SysRoleRepository();
        private RoleActionRepository m_roleActionRepo = new RoleActionRepository();
        private string m_errorMessage = EnumService.GetDescription(MessageContent.error);

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role">SysRole</param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        [ResponseType(typeof(Message))]
        public IHttpActionResult AddSysRole(SysRole role)
        {
            try
            {
                string content = string.Empty;
                bool state = false;

                var existRole = m_sysRoleRepo.GetSysRoleForName(role.Name);
                if (null == existRole)
                {
                    role.AddTime = DateTime.Now;
                    bool result = m_sysRoleRepo.AddSysRole(role);
                    if (result)
                    {
                        content = "角色信息添加成功";
                        state = true;
                    }
                    else
                    {
                        content = "角色信息添加失败";
                        state = false;
                    }
                }
                else
                {
                    content = "重复提醒，角色信息（名称）已存在";
                    state = false;
                }
                return Ok(new Message { Content = content, State = state });
            }
            catch
            {
                return BadRequest(m_errorMessage);
            }
        }
            
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="role">SysRole</param>
        /// <returns></returns>
        [HttpPost]
        [Route("modify")]
        [ResponseType(typeof(Message))]
        public IHttpActionResult ModifySysRole(SysRole role)
        {
            try
            {
                string content = string.Empty;
                bool state = false;

                var existRole = m_sysRoleRepo.GetSysRoleForName(role.Name);
                if (null == existRole ||
                    (existRole.Id == role.Id && existRole.Desc != role.Desc))
                {
                    bool result = m_sysRoleRepo.ModifySysRole(role);
                    if (result)
                    {
                        content = "角色信息修改成功";
                        state = true;
                    }
                    else
                    {
                        content = "角色信息修改失败";
                        state = false;
                    }
                }
                else
                {
                    content = "重复提醒，角色信息（名称）已存在";
                    state = false;
                }
                return Ok(new Message { Content = content, State = state });
            }
            catch
            {
                return BadRequest(m_errorMessage);
            }
        }

        
        /// <summary>
        /// 查询角色，条件：SysRole.Id
        /// </summary>
        /// <param name="id">SysRole.Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("find")]
        [ResponseType(typeof(SysRole))]
        public IHttpActionResult FindSysRoleForId(int id)
        {
            try
            {
                var role = m_sysRoleRepo.GetSysRoleForId(id);
                if (null != role)
                {
                    return Ok(role);
                }
                else
                {
                    return Ok(new Message { Content = "未查询到角色信息", State = false });
                }
            }
            catch
            {
                return BadRequest(m_errorMessage);
            }
        }

        /// <summary>
        /// 查询角色
        /// </summary>
        /// <returns>The roles.</returns>
        [HttpGet]
        [Route("list")]
        [ResponseType(typeof(IQueryable<SysRole>))]
        public IHttpActionResult AllSysRoles()
        {
            try
            {
                var roles = m_sysRoleRepo.GetAllSysRoles();
                if (null != roles && roles.Count() > 0)
                {
                    return Ok(roles);
                }
                else
                {
                    return Ok(new Message { Content = "暂无数据", State = false });
                }
            }
            catch
            {
                return BadRequest(m_errorMessage);
            }
        }

        /// <summary>
        /// 添加(修改)角色拥有的模块动作
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="actionIDs"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("action/chg")]
        [ResponseType(typeof(Message))]
        public IHttpActionResult ModifyActionsWithRole(int roleId, string actionIDs)
        {
            try
            {
                bool result = m_roleActionRepo.ModifyRoleActionsWithRoleIdAndActionIDs(roleId, actionIDs);
                if (result)
                {
                    return Ok(new Message { Content = "设置角色拥有模块动作成功", State = true });
                }
                else
                {
                    return Ok(new Message { Content = "设置角色拥有模块动作失败", State = false });
                }
            }
            catch
            {
                return BadRequest(m_errorMessage);
            }
        }

        /// <summary>
        /// 查询角色拥有的模块动作
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("action/find")]
        [ResponseType(typeof(IQueryable<RoleAction>))]
        public IHttpActionResult FindActionsWithRole(int roleId)
        {
            try
            {
                var roleActions = m_roleActionRepo.GetRoleActionsForRoleId(roleId);
                if (null != roleActions && roleActions.Count() > 0)
                {
                    return Ok(roleActions);
                }
                else
                {
                    return Ok(new Message { Content = "暂无数据", State = false });
                }
            }
            catch
            {
                return BadRequest(m_errorMessage);
            }
        }
    }
}
