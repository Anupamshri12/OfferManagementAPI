using Microsoft.EntityFrameworkCore;
using PiePayAssignment.DAO.Interface;
using PiePayAssignment.Enitites;
using PiePayAssignment.Services.Interface;

namespace PiePayAssignment.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferDao _offerDao;
        public OfferService(IOfferDao offerDao)
        {
            _offerDao = offerDao;
        }
        public List<AvailableOffers>? GetMatchedOffers(string ?bankName ,string ?paymentInstrument)
        {
            var matchedOffers = _offerDao.GetAllOffers();
            if(matchedOffers == null )
            {
                return null;
            }
            if (!string.IsNullOrEmpty(bankName))
            {
                matchedOffers = matchedOffers.Where(o => o.banks
                   .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                   .Any(b => string.Equals(b, bankName, StringComparison.OrdinalIgnoreCase))
                   ).ToList();
            }

            if (!string.IsNullOrEmpty(paymentInstrument))
            {
                matchedOffers = matchedOffers.Where(o => o.paymentInstrument.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                    .Any(b => string.Equals(b, paymentInstrument, StringComparison.OrdinalIgnoreCase)))
                .ToList();
            }
            return matchedOffers;
        }
    }
}
