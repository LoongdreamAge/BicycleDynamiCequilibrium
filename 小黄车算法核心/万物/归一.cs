using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小黄车算法核心.万物
{
    public class 归一
    {
        public string 编号 { get; protected set; }
        public int 移动步数 { get; protected set; }
        protected int X { get; set; }
        protected int Y { get; set; }
        public Point 坐标 => new Point(X, Y);
    }
}