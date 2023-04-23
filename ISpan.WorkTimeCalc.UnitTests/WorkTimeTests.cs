using NUnit.Framework.Internal.Execution;

namespace ISpan.WorkTimeCalc.UnitTests
{
    public class WorkTimeTests
    {


        [Test]
        public void LeaveHoursCalc_計算請假時間_9點至18點()
        {
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(9, 18);
            Assert.AreEqual(8, actual);
        }

        [Test]
        public void LeaveHoursCalc_計算請假時間_6點至23點()
        {
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(6, 23);
            Assert.AreEqual(8, actual);
        }

        [Test]
        public void LeaveHoursCalc_計算請假時間_12點至18點()
        {
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(12, 18);
            Assert.AreEqual(5, actual);
        }

        [Test]
        public void LeaveHoursCalc_計算請假時間_9點至11點()
        {
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(9, 11);
            Assert.AreEqual(2, actual);
        }

        [Test]
        public void LeaveHoursCalc_計算請假時間_錯誤的時間範圍()
        {
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(12, int.MaxValue);
            Assert.AreEqual(-1, actual);
        }

        [Test]
        public void LeaveHoursCalc_計算請假時間_工時範圍外()
        {
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(6, 7);
            Assert.AreEqual(0, actual);
        }


        [Test]
        public void LeaveHoursCalc_計算請假時間_DateTime_1天以內()
        {
            DateTime dt1 = new DateTime(2023, 04, 10, 9, 00, 00);
            DateTime dt2 = new DateTime(2023, 04, 10, 18, 00, 00);
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(dt1, dt2);
            Assert.AreEqual(8, actual);
        }

        [Test]
        public void LeaveHoursCalc_計算請假時間_DateTime_3天()
        {
            DateTime dt1 = new DateTime(2023, 04, 10, 9, 00, 00);
            DateTime dt2 = new DateTime(2023, 04, 12, 18, 00, 00);
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(dt1, dt2);
            Assert.AreEqual(24, actual);
        }

        [Test]
        public void LeaveHoursCalc_計算請假時間_DateTime_3天_9點到9點()
        {
            DateTime dt1 = new DateTime(2023, 04, 10, 9, 00, 00);
            DateTime dt2 = new DateTime(2023, 04, 12, 9, 00, 00);
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(dt1, dt2);
            Assert.AreEqual(16, actual);
        }
        [Test]
        public void LeaveHoursCalc_計算請假時間_DateTime_結束時間小於開始時間()
        {
            DateTime dt1 = new DateTime(2023, 04, 10, 9, 00, 00);
            DateTime dt2 = new DateTime(2023, 04, 09, 9, 00, 00);
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(dt1, dt2);
            Assert.AreEqual(-1, actual);
        }
    }
}
