
/*
	SQL Script for filling the Haarlem Festival database for group A4.
	
	Authors:
		Nick Versteeg
		Charlene Ram
*/

begin

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

end -- Database clearing statements 

begin 

INSERT INTO Subjects (Name, Description)
VALUES
('Jazz', 'Nice music'),
('Talking', 'Famous Haarlemmers'),
('Tours', 'Historic Tour'),
('Dining', 'Dinner in Haarlem');

INSERT INTO Locations (Street, Postalcode, Name)
VALUES
('Lange Veerstraat 4', '2011 DB', 'Restaurant Mr. & Mrs.'),
('Spaarne', '2011 CL', 'Ratatouille'),
('Twijnderslaan 7', '2012 BG', 'Restaurant Fris'),
('Spekstraat 4', '2011 HM', 'Specktakel'),
('Grote Markt 13', '2011 RC', 'Grand Cafe Brinkmann'),
('Oude Groenmarkt 10', '2011 HL', 'Urban Frenchy Bistro Toujours'),
('Zijlstraat 39', '2011 TK', 'The Golden Bull'),
('Lange Begijnestraat 9', '2011 HH', 'De Toneelschuur'),
('Zijlsingel 2', '2011 DN', 'Restaurant Mr. & Mrs.'),
('Grote Markt 22', '2011 RD', 'Grote St. Bavokerk');

INSERT INTO Cuisine (Name) 
VALUES 
('Dutch'),
('Fish and Seafood'),
('European'),
('French'),
('International'),
('Asian'),
('Modern'),
('Steakhouse'),
('Argentinian');

-- Possible issues with inserting tourguides due to changing IDs.
INSERT INTO Walking (Id, TourGuideId) 
VALUES 
(1, 11),
(2, 12),
(3, 13),
(4, 14),
(5, 15),
(6, 16);




end -- Database insert statements

