using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 小黄车算法题.Utils;

namespace 小黄车算法题
{
    internal class 地铁站
    {
        public 地铁站(string 车站编号,int 初始X,int 初始Y)
        {
            _编号 = 车站编号;
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
        
        public List<自行车> 当前装载 { get; set; } = new List<自行车>();

        public void 停放一辆车(自行车 车)
        {
            当前装载.Add(车);
        }

        public 自行车 放走一辆车()
        {
            if (当前装载.Any())
            {
                var 车=当前装载.First();
                if (车==null)
                {
                    //为啥拿不到
                    throw new Exception($"当前拿不到");
                }
                string 车编号 = 车.编号;
                当前装载.Remove(车);
                return new 自行车(车编号);
            }
            return null;
        }
    }
}
