using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar.GenerationStrategy {
    public interface IGenerationStrategy {
        public PdfDocument Generate(IProgress<Tuple<int, int>> progressCallback);
    }
}
