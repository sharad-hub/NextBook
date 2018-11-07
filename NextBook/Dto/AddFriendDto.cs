using System;

namespace NextBook.Dto
{
    public class AddFriendRequestDto
    {

        public long SenderId { get; set; }


        public long RecipientId { get; set; }

        public DateTime RequestSent { get; set; }

        public bool Accepted { get; set; }

        public AddFriendRequestDto()
        {
            RequestSent = DateTime.Now;
        }
    }
}
