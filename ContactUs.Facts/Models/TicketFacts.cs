using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Should;
using ContactUs.Models;
using ContactUs.Models.States;

namespace ContactUs.Facts.Models
{
    public class TicketFacts
    {


        public class IsAbleToChangeStatus
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
                newTicket.Reject("test reject");


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

        public class ChangeStatus
        {
            [Fact]
            public void ChangeFromNewToAccepted()
            {
                var t = new Ticket();

                Assert.True(t.Status == TicketStatus.New);
                Assert.Equal(1, t.TicketStates.Count());

                t.Accept();

                Assert.True(t.Status == TicketStatus.Accepted);
                Assert.Equal(2, t.TicketStates.Count());
            }

            [Fact]
            public void ChangeFromNewToRejected()
            {
                var t = new Ticket();

                Assert.True(t.Status == TicketStatus.New);
                Assert.Equal(1, t.TicketStates.Count());

                t.Reject(reason: "test reject");

                Assert.True(t.Status == TicketStatus.Rejected);
                Assert.Equal(2, t.TicketStates.Count());
                var s2 = t.CurrentState as RejectedTicketState;
                Assert.Equal("test reject", s2.Reason);
            }

            [Fact]
            public void CannotChangeFromNewToClosed()
            {
                var t = new Ticket();

                Assert.Throws<InvalidOperationException>(() =>
                {
                    t.Close();
                });
            }
        }
    }
}
