using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqOptionApiDotNet.Samples.SampleRunners;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IqOptionApiDotNet.Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // change this to run example
                Task.Run(() => new ChangeBalanceSample().RunSample());

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}