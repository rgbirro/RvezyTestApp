using Microsoft.AspNetCore.Mvc;
using RVezyTestApp.Model;

namespace RVezyTestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppControler : ControllerBase
    {           
        List<ListingsModel> result { get; set; }

        public AppControler()
        {
            result = new();
        }

        private void ReadFile ()
        {
            try
            {
                // Open the text file using a stream reader.
                using var sr = new StreamReader("Resources/Listings.csv");
                // Read the stream as a string, and write the string to the console.
                while (sr.Peek() >= 0)
                {
                    String[] s = sr.ReadLine().Split(";");
                    ListingsModel listingsModel = new();
                    listingsModel.id = int.Parse(s[0]);
                    listingsModel.listingUrl = s[1];
                    listingsModel.name = s[2];
                    listingsModel.description = s[3];
                    listingsModel.propertyType = s[4];
                    result.Add(listingsModel);
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        [HttpGet(Name = "ListListings")]
        public IEnumerable<ListingsModel> Get()
        {
            ReadFile();
            return result.ToArray();
        }
                
        [HttpGet("id/{listingId}", Name = nameof(GetListingsById))]
        public IEnumerable<ListingsModel> GetListingsById(int listingId)
        {
            ReadFile();
            return result.Where(listing => listing.id == listingId).ToArray();
        }

        [HttpGet("propertyType/{propertyType}", Name = nameof(GetListingsByPropertyId))]
        public IEnumerable<ListingsModel> GetListingsByPropertyId(String propertyType)
        {
            ReadFile();
            return result.Where(listing => listing.propertyType == propertyType).ToArray();
        }
    }
}