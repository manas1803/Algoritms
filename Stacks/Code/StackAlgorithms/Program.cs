using System;

namespace StackAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            NearestGreaterToRight ngr = new NearestGreaterToRight();
            //ngr.Main();

            NearestGreaterToLeft ngl = new NearestGreaterToLeft();
            //ngl.Main();

            NearestSmallestToLeft nsl = new NearestSmallestToLeft();
            //nsl.Main();

            NearestSmallestToRight nsr = new NearestSmallestToRight();
            //nsr.Main();

            StockSpanProblem ssp = new StockSpanProblem();
            //ssp.Main();

            MaximumAreaHistogram mah = new MaximumAreaHistogram();
            mah.Main();
        }
    }
}
