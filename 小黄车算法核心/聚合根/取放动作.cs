using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 小黄车算法核心.万物;

namespace 小黄车算法核心.聚合根
{
    public interface 取放动作
    {
        public 自行车 放下一辆车();
        public void 获得一辆车(自行车 车车);
    }
}
