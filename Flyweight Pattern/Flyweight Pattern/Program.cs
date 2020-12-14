using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Flyweight_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            WebSiteFactory f = new WebSiteFactory();

            WebSite fx = f.GetWebSiteCategory("微博");
            fx.Use(new User("小怪兽"));

            WebSite fz = f.GetWebSiteCategory("微博");
            fz.Use(new User("朝阳区XXX"));

            WebSite fw = f.GetWebSiteCategory("空间");
            fw.Use(new User("空朋好"));

            WebSite fq = f.GetWebSiteCategory("空间");
            fq.Use(new User("飞翔的企鹅"));

            WebSite fu = f.GetWebSiteCategory("虎扑");
            fu.Use(new User("冰淇凌"));

            WebSite fo = f.GetWebSiteCategory("朋友圈");
            fo.Use(new User("花开富贵"));

            Console.WriteLine("得到网站分类总数为{0}", f.GetWebSiteCount());

            Console.Read();
        }
    }


    public class User
    {
        //用户类，是网站类的外部状态
        private string name;
        public User(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }

    abstract class WebSite
    {
        //网站抽象类
        //使用方法需要传递用户对象
        public abstract void Use(User user);
    }

    class ConcreteWebSite : WebSite
    {
        //具体网站类
        private string name = "";
        public ConcreteWebSite(string name)
        {
            this.name = name;
        }

        public override void Use(User user)
        {
            //实现Use方法
            Console.WriteLine("网站分类：" + name + "用户:" + user.Name);
        }

    }

    class WebSiteFactory
    {
        //网站工厂
        private Hashtable flyweights = new Hashtable();

        //获得网站分类
        public WebSite GetWebSiteCategory(string key)
        {
            if (!flyweights.ContainsKey(key))
                flyweights.Add(key, new ConcreteWebSite(key));
            return ((WebSite)flyweights[key]);
        }

        //获得网站分类总数
        public int GetWebSiteCount()
        {
            return flyweights.Count;
        }
    }


}
