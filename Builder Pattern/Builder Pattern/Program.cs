using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建指挥者和构造者
            var director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            // 老板叫员工去组装第一台电脑
            director.Construct(b1);

            // 组装完，组装人员搬来组装好的电脑
            Computer computer1 = b1.GetComputer();
            computer1.Show();

            // 老板叫员工去组装第二台电脑
            director.Construct(b2);
            Computer computer2 = b2.GetComputer();
            computer2.Show();

            Console.Read();
        }
        public class Director
        {
            // 组装电脑
            public void Construct(Builder builder)
            {
                builder.BuildPartCpu();
                builder.BuildPartMainBoard();
            }
        }
    
    }

    public class Director
    {
        // 组装电脑
        public void Construct(Builder builder)
        {
            builder.BuildPartCpu();
            builder.BuildPartMainBoard();
        }
    }


    public class Computer
    {
        // 电脑组件集合
        private readonly IList<string> _parts = new List<string>();

        // 把单个组件添加到电脑组件集合中
        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("正在组装.......");
            foreach (string part in _parts)
            {
                Console.WriteLine("组件" + part + "已装好");
            }

            Console.WriteLine("电脑组装好了");
        }
    }

    public abstract class Builder
    {
        // 装CPU
        public abstract void BuildPartCpu();
        // 装主板
        public abstract void BuildPartMainBoard();

        // 等等

        // 获得组装好的电脑
        public abstract Computer GetComputer();
    }


    public class ConcreteBuilder1 : Builder
    {
        readonly Computer _computer = new Computer();
        public override void BuildPartCpu()
        {
            _computer.Add("CPU1");
        }

        public override void BuildPartMainBoard()
        {
            _computer.Add("Main board1");
        }

        public override Computer GetComputer()
        {
            return _computer;
        }
    }

    public class ConcreteBuilder2 : Builder
    {
        readonly Computer _computer = new Computer();
        public override void BuildPartCpu()
        {
            _computer.Add("CPU2");
        }

        public override void BuildPartMainBoard()
        {
            _computer.Add("Main board2");
        }

        public override Computer GetComputer()
        {
            return _computer;
        }
    }



}
