using PiePayAssignment.DAO.Interface;
using PiePayAssignment.Enitites;
using PiePayAssignment.OfferDbContext;

namespace PiePayAssignment.DAO.Implemetation
{
    public class OfferDao:IOfferDao
    {
        private readonly ApplicationDbContext _dbcontext;
        public OfferDao(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<AvailableOffers> ?GetAllOffers()
        {
            return _dbcontext.OfferAvailable.ToList();
        }
        public AvailableOffers ?GetOffer(string adjustmentid)
        {
           return _dbcontext.OfferAvailable.FirstOrDefault(x => x.adjustmentId == adjustmentid);
        }
        public void AddOffer(List<AvailableOffers>offer)
        {
            _dbcontext.AddRange(offer);
        }
        public void SaveOffer()
        {
            _dbcontext.SaveChanges();
        }

        
    }
}
