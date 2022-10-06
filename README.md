# GoogleMapsTask

This small project provides implementation for Google Maps UI test strategy focusing on address lookups.
This project uses **Selenium WebDrive** and **NUnit** for browser automation and currently supports only Chrome browser.

### Dependencies:
Dotnet 6.0 (https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

Chrome browser (https://www.google.com/chrome/)

### Running the tests:
Open the projects visual studio solution file (.sln) and run the tests using the test explorer window.

### Modules overview:
* **Tests:** You can look at the test file to view the test implementation under "GoogleMapsAddressSearchTests.cs"

* **Google Module:** The "GoogleMapsFacade" bundles and simplifies google maps utilities and WebDriver functionality for cleaner API exposed to the test scripts.

* **WebDriver Module:** Selenium WebDriver is wrapped in our own implementation for added functionality and is created using a webDriver factory pattern to encapsolate the browser specific web driver creation, and provide unified API to be used throught the project.

* **Browsers Module:** Multi browser test solution execution feature is present, although the solution support only Chrome atm. 
To explore a multi browser test execution create a text file at the following path > @rootDirectory\TestsParameters\Browsers.txt, where root directory is the directory of the .dll file.
The browsers textfile parsers expects each line to contain one browser name, for example:
```
Chrome
Firefox
```
