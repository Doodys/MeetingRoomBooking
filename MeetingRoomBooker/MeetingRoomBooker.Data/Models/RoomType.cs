using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRoomBooker.Data.Models
{
    public class RoomType
    {
        private RoomType(RoomTypeEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
        }

        protected RoomType() { } //for entity framework


        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public static implicit operator RoomType(RoomTypeEnum @enum) => new RoomType(@enum);

        public static implicit operator RoomTypeEnum(RoomType roomType) => (RoomTypeEnum)roomType.Id;
    }
}
