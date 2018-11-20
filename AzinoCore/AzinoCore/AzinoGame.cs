using System;

namespace AzinoCore
{
    public class AzinoGame
    {
        public AzinoGame()
        {
            Balance = Rules.StartBalance;
        }

        public int Balance { get; private set; }
    }

    public static class Rules
    {
        static Rules()
        {
            StartBalance = 100;
            SpinCost = 10;
        }

        public static int SpinCost { get; }
        public static int StartBalance { get; }
    }
}
