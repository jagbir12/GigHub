using GigHub.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Dtos
{
    public class FollowingDto
    {
        public string FolloweeId { get; set; }
    }
}