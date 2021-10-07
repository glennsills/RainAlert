# Rain Alert
This solution builds an application that notifies users when it is likely to rain in their area.
I am writing this just to experiment with NET 6.0, so the application itself is intentionally
trivial. On the other hand, I have decomposed it more than the problem domain requires, just
so I could try more .NET 6.0 features.

## Rain Alert Web
This will be a trivial Razor Page application that lets users:

- Sign up for the app. This will gather zip code, email and phone number, first and last name.
- Authentication will use Microsoft Identity. The user's email address will be the user name
- The application will talk to a api back end. In an application so simple that is really overkill but I might try a couple of different UI frameworks before I am done.
- There will be an admin user at some point that can look at and modify all users.

## Rain Alert API
This service perform the data access functions implied by the Rain Alert Web applications functionality. 
It is responsible for setting up IHttpClientFactory concerns for the underlying library RainAlert.WeatherForcast.


## Rain Alert Worker
This appliction will be a service that runs in the background, finding locations where it is going to rain
and sending alerts to the appropriate users who requested the alerts.

## Weather Service Class Library
This class library will encapsulate talking to a service that gets weather reports. Weather reports all 
seem to be based on longitude and latitude, so it will also encapsulate access to a geocoding service.
