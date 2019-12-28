﻿using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Dtos;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();

            return notifications.Select(n => new NotificationDto() {
                DateTime = n.DateTime,
                Gig = new GigDto
                {
                    Artist = new UserDto
                    {
                        Id = n.Gig.Artist.Id,
                        Name = n.Gig.Artist.Name
                    },
                    DateTime = n.Gig.DateTime,
                    Id = n.Gig.Id,
                    IsCancelled = n.Gig.IsCancelled,
                    Venue = n.Gig.Venue
                },
                OriginalDateTime = n.OriginalDateTime,
                OriginalVenue = n.OriginalVenue,
                Type = n.Type
            });
        }
    }
}
