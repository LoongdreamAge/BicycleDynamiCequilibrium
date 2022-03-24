using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 小黄车算法题.Utils;

namespace 小黄车算法题
{
    internal class 路人
    {
        public 路人(string 路人编号, int 可移动步数, int 初始X, int 初始Y)
        {
            _编号 = 路人编号;
            _移动步数 = 可移动步数;
            X = 初始X;
            Y = 初始Y;
        }

        private string _编号;

        public string 编号
        {
            get { return _编号; }
            private set { _编号 = value; }
        }

        private int _移动步数;

        public int 移动步数
        {
            get { return _移动步数; }
            private set { _移动步数 = value; }
        }

        private int X { get; set; }
        private int Y { get; set; }
        public KeyValuePair<int, int> 坐标 => new KeyValuePair<int, int>(X, Y);

        public 自行车 当前骑车 { get; set; }

        public void 移动()
        {
            //循环走步
            for (int i = 0; i < _移动步数; i++)
            {
                var 新坐标 = 随机方法.随机移动一个向量位置(X, Y);
                X = 新坐标.Key;
                Y = 新坐标.Value;
            }
        }
        public void 骑走一辆车(自行车 车)
        {
            当前骑车 = 车;
        }

        public 自行车 停下一辆车()
        {
            if (当前骑车 != null)
            {
                string 车编号 = 当前骑车.编号;
                当前骑车 = null;
                return new 自行车(车编号);
            }

            return null;
        }

        public 地铁站 我在哪一站(Dictionary<string, 地铁站> 地铁站们)
        {
            return 地铁站们.FirstOrDefault(x => x.Value.坐标.Key == X && x.Value.坐标.Value == Y).Value ?? null;
        }
    }
}