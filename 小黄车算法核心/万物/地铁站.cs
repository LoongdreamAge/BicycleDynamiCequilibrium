using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 小黄车算法核心.聚合根;

namespace 小黄车算法核心.万物
{
    public class 地铁站 : 归一, 取放动作
    {
        public 地铁站(string 车站编号, int 初始X, int 初始Y)
        {
            编号 = 车站编号;
            X = 初始X;
            Y = 初始Y;
        }

        public List<自行车> 当前装载 { get; set; } = new List<自行车>();

        public 自行车 放下一辆车()
        {
            if (当前装载.Any())
            {
                var 车 = 当前装载.First();
                string 车编号 = 车.编号;
                当前装载.Remove(车);
                return new 自行车(车编号);
            }
            return null;
        }

        public void 获得一辆车(自行车 车车)
        {
            当前装载.Add(车车);
        }
    }
}
