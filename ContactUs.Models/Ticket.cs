using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Models
{
    public class Ticket
    {
        public string Id { get; set; }

        public DateTime LastActivityDate { get; set; }
        public string LastActivityByUser { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public TicketStatus Status { get; private set; }

        public void Accept()
        {
            if (CanChange(TicketStatus.Accepted))
            {
                Status = TicketStatus.Accepted;
            }
        }


        public void Close()
        {
            if (CanChange(TicketStatus.Closed))
            {
                Status = TicketStatus.Closed;
            }
        }

        public void Reject()
        {
            if(CanChange(TicketStatus.Rejected))
            {
                Status = TicketStatus.Rejected;
            }
        }

        public bool CanChange(TicketStatus status)
        {
            switch (Status)
            {
                case TicketStatus.New:
                    if (status == TicketStatus.Accepted) return true;
                    if (status == TicketStatus.Rejected) return true;
                    break;
                case TicketStatus.Accepted:
                    if (status == TicketStatus.Closed) return true;
                    if (status == TicketStatus.Rejected) return true;
                    return false;
                case TicketStatus.Closed:
                case TicketStatus.Rejected:
                    return false;
            }
            return false;
        }
    }
}
