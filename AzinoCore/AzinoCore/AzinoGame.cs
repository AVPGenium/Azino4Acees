using System;

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

        public int Balance { get; private set; }
        public int[] State { get; private set; }
    }

    public static class Rules
    {
        static Rules()
        {
            StartBalance = 100;
            SpinCost = 10;
        }

        public static int GetDelta(int[] state)
        {
            return 0;
        }

        public static int SpinCost { get; }
        public static int StartBalance { get; }
    }
}

