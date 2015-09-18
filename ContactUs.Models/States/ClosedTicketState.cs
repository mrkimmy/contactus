using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Models.States
{
    public class ClosedTicketState : TicketState
    {

        public ClosedTicketState(Ticket ticket) : base(ticket) { }

        public override TicketStatus Status
        {
            get { return TicketStatus.Closed; }
        }

        public ClosedTicketState()
        {

        }
    }
}
