using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MeetingRoomBooker.Data.Models
{
    public class Room
    {
        public int Id { get; set; }
        [DefaultValue(false)]
        public bool Status { get; set; }
        [Required]
        [MaxLength(6)]
        public string Number { get; set; }
        //[]
        //public RoomType Type { get; set; }



        [Required]
        [DisplayName(displayName: "Type of room")]
        public RoomTypeEnum TypeId { get; set; }
    }
}
