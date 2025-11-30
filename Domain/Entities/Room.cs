using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Room : General
    {

        public string Name { get; set; }
        public RoomType Type { get; set; }
        public string Description { get; set; }


        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }


        public Guid? CoverImageId { get; set; }
        [NotMapped]
        public RoomImage CoverImage { get; set; }


        public int? Discount { get; set; }
        public DiscountTypes? DiscountType { get; set; }


        public decimal DailyPrice { get; set; }
        public decimal WeeklyPrice { get; set; }
        public decimal MonthlyPrice { get; set; }


        // Navigation property
        public ICollection<Service> Services { get; set; } = new List<Service>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<RoomImage> Images { get; set; }


        public decimal GetPrice(int days, int rate)
        {

            decimal price;

            if (days > 7)
                price = this.WeeklyPrice * days / rate;
            else if (days > 30)
                price = this.MonthlyPrice * days / rate;
            else
                price = this.DailyPrice * days / rate;

            if (Discount.HasValue && DiscountType.HasValue)
            {
                return ApplyDiscount(price);
            }

            return price;

        }

        public decimal ApplyDiscount(decimal basePrice)
        {
            if (Discount == null && DiscountType == null)
                return basePrice;


            return DiscountType switch
            {
                DiscountTypes.Percentage => basePrice - (basePrice * Discount.Value / 100m),
                DiscountTypes.Fixed => basePrice - Discount.Value,
                _ => basePrice,
            };
        }

    }
}
