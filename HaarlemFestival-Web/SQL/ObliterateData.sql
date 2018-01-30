
-- These tables are not referenced by any tables and can be removed first.
DELETE FROM Tickets;

-- These tables must be removed in order to avoid FK constraints.

----  Reference from Ticket
DELETE FROM Customers;
DELETE FROM Jazz;
DELETE FROM Talking;
DELETE FROM Walking;
DELETE FROM Dining;
-- Needs to happen last, as all types of activities reference this table.
DELETE FROM Activities;


----  Reference from Walking
DELETE FROM TourGuides;

----  Reference from Dining
DELETE FROM Restaurants;

----  Reference from Talking
DELETE FROM Interviewees;


----  Reference from Restaurant
DELETE FROM Cuisine;


----  Reference from Activity
DELETE FROM Subjects;

----  Reference from Walking & Activity
DELETE FROM Locations;


----  Doesn't need to be refilled with mock data.
-- DELETE FROM Accounts;