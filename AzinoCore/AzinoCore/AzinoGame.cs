using System;
using Newtonsoft.Json;

namespace AzinoCore
{
    public class AzinoGame
    {
        public AzinoGame()
        {
            Balance = Rules.StartBalance;
            State = new int[] { 1, 2, 3, 4, 5 };
        }

        public void Spin()
        {
            if (Balance < Rules.SpinCost)
                return;
            Balance -= Rules.SpinCost;
            Random r = new Random();
            for(int i=0; i<5; ++i)
            {
                State[i] = r.Next(10);
            }
            Balance += Rules.GetDelta(State);
        }

        public void SmallSpin(int index)
        {
            if (Balance < Rules.SmallSpinCost)
                return;
            Balance -= Rules.SmallSpinCost;
            Random r = new Random();
            State[index] = r.Next(10);
            Balance += Rules.GetDelta(State);
        }

        public int Balance { get; private set; }
        public int[] State { get; private set; }
    }

    public static class Rules
    {
        static AzinoProperties Config;

        public static int SpinCost => Config.SpinCost;
        public static int SmallSpinCost => Config.SmallSpinCost;
        public static int StartBalance => Config.StartBalance;
        public static int Prize1 => Config.Prize1;
        public static int Prize2 => Config.Prize2;
        public static int Prize3 => Config.Prize3;
        public static int Prize4 => Config.Prize4;
        public static int Prize5 => Config.Prize5;

        static Rules()
        {
            Config = AzinoProperties.Load("config.json");
        }

        public static int GetDelta(int[] state)
        {
            int[] cnt = new int[10];
            foreach(var x in state)
            {
                cnt[x]++;
            }
            int[] combos = new int[6];
            foreach(var x in cnt)
            {
                combos[x]++;
            }
            int prize = Config.Prize1 * combos[1]
                      + Config.Prize2 * combos[2]
                      + Config.Prize3 * combos[3]
                      + Config.Prize4 * combos[4]
                      + Config.Prize5 * combos[5];
            return prize;
        }
    }
}

