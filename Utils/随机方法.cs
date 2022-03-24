using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小黄车算法题.Utils
{
    internal class 随机方法
    {
        static object _lock = new object();
        static Random random = new Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// 随机移动位置
        /// </summary>
        /// <remarks>最大画布在这里看<see cref="常量.画布尺寸"/>，而且切记X轴向右正向延伸，Y轴向下正向延伸</remarks>
        /// <param name="当前X"></param>
        /// <param name="当前Y"></param>
        /// <returns></returns>
        public static KeyValuePair<int, int> 随机移动一个向量位置(int 当前X, int 当前Y)
        {
            int X向量 = 0;
            int Y向量 = 0;
            int 初始X = 当前X;
            int 初始Y = 当前Y;
            //超过100次还不行，这人举棋不定，就不要走了
            int 循环次数 = 100;
            do
            {
                X向量 = 0;
                Y向量 = 0;
                //随一个方向
                var 移动方向 = 随机一个方向();
                switch (移动方向)
                {
                    case 方向.上:
                    {
                        Y向量 -= 1;
                        break;
                    }
                    case 方向.下:
                    {
                        Y向量 += 1;
                        break;
                    }
                    case 方向.左:
                    {
                        X向量 -= 1;
                        break;
                    }
                    case 方向.右:
                    {
                        X向量 += 1;
                        break;
                    }
                }

                //检查一下是不是越界了
                当前X += X向量;
                当前Y += Y向量;
                if (当前X >= 0 && 当前X <= 常量.画布尺寸.Key - 1)
                {
                    //X坐标合理，看看Y的
                    if (当前Y >= 0 && 当前Y <= 常量.画布尺寸.Value - 1)
                    {
                        //恭喜，这一步走对了
                        break;
                    }
                }

                //抱歉，你这一步触底了，重走
                当前X = 初始X;
                当前Y = 初始Y;
                循环次数--;
            } while (循环次数 > 0);

            return new KeyValuePair<int, int>(当前X, 当前Y);
        }

        public static 方向 随机一个方向()
        {
            lock (_lock)
                return (方向)random.Next(0, 4);
        }

        public static 地铁站 随机选择一个出生点(Dictionary<string, 地铁站> 地铁站们)
        {
            int index = 0;
            lock (_lock)
                index = random.Next(0, 地铁站们.Count - 1);
            return 地铁站们[地铁站们.Keys.ToArray()[index]];
        }
        
    }
}
