using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Data
{

    public class MountainInfo
    {    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string County { get; set; }

        public string Muncipiality { get; set; }

        public string OfficialName { get; set; }

        [NotMapped]
        public string MetresAboveSeaLevel { get; set; }

        [NotMapped]
        public string PrimaryFactor { get; set; }

        public string ReferencePoint { get; set; }

        public string Comments { get; set; }

        [Column("MetresAboveSeaLevel")]
        public double CalculatedMetresAboveSeaLevel { get; set; }

        [Column("PrimaryFactor")]
        public double CalculatedPrimaryFactor { get; set; }

        [NotMapped]
        public double CalculateMetresAboveSeaLevel
        {
            get
            {
                var input = MetresAboveSeaLevel;
                return WashAltimeterData(input);
            }
        }

        [NotMapped]
        public double CalculatePrimaryFactor
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
