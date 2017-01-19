# mindbody

Use the following commands to execute the tests using Developer Command Prompt for VS2015. 

#Using Chrome
mstest /testcontainer:automation\chrome\ParkingCalculatorUnitTest.dll /resultsfile:chrome_testresultall.trx 

mstest /testcontainer:automation\chrome\ParkingCalculatorUnitTest.dll /resultsfile:chrome_smoketest.trx  /category:SmokeTest

mstest /testcontainer:automation\chrome\ParkingCalculatorUnitTest.dll /resultsfile:chrome_edgeases.trx  /category:EdgeCases

mstest /testcontainer:automation\chrome\ParkingCalculatorUnitTest.dll /resultsfile:chrome_invalidinput.trx  /category:InvalidInput


#Using Internet Explorer
mstest /testcontainer:automation\ie\ParkingCalculatorUnitTest.dll /resultsfile:ie_testresultall.trx 

mstest /testcontainer:automation\ie\ParkingCalculatorUnitTest.dll /resultsfile:ie_smoketest.trx  /category:SmokeTest

mstest /testcontainer:automation\ie\ParkingCalculatorUnitTest.dll /resultsfile:ie_edgeases.trx  /category:EdgeCases

mstest /testcontainer:automation\ie\ParkingCalculatorUnitTest.dll /resultsfile:ie_invalidinput.trx  /category:InvalidInput

