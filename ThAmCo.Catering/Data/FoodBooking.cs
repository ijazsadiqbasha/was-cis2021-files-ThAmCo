using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ThAmCo.Catering.Data
{
    public class FoodBooking
    {
        public FoodBooking()
        {

        }

        public FoodBooking(int numberOfGuests, int clientReferenceId) : this()
        {
            NumberOfGuests = numberOfGuests;
            ClientReferenceId = clientReferenceId;
        }

        public int FoodBookingId { get; set; }

        public int ClientReferenceId { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }

        public int MenuId { get; set; }

        [Required]
        public Menu Menu { get; set; }

    }
}
