using System.Globalization;
using System.Text.Json.Serialization;

namespace MountainDataSet.Console
{
    public class MountainInfo
    {
        public string County { get; set; }

        public string Muncipiality { get; set; }

        public string OfficialName { get; set; }

        [JsonIgnore]
        public string MetresAboveSeaLevel { get; set; }

        [JsonIgnore]
        public string PrimaryFactor { get; set; }
      
        public string ReferencePoint { get; set; }

        public string Comments { get; set; }

        public double CalculatedMetresAboveSeaLevel
        {
            get
            {
                var input = MetresAboveSeaLevel;
                return WashAltimeterData(input);
            }
        }

        public double CalculatedPrimaryFactor
        {
            get
            {
                var input = PrimaryFactor;
                return WashAltimeterData(input);
            }
        }

        private static double WashAltimeterData(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }
            input = input.Replace(".00", "");

            double height;
            if (double.TryParse(input, NumberStyles.Number, new CultureInfo("nb-NO"), out height))
            {
                if (height > 10000)
                {
                    height = height / 1000;
                }
                return height;
            }
            return 0;
        }
    }
}
