using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Models.States
{
    public class NewTicketState :TicketState
    {
        public override TicketStatus Status
        {
            get { return TicketStatus.New; }
        }

        public NewTicketState(Ticket ticket) :base(ticket)
        {
            //
        }

        public override bool IsAcceptable
        {
            get
            {
                return true; ;
            }
        }

        public override bool IsRejectable
        {
            get
            {
                return true;
            }
        }

        public NewTicketState() :base()
        {

        }
    }
}
