using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Samples.SampleRunners;

namespace IqOptionApiDotNet.Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // To configure username and password for tests add to:
                // Projects > IqOptionApiDotNet.Sampes Properties (Debug option)
                // In Environment Variables, the following options
                // IqOptionUserName:
                // IqOptionPassord:

                // Uncomment the lines below to run the examples

                //Task.Run(() => new AlertsSample().RunSample());
                Task.Run(() => new ChangeBalanceSample().RunSample());
                //Task.Run(() => new CopyTradeSample().RunSample());
                //Task.Run(() => new GetFinancialInformationSample().RunSample());
                //Task.Run(() => new GetProfileSample().RunSample());
                //Task.Run(() => new GetCandlesSample().RunSample());
                //Task.Run(() => new GetTopAssetsSample().RunSample());
                //Task.Run(() => new GetUserProfileClientSample().RunSample());
                //Task.Run(() => new GetUsersAvailabilitySample().RunSample());
                //Task.Run(() => new OpenBinaryOptionsSample().RunSample());
                //Task.Run(() => new PlaceDigitalOptionSample().RunSample());
                //Task.Run(() => new RequestLeaderboardDealsClientSample().RunSample());
                //Task.Run(() => new RequestLeaderboardUserinfoDealsClientSample().RunSample());
                //Task.Run(() => new ResetTrainingBalanceSample().RunSample());
                //Task.Run(() => new SubscribeLiveDealSample().RunSample());
                //Task.Run(() => new SubscribeRealtimeCandlesSample().RunSample());
                //Task.Run(() => new SubscribeTradersMoodSample().RunSample());

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}