using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 小黄车算法核心.万物;

namespace 小黄车算法核心.元数
{
    public class 元
    {
        //先初始化地铁站
        public static Dictionary<string, 地铁站> 地铁站们 = new Dictionary<string, 地铁站>()
        {
            { "A", new 地铁站("A", 0, 0) },
            { "B", new 地铁站("B", 7, 7) },
            { "C", new 地铁站("C", 3, 2) }
        };

        //初始化货车
        //货车的起始位置没有说明，那么就算随机，一个给到A，一个给到B
        public static Dictionary<string, 货车> 货车们 = new Dictionary<string, 货车>()
        {
            {"大货",new 货车("大货",20,3,0,0)},
            {"小货",new 货车("小货",20,3,7,7)}
        };

        //一开始是没人的
        //Dictionary<string, 路人> 路人们 = new Dictionary<string, 路人>();
        public static List<路人> 路人们 = new List<路人>();
    }
}