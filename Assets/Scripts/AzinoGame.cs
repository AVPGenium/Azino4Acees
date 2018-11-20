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
			for (int i = 0; i < 5; ++i)
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
			Prize1 = -20;
			Prize2 = 0;
			Prize3 = 20;
			Prize4 = 30;
			Prize5 = 100;
			Prize2and2 = 50;
			Prize2and3 = 80;
		}

		public static int GetDelta(int[] state)
		{
			int[] cnt = new int[10];
			foreach (var x in state)
			{
				cnt[x]++;
			}
			int[] combos = new int[6];
			foreach (var x in cnt)
			{
				combos[x]++;
			}
			if (combos[5] > 0) return Prize5;
			if (combos[4] > 0) return Prize4;
			if (combos[3] > 0 && combos[2] > 0) return Prize2and3;
			if (combos[3] > 0) return Prize3;
			if (combos[2] > 1) return Prize2and2;
			if (combos[2] > 0) return Prize2;
			return Prize1;
		}

		public static int SpinCost { get; }
		public static int StartBalance { get; }
		public static int Prize1 { get; }
		public static int Prize2 { get; }
		public static int Prize3 { get; }
		public static int Prize4 { get; }
		public static int Prize5 { get; }
		public static int Prize2and2 { get; }
		public static int Prize2and3 { get; }
	}
}

