using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Samples.SampleRunners;

namespace IqOptionApiDotNet.Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // To configure username and password for tests add to:
            // Projects > IqOptionApiDotNet.Sampes Properties (Debug option)
            // In Environment Variables, the following options
            // IqOptionUserName:
            // IqOptionPassword:

            bool showMenu = true;

            while (showMenu)
            {
                showMenu = MainMenu();
            }

        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(" 1) GetAdditionalBlocksSample");
            Console.WriteLine(" 2) GetProfileSample");
            Console.WriteLine(" 3) GetInitializationDataSample");
            Console.WriteLine(" 4) GetBalancesSample");
            Console.WriteLine(" 5) AlertsSample");
            Console.WriteLine(" 6) ChangeBalanceSample [PRACTICE]");
            Console.WriteLine(" 7) Dont Use");
            Console.WriteLine(" 8) GetUserSettingsSample");
            Console.WriteLine(" 9) GetCurrencySample");
            Console.WriteLine("10) GetFinancialInformationSample");
            Console.WriteLine("11) GetCandlesSample");
            Console.WriteLine("12) GetTopAssetsSample");
            Console.WriteLine("13) GetUserProfileClientSample");
            Console.WriteLine("14) GetUsersAvailabilitySample");
            Console.WriteLine("15) OpenBinaryOptionsSample");
            Console.WriteLine("16) PlaceDigitalOptionSample");
            Console.WriteLine("17) RequestLeaderboardDealsClientSample");
            Console.WriteLine("18) RequestLeaderboardUserinfoDealsClientSample");
            Console.WriteLine("19) ResetTrainingBalanceSample");
            Console.WriteLine("20) SubscribeLiveDealSample");
            Console.WriteLine("21) SubscribeRealtimeCandlesSample");
            Console.WriteLine("22) SubscribeTradersMoodSample");
            Console.WriteLine("23) SetUserSettingsSample");
            Console.WriteLine("24) SubscribeBalanceChangedSample");
            Console.WriteLine("25) CopyTradeSample [NOT WORKING]");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(" 0) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    //Task.Run(() => new GetAdditionalBlocksSample().RunSample()); -> Dont Use
                    return true;
                case "2":
                    Task.Run(() => new GetProfileSample().RunSample());
                    return true;
                case "3":
                    Task.Run(() => new GetInitializationDataSample().RunSample());
                    return true;
                case "4":
                    Task.Run(() => new GetBalancesSample().RunSample());
                    return true;
                case "5":
                    Task.Run(() => new AlertsSample().RunSample());
                    return true;
                case "6":
                    Task.Run(() => new ChangeBalanceSample().RunSample());
                    return true;
                case "7":
                    //Task.Run(() => new ChangeBalanceReal().RunSample()); -> Dont Use
                    return true;
                case "8":
                    Task.Run(() => new GetUserSettingsSample().RunSample());
                    return true;
                case "9":
                    Task.Run(() => new GetCurrencySample().RunSample());
                    return true;
                case "10":
                    Task.Run(() => new GetFinancialInformationSample().RunSample());
                    return true;
                case "11":
                    Task.Run(() => new GetCandlesSample().RunSample());
                    return true;
                case "12":
                    Task.Run(() => new GetTopAssetsSample().RunSample());
                    return true;
                case "13":
                    Task.Run(() => new GetUserProfileClientSample().RunSample());
                    return true;
                case "14":
                    Task.Run(() => new GetUsersAvailabilitySample().RunSample());
                    return true;
                case "15":
                    Task.Run(() => new OpenBinaryOptionsSample().RunSample());
                    return true;
                case "16":
                    Task.Run(() => new PlaceDigitalOptionSample().RunSample());
                    return true;
                case "17":
                    Task.Run(() => new RequestLeaderboardDealsClientSample().RunSample());
                    return true;
                case "18":
                    Task.Run(() => new RequestLeaderboardUserinfoDealsClientSample().RunSample());
                    return true;
                case "19":
                    Task.Run(() => new ResetTrainingBalanceSample().RunSample());
                    return true;
                case "20":
                    Task.Run(() => new SubscribeLiveDealSample().RunSample());
                    return true;
                case "21":
                    Task.Run(() => new SubscribeRealtimeCandlesSample().RunSample());
                    return true;
                case "22":
                    Task.Run(() => new SubscribeTradersMoodSample().RunSample());
                    return true;
                case "23":
                    Task.Run(() => new SetUserSettingsSample().RunSample());
                    return true;
                case "25":
                    Task.Run(() => new SubscribeBalanceChangedSample().RunSample());
                    return true;
                case "24":
                    Task.Run(() => new CopyTradeSample().RunSample());  //-> Not Working IqOption has disabled Features necessary
                    return true;
                default:
                    return true;
            }
        }
    }
}