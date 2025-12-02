SELECT * FROM tbEvents WHERE EventId = 1; -- replace 1 with the ID
ALTER TABLE tbEventRegistrations
ADD CONSTRAINT FK_tbEventRegistrations_tbEvents
FOREIGN KEY (EventId) REFERENCES tbEvents(EventId);
