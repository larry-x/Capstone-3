INSERT INTO park(parkCode, parkName, state, acreage, elevationInFeet, milesOfTrail, numberOfCampsites, climate, yearFounded, annualVisitorCount, inspirationalQuote, inspirationalQuoteSource, parkDescription, entryFee, numberOfAnimalSpecies)
VALUES('FRM', 'FarmerFarm', 'OH', 200, 200, 200, 1, 'warm', 1900, 20, 'Hello', 'USA', 'nice', 10, 2);

INSERT INTO park(parkCode, parkName, state, acreage, elevationInFeet, milesOfTrail, numberOfCampsites, climate, yearFounded, annualVisitorCount, inspirationalQuote, inspirationalQuoteSource, parkDescription, entryFee, numberOfAnimalSpecies)
VALUES('AMM', 'AmericanFarm', 'PA', 2, 3, 4,2, 'cold', 1920, 10, 'World', 'CAN', 'cool', 1, 3);

INSERT INTO survey_result(parkCode, emailAddress, state, activityLevel)
VALUES('FRM', 'hello@world.com', 'TX', 'active');

INSERT INTO survey_result(parkCode, emailAddress, state, activityLevel)
VALUES('AMM', 'hello@usa.com', 'OH', 'extremely active');

INSERT INTO weather(parkCode, fiveDayForecastValue, low, high, forecast)
VALUES('FRM', 1, 24, 99, 'rain');

INSERT INTO weather(parkCode, fiveDayForecastValue, low, high, forecast)
VALUES('AMM', 1, 22, 89, 'sunny');


/*
SELECT TEST: sql insert -> create compare object -> make/call dao -> datatest (expected rows, actual)
INSERT TEST: make object -> make/call dao -> SELECT (expected count, actual) | (exception fail if invalid)
UPDATE TEST: sql insert -> make/call dao using max id -> (SELECT with max id to compare values)
DELETE TEST: sql insert -> make/call dao -> SELECT (expected rows, actual)
*/



