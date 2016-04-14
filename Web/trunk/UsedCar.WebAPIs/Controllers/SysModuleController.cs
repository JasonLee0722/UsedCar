using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using UsedCar.Domain;
using UsedCar.WebAPIs.Models;

namespace UsedCar.WebAPIs.Controllers
{
    /// <summary>
    /// 功能模块_APIs（身份验证）
    /// </summary>
    [Authorize]
    [RoutePrefix("api/module")]
    public class SysModuleController : ApiController
    {
        private SysModuleRepository m_sysModuleRepo = new SysModuleRepository();
        private string m_errorMessage = EnumService.GetDescription(MessageContent.error);

        /// <summary>
        /// 添加功能模块
        /// </summary>
        /// <param name="module">SysModule</param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        [ResponseType(typeof(Message))]
        public IHttpActionResult AddSysModule(SysModule module)
        {
            try
            {
                string content = string.Empty;
                bool state = false;

                var existModule = m_sysModuleRepo.GetSysModuleForName(module.Name);
                if (null == existModule)
                {
                    bool result = m_sysModuleRepo.AddSysModule(module);
                    if (result)
                    {
                        content = "模块信息添加成功";
                        state = true;
                    }
                    else
                    {
                        content = "模块信息添加失败";
                        state = false;
                    }
                }
                else
                {
                    content = "重复提醒，模块信息（名称）已存在";
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
        /// 修改功能模块
        /// </summary>
        /// <param name="module">SysModule</param>
        /// <returns></returns>
        [HttpPost]
        [Route("modify")]
        [ResponseType(typeof(Message))]
        public IHttpActionResult ModifySysModule(SysModule module)
        {
            try
            {
                string content = string.Empty;
                bool state = false;

                var existModule = m_sysModuleRepo.GetSysModuleForName(module.Name);
                if (null == existModule ||
                    (existModule.Id == module.Id && existModule.ParentId != module.ParentId))
                {
                    bool result = m_sysModuleRepo.ModifySysModule(module);
                    if (result)
                    {
                        content = "模块信息修改成功";
                        state = true;
                    }
                    else
                    {
                        content = "模块信息修改失败";
                        state = false;
                    }
                }
                else
                {
                    content = "重复提醒，模块信息（名称）已存在";
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
        /// 查询功能模块，条件：SysModule.Id
        /// </summary>
        /// <param name="id">SysModule.Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("find")]
        [ResponseType(typeof(SysModule))]
        public IHttpActionResult FindSysModuleForId(int id)
        {
            try
            {
                var module = m_sysModuleRepo.GetSysModuleForId(id);
                if (null != module)
                {
                    return Ok(module);
                }
                else
                {
                    return Ok(new Message { Content = "未查询到功能模块信息", State = false });
                }
            }
            catch
            {
                return BadRequest(m_errorMessage);
            }
        }

        /// <summary>
        /// 查询功能模块，条件：SysModule.ParentId
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("find")]
        [ResponseType(typeof(IQueryable<SysModule>))]
        public IHttpActionResult FindSysModulesForParentId(int parentId)
        {
            try
            {
                var modules = m_sysModuleRepo.GetSysModulesForParentId(parentId);
                if (null != modules && modules.Count() > 0)
                {
                    return Ok(modules);
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
        /// 查询所有功能模块
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        [ResponseType(typeof(IQueryable<SysModule>))]
        public IHttpActionResult AllSysModules()
        {
            try
            {
                var modules = m_sysModuleRepo.GetAllSysModules();
                if (null != modules && modules.Count() > 0)
                {
                    return Ok(modules);
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
