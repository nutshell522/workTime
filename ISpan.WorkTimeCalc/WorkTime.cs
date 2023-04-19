namespace ISpan.WorkTimeCalc
{
	public class WorkTime
	{
		// 定義上班時間
		private const int workBegin = 9;
		// 定義下班時間
		private const int workEnd = 18;

		// 將需要扣除的休息時間放入陣列
		private int[] _restTimes = { 12 };
		private List<int> RestTime => _restTimes.ToList();
		/// <summary>
		/// 獲得請假時間資訊
		/// </summary>
		/// <param name="leaveBegin">請假開始時間</param>
		/// <param name="leaveEnd">請假結束時間</param>
		/// <returns></returns>
		public string GetLeaveHoursInfo(int leaveBegin, int leaveEnd)
		{
			int result = LeaveHoursCalc(leaveBegin, leaveEnd);
			return result < 0
				? "輸入的時間不正確，請重新輸入"
				: $"請假的時間 從 {leaveBegin,2} 至 {leaveEnd,2} 為: {result} 小時";
		}

		/// <summary>
		/// 計算請假時數
		/// </summary>
		/// <param name="leaveBegin">請假開始時間</param>
		/// <param name="leaveEnd">請假結束時間</param>
		/// <returns></returns>
		public int LeaveHoursCalc(int leaveBegin, int leaveEnd)
		{
			// 驗證開始、結束時間，不合法即回傳 -1
			if (!IsReasonableTime(leaveBegin, leaveEnd)) return -1;

			leaveBegin = Math.Max(leaveBegin, workBegin); // 如果開始時間小於上班時間，等於上班時間
			leaveEnd = Math.Min(leaveEnd, workEnd); // 如果結束時間大於下班時間，等於下班時間

			// 獲得一個正式請假的時間段清單(過濾掉休息時間)
			List<int> leaveHours = HoursToList(leaveBegin, leaveEnd, RestTime);

			return leaveHours.Count;
		}

		/// <summary>
		/// 將時間過濾後放入列表
		/// </summary>
		/// <param name="begin">開始時間</param>
		/// <param name="end">結束時間</param>
		/// <param name="filterList">要過濾掉的時間段</param>
		/// <returns></returns>
		private List<int> HoursToList(int begin, int end, List<int>? filterList = null)
		{
			var hourList = new List<int>();
			filterList = filterList ?? new List<int>();

			for (int i = begin; i < end; i++)
			{
				// 如果此時間為需要過濾掉的時間，直接進入下一圈，不添加此時間
				if (filterList.Contains(i)) continue;

				hourList.Add(i);
			}

			return hourList;
		}

		/// <summary>
		/// 驗證時間數字是否合法
		/// </summary>
		/// <param name="begin">開始時間</param>
		/// <param name="end">結束時間</param>
		/// <returns></returns>
		private bool IsReasonableTime(int begin, int end)
		{
			if (begin < 0
				|| end < 0
				|| begin > 24
				|| end > 24
				|| begin > end) return false;

			else return true;
		}
	}
}