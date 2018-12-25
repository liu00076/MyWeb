
namespace Helper.Helper.Designer {

    /// <summary>
    /// 多线程条件下的单例模式
    /// </summary>
    public abstract class SingleHelperInThread<T> where T : class, new() {
        private static T single;
        private static object lockobj = new object();
        public static T GetInstance() {
            if(single == null) {
                lock(lockobj) {
                    if(single == null) {
                        single = new T();
                    }
                }
            }
            return single;
        }
    }

    /// <summary>
    /// 用懒汉模式实现单例功能。
    /// 懒汉单例模式的实现方法主要是通过内部类的静态成员
    /// 来实现当前类的单例模式。
    /// </summary>
    public class LazySingle<T> where T:class,new() {

        //私有的构造函数防止别人New。
        private LazySingle(){}

        //内部对象，通过静态成员的实例化，实现
        private static class SingleHolder {
            //单例变量
            public static T instance = new T();
        }

        //获取单例对象实例。
        public static T GetInstance() {
            return SingleHolder.instance;
        }
    }

    /// <summary>
    /// 饿汉模式构造对象。
    /// </summary>
    public class HungerSingle {
        private static readonly HungerSingle instance = new HungerSingle();

        private HungerSingle() { }

        public static HungerSingle GetInstance() {
            return instance;
        }
    }
}
