using NUnit.Framework.Internal.Execution;

namespace ISpan.WorkTimeCalc.UnitTests
{
    public class WorkTimeTests
    {


        [Test]
        public void LeaveHoursCalc_�p��а��ɶ�_9�I��18�I()
        {
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(9, 18);
            Assert.AreEqual(8, actual);
        }

        [Test]
        public void LeaveHoursCalc_�p��а��ɶ�_6�I��23�I()
        {
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(6, 23);
            Assert.AreEqual(8, actual);
        }

        [Test]
        public void LeaveHoursCalc_�p��а��ɶ�_12�I��18�I()
        {
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(12, 18);
            Assert.AreEqual(5, actual);
        }

        [Test]
        public void LeaveHoursCalc_�p��а��ɶ�_9�I��11�I()
        {
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(9, 11);
            Assert.AreEqual(2, actual);
        }

        [Test]
        public void LeaveHoursCalc_�p��а��ɶ�_���~���ɶ��d��()
        {
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(12, int.MaxValue);
            Assert.AreEqual(-1, actual);
        }

        [Test]
        public void LeaveHoursCalc_�p��а��ɶ�_�u�ɽd��~()
        {
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(6, 7);
            Assert.AreEqual(0, actual);
        }


        [Test]
        public void LeaveHoursCalc_�p��а��ɶ�_DateTime_1�ѥH��()
        {
            DateTime dt1 = new DateTime(2023, 04, 10, 9, 00, 00);
            DateTime dt2 = new DateTime(2023, 04, 10, 18, 00, 00);
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(dt1, dt2);
            Assert.AreEqual(8, actual);
        }

        [Test]
        public void LeaveHoursCalc_�p��а��ɶ�_DateTime_3��()
        {
            DateTime dt1 = new DateTime(2023, 04, 10, 9, 00, 00);
            DateTime dt2 = new DateTime(2023, 04, 12, 18, 00, 00);
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(dt1, dt2);
            Assert.AreEqual(24, actual);
        }

        [Test]
        public void LeaveHoursCalc_�p��а��ɶ�_DateTime_3��_9�I��9�I()
        {
            DateTime dt1 = new DateTime(2023, 04, 10, 9, 00, 00);
            DateTime dt2 = new DateTime(2023, 04, 12, 9, 00, 00);
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(dt1, dt2);
            Assert.AreEqual(16, actual);
        }
        [Test]
        public void LeaveHoursCalc_�p��а��ɶ�_DateTime_�����ɶ��p��}�l�ɶ�()
        {
            DateTime dt1 = new DateTime(2023, 04, 10, 9, 00, 00);
            DateTime dt2 = new DateTime(2023, 04, 09, 9, 00, 00);
            WorkTime workTime = new WorkTime();
            double actual = workTime.LeaveHoursCalc(dt1, dt2);
            Assert.AreEqual(-1, actual);
        }
    }
}
