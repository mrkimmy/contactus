using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Should;
using ContactUs.Models;

namespace ContactUs.Facts.Models
{
    public class TicketFacts
    {
        
        [Fact]
        public void NewTicketStatus_ShouldBeNew()
        {
            Ticket newTicket = new Ticket();

            Assert.Equal(TicketStatus.New, newTicket.Status);
        }


        [Fact]
        public void NewTicket_AbleToChangeToAcceptedAndRejected_ButNotClosed()
        {
            Ticket newTicket = new Ticket();

            
            
            Assert.True(newTicket.IsAcceptable);
            Assert.False(newTicket.IsCloseable);
        }

        [Fact]
        public void AcceptedTicket_AbleToChangeToClosedOrRejected()
        {
            Ticket newTicket = new Ticket();
            newTicket.Accept();
         
            Assert.True(newTicket.IsCloseable);
            Assert.True(newTicket.IsRejectable);
       
        }

        [Fact]
        public void RejectedTicket_CannotChangeStatusAnymore()
        {
            Ticket newTicket = new Ticket();
            newTicket.Reject();

     
            Assert.False(newTicket.IsRejectable);
            Assert.False(newTicket.IsCloseable);
        }

        [Fact]
        public void ClosedTicket_CannotChangeStatusAnymore()
        {
            Ticket newTicket = new Ticket();
            newTicket.Accept();
            newTicket.Close();

            
            Assert.False(newTicket.IsAcceptable);
            Assert.False(newTicket.IsRejectable);
        }
    }
}
