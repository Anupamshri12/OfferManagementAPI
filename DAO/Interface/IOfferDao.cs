using PiePayAssignment.Enitites;

namespace PiePayAssignment.DAO.Interface
{
    public interface IOfferDao
    {
        public void AddOffer(List<AvailableOffers>offer);
        public void SaveOffer();

        public List<AvailableOffers> GetAllOffers();

        public AvailableOffers GetOffer(string adjustmentid);
    }
}
