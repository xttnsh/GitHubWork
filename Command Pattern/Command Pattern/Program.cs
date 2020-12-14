using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //开店前准备
            Barbecuer monkey = new Barbecuer();
            Command bakeMuttonCommand1 = new BakeMuttonCommand(monkey);
            Command bakeMuttonCommand2 = new BakeMuttonCommand(monkey);
            Command bakeChickenCommand1 = new BakeChickenCommand(monkey);
            Waiter mm = new Waiter();

            //开门营业，服务员根据用户要求，通知厨房开始制作
            mm.SetOrder(bakeMuttonCommand1);
            mm.Notify();  //调用通知
            mm.SetOrder(bakeMuttonCommand2);
            mm.Notify();
            mm.SetOrder(bakeChickenCommand1);
            mm.Notify();

            Console.Read();
        }
        public abstract class Command
        {
            protected Barbecuer receiver;

            //抽象命令类，确定谁烤肉串
            public Command(Barbecuer receiver)
            {
                this.receiver = receiver;
            }

            //执行命令
            abstract public void ExcuteCommand();
        }

        public class Waiter
        {
            //服务员类，不管用户什么命令，只管记录订单，然后通知烤肉者执行
            private Command command;
            //设置订单
            public void SetOrder(Command command)
            {
                this.command = command;
            }

            //通知执行
            public void Notify()
            {
                command.ExcuteCommand();
            }
        }
        public class Barbecuer
        {
            //烤羊肉串
            public void BakeMutton()
            {
                Console.WriteLine("烤羊肉串，不香不要钱~");
            }

            //烤鸡
            public void BakeChicken()
            {
                Console.WriteLine("大吉大利，今晚吃鸡~");
            }
        }
        //烤羊肉串类
        class BakeMuttonCommand : Command
        {
            public BakeMuttonCommand(Barbecuer receiver)
                : base(receiver)
            {
            }

            //重写方法，具体命令类，执行命令时，执行具体行为
            public override void ExcuteCommand()
            {
                receiver.BakeMutton();
            }
        }

        //烤鸡类
        class BakeChickenCommand : Command
        {
            public BakeChickenCommand(Barbecuer receiver)
                : base(receiver)
            {
            }

            public override void ExcuteCommand()
            {
                receiver.BakeChicken();
            }
        }
    }
}


