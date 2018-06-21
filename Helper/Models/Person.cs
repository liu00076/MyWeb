using System;
using Helper.Attributes;

namespace Helper
{
    /// <summary>
    /// 人实体类
    /// </summary>
    [Serializable]
    public class Person
    {
        private int age;
        private string name;
        private DateTime lastLoginTime;

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        [Trims("Liu",30)]
        public DateTime LastLoginTime
        {
            get { return lastLoginTime; }
            set { lastLoginTime = value; }
        }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age
        {
            get { return age; }
            set { age = value; }
        }        
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private object obj = new object();
        public void GetAge() {
            lock(this) {
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine(this.Age);
            }
        }

        private object objGetTime = new object();
       
        public void GetLastDateTime() {
            lock(this) {
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine(this.LastLoginTime);
            }
        }
    }
}
