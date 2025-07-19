using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiePayAssignment.Enitites
{
    [Table(name:"AvailableOffer")]
    public class AvailableOffers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int OfferId { get; set; }
        public required string adjustmentType { get; set; }
        public required string adjustmentSubtype { get; set; }
        [Key]

        public required string adjustmentId { get; set; }
        public required string title { get; set; }
        public required string summary { get; set; }

        public required string paymentInstrument { get; set; }
        public required string banks { get; set; }
        public required string emiMonths{ get; set; }

    }
}
