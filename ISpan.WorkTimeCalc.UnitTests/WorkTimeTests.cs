using NUnit.Framework.Internal.Execution;

namespace ISpan.WorkTimeCalc.UnitTests
{
	public class WorkTimeTests
	{


		[Test]
		public void LeaveHoursCalc_�p��а��ɶ�_9�I��18�I()
		{
			WorkTime workTime = new WorkTime();
			int actual = workTime.LeaveHoursCalc(9, 18);
			Assert.AreEqual(8, actual);
		}

		[Test]
		public void LeaveHoursCalc_�p��а��ɶ�_6�I��23�I()
		{
			WorkTime workTime = new WorkTime();
			int actual = workTime.LeaveHoursCalc(6, 23);
			Assert.AreEqual(8, actual);
		}

		[Test]
		public void LeaveHoursCalc_�p��а��ɶ�_12�I��18�I()
		{
			WorkTime workTime = new WorkTime();
			int actual = workTime.LeaveHoursCalc(12, 18);
			Assert.AreEqual(5, actual);
		}

		[Test]
		public void LeaveHoursCalc_�p��а��ɶ�_9�I��11�I()
		{
			WorkTime workTime = new WorkTime();
			int actual = workTime.LeaveHoursCalc(9, 11);
			Assert.AreEqual(2, actual);
		}

		[Test]
		public void LeaveHoursCalc_�p��а��ɶ�_12�I��25�I()
		{
			WorkTime workTime = new WorkTime();
			int actual = workTime.LeaveHoursCalc(12, 25);
			Assert.AreEqual(-1, actual);
		}
	}
}