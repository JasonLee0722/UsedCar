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
    /// 系统模块动作_APIs（身份验证）
    /// </summary>
    [Authorize]
    [RoutePrefix("api/action")]
    public class SysActionController : ApiController
    {
        private SysActionRepository m_sysActionRepo = new SysActionRepository();
        private string m_errorMessage = EnumService.GetDescription(MessageContent.error);

        /// <summary>
        /// 添加系统模块动作
        /// </summary>
        /// <param name="action">SysAction</param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        [ResponseType(typeof(Message))]
        public IHttpActionResult AddSysAction(SysAction action)
        {
            try
            {
                string content = string.Empty;
                bool state = false;

                var existAction = m_sysActionRepo.GetSysActionForName(action.Name);
                if (null == existAction)
                {
                    bool result = m_sysActionRepo.AddSysAction(action);
                    if (result)
                    {
                        content = "动作信息添加成功";
                        state = true;
                    }
                    else
                    {
                        content = "动作信息添加失败";
                        state = false;
                    }
                }
                else
                {
                    content = "重复提醒，动作信息（名称）已存在";
                    state = false;
                }
                return Ok(new Message{ Content=content, State=state });
            }
            catch
            {
                return BadRequest(m_errorMessage);
            }
        }

        /// <summary>
        /// 修改系统模块动作
        /// </summary>
        /// <param name="action">SysAction</param>
        /// <returns></returns>
        [HttpPost]
        [Route("modify")]
        [ResponseType(typeof(Message))]
        public IHttpActionResult ModifySysAction(SysAction action)
        {

            try
            {
                string content = string.Empty;
                bool state = false;

                var existAction = m_sysActionRepo.GetSysActionForName(action.Name);
                if (null == existAction ||
                    (existAction.Id == action.Id && existAction.ModuleId != action.ModuleId))
                {
                    bool result = m_sysActionRepo.ModifySysAction(action);
                    if (result)
                    {
                        content = "动作信息修改成功";
                        state = true;
                    }
                    else
                    {
                        content = "动作信息修改失败";
                        state = false;
                    }
                }
                else
                {
                    content = "重复提醒，动作信息（名称）已存在";
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
        /// 查询系统动作信息，条件：SysAction.Id
        /// </summary>
        /// <param name="id">SysAction.Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("find")]
        [ResponseType(typeof(SysAction))]
        public IHttpActionResult FindSysActionForId(int id)
        {
            try
            {
                var module = m_sysActionRepo.GetSysActionForId(id);
                if (null != module)
                {
                    return Ok(module);
                }
                else
                {
                    return Ok(new Message{ Content = "未查询到模块动作信息", State = false });
                }
            }
            catch
            {
                return BadRequest(m_errorMessage);
            }
        }

        /// <summary>
        /// 查询系统动作信息，条件：SysModule.Id
        /// </summary>
        /// <param name="moduleId">SysModule.Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("find")]
        [ResponseType(typeof(IQueryable<SysAction>))]
        public IHttpActionResult FindSysActionsForModuleId(int moduleId)
        {
            try
            {
                var actions = m_sysActionRepo.GetSysActionsForModuleId(moduleId);
                if (null != actions && actions.Count() > 0)
                {
                    return Ok(actions);
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
        /// 查询系统模块动作信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        [ResponseType(typeof(IQueryable<SysAction>))]
        public IHttpActionResult AllSysActions()
        {
            try
            {
                var actions = m_sysActionRepo.GetAllSysActions();
                if (null != actions && actions.Count() > 0)
                {
                    return Ok(actions);
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
