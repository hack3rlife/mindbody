# mindbody

Use the following commands to execute the tests using Developer Command Prompt for VS2015. Note that you may need to update "C:\git\mindbody" based on your folder structure.

#Using Chrome
mstest /testcontainer:C:\git\mindbody\bin\chrome\Release\ParkingCalculatorUnitTest.dll /resultsfile:testresultall.trx 

mstest /testcontainer:C:\git\mindbody\bin\chrome\Release\ParkingCalculatorUnitTest.dll /resultsfile:testresultall.trx  /category:SmokeTest

mstest /testcontainer:C:\git\mindbody\bin\chrome\Release\ParkingCalculatorUnitTest.dll /resultsfile:testresultall.trx  /category:EdgeCases

mstest /testcontainer:C:\git\mindbody\bin\chrome\Release\ParkingCalculatorUnitTest.dll /resultsfile:testresultall.trx  /category:InvalidInput


#Using Internet Explorer
mstest /testcontainer:C:\git\mindbody\bin\ie\Release\ParkingCalculatorUnitTest.dll /resultsfile:testresultall.trx 

mstest /testcontainer:C:\git\mindbody\bin\ie\Release\ParkingCalculatorUnitTest.dll /resultsfile:testresultall.trx  /category:SmokeTest

mstest /testcontainer:C:\git\mindbody\bin\ie\Release\ParkingCalculatorUnitTest.dll /resultsfile:testresultall.trx  /category:EdgeCases

mstest /testcontainer:C:\git\mindbody\bin\ie\Release\ParkingCalculatorUnitTest.dll /resultsfile:testresultall.trx  /category:InvalidInput
