using System;
using System.Collections.Generic;

namespace Helper {
    public class ListHelper {
        #region 获取列表的部分内容
        /// <summary>
        /// 得到列表的部分内容
        /// </summary>
        /// <typeparam name="T">列表的中内容类型</typeparam>
        /// <param name="list">要取值的列表</param>
        /// <param name="pageIndex">页面的开始页</param>
        /// <param name="pageSize">每页取值数</param>
        /// <returns>获取中的List部分内容</returns>
        public static List<T> GetListRange<T>(List<T> list, int pageIndex, int pageSize) {
            if(pageIndex <= 0)
                pageIndex = 1;
            if(pageSize <= 0)
                return list;
            if(list == null || list.Count == 0)
                return null;
            int begin = (pageIndex - 1) * pageSize;

            if(list.Count < begin)
                return null;
            int count = begin + pageSize > list.Count ? list.Count - begin : pageSize;
            return list.GetRange(begin, count);
        }
        /// <summary>
        /// 得到某个列表的部分内容
        /// </summary>
        /// <typeparam name="T">列表的中内容类型</typeparam>
        /// <param name="list">要取值的列表</param>
        /// <param name="startIndex">从那条记录开始</param>
        /// <param name="pageSize">每页的记录数</param>
        /// <returns></returns>
        public static List<T> GetListRangeByStartIndex<T>(List<T> list, int startIndex, int pageSize) {
            if(startIndex <= 0)
                startIndex = 1;
            if(pageSize <= 0)
                return list;
            if(list == null || list.Count == 0)
                return null;

            if(list.Count < startIndex)
                return null;

            int count;
            if(list.Count >= startIndex + pageSize) {
                count = pageSize;
            }
            else {
                count = (list.Count - (startIndex - 1)) % pageSize;

                if(count == 0)
                    count = pageSize;
            }
            return list.GetRange(startIndex - 1, count);
        }
        /// <summary>
        /// 随机得到列表的部分数据
        /// </summary>
        /// <typeparam name="T">列表中保存的类型</typeparam>
        /// <param name="list">要取值的列表</param>
        /// <param name="count">要随机取的数量</param>
        /// <returns>从列表中随机取的值</returns>
        public static IList<T> GetRandomList<T>(IList<T> list, int count) {
            if(list == null || list.Count <= count) {
                return list;
            }
            List<T> tempList = new List<T>(list);
            Random random = new Random();
            for(int i = 0; i < count; i++) {
                int index0 = random.Next(i, list.Count);
                T temp = tempList[index0];
                tempList[index0] = tempList[i];
                tempList[i] = temp;
            }
            return tempList.GetRange(0, count);
        }
        #endregion
        /*  对list进行排序的多种实现方法
        /// <summary>
        /// 自定义实现IComparer<T>接口,用于在Sort方法中进行排序
        /// </summary>
        public class Sort : IComparer<Person> {
            /// <summary>
            /// 根据用户最后一次登录的时间对列表进行排序
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(Person x, Person y) {
                if(x.LastLoginTime > y.LastLoginTime)
                    return 1;
                else if(x.LastLoginTime == y.LastLoginTime)
                    return 0;
                else
                    return -1;
            }
        }
         
        static void Main(string[] args) {
            List<Person> list = new List<Person>();
            for(int i = 10; i >= 0; i--) {
                Person people = new Person();
                people.Name = "Luu";
                people.LastLoginTime = DateTime.Now.AddDays(i);
                list.Add(people);
            }

            使用linq对list进行排序
            var ascendingList = from u in list orderby u.LastLoginTime ascending select u;
            foreach(var item in ascendingList) {
                Console.WriteLine(item.LastLoginTime);
            }

            使用匿名方法对list进行排序
            var ascendingList = list.OrderBy(m => m.LastLoginTime);
            foreach(var item in ascendingList) {
                Console.WriteLine(item.LastLoginTime);
            }
            比较容易理解的排序方法
            list.Sort((Person person, Person persons) => {
                return person.LastLoginTime.CompareTo(persons.LastLoginTime);
            }
                );

            使用继承IComparer<T>接口的比较器对整个 System.Collections.Generic.List<T> 中的元素进行排序。           
            Sort sort = new Sort();
            list.Sort(sort.Compare);
            foreach(var item in list) {
                Console.WriteLine(item.LastLoginTime);
            }
        }
         */
    }
}
