namespace ISpan.WorkTimeCalc
{
    public class WorkTime
    {
        // 上班時間
        private const int workBegin = 9;
        // 下班時間
        private const int workEnd = 18;

        // 開始休息時間
        private const double RestBegin = 12;
        // 結束休息時間
        private const double RestEnd = 13;
        /// <summary>
        /// 獲得請假時間資訊
        /// </summary>
        /// <param name="leaveBegin">請假開始時間</param>
        /// <param name="leaveEnd">請假結束時間</param>
        /// <returns></returns>
        public string GetLeaveHoursInfo(int leaveBegin, int leaveEnd)
        {
            double result = LeaveHoursCalc(leaveBegin, leaveEnd);
            return result < 0
                ? "請輸入正確起始及結束時間"
                : $"請假的時間 從 {leaveBegin,2} 至 {leaveEnd,2} 為: {result} 小時";
        }
        /// <summary>
        /// 計算請假時數
        /// </summary>
        /// <param name="leaveBegin">請假開始時間</param>
        /// <param name="leaveEnd">請假結束時間</param>
        /// <returns></returns>
        public double LeaveHoursCalc(DateTime leaveBegin, DateTime leaveEnd)
        {
            // 驗證開始、結束時間，不合法即回傳 -1
            if (!IsReasonableTime(leaveBegin, leaveEnd)) return -1;

            // 算出傳入日期橫跨了多少天
            TimeSpan ts = leaveEnd.Date - leaveBegin.Date;
            int totaldays = (int)Math.Ceiling(ts.TotalDays);

            DateTime leaveBeginOfDate;
            DateTime leaveEndOfDate;

            // 儲存總時數的變數
            double leaveHours = 0;

            // 計算每天時間
            for (int i = 0; i <= totaldays; i++)
            {
                // 如果計算的不是第一天，起始時間為0:00
                leaveBeginOfDate = i == 0 ? leaveBegin : leaveBegin.AddDays(i).Date;
                // 如果計算的不是最後一天，結束時間為24:00
                leaveEndOfDate = i == totaldays ? leaveEnd : leaveBeginOfDate.AddDays(1).Date;

                // 當天幾點開始
                double begin = (leaveBeginOfDate - leaveBeginOfDate.Date).TotalHours;
                // 當天幾點結束
                double end = (leaveEndOfDate - leaveBeginOfDate.Date).TotalHours;

                // 計算當天的總時數
                leaveHours += LeaveHoursCalc(begin, end);
            }

            return leaveHours;
        }

        /// <summary>
        /// 計算請假時數
        /// </summary>
        /// <param name="leaveBegin">請假開始時間</param>
        /// <param name="leaveEnd">請假結束時間</param>
        /// <returns></returns>
        public double LeaveHoursCalc(double leaveBegin, double leaveEnd)
        {
            // 驗證開始、結束時間，不合法即回傳 -1
            if (!IsReasonableTime(leaveBegin, leaveEnd)) return -1;

            // 將需計算的開始及結束時間，限制在上班時間段裡
            leaveBegin = WorkTimeBondary(leaveBegin);
            leaveEnd = WorkTimeBondary(leaveEnd);

            // 如果請假開始時間在休息範圍時間內，重設在休息時間開始時
            leaveBegin = IsInRange(leaveBegin, RestBegin, RestEnd) ? RestBegin : leaveBegin;
            // 如果請假結束時間在休息範圍時間內，重設在休息時間結束時
            leaveEnd = IsInRange(leaveEnd, RestBegin, RestEnd) ? RestEnd : leaveEnd;

            // 回傳總請假時數
            return HoursCalcWithoutRange(leaveBegin, leaveEnd, RestBegin, RestEnd);

        }
        /// <summary>
        /// 獲得去除掉指定範圍的時數
        /// </summary>
        /// <param name="timeBegin">起始時間</param>
        /// <param name="timeEnd">結束時間</param>
        /// <param name="rangeBegin">去除範圍時間起始</param>
        /// <param name="rangeEnd">去除範圍時間結束</param>
        /// <returns></returns>
        private double HoursCalcWithoutRange(double timeBegin, double timeEnd, double rangeBegin, double rangeEnd)
        {
            double totalhour = timeEnd - timeBegin;

            // 如果時間段包含要去除的範圍，則扣除
            if (IsInRange(rangeBegin, timeBegin, timeEnd) && IsInRange(rangeEnd, timeBegin, timeEnd))
                return Math.Round(totalhour - (rangeEnd - rangeBegin), 1, MidpointRounding.AwayFromZero);

            return Math.Round(totalhour, 1, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// 驗證時間數字是否合法
        /// </summary>
        /// <param name="begin">開始時間</param>
        /// <param name="end">結束時間</param>
        /// <returns></returns>
        private bool IsReasonableTime(DateTime begin, DateTime end) => begin <= end;

        /// <summary>
        /// 驗證時間數字是否合法
        /// </summary>
        /// <param name="begin">開始時間</param>
        /// <param name="end">結束時間</param>
        /// <returns></returns>
        private bool IsReasonableTime(double begin, double end)
        {
            if (begin < 0 || end < 0 || begin > 24 || end > 24) return false;

            return begin <= end;
        }

        /// <summary>
        /// 將時間限制在上班時間以內
        /// </summary>
        /// <param name="time">時間</param>
        /// <returns></returns>
        private double WorkTimeBondary(double time)
        {
            time = Math.Max(time, workBegin); // 如果時間小於上班時間，等於上班時間
            time = Math.Min(time, workEnd); // 如果時間大於下班時間，等於下班時間

            return time;
        }
        /// <summary>
        /// 判斷參數是否在範圍內
        /// </summary>
        /// <param name="time">參數</param>
        /// <param name="rangeBegin">範圍起始</param>
        /// <param name="rangeEnd">範圍結束</param>
        /// <returns></returns>
        private bool IsInRange(double time, double rangeBegin, double rangeEnd) => time >= rangeBegin && time <= rangeEnd;
    }
}