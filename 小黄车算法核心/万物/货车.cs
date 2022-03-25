using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 小黄车算法核心.快捷工具;
using 小黄车算法核心.聚合根;

namespace 小黄车算法核心.万物
{
    public class 货车 : 归一, 取放动作, 运动动作
    {
        public 货车(string 车编号, int 载货量, int 可移动步数, int 初始X, int 初始Y)
        {
            编号 = 车编号;
            最大装载量 = 载货量;
            移动步数 = 可移动步数;
            X = 初始X;
            Y = 初始Y;
        }
        public int 最大装载量 { get; }

        public List<自行车> 当前装载 { get; set; } = new List<自行车>();

        public void 移动()
        {
            //循环走步
            for (int i = 0; i < 移动步数; i++)
            {
                var 新坐标 = 随机方法.随机移动一个向量位置(X, Y);
                X = 新坐标.Key;
                Y = 新坐标.Value;
            }
        }
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
