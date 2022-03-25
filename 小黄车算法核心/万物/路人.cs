using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 小黄车算法核心.元数;
using 小黄车算法核心.快捷工具;
using 小黄车算法核心.聚合根;

namespace 小黄车算法核心.万物
{
    public class 路人 : 归一, 取放动作, 运动动作
    {
        public 路人(string 路人编号, int 可移动步数, int 初始X, int 初始Y)
        {
            编号 = 路人编号;
            移动步数 = 可移动步数;
            X = 初始X;
            Y = 初始Y;
        }
        public 自行车 当前骑车 { get; set; }

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

        public 地铁站 我在哪一站()
        {
            return 元.地铁站们.FirstOrDefault(x => x.Value.坐标.X == X && x.Value.坐标.Y == Y).Value ?? null;
        }

        public bool 我在路上么 => 我在哪一站() == null;

        public 自行车 放下一辆车()
        {
            if (当前骑车 != null)
            {
                string 车编号 = 当前骑车.编号;
                当前骑车 = null;
                return new 自行车(车编号);
            }

            return null;
        }

        public void 获得一辆车(自行车 车车)
        {
            当前骑车 = 车车;
        }
    }
}