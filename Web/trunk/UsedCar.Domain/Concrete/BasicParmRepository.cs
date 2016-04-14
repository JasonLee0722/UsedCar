using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCar.Domain
{
    public class BasicParmRepository
    {
        private EFDbContext m_db = new EFDbContext();

        /// <summary>
        /// 添加基本参数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public BasicParm AddBasicParm(BasicParm obj)
        {
            var query = FindBasicParmWithObject(obj);
            if (null == query)
            {
                obj.GUID = Guid.NewGuid().ToString();
                m_db.BasicParms.Add(obj);
                m_db.SaveChanges();
                return obj;
            }
            else
            {
                return query;
            }
        }

        /// <summary>
        /// 查询基本参数，条件：GUID
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public BasicParm GetBasicParmForGUID(string guid)
        {
            var query = (from q in m_db.BasicParms
                                  where q.GUID == guid
                                  select q)
                .FirstOrDefault();
            return query;
        }

        /// <summary>
        /// 查询基本参数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private BasicParm FindBasicParmWithObject(BasicParm obj)
        {
            var query = (from q in m_db.BasicParms
                                  where q.Firm == obj.Firm &&
                                      q.Class == obj.Class &&
                                      q.GearBox == obj.GearBox &&
                                      q.Body == obj.Body &&
                                      q.L == obj.L &&
                                      q.W == obj.W &&
                                      q.H == obj.H &&
                                      q.WheelBase == obj.WheelBase &&
                                      q.Trunk == obj.Trunk &&
                                      q.KG == obj.KG
                                  select q)
                .FirstOrDefault();
            return query;
        }
    }

}
