using PiePayAssignment.Enitites;

namespace PiePayAssignment.Services.Interface
{
    public interface IOfferService
    {
        public List<AvailableOffers> ?GetMatchedOffers(string? bankName, string? paymentInstrument);
    }
}
