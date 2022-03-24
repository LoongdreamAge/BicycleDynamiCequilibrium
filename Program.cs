// See https://aka.ms/new-console-template for more information

using System.Text;
using 小黄车算法题;
using 小黄车算法题.Utils;

#region 初始化
//先初始化地铁站
Dictionary<string,地铁站> 地铁站们 = new Dictionary<string, 地铁站>()
{
    {"A",new 地铁站("A",0,0)},
    {"B",new 地铁站("B",7,7)},
    {"C",new 地铁站("C",3,2)}
};

//初始化货车
//货车的起始位置没有说明，那么就算随机，一个给到A，一个给到B
Dictionary<string, 货车> 货车们 = new Dictionary<string, 货车>()
{
    {"大货",new 货车("大货",20,3,0,0)},
    {"小货",new 货车("小货",20,3,7,7)}
};

//一开始是没人的
//Dictionary<string, 路人> 路人们 = new Dictionary<string, 路人>();
List<路人> 路人们 = new List<路人>();
#endregion

#region 装载

//然后初始化装载
//地铁站先装车
//车车是匿名的，所以只要拥有一个随机编码就可以了
//A站
for (int i = 0; i < 30; i++)
{
    地铁站们["A"].当前装载.Add(new 自行车(Guid.NewGuid().ToString()));
}

//B站
for (int i = 0; i < 40; i++)
{
    地铁站们["B"].当前装载.Add(new 自行车(Guid.NewGuid().ToString()));
}

//C站
for (int i = 0; i < 30; i++)
{
    地铁站们["C"].当前装载.Add(new 自行车(Guid.NewGuid().ToString()));
}


#endregion

#region 开始模拟
//模拟250秒内的玩法
TimeOnly time = new TimeOnly(0, 0, 0);
for (int i = 0; i < 250; i++)
{
    #region 路人行为
    //先随机一个路人
    string 路人编号 = Guid.NewGuid().ToString();
    var 出生点 = 随机方法.随机选择一个出生点(地铁站们);
    var 新路人 = new 路人(路人编号, 1, 出生点.坐标.Key, 出生点.坐标.Value);
    //让他骑上一辆车
    //新路人.骑走一辆车(出生点.放走一辆车());
    //加入大众
    路人们.Add(新路人);

    //路人开始跑路
    foreach (var 路人甲 in 路人们)
    {
        //如果有车，就走，没车，就停着不动
        if (路人甲.当前骑车!=null)
        {
            路人甲.移动();
        }
        //看看他是不是到某个地铁站了，到了就把车放下
        var 地铁站 = 路人甲.我在哪一站(地铁站们);
        if (地铁站!=null)
        {
           //有车还车， 没车骑走
           var 车 = 路人甲.停下一辆车();
           if (车==null)
           {
               //这货没骑车，看看车站还有车么
               if (地铁站.当前装载.Any())
               {
                   //给挑一辆
                   路人甲.骑走一辆车(地铁站.放走一辆车());
               }
               else
               {
                   //没车了，傻站着吧
                   //啥也不做
               }
           }
           else
           {
                //有车，停下来
                地铁站.停放一辆车(车);
            }
        }
    }
    #endregion

    //OK 现在看看，大家的实际情况
    //00:25:00 A站车14，B站车36，C站车23，路上车22，B到A运输5辆车
    StringBuilder sb =new StringBuilder();
    time=time.Add(new TimeSpan(0, 0, 1));
    sb.Append($"{time.ToString("HH:mm:ss")} ");
    int 车站车总量=0;
    //先检查车站存车情况
    foreach (var 地铁站甲 in 地铁站们)
    {
        var 当前车站车数量 = 地铁站甲.Value.当前装载.Count;
        车站车总量 += 当前车站车数量;
        sb.Append($"{地铁站甲.Key}站车{当前车站车数量}，");
    }
    sb.Append($"路上车{100- 车站车总量}，");
    Console.WriteLine(sb.ToString());
}

#endregion
