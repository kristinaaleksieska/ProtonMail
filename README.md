# ProtonMail

This is a testing framework built to test only the Folders and Labels page of ProtonMail (https://beta.protonmail.com/settings/u/0/labels#folderlist)

The solution is based on the Page-Object-Model designing pattern.
It is divided into four seperate projects:
* BaseSupport; Here are located the basic support tools used in each of the other projects, like the RandomDataGenerator that is used for getting random data (alphanumeric strings, integers, random value from a given list, etc.), the Logger (used in the test methods that describe each step of the test) and the user information (Since this is only a test user, the credentials are added here)
* DriverSettings; Here are located methods and settings that correspond to the Driver, setting timeouts, implicit waits & creation of the drivers. Currently, there are two supported drivers (Chrome & Firefox), but another driver can be easily added into the DriverFactory class.
* Pages; Here are located the Components, their methods (located in a separate static class called {Component}Extensions, the Pages (this case only 1) and the pages extensions ({Page}ActionExtensions and {Page}VerifyExtensions). In this solution, the constants used for the testing purposes are also located here. 
* Tests; In the Tests solution are the tests, with implementation for both Drivers, Chrome and Firefox. There is a seperate CommonTestMethods static class that stores the test methods, because all scenarios are being used for both browsers and in that way, duplication of code is being reduced.

*It is important to note that in the test scenarios, there is not a test for deletion of labels, nor folders, but that has been done after each test in TearDown attribute, that goes and deletes all previously added folders and labels and makes sure that after each test, the environment is clean. This has been found to be a more flexible solution to the maximum number of folders permitted for a basic user.*


