namespace calendar.GenerationStrategy.SinglePage.Models {
    public class Page {
        private List<DateTime> _dates;
        private int _kw;

        public Page(List<DateTime> dates, int kw)
        {
            _dates = dates;
            _kw = kw;
        }

        public int WeekOfYear()
        {
            return _kw;
        }

        public int GetYear()
        {
            return _dates.ElementAt(0).Year;
        }

        public string GetWeekDay(int index)
        {
            var date = _dates.ElementAt(index);
            return CalendarHelper.DayOfWeekToString(date.DayOfWeek);
        }

        public string GetDate(int index)
        {
            return _dates.ElementAt(index).ToShortDateString();
        }
    }
}
