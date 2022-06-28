# ScorpiusClient
A Xamarin.Forms Client application to receive notifications from the [Scorpius GE](https://github.com/jmSfernandes/ScorpiusGE)

This a example of an App that implements the Firebase Cloud Messaging (FCM).
Which can be used with the ScorpiusGE to receive notification inbound from the FIWARE ecosystem (i.e., ORION subscriptions)

However this can also be used with any other Firebase Server, or with the Firebase Console.

## Run application
To run the application use JetBrains Rider or VS 2022.

Xamarin.Forms is a cross-platform framework that allows the creation of mobile applications for both Android and iOS.
However, in this example only the Android Application is implemented. 
It's fairly easy to implement the rest of the application for iOS, however to test on iOS you need a real device (FCM doesn't work with the simulator).

As such you should run only the Android configuration.


**Note**: that you should replace the `google-services.json` file in order for the app to work. 
The google-services.json should be generated for the same Firebase project that you use in the Scorpius GE.

**Note**: you may also need to change the package name in the AndroidManifest to match the package name in your google-services.json.

## Functionalities:

* The app allows the user to register to any topic and receive notification, that will pop up as a system app notification. 

* A list of registered topics are showed in the application screen.

* The user can also unregister all of the topics. 

**Note**: The list of topics is only keeped in runtime, you should unregister everything before leaving the application,
if you don't want to receive more notifications.




## LICENSE 
MIT License

Copyright (c) 2022 J. Fernandes

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
