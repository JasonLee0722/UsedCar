using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCar.Domain
{
    public class EngineParmRepository
    {
        private EFDbContext m_db = new EFDbContext();

        /// <summary>
        /// 添加发动机参数
        /// </summary>
        /// <returns>The engine parm.</returns>
        /// <param name="obj">Object.</param>
        public EngineParm AddEngineParm(EngineParm obj)
        {
            var query = FindEngineParmWithObject(obj);
            if (null == query)
            {
                obj.GUID = Guid.NewGuid().ToString();
                m_db.EngineParms.Add(obj);
                m_db.SaveChanges();

                return obj;
            }
            else
                return query;
        }

        /// <summary>
        /// 查询发动机参数信息，条件：GUID
        /// </summary>
        /// <returns>The engine parm by GUI.</returns>
        /// <param name="guid">GUID.</param>
        public EngineParm GetEngineParmForGUID(string guid)
        {
            var query = (from q in m_db.EngineParms
                                  where q.GUID == guid
                                  select q)
                .FirstOrDefault();
            return query;
        }

        /// <summary>
        /// 查询发动机参数信息
        /// </summary>
        /// <returns>The engine parm with object.</returns>
        /// <param name="obj">Object.</param>
        private EngineParm FindEngineParmWithObject(EngineParm obj)
        {
            var query = (from q in m_db.EngineParms
                                  where q.AirIntake == obj.AirIntake &&
                                      q.Cylinder == obj.Cylinder &&
                                      q.FullPower == obj.FullPower &&
                                      q.Torque == obj.Torque &&
                                      q.FuelType == obj.FuelType &&
                                      q.FuelMode == obj.FuelMode &&
                                      q.FSW == obj.FSW &&
                                      q.ES == obj.ES
                                  select q)
                .FirstOrDefault();
            return query;
        }
    }
}

