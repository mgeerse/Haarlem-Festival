DELETE FROM Accounts;
DELETE FROM Activities;
DELETE FROM Subjects;
DELETE FROM Tickets;
DELETE FROM Customers;

-- Admin accounts
insert into Accounts (Name, Username, Password, AccountType) values 
      ('Beatrice McAllester', 'bmcallester0', 'GK5OBjUfX', 0),
      ('Edd Puttrell',  'eputtrell1', 'Fw30wzw',  1),
      ('Cherish Witham',  'cwitham2',  'dRx2Qy2r',  1);

-- Subjects
insert into Subjects (Name, Description) values
      ('Historic Haarlem', 'TBD'), -- 1
      ('Dining in Haarlem', 'TBD'), -- 2
      ('Jazz@Patronaat',  'TBD'), -- 3
      ('Talking Haarlem',  'TBD'); -- 4

-- Tours 
-- Wat een kutwerk.
insert into Activities (Name, Description, Location, StartTime, EndTime, SubjectId) values
      ('Tour Dutch', 'A Dutch tour through Haarlem', '20180726 10:00:00 AM','20180726 12:30:00 PM', 1),
      ('Tour English', 'An English tour through Haarlem', '20180726 10:00:00 AM','20180726 12:30:00 PM', 1),
      ('Tour Dutch', 'A Dutch tour through Haarlem', '20180726 13:00:00 AM','20180726 15:30:00 PM', 1),
      ('Tour English', 'An English tour through Haarlem', '20180726 13:00:00 AM','20180726 15:30:00 PM', 1),
      ('Tour Dutch', 'A Dutch tour through Haarlem', '20180726 16:00:00 AM','20180726 18:30:00 PM', 1),
      ('Tour English', 'An English tour through Haarlem', '20180726 16:00:00 AM','20180726 18:30:00 PM', 1),
	  
      ('Tour Dutch', 'A Dutch tour through Haarlem', '20180726 10:00:00 AM','20180726 12:30:00 PM', 1),
      ('Tour English', 'An English tour through Haarlem', '20180726 10:00:00 AM','20180726 12:30:00 PM', 1),
      ('Tour Dutch', 'A Dutch tour through Haarlem', '20180726 13:00:00 AM','20180726 15:30:00 PM', 1),
      ('Tour English', 'An English tour through Haarlem', '20180726 13:00:00 AM','20180726 15:30:00 PM', 1),
      ('Tour Chinese', 'A Chinese tour through Haarlem', '20180726 13:00:00 AM','20180726 15:30:00 PM', 1),
      ('Tour Dutch', 'An English tour through Haarlem', '20180726 16:00:00 AM','20180726 18:30:00 PM', 1),
      ('Tour English', 'An English tour through Haarlem', '20180726 16:00:00 AM','20180726 18:30:00 PM', 1),
	  
      ('Tour Dutch', 'A Dutch tour through Haarlem', '20180726 10:00:00 AM','20180726 12:30:00 PM', 1),
      ('Tour English', 'An English tour through Haarlem', '20180726 10:00:00 AM','20180726 12:30:00 PM', 1),
      ('Tour Dutch', 'A Dutch tour through Haarlem', '20180726 13:00:00 AM','20180726 15:30:00 PM', 1),
      ('Tour English', 'An English tour through Haarlem', '20180726 13:00:00 AM','20180726 15:30:00 PM', 1),
      ('Tour Chinese', 'A Chinese tour through Haarlem', '20180726 13:00:00 AM','20180726 15:30:00 PM', 1),
      ('Tour Dutch', 'A Dutch tour through Haarlem', '20180726 16:00:00 AM','20180726 18:30:00 PM', 1),
      ('Tour English', 'An English tour through Haarlem', '20180726 16:00:00 AM','20180726 18:30:00 PM', 1),
      ('Tour Chinese', 'A Chinese tour through Haarlem', '20180726 16:00:00 AM','20180726 18:30:00 PM', 1);

-- Restaurants