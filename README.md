
# Build
Run command `dotnet build` in the root directory of the project.
Tests are based on dotnet 8 framework.

# Setup

Fill up the `appsettings.json` file with your ClientId and ClientSecret from Mangopay.

```
{
  "Settings": {
    "BaseUrl": "https://api.sandbox.mangopay.com",
    "ClientId": "",
    "ClientSecret": ""
  }
}
```

# Run
Run command `dotnet test` in the root directory of the project.

# Task Comments
- I decided to spend 6 hours for this challenge. I think this is fair amount of time I can dedicate without any compensation. I have not finished all the tasks, but I believe that I have shown my skills in the areas that are important for the position.
- The presented user story seems to be way too general. It is not clear what the user wants to achieve. The user story should be split into smaller parts. Otherwise we would need to create dozens (or even hundreds) of ACs for this single User Story. But for the sake of interview task I will do what I was asked to, which is creation of API tests based on the Acceptance Criterias within the document.
- Acceptance Criteria 1 and 2 do not fit into the this User Story, because they are not testing any transaction. They are more like precondition steps from my point of view. Instead these ACs could be part of a different User Story: 
 **"As a Mangopay API client I want to use the API in order to manage users and their wallets"**
- There are many enhancements that could be done to the code. For instance:
	- third party logger could be added like serilog
	- BDD layer could be added so the tests would be written in a more human readable way. I would use SpecFlow for that. I can show some sample within the PRIVATE repositories I have on github.
	- Simple pipeline to run tests on Github Actions could be added.

 # Responses to Additional Work points:
1. Implemented negative test that checks if the wallet is not created when not existing currency is passed
2. I have not "borrowed" any code and I am happy to present my solution myself.
3. This is the readme. :-)
4. At this moment I used builder pattern and factory pattern. On the other hand I do not think that extensive amount of design patterns within the code makes it cleaner.
5. Tests should run in parallel.
6. There is not much data that can be caught for the API tests. At this moment all failures are logged with a description what was expected, what was an actual result and some information about the step that failed.
7. 
	a) In order to create performance tests I would need to contact "the business" and ask for the expected load. I would need information about the scenarios that are predicted to be performed by users frequently. Depending on the answers I would go either with Jmeter, Gatling or k6. That also depends on the current team skillset, because I believe that I would not be the only contributor here. All in all I believe the hardest part would be gathering requirements so the outcome of those expensive tests would be useful.
	b) Accessibility I think is out of scope here. There is no Graphical User Interface to test. But if there was one, I would go with Playwright and some extra npm packages.
	c) Security tests could be performed with OWASP ZAP or Burp Suite. I would need to know what kind of security tests are expected. But the obvious checks could be done right away: unauthorized API calls, invalid/expired tokens, SQL injections and so on.
	d) This is of course not the end of the list. We would need to check manually the quality of logging, telemetry, monitoring, alerting, etc.

PS There is invalid sandbox environment url in documentation here: https://docs.mangopay.com/api-reference/overview/introduction#environments
PS2 I am happy to extend this framework and test suite in the technical interview if needed
