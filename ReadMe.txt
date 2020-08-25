Sprint Planning : - 
https://dev.azure.com/gauravminhas/BookMe%20(.Net%20Framework)/_boards/board/t/BookMe%20(.Net%20Framework)%20Team/Issues




Doubts:- 
    1. how and when To dispose of the dbContext correctly? 
    





Challenges Faced
    1. Poco serialization with navigation properties 
        -Implemented DTOs and AutoMapper
        
    2. LifeTime and management of DBContext 
		- Thread Safe Exception when using singleton method for DB context
			The context cannot be used while the model is being created. This exception may be thrown if the context is used inside the OnModelCreating method or if the same context instance is accessed by multiple threads concurrently. Note that instance members of DbContext and related classes are not guaranteed to be thread safe.

    3. The application goes in maintenance mode and thus only Reads and no writes 
        - Segregated Read from writes  using CQSP


	4. Implement Transaction for complex business Activities 
		- Implement Resource Manager 
		- Impliment Transaction Manager 
		- Implement a 2-stage Commit
		

	5. Multi-Db Context Implementation 




Learnings 
	1. Why should the DBcontext not be instanciated in repo Project or EF projects and rather in Business logic layers 
		- To manage the db contect lifecycle effectly and dispose the dbContext as soon as it has been used up 
		- If the Db contect persists for long there will be concurrency problems;
		- dont new up a instance, instead inject a dependency using factory methode ! 








Research 
	1. Database Isolation levels & transactions support 
	2. transaction isolation level






Useful links 
	Table Structure : 
		C:\Users\rainbow train\Dropbox1\Dropbox\100. BookMeApp

	MindBody 
		https://developers.mindbodyonline.com/PublicDocumentation/V6?csharp#endpoints

