using System.Collections.Generic;

namespace Giftbit.API.Model.Response
{
    public class RetrieveShortlinksResponse
    {
        public List<Shortlink> Shortlinks { get; set; }
        public int TotalCount { get; set; }
        public ResponseInfo Info { get; set; }
        public int NumberOfResults { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Status { get; set; }
    }
}