using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 小黄车算法题.Utils;

namespace 小黄车算法题
{
    internal class 货车
    {
        public 货车(string 车编号,int 载货量,int 可移动步数,int 初始X,int 初始Y)
        {
            _编号 = 车编号;
            _最大装载量 = 载货量;
            _移动步数 = 可移动步数;
            X = 初始X;
            Y = 初始Y;
        }

        private string _编号;

        public string 编号
        {
            get
            {
                return _编号;
            }
            private set
            {
                _编号=value;
            }
        }

        private int X { get; set; }
        private int Y { get; set; }
        public KeyValuePair<int, int> 坐标 => new KeyValuePair<int, int>(X, Y);
        
        private int _最大装载量;
        public int 最大装载量
        {
            get
            {
                return _最大装载量;
            }
            private set
            {
                _最大装载量 = value;
            }
        }

        private int _移动步数;
        public int 移动步数
        {
            get
            {
                return _移动步数;
            }
            private set
            {
                _移动步数 = value;
            }
        }

        public List<自行车> 当前装载 { get; set; } = new List<自行车>();

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
        public void 装载一辆车(自行车 车)
        {
            当前装载.Add(车);
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
    }
}
