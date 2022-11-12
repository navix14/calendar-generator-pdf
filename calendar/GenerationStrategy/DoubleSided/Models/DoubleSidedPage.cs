namespace calendar.GenerationStrategy.DoubleSided.Models {
    class DoubleSidedPage {
        public DoubleSidedPage(SplittedPage front, SplittedPage back)
        {
            Front = front;
            Back = back;
        }

        public SplittedPage Front { get; }
        public SplittedPage Back { get; }
    }
}
