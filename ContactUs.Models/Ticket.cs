using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactUs.Models.States;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactUs.Models
{
    public class Ticket
    {
        public string Id { get; set; }

        public DateTime LastActivityDate { get; set; }
        public string LastActivityByUser { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }

        [Required]
        public TicketState CurrentState
        {
            get
            {
                return TicketStates
                  .OrderBy(t => t.Date)
                  .LastOrDefault();
            }
        }


        [InverseProperty("Ticket")]
        public virtual ICollection<TicketState> TicketStates { get; set; }

        public Ticket()
        {
            TicketStates = new HashSet<TicketState>(); //use HashSet for create table in entityframework
            //ChangeStatus(new NewTicketState(this));
        }

        public TicketStatus Status { get { return CurrentState.Status; } }

        public bool IsAcceptable
        {
            get { return CurrentState.IsAcceptable; }
        }

        public bool IsRejectable
        {
            get { return CurrentState.IsRejectable; }
        }

        public bool IsCloseable
        {
            get { return CurrentState.IsCloseable; }
        }

        internal void ChangeStatus(TicketState state)
        {
            TicketStates.Add(state);
            //CurrentState = state;
        }

        public void Accept()
        {
            if (!this.IsAcceptable)
            {
                throw new InvalidOperationException();
            } 
            ChangeStatus(new AccetpedTicketState(this));
        }


        public void Close()
        {
            if (!this.IsCloseable)
            {
                throw new InvalidOperationException();
            }
            ChangeStatus(new ClosedTicketState(this));
        }

        public void Reject(string reason)
        {
            if (!this.IsRejectable)
            {
                throw new InvalidOperationException();
            }
            RejectedTicketState s = new RejectedTicketState();
            s.Reason = reason;
            ChangeStatus(s);
        }

   
    }
}
