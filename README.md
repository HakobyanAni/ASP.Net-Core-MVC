# ASP.Net-Core - MVC

<h2>What is ASP.NET Core ?</h2>

<h4>ASP.NET Core is the new web framework from Microsoft. It has been redesigned from the ground up to be fast, flexible, modern,
and work across different platforms.</br>
</br>
ASP.NET Core is an open source and cloud-optimized web framework for developing modern web applications that can be developed 
and run on Windows, Linux and the Mac. It includes the MVC framework, which now combines the features of MVC and Web API into a single 
web programming framework.</h4>

<h2>What is the MVC pattern ?</h2>
<h4><p>ASP.NET Core MVC is a rich framework for building web apps and APIs using the Model-View-Controller design pattern.</p>
<p>The Model-View-Controller (MVC) architectural pattern separates an application into three main groups of components: Models, Views, and Controllers. This pattern helps to achieve separation of concerns. Using this pattern, user requests are routed to a Controller which is responsible for working with the Model to perform user actions and/or retrieve results of queries. The Controller chooses the View to display to the user, and provides it with any Model data it requires.</p></h4>
<p>The following diagram shows the three main components and which ones reference the others:</p>
<img src="https://user-images.githubusercontent.com/45730967/54558360-f5f7d680-49d6-11e9-8780-b34801aa3061.png" width="327px" height="314px" />
<h4>This delineation of responsibilities helps you scale the application in terms of complexity because it's easier to code, debug, and test something (model, view, or controller) that has a single job. It's more difficult to update, test, and debug code that has dependencies spread across two or more of these three areas. For example, user interface logic tends to change more frequently than business logic. If presentation code and business logic are combined in a single object, an object containing business logic must be modified every time the user interface is changed. This often introduces errors and requires the retesting of business logic after every minimal user interface change.</h4>
<h3>Model Responsibilities</h3>
<h4>The Model in an MVC application represents the state of the application and any business logic or operations that should be performed by it. Business logic should be encapsulated in the model, along with any implementation logic for persisting the state of the application. Strongly-typed views typically use ViewModel types designed to contain the data to display on that view. The controller creates and populates these ViewModel instances from the model.</h4>
<h3>View Responsibilities</h3>
<h4>Views are responsible for presenting content through the user interface. They use the Razor view engine to embed .NET code in HTML markup. There should be minimal logic within views, and any logic in them should relate to presenting content. If you find the need to perform a great deal of logic in view files in order to display data from a complex model, consider using a View Component, ViewModel, or view template to simplify the view.</h4>
<h3>Controller Responsibilities</h3>
<h4>Controllers are the components that handle user interaction, work with the model, and ultimately select a view to render. In an MVC application, the view only displays information; the controller handles and responds to user input and interaction. In the MVC pattern, the controller is the initial entry point, and is responsible for selecting which model types to work with and which view to render (hence its name - it controls how the app responds to a given request).</h4>
<h2>What is ASP.NET Core MVC ?</h2>
<h4><p>    The ASP.NET Core MVC framework is a lightweight, open source, highly testable presentation framework optimized for use with ASP.NET Core.</p>
<p>    ASP.NET Core MVC provides a patterns-based way to build dynamic websites that enables a clean separation of concerns. It gives you full control over markup, supports TDD-friendly development and uses the latest web standards. n the Model-View-Controller (MVC) pattern, the view handles the app's data presentation and user interaction.</p>
<p>    A view is an HTML template with embedded Razor markup. Razor markup is code that interacts with HTML markup to produce a webpage that's sent to the client. In ASP.NET Core MVC, views are .cshtml files that use the C# programming language in Razor markup. Usually, view files are grouped into folders named for each of the app's controllers. The folders are stored in a <b>Views</b> folder.</p>
Controllers, actions, and action results are a fundamental part of how developers build apps using ASP.NET Core MVC. A controller is used to define and group a set of actions. An action (or action method) is a method on a controller which handles requests. Controllers logically group similar actions together. This aggregation of actions allows common sets of rules, such as routing, caching, and authorization, to be applied collectively. </h4>
