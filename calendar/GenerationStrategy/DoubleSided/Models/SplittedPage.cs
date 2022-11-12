namespace calendar.GenerationStrategy.DoubleSided.Models {
    class SplittedPage {
        public SplittedPage(Subpage left, Subpage right)
        {
            Left = left;
            Right = right;
        }

        public Subpage Left { get; }
        public Subpage Right { get; }
    }
}
