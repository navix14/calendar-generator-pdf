namespace calendar.GenerationStrategy.DoubleSided.Models {
    /*
     * Generates one PDF containing front & back page
     */
    class Subpage {
        private List<DateTime> _dates;

        public Subpage(List<DateTime> dates)
        {
            _dates = dates;
        }

        public string GetMonth()
        {
            return CalendarHelper.MonthToString(_dates.First().Month - 1);
        }

        public int GetYear()
        {
            return _dates.First().Year;
        }

        public int GetWeekOfYear()
        {
            return CalendarHelper.GetWeekOfYear(_dates.First());
        }

        public int GetFirstDay()
        {
            return _dates.First().Day;
        }

        public int GetLastDay()
        {
            return _dates.Last().Day;
        }

        public string GetWeekDay(int index)
        {
            var dow = _dates.ElementAt(index).DayOfWeek;
            return CalendarHelper.DayOfWeekToString(dow);
        }

        public int GetDayOfMonth(int index)
        {
            return _dates.ElementAt(index).Day;
        }
    }
}
