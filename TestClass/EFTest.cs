using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using EF;

namespace TestClass
{
    /// <summary>
    /// 使用EF 的ModeFirst创建对象
    /// </summary>
    public class EFTest
    {
        public void TestEFAdd()
        {
            var db = new GGN_NewsEntities();
            var game = new TGame
            {
                Name = "水果忍者",
                State = true
            };
            db.TGame.Add(game);
            Console.WriteLine(db.SaveChanges());
        }

        public void TestEFEditorOther()
        {
            //将对象加入ef容器，并获取当前ef 实体对象的 状态管理对象
            var db = new GGN_NewsEntities();
            //db.TGame.MergeOption = MergeOption.NoTracking;
            var game = new TGame
            {
                Id = 1,
                Name = "水果忍者修改",
                State = false
            };
            //将对象加入 EF容器，并获取 当前实体对象 的 状态管理对象。单纯的使用Attach对象不能够获取ef 的状态管理对象
            var entry = db.Entry(game);
            //设置 该对象 为未被修改过
            entry.State = EntityState.Unchanged;
            //设置 该对象 为修改过
            entry.Property("Name").IsModified = true;
            Console.WriteLine(db.SaveChanges());
        }

        public void TestEFDelete()
        {
            var db = new GGN_NewsEntities();
            var game = new TGame {Id = 2};
            db.TGame.Attach(game);
            db.TGame.Remove(game);
            Console.WriteLine(db.SaveChanges());
        }

        public void TestEFSelect()
        {
            var db = new GGN_NewsEntities();
            db.TGame.Select(m => m);
            var game = db.TGame.First();
        }

        /// <summary>
        ///     EF在修改一个数据，通过主键来修改
        /// </summary>
        public void TestEFeditor()
        {
            var db = new GGN_NewsEntities();
            var game = new TGame {Id = 1, Name = "天天跑酷", State = true};
            db.TGame.Add(game);
            Console.WriteLine(db.SaveChanges());
        }

        /// <summary>
        ///     获取多对多关系
        /// </summary>
        public void TestGetManyToMany()
        {
            var db = new GGN_NewsEntities();
            var query = (from t in db.TGame
                where t.Name == "水果忍者"
                select t).FirstOrDefault();
            Console.WriteLine(query.TGameRCategory.Count());
            //db.Entry<TGame>().HasRequired();
        }
    }
}