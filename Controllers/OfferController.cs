using Microsoft.AspNetCore.Mvc;
using PiePayAssignment.DAO.Interface;
using PiePayAssignment.Enitites;
using PiePayAssignment.OfferDbContext;
using PiePayAssignment.Services.Interface;
using System;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace PiePayAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IOfferService _offerService;
        private readonly IOfferDao _offerdao;
        public OfferController(HttpClient httpClient ,IOfferService offerService ,IOfferDao offerdao)
        {
            _httpClient = httpClient;
            _offerService = offerService;
            _offerdao = offerdao;
        }
        [HttpPost]
        [Route("offer")]
        public IActionResult Get(List<OfferModel>getparseresponse)
        {
            
                int noOfOffersIdentified = getparseresponse.Count();
                int newoffercount = 0;
                List <AvailableOffers> availableOffers = new();
                foreach(var offer in getparseresponse)
                {
                    
                    if(_offerdao.GetOffer(offer.adjustment_id) == null)
                {

                    AvailableOffers offers = new AvailableOffers()
                    {
                        adjustmentId = offer.adjustment_id,
                        adjustmentType = offer.adjustment_type,
                        adjustmentSubtype = offer.adjustment_sub_type,
                        title = offer.title,
                        summary = offer.summary,
                        paymentInstrument = string.Join(",", offer.contributors.payment_instrument),
                        emiMonths = string.Join(",", offer.contributors.emi_months),
                        banks = string.Join(",", offer.contributors.banks)

                    };
                    availableOffers.Add(offers);
                    newoffercount++;

                }
                    

                }
               _offerdao.AddOffer(availableOffers);
               _offerdao.SaveOffer();
            return Ok(new { noOfOffersIdentified = noOfOffersIdentified, noOfNewOffersCreated = newoffercount });

            }

        [HttpGet]
        [Route("highest-discount")]
        public IActionResult BestOfferDiscount(int amountToPay ,string ?bankName ,string ?paymentInstrument)
        {

            var getmatchedoffers = _offerService.GetMatchedOffers(bankName, paymentInstrument); 
            if(getmatchedoffers == null)
            {
                return Ok(new { message = "No matched offers found" });
            }
            decimal maxDiscount = 0;

            foreach(var offer in getmatchedoffers)
            {
                decimal getDiscount = GetDiscount.getOfferDiscount(offer.summary, amountToPay);
                if(maxDiscount < getDiscount)
                {
                    maxDiscount = getDiscount;
                }
            }
            return Ok(new{ highestDiscountAmount=maxDiscount});
        }
          }

    }

