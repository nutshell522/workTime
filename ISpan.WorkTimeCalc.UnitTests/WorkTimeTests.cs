using NUnit.Framework.Internal.Execution;

namespace ISpan.WorkTimeCalc.UnitTests
{
	public class WorkTimeTests
	{


		[Test]
		public void LeaveHoursCalc_計算請假時間_9點至18點()
		{
			WorkTime workTime = new WorkTime();
			int actual = workTime.LeaveHoursCalc(9, 18);
			Assert.AreEqual(8, actual);
		}

		[Test]
		public void LeaveHoursCalc_計算請假時間_6點至23點()
		{
			WorkTime workTime = new WorkTime();
			int actual = workTime.LeaveHoursCalc(6, 23);
			Assert.AreEqual(8, actual);
		}

		[Test]
		public void LeaveHoursCalc_計算請假時間_12點至18點()
		{
			WorkTime workTime = new WorkTime();
			int actual = workTime.LeaveHoursCalc(12, 18);
			Assert.AreEqual(5, actual);
		}

		[Test]
		public void LeaveHoursCalc_計算請假時間_9點至11點()
		{
			WorkTime workTime = new WorkTime();
			int actual = workTime.LeaveHoursCalc(9, 11);
			Assert.AreEqual(2, actual);
		}

		[Test]
		public void LeaveHoursCalc_計算請假時間_12點至25點()
		{
			WorkTime workTime = new WorkTime();
			int actual = workTime.LeaveHoursCalc(12, 25);
			Assert.AreEqual(-1, actual);
		}
	}
}