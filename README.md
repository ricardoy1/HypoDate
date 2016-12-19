HypoDates

First conding challenge.

Workflow

The user will be requested to enter two dates, date FROM and TO. 
Each date is composed by 3 separate components: day, month and year.
Once the user has entered the two dates, the application will inform the elapsed days between those 2 dates.

Validations.

The dates will be validated in two separate stages:

1. Input
The application will ensure the user enters numbers and only numbers.
The application will ensure the user does not enter an invalid year. Only years between 1901 and 2999 will be allowed. (I know there won't be experiements in the future, but this is as per the documentation, I would suggest we shouldn't allow users to enter a date future than today's date.)
The application will ensure we enter a month number from 1 to 12.
The application will ensure the day number is valid depending on the month and whether the year is leap year in February.

2. Range

Once the user has successfully entered the two dates, the application will validate the date FROM not later than TO date.

Results

The application will inform the number of days and ask the user if she/he want to keep adding experiment days.


Technology

The technology selected is:
C# 5.0 with Visual Studio 2013. 
Console Application



