using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小黄车算法题
{
    internal class 自行车
    {
        public 自行车(string 自行车编号)
        {
            _编号 = 自行车编号;
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
                _编号 = value;
            }
        }
    }
}
