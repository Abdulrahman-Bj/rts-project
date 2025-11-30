using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public static class ReservationRepositoryExtension
    {

        public static IQueryable<Reservation> WhereOverlapping(this IQueryable<Reservation> query, DateTime statedAt, DateTime endedAt)
        {
            return query.Where(r => r.StartedAt < endedAt && r.EndedAt > statedAt).AsQueryable();
        }

        public static IQueryable<Reservation> WhereByRoom(this IQueryable<Reservation> query, Guid roomId)
        {
            return query.Where(r => r.RoomId == roomId).AsQueryable();
        }

        public static IQueryable<Reservation> WhereByHotel(this IQueryable<Reservation> query, Guid hotelId)
        {
            return query.Where(r => r.Room.HotelId == hotelId).AsQueryable();
        }

        public static IServiceCollection AddReservationRepository(this IServiceCollection services)
        {
            services.AddScoped<IReservationRepository, ReservationRepository>();
            return services;
        }
    }
}
