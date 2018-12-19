using System.Collections.Generic;

namespace Giftbit.API.Model.Response
{
    public class ListRegionsResponse
    {
        public List<Region> Regions { get; set; }
        public ResponseInfo Info { get; set; }
    }
}