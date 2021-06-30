# DIO.Series
#### Project created for the GFT START #2.NET Bootcamp by Digital Innovation One on June 2021.  *(In Development)*
###### Author: Marcus Santos  


**Project Objectve:**  
>Practice *Object Oriented Programing* in a simple project where the user can create, read, update and delete *(CRUD)* his favorite (or totally invented) TV series, storing the data in memory using a list of series inside an repository.  
The proposal for the project was that the application should be a console UI one, but for thinking about that we should always try to performe beyond expectations, I decided to implement a different aproach, using instead a Web App MVC UI and moving the data access layer of the application to a different project, a class library, that would be responsible only for it, releasing that layer to be used in different UI types.  
All that considered, the purpose of the project was to utilize OOP to develop a simple project that could store and access data in memory about TV series and that objective is fulfiled here by apllying inheritance, abstraction, polymorphism and encapsulation.  
By using abstractions in the data access layer the purpose was making the data access/storage able to be done in different types of databases by switching implementations.  

**Considerations Over Project Design Choices:**  
Envisionig to apply some of the best pratices like the SOLID principles some choices has been made to better the codebase:
>- **Separation of Responsabilities**  
Inside the solution the application is divided in two layers by responsabilities, based on the idea that the UI should't know about the data access code, and the data access code should be capable of be used in different types of UI:
>   - **DIO.Series.DataLibrary:** *This project is responsible for the 'data access' layer of the application, dealing with data models and access to the series repository.*
>   - **DIO.Series.MVC:** *This project is where the UI layer of the application resides, the Views and related models.*
>- **Liskov Substitution Principle**  
The program make use of base abstractions that can replace their derived abstractions in the code, for example:  
>   - *The IRepository interface serves as a base abstraction for the 'data access' part of the application where the CRUD operations are performed. It can be used to represent different implementations of data access, in this case a ISeriesRepository is derived from it that is implemented by the SeriesListRepository, a repository that store the series objects in a list but could just as easily be a 'SeriesSqlServerRepository' who would do the same operations but accessing a SQL Server database or a totally different object's repository. In all the different cases possible, the IRepository interface would be used not his derived abstractions or implementations.*
>- **Interface Segregation Principle**  
The program make use of Interface Segregation to facilitate the maintenance and readability of the code in addition to greater cohesion by making use of more specific interfaces, for example:
>   - *In the UI layer of the application I have made use of the IViewSeries and the IUpdateSeries that respectively are specific for showing data to the user and updating a existing series properties.*
>- **Depedency Inversion:**  
The program utilizes the Depedency Injection pattern (DI) to apply the Depedency Inversion principle (DIP) where the class pass to depend from abstractions and not from another classes of lesser levels, turning the class not coupled with other classes what make the design less rigid, for example:
>   - *Istead of repeating the instatiation of the Series class within the program, I opted to utilize the ISeries interface, making easy to change the implementation if needed and executing maitenance on the code, and where without this pattern a ' = new Series' would be needed now a constructor injection is apllied where the ISeries interface is passed in as a paramater and the implementation is resolved by the web application service container.*
